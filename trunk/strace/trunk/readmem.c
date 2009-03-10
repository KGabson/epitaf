#include "includes.h"
#include "errors.h"

char			*read_string(int p_child, void *ptr)
{
  struct ptrace_io_desc io_desc;
  char			*strbuf;

  strbuf = mallocX(MAX_STRING_SIZE * sizeof(strbuf));
  io_desc.piod_op = PIOD_READ_D;
  io_desc.piod_offs = ptr;
  io_desc.piod_addr = strbuf;
  io_desc.piod_len = MAX_STRING_SIZE;
  ptraceX(PT_IO, p_child, (caddr_t)&io_desc, 0);
  return (strbuf);
}
