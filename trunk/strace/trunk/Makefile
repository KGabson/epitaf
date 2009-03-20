##
## Makefile for minishell in /u/ept2/desert_t/rendu/c/minishell
## 
## Made by thomas desert
## Login   <desert_t@epita.fr>
## 
## Started on  Fri Nov 10 15:42:05 2006 thomas desert
## Last update Thu Feb  5 23:01:59 2009 thomas desert
##

SRC =		strace.c 	\
		errors.c 	\
		readmem.c	\
		st_print.c	\
		tools.c

OBJ =		$(SRC:.c=.o)
CC =		gcc -g
CFLAGS =	-W -Wall $(INCLUDE)
NAME =		strace

all: syscall_info $(OBJ)
	$(CC) $(OBJ) -o $(NAME)

syscall_info:
		chmod +x php/make_syscall_info_h.php
		php/make_syscall_info_h.php
clean:
	rm -f *.o
	rm -f *~

fclean: clean
	rm -f $(NAME)
	rm -r ./syscall_info.h

re: fclean all
