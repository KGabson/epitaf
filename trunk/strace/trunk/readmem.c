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

void			read_string(int p_child, void *child_addr)
{
  char			*str;

  str = ptrace_read(p_child, child_addr, MAX_STRING_SIZE);
  str_limit(str, "...");
  printf("%s", str);
}

void			read_ptr(int p_child, void *child_addr)
{
  void			*ptr;

  ptr = ptrace_read(p_child, child_addr, sizeof(void *));
  printf("%x", (unsigned int)ptr);
}

void			read_char(int p_child, void *child_addr)
{
  char			*res;

  res = ptrace_read(p_child, child_addr, sizeof(char));
  printf("%c", *res);
}

void			read_short(int p_child, void *child_addr)
{
  char			*res;

  res = ptrace_read(p_child, child_addr, sizeof(short));
  printf("%hd", *res);
}

void			read_int(int p_child, void *child_addr)
{
  int			*res;

  res = ptrace_read(p_child, child_addr, sizeof(int));
  printf("%d", *res);
}

void			read_long(int p_child, void *child_addr)
{
  long			*res;

  res = ptrace_read(p_child, child_addr, sizeof(long));
  printf("%ld", *res);
}

void			read_double(int p_child, void *child_addr)
{
  double		*res;

  res = ptrace_read(p_child, child_addr, sizeof(double));
  printf("%fd", *res);
}

void			read_float(int p_child, void *child_addr)
{
  float		*res;

  res = ptrace_read(p_child, child_addr, sizeof(float));
  printf("%fd", *res);
}

void			str_limit(char *str, char *end)
{
  int			end_len;
  int			i;

  end_len = strlen(end);
  for (i = 0; (i < MAX_STRING_SIZE - 1) && (str[i] != 0); i++);
  if (i == MAX_STRING_SIZE - 1)
    {
      strcpy(&str[MAX_STRING_SIZE - end_len - 1], end);
    }
}
