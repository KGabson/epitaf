#include "includes.h"
#include "errors.h"
#include "syscall_names.h"
#include "readmem.h"

void			analize(char *ptr)
{
  int i = 0;

  printf("Analizing: %c...\n", ptr[0]);
  printf("Analizing: %c...\n", ptr[0]);
  printf("Analizing: %c...\n", ptr[0]);
  while (ptr[i] != 0)
    {
      //printf("-> %c\n", ptr[i]);
      write(1, &ptr[i], 1);
      i++;
    }
}


int			main(int ac, char **av)
{
  pid_t			p_child;
  int			status;
  int			start = 0;
  int			keep_going = 1;
  char			*args[] = { "command" , 0 };
  char			*env[] = { NULL };
  char			*cmd;
  struct reg		regs;
  int			reg_val;

  cmd = (ac > 1) ? av[1] : "./command";
  args[0] = cmd;
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
      while(keep_going)
	{
	  waitX(&status);
	  if (WIFEXITED(status))
	    {
	      puts("Child process finished. End.");
	      exit (0);
	      return (0);
	    }
	  if (start)
	    {
	      ptraceX(PT_GETREGS, p_child, (caddr_t)&regs, 0);
	      reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)regs.r_eip, 0);
	      if ((reg_val & ~0xffff80cd) == 0) //We have an int 80 here
		{
		  if (regs.r_eax > SYS_MAXSYSCALL)
		   {
		      printf("EAX bad value... Ignoring.\n");
		   }
		  else if (SYSCALL_NAMES[regs.r_eax] == 0)
		    {
		      printf("Unimplemented syscall: %d\n", regs.r_eax);
		    }
		  else
		    {
		      reg_val = ptraceX(PT_READ_D, p_child, (caddr_t)(regs.r_esp + 8), 0);
		      if (regs.r_eax == 4)
			{
			  //char *machin = (char *)reg_val;
			  //printf("Write: ESP = [%s]\n", machin);

			  //printf("Write: ESP = [%p]\n", (char *)reg_val);
			  //analize((char*)reg_val);
			  char *str = read_string(p_child, (void *)reg_val);
			  printf("===> %s\n", str);
			}
		      printf("Calling %s...\n", SYSCALL_NAMES[regs.r_eax]);
		    }
		}
	    }
	  ptraceX(PT_STEP, p_child, (caddr_t)1, 0);
	  if (!start)
	    start = 1;
	}
    }
  return (0);
}
