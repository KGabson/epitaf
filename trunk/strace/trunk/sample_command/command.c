#include <sys/types.h>
#include <sys/uio.h>
#include <unistd.h>

int main()
{
  //printf("Youpi la commande hop hop hop me faut plus de 30 characteres de merde la !! Alors ta gueule STRACE !\n");
  write(1, "Hello\n", 7);
  return (0);
}
