void	*ptrace_read(int p_child, void *child_addr, int size);
void	read_string(int p_child, unsigned int esp_value);
void	read_ptr(int p_child, unsigned int esp_value);
void	read_esp(int p_child, unsigned int esp_value);
void	read_char(int p_child, unsigned int esp_value);
void	read_short(int p_child, unsigned int esp_value);
void	read_int(int p_child, unsigned int esp_value);
void	read_long(int p_child, unsigned int esp_value);
void	read_double(int p_child, unsigned int esp_value);
void	read_float(int p_child, unsigned int esp_value);
void	str_limit(char *str, char *end);

