#include "includes.h"
#include "st_print.h"

t_st_print_fct ST_PRINT[] =
  {
    {"char *", read_string},

    {"void *", read_ptr},

    {"int", read_int},

    {"double", read_double},

    {"long", read_long},

    {"double", read_double},

    {0, 0}
  };

void		st_print(char *type, int p_child, void *child_addr)
{
  int		i, ok;

  i = 0;
  ok = 0;
  while (ST_PRINT[i].type != 0)
    {
      if (!strcmp(ST_PRINT[i].type, type))
	{
	  ST_PRINT[i].fct_read(p_child, child_addr);
	  ok = 1;
	}
      i++;
    }
  if (!ok)
    printf("[Could not read value for type %s]", type);

}
