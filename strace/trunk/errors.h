#include "includes.h"

void	ERROR(char *fct_name);
void	DEBUG(char *fct_name, char *str);
int	ptraceX(int request, pid_t pid, caddr_t addr, int data);
pid_t	forkX();
pid_t	waitpidX(pid_t pid, int *status, int options);
pid_t	waitX(int *status);
void	*mallocX(size_t size);
