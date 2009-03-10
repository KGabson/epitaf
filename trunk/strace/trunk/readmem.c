#include "readmem.h"
#include "includes.h"
#include "errors.h"

void			*ptrace_read(int p_child, void *child_addr, int size)
{
  struct ptrace_io_desc io_desc;
  void			*res;

  res = mallocX(size * sizeof(res));
  io_desc.piod_op = PIOD_READ_D;
  io_desc.piod_offs = child_addr;
  io_desc.piod_addr = res;
  io_desc.piod_len = size;
  ptraceX(PT_IO, p_child, (caddr_t)&io_desc, 0);
  return (res); //Please, free me !
}

char			*read_string(int p_child, void *child_addr)
{
  char			*res;

  res = ptrace_read(p_child, child_addr, MAX_STRING_SIZE);
  str_limit(res, "...");
  return (res);
}

char			read_char(int p_child, void *child_addr)
{
  char			*res;

  res = ptrace_read(p_child, child_addr, sizeof(char));
  return (*res);
}

int			read_int(int p_child, void *child_addr)
{
  int			*res;

  res = ptrace_read(p_child, child_addr, sizeof(int));
  return (*res);
}

long			read_long(int p_child, void *child_addr)
{
  long			*res;

  res = ptrace_read(p_child, child_addr, sizeof(long));
  return (*res);
}

double			read_double(double p_child, void *child_addr)
{
  double		*res;

  res = ptrace_read(p_child, child_addr, sizeof(double));
  return (*res);
}

float			read_float(float p_child, void *child_addr)
{
  float		*res;

  res = ptrace_read(p_child, child_addr, sizeof(float));
  return (*res);
}

void			str_limit(char *str, char *end)
{
  int			end_len;
  int			i;

  end_len = strlen(end);
  for (i = 0; (i < MAX_STRING_SIZE - 1) || (str[i] == 0); i++);
  if (i == MAX_STRING_SIZE - 1)
    {
      puts("plus grand !!");
      strcpy(&str[MAX_STRING_SIZE - end_len - 1], end);
    }
}
