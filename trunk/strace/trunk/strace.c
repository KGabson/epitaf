#include "includes.h"
#include "errors.h"
//#include "syscall_names.h"
#include "sys/syscall.h"

int			main(int ac, char **av)
{
  pid_t			p_child;
  int			status;
  int			start = 0;
  int			keep_going = 1;
  char			*args[] = { "command" , 0 };
  char			*env[] = { NULL };
  char			*cmd;
  //caddr_t		addr;
  struct reg		regs;
  int			reg_val;
  
  cmd = (ac > 1) ? av[1] : "./command";
  args[0] = cmd;
  printf("Command: %s\n", cmd);
  p_child = forkX();

  if (!p_child)
    {
      //puts("child...");
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
	      if ((unsigned short)reg_val == 0x80cd)
		{
		  if (regs.r_eax > SYS_MAXSYSCALL)
		   {
		      printf("EAX bad value... Ignoring.\n");
		    }
		  else
		    {
		      printf("You called %d syscall\n", regs.r_eax);
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
