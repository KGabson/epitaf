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
		st_print.c
OBJ =		$(SRC:.c=.o)
CC =		gcc -g
#LIB =		-L${HOME}/rendu/lib -lmy_netbsd
#INCLUDE =	-I${HOME}/rendu/include
CFLAGS =	-W -Wall $(INCLUDE)
NAME =		strace

all: $(OBJ)
	$(CC) $(OBJ) -o $(NAME)

syscall_info:
		php/make_syscall_info_h.php
clean:
	rm -f *.o
	rm -f *~

fclean: clean
	rm -f $(NAME)

re: fclean all
