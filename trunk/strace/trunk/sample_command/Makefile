##
## Makefile for minishell in /u/ept2/desert_t/rendu/c/minishell
## 
## Made by thomas desert
## Login   <desert_t@epita.fr>
## 
## Started on  Fri Nov 10 15:42:05 2006 thomas desert
## Last update Thu Feb  5 23:01:59 2009 thomas desert
##

SRC =		command.c
OBJ =		$(SRC:.c=.o)
CC =		gcc
#CFLAGS =
NAME =		command

all: $(OBJ)
	$(CC) $(OBJ) -o $(NAME)

clean:
	rm -f *.o
	rm -f *~

fclean: clean
	rm -f $(NAME)

re: fclean all
