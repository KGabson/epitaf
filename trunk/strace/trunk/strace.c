/*
****************************************************************
 **
 ** STRACE: Tracing system calls for a given process (2008-03)
 ** ************************************************************
 **
 ** Authors: Gregory MOULIN, Thomas DESERT
 ** System: FreeBSD
 **
 ***************************************************************
*/
#include "includes.h"
#include "errors.h"
#include "readmem.h"
#include "syscall_info.h"
#include "st_print.h"
#include "tools.h"

extern char **environ;
int attached_pid = 0;

typedef struct		s_opt_struct
{
  int	attach_pid;
  char	*command;
}			t_opt_struct;

void			usage(char *filename)
{
  printf("Usage: %s <option>\n", filename);
  puts("\t-h: Display this help message");
  puts("\t-v: Display program information");
  puts("\t-p: pid to attach");
  puts("\t-e: Command to execute");
  exit(0);
}

void			info()
{
  printf("%s - %s: %s\n", MY_NAME, VERSION, MY_DESCRIPTION);
  exit(0);
}

/**
 * reading program arguments
 **/
t_opt_struct		read_opt(int ac, char **av)
{
  int			opt;
  t_opt_struct		ret = { 0, NULL };

  while ((opt = getopt(ac, av, "hvp:e:")) != -1)
    {
      switch (opt)
	{
	case 'v':
	  info();
	  break;
	case 'p':
	  ret.attach_pid = atoi(optarg);
	  break;
	case 'e':
	  ret.command = optarg;
	  break;
	case 'h':
	default:
	  usage(av[0]);
	}
    }
  return ret;
}

/**
 * Will read each argument passed to a syscall
 * at $esp + 4, + 8, ...
 **/
void			display_syscall_info(int num_syscall, int p_child, unsigned int child_esp)
{
  t_sysinfo		sysinfo;
  int			i, reg_val;

  sysinfo = SYSINFO[num_syscall];
  printf("%s(", sysinfo.sysname);
  for (i = 0; i < sysinfo.nbargs; i++)
    {
      child_esp += 4;
      reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)(child_esp), 0);
      printf("(%s) ", sysinfo.argtype[i]);
      st_print(sysinfo.argtype[i], p_child, reg_val);
      if (i < sysinfo.nbargs - 1)
	printf(", ");
    }
  printf(")");
}

/**
 * Reading registries for a step,
 * and testing if it's an interuption 80 (a system call)
 **/
int			read_regs(int p_child)
{
  struct reg		regs;
  int			reg_val;

  ptraceX(PT_GETREGS, p_child, (caddr_t)&regs, 0);
  reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)regs.r_eip, 0);

  if ((reg_val & ~0xffff80cd) != 0)
    return (-1);
  if (regs.r_eax > SYS_MAXSYSCALL)
    {
      printf("Invalid syscall value: %d\n", regs.r_eax);
      return (-1);
    }
  if (SYSINFO[regs.r_eax].sysname == NULL)
    {
      printf("Syscall information not available: %d\n", regs.r_eax);
      return (SYS_MAXSYSCALL);
    }
  else
    {
      display_syscall_info(regs.r_eax, p_child, regs.r_esp);
    }
  return (regs.r_eax);
}

/**
 * Looping and watching the traced process
 **/
int			ptrace_loop(int p_child, int attached)
{
  int			status;
  int			start, is_syscall;
  int			step = 1;
  int			num_syscall;
  struct reg		regs;

  start = (attached) ? 1 : 0;
  is_syscall = 0;
  num_syscall = 0;
  waitX(&status);
  while (!WIFEXITED(status))
    {
      if (is_syscall)
	{
	  ptraceX(PT_GETREGS, p_child, (caddr_t)&regs, 0);
	  printf(" = ");
	  st_print(SYSINFO[num_syscall].return_type, p_child, regs.r_eax);
	  printf("\n");
	  is_syscall = 0;
	}
      if (start)
	{
	  num_syscall = read_regs(p_child);
	  if (num_syscall >= 0 && num_syscall < SYS_MAXSYSCALL)
	    is_syscall = 1;
	}
      ptraceX(PT_STEP, p_child, (caddr_t)step, 0);
      start++;
      waitX(&status);
    }
  puts("Child process finished. End.");
  return (0);
}

/**
 * Will fork current process and launch ptrace_loop for the child process
 **/
int			ptrace_fork(char *cmd)
{
  char			*args[] = { "command" , 0 };
  int			ret = -1;
  int			p_child;
  char			**wordtab = NULL;

  wordtab = str_to_wordtab(cmd);
  printf("Command: %s\n", cmd);
  p_child = forkX();

  if (!p_child)
    {
      ptraceX(PT_TRACE_ME, 0, NULL, 0);
      if (wordtab)
	execve(wordtab[0], wordtab, environ);
      else
	execve(cmd, args, environ);
      ERROR("execve");
    }
  else
    {
      ret = ptrace_loop(p_child, 0);
    }
  return (ret);
}

/**
 * Detaching child process
 * TODO: Make it work, ptrace fails here !!!
 */
void			ptrace_detach(int pid)
{
  ptraceX(PT_DETACH, pid, 0, 0);
}

/**
 * Watching SIGINT if we attached a process
 **/
void			catch_signal(int s)
{
  printf("Recieved SIGINT(%d). Detaching process %d...\n", s, attached_pid);
  ptrace_detach(attached_pid);
}

/**
 * Attaching process for given PID
 **/
int			ptrace_attach(int pid)
{
  printf("Attaching process %d...\n", pid);
  ptraceX(PT_ATTACH, pid, NULL, 0);
  printf("PID %d attached, starting loop.\n", pid);
  attached_pid = pid;
  signal(SIGINT, catch_signal);
  return ptrace_loop(pid, 1);
}

int			main(int ac, char **av)
{
  t_opt_struct		options;
  int			ret = 0;

  options = read_opt(ac, av);

  if (options.attach_pid != 0)
    ret = ptrace_attach(options.attach_pid);
  else
    {
      if (options.command == NULL && ac < 2)
	options.command = "./command";
      else if (options.command == NULL)
	options.command = av[1];
      ret = ptrace_fork(options.command);
    }
  return (0);
}
