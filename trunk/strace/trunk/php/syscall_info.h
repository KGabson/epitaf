typedef struct s_sysinfo
{
  int	nbargs;
  char	*sysname;
  char	*sysproto[128];
  char  *return_type;
}t_sysinfo;

t_sysinfo	SYSINFO[4] =
{
  { 3, "write", { "int fd", "char * str", "int nb" },"int" }
};
