#include "includes.h"

void	ERROR(char *);
int	ptraceX(int request, pid_t pid, caddr_t addr, int data);
pid_t	forkX();
pid_t	waitpidX(pid_t pid, int *status, int options);
pid_t	waitX(int *status);

