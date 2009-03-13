#include "includes.h"
#include "errors.h"
#include "syscall_names.h"
#include "readmem.h"

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

int			ptrace_loop(int p_child)
{
  int			keep_going = 1;
  int			status;
  struct reg		regs;
  int			reg_val;
  int			start = 0;
  char			*strbuf;

  while(keep_going)
    {
      waitX(&status);
      if (WIFEXITED(status))
	{
	  puts("Child process finished. End.");
	  return (0);
	}
      if (!start) //execve first instruction. Skipping...
	{
	  start++;
	  ptraceX(PT_STEP, p_child, (caddr_t)1, 0);
	  continue;
	}
      //Reading $eip value into registries
      ptraceX(PT_GETREGS, p_child, (caddr_t)&regs, 0);
      reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)regs.r_eip, 0);
      if ((reg_val & ~0xffff80cd) == 0) //We have an int 80 here
	{
	  if (regs.r_eax > SYS_MAXSYSCALL)
	    printf("Unknown syscall number: %d... Ignoring.\n", regs.r_eax);
	  else if (SYSCALL_NAMES[regs.r_eax] == 0)
	    printf("Unimplemented syscall: %d\n", regs.r_eax);
	  else
	    {
	      //Reading syscall arguments
	      reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)(regs.r_esp + 8), 0);
	      if (regs.r_eax == 4)
		{
		  strbuf = read_string(p_child, (void *)reg_val);
		  printf("===> [%s]\n", strbuf);
		  free(strbuf);
		}
	      printf("Calling %s...\n", SYSCALL_NAMES[regs.r_eax]);
	    }
	}
      ptraceX(PT_STEP, p_child, (caddr_t)1, 0);
      if (!start)
	start = 1;
    }
  return (0);
}

void			child()
{

}

int			ptrace_fork(char *cmd)
{
   char			*args[] = { "command" , 0 };
   char			*env[] = { NULL };
   int			ret = -1;
   int			p_child;

  printf("Command: %s\n", cmd);
  p_child = forkX();

  if (!p_child)
    {
      ptraceX(PT_TRACE_ME, 0, NULL, 0);
      execve(cmd, args, env);
      ERROR("execve");
    }
  else
    {
      ret = ptrace_loop(p_child);
    }
  return (ret);
}

int			ptrace_attach(int pid)
{
  int			p_child;

  printf("Attaching process %d...\n", pid);
  ptraceX(PT_ATTACH, pid, NULL, 0);
  printf("PID %d attached, starting loop.", pid);
  return ptrace_loop(pid);
}

int			main(int ac, char **av)
{
  pid_t			p_child;
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
