#include "includes.h"
#include "errors.h"

void			print_wordtab(char **tab)
{
  int			i = 0;

  while (tab[i])
    {
      printf("=> %s\n", tab[i++]);
    }
}

char			**str_to_wordtab(char *str)
{
  char			**res;
  int			nb_args = 1;
  int			i = 0;
  int			j = 0;
  int			k = 0;

  while (str[i] == ' ' && str[i])
    i++;
  if (!str[i])
    return (NULL);
  while (str[i])
    {
      if (str[i] == ' ')
	{
	  nb_args++;
	  while (str[i] == ' ' && str[i])
	    i++;
	}
      else
	i++;
    }
  res = mallocX((nb_args + 1) * sizeof(res));
  i = 0;
  while (str[i] == ' ' && str[i])
    i++;
  res[j] = &str[i];
  while (str[i])
    {
      if (str[i] == ' ')
	{
	  res[j++][k] = 0;
	  i++;
	  while(str[i] == ' ' && str[i])
	    i++;
	  res[j] = &str[i];
	  k = 0;
	}
      else
	{
	  i++;
	  k++;
	}
    }
  res[j + 1] = 0;
  return res;
}

void			free_wordtab(char **tab)
{
  int			i = 0;

  while (tab[i])
    free(tab[i++]);
  free(tab);
}
