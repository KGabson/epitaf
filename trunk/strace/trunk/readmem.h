void	*ptrace_read(int p_child, void *child_addr, int size);
void	read_string(int p_child, void *child_addr);
void	read_ptr(int p_child, void *child_addr);
void	read_char(int p_child, void *child_addr);
void	read_short(int p_child, void *child_addr);
void	read_int(int p_child, void *child_addr);
void	read_long(int p_child, void *child_addr);
void	read_double(int p_child, void *child_addr);
void	read_float(int p_child, void *child_addr);
void	str_limit(char *str, char *end);

