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

void			print_all(char *str)
{
  int			i;

  i = 0;
  while (str[i] != '\0')
    {
      switch (str[i])
	{
	case '\n':
	  printf("\\n");
	  break;
	case '\t':
	  printf("\\t");
	  break;
	default:
	  printf("%c", str[i]);
	}
      i++;
    }
  printf("\\0");
}

void			read_string(int p_child, unsigned int esp_value)
{
  char			*str;

  str = ptrace_read(p_child, (void *)esp_value, MAX_STRING_SIZE);
  str_limit(str, "...");
  print_all(str);
  free(str);
}

void			read_esp(int p_child, unsigned int esp_value)
{
  printf("0x%x", esp_value);
}

void			read_char(int p_child, unsigned int esp_value)
{
  printf("%d", (char)esp_value);
}

void			read_short(int p_child, unsigned int esp_value)
{
  printf("%hd", (short)esp_value);
}

void			read_int(int p_child, unsigned int esp_value)
{
  printf("%d", (int)esp_value);
}

void			read_long(int p_child, unsigned int esp_value)
{
  printf("%ld", (long)esp_value);
}

void			read_double(int p_child, unsigned int esp_value)
{
  printf("%fd", (double)esp_value);
}

void			read_float(int p_child, unsigned int esp_value)
{
  printf("%fd", (float)esp_value);
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
