#include "includes.h"
#include "st_print.h"

t_st_print_fct ST_PRINT[] =
  {
    {"char *", read_string},

    {"void *", read_esp},
    {"const void *", read_string},

    {"char", read_char},

    {"short", read_short},

    {"int", read_int},
    {"size_t", read_int},

    {"long", read_long},

    {"double", read_double},

    {"float", read_float},

    {"unknown", read_esp},

    {0, 0}
  };

void		st_print(char *type, int p_child, unsigned int esp_value)
{
  int		i, ok;

  i = 0;
  ok = 0;
  while (ST_PRINT[i].type != 0)
    {
      if (!strcmp(ST_PRINT[i].type, type))
	{
	  ST_PRINT[i].fct_read(p_child, esp_value);
	  ok = 1;
	}
      i++;
    }
  if (!ok)
    printf("[unknown type %s] = 0x%x", type, esp_value);
}
