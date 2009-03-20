#ifndef			__ST_PRINT__
# define		__ST_PRINT__

# include "readmem.h"

typedef	struct		s_st_print_fct
{
  char			*type;
  void			(*fct_read)(int p_child, unsigned int esp_value);
}			t_st_print_fct;

void			st_print(char *type, int p_child, unsigned int esp_value);

#endif
