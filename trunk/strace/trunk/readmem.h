void	*ptrace_read(int p_child, void *child_addr, int size);
char	*read_string(int p_child, void *child_addr);
char	read_char(int p_child, void *child_addr);
int	read_int(int p_child, void *child_addr);
double	read_double(int p_child, void *child_addr);
float	read_float(int p_child, void *child_addr);
void	str_limit(char *str, char *end);

