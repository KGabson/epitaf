void	*ptrace_read(int p_child, void *child_addr, int size);
char	*read_string(int p_child, void *child_addr);
void	str_limit(char *str, char *end);

