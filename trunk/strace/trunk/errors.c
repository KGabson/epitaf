#include "errors.h"

void			ERROR(char *fct_name)
{
  printf("%s error: %s\n", fct_name, strerror(errno));
  exit(-1);
}

int			ptraceX(int request, pid_t pid, caddr_t addr, int data)
{
  int			ret;

  errno = 0;
  ret = ptrace(request, pid, addr, data);
  if (errno)
    ERROR("ptrace");
  return (ret);
}

pid_t			forkX()
{
  pid_t			p_child;

  p_child = fork();
  if (p_child < 0)
    ERROR("fork");
  return (p_child);
}

pid_t			waitpidX(pid_t pid, int *status, int options)
{
  pid_t			ret;

  ret = waitpid(pid, status, options);
  if (ret != pid)
    ERROR("waitpid");
  return (ret);
}

pid_t			waitX(int *status)
{
  pid_t			ret;

  ret = wait(status);
  if (ret < 0)
    ERROR("wait");
  return (ret);
}
