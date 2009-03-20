
typedef struct s_sysinfo
{
  int   nbargs;
  char  *sysname;
  char  argtype[8][128];
  char	argname[8][128];
  char  *return_type;
}t_sysinfo;

t_sysinfo       SYSINFO[483] =
  {
    {1, "syscall", {"int"}, {"int"}, "int"},
    {1, "exit", {"int"}, {"int"}, "void"},
    {0, "fork", {""}, {""}, "int"},
    {3, "read", {"int", "void *", "size_t"}, {"fd", "buf", "size_t"}, "int"},
    {3, "write", {"int", "const void *", "size_t"}, {"fd", "buf", "size_t"}, "int"},
    {3, "open", {"char *", "int", "int"}, {"path", "flags", "int"}, "int"},
    {1, "close", {"int"}, {"int"}, "int"},
    {0, "wait4", {""}, {""}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "link", {"char *", "char *"}, {"path", "char *"}, "int"},
    {1, "unlink", {"char *"}, {"char *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "chdir", {"char *"}, {"char *"}, "int"},
    {1, "fchdir", {"int"}, {"int"}, "int"},
    {3, "mknod", {"char *", "int", "int"}, {"path", "mode", "int"}, "int"},
    {2, "chmod", {"char *", "int"}, {"path", "int"}, "int"},
    {3, "chown", {"char *", "int", "int"}, {"path", "uid", "int"}, "int"},
    {1, "break", {"char *"}, {"char *"}, "int"},
    {3, "freebsd4_getfsstat", {"struct ostatfs *", "long", "int"}, {"buf", "bufsize", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, "getpid", {""}, {""}, "int"},
    {4, "mount", {"char *", "char *", "int", "caddr_t"}, {"type", "path", "flags", "caddr_t"}, "int"},
    {2, "unmount", {"char *", "int"}, {"path", "int"}, "int"},
    {1, "setuid", {"uid_t"}, {"uid_t"}, "int"},
    {0, "getuid", {""}, {""}, "int"},
    {0, "geteuid", {""}, {""}, "int"},
    {4, "ptrace", {"int", "pid_t", "caddr_t", "int"}, {"req", "pid", "addr", "int"}, "int"},
    {3, "recvmsg", {"int", "struct msghdr *", "int"}, {"s", "msg", "int"}, "int"},
    {3, "sendmsg", {"int", "struct msghdr *", "int"}, {"s", "msg", "int"}, "int"},
    {6, "recvfrom", {"int", "caddr_t", "size_t", "int", "struct sockaddr *__restrict", "__socklen_t *__restrict"}, {"s", "buf", "len", "flags", "from", "__socklen_t *__restrict"}, "int"},
    {3, "accept", {"int", "struct sockaddr *__restrict", "__socklen_t *__restrict"}, {"s", "name", "__socklen_t *__restrict"}, "int"},
    {3, "getpeername", {"int", "struct sockaddr *__restrict", "__socklen_t *__restrict"}, {"fdes", "asa", "__socklen_t *__restrict"}, "int"},
    {3, "getsockname", {"int", "struct sockaddr *__restrict", "__socklen_t *__restrict"}, {"fdes", "asa", "__socklen_t *__restrict"}, "int"},
    {2, "access", {"char *", "int"}, {"path", "int"}, "int"},
    {2, "chflags", {"char *", "int"}, {"path", "int"}, "int"},
    {2, "fchflags", {"int", "int"}, {"fd", "int"}, "int"},
    {0, "sync", {""}, {""}, "int"},
    {2, "kill", {"int", "int"}, {"pid", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, "getppid", {""}, {""}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "dup", {"u_int"}, {"u_int"}, "int"},
    {0, "pipe", {""}, {""}, "int"},
    {0, "getegid", {""}, {""}, "int"},
    {4, "profil", {"caddr_t", "size_t", "size_t", "u_int"}, {"samples", "size", "offset", "u_int"}, "int"},
    {4, "ktrace", {"const char *", "int", "int", "int"}, {"fname", "ops", "facs", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, "getgid", {""}, {""}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "getlogin", {"char *", "u_int"}, {"namebuf", "u_int"}, "int"},
    {1, "setlogin", {"char *"}, {"char *"}, "int"},
    {1, "acct", {"char *"}, {"char *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "sigaltstack", {"stack_t *", "stack_t *"}, {"ss", "stack_t *"}, "int"},
    {3, "ioctl", {"int", "u_long", "caddr_t"}, {"fd", "com", "caddr_t"}, "int"},
    {1, "reboot", {"int"}, {"int"}, "int"},
    {1, "revoke", {"char *"}, {"char *"}, "int"},
    {2, "symlink", {"char *", "char *"}, {"path", "char *"}, "int"},
    {3, "readlink", {"char *", "char *", "int"}, {"path", "buf", "int"}, "int"},
    {3, "execve", {"char *", "char **", "char **"}, {"fname", "argv", "char **"}, "int"},
    {1, "umask", {"int"}, {"int"}, "int"},
    {1, "chroot", {"char *"}, {"char *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {3, "msync", {"void *", "size_t", "int"}, {"addr", "len", "int"}, "int"},
    {0, "vfork", {""}, {""}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {1, "sbrk", {"int"}, {"int"}, "int"},
    {1, "sstk", {"int"}, {"int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "vadvise", {"int"}, {"int"}, "int"},
    {2, "munmap", {"void *", "size_t"}, {"addr", "size_t"}, "int"},
    {3, "mprotect", {"const void *", "size_t", "int"}, {"addr", "len", "int"}, "int"},
    {3, "madvise", {"void *", "size_t", "int"}, {"addr", "len", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {3, "mincore", {"const void *", "size_t", "char *"}, {"addr", "len", "char *"}, "int"},
    {2, "getgroups", {"u_int", "gid_t *"}, {"gidsetsize", "gid_t *"}, "int"},
    {2, "setgroups", {"u_int", "gid_t *"}, {"gidsetsize", "gid_t *"}, "int"},
    {0, "getpgrp", {""}, {""}, "int"},
    {2, "setpgid", {"int", "int"}, {"pid", "int"}, "int"},
    {3, "setitimer", {"u_int", "struct itimerval *", "struct itimerval *"}, {"which", "itv", "struct itimerval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "swapon", {"char *"}, {"char *"}, "int"},
    {2, "getitimer", {"u_int", "struct itimerval *"}, {"which", "struct itimerval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, "getdtablesize", {""}, {""}, "int"},
    {2, "dup2", {"u_int", "u_int"}, {"from", "u_int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "fcntl", {"int", "int", "long"}, {"fd", "cmd", "long"}, "int"},
    {5, "select", {"int", "fd_set *", "fd_set *", "fd_set *", "struct timeval *"}, {"nd", "in", "ou", "ex", "struct timeval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "fsync", {"int"}, {"int"}, "int"},
    {3, "setpriority", {"int", "int", "int"}, {"which", "who", "int"}, "int"},
    {3, "socket", {"int", "int", "int"}, {"domain", "type", "int"}, "int"},
    {3, "connect", {"int", "caddr_t", "int"}, {"s", "name", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "getpriority", {"int", "int"}, {"which", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {3, "bind", {"int", "caddr_t", "int"}, {"s", "name", "int"}, "int"},
    {5, "setsockopt", {"int", "int", "int", "caddr_t", "int"}, {"s", "level", "name", "val", "int"}, "int"},
    {2, "listen", {"int", "int"}, {"s", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {2, "gettimeofday", {"struct timeval *", "struct timezone *"}, {"tp", "struct timezone *"}, "int"},
    {2, "getrusage", {"int", "struct rusage *"}, {"who", "struct rusage *"}, "int"},
    {5, "getsockopt", {"int", "int", "int", "caddr_t", "int *"}, {"s", "level", "name", "val", "int *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "readv", {"int", "struct iovec *", "u_int"}, {"fd", "iovp", "u_int"}, "int"},
    {3, "writev", {"int", "struct iovec *", "u_int"}, {"fd", "iovp", "u_int"}, "int"},
    {2, "settimeofday", {"struct timeval *", "struct timezone *"}, {"tv", "struct timezone *"}, "int"},
    {3, "fchown", {"int", "int", "int"}, {"fd", "uid", "int"}, "int"},
    {2, "fchmod", {"int", "int"}, {"fd", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "setreuid", {"int", "int"}, {"ruid", "int"}, "int"},
    {2, "setregid", {"int", "int"}, {"rgid", "int"}, "int"},
    {2, "rename", {"char *", "char *"}, {"from", "char *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {2, "flock", {"int", "int"}, {"fd", "int"}, "int"},
    {2, "mkfifo", {"char *", "int"}, {"path", "int"}, "int"},
    {6, "sendto", {"int", "caddr_t", "size_t", "int", "caddr_t", "int"}, {"s", "buf", "len", "flags", "to", "int"}, "int"},
    {2, "shutdown", {"int", "int"}, {"s", "int"}, "int"},
    {4, "socketpair", {"int", "int", "int", "int *"}, {"domain", "type", "protocol", "int *"}, "int"},
    {2, "mkdir", {"char *", "int"}, {"path", "int"}, "int"},
    {1, "rmdir", {"char *"}, {"char *"}, "int"},
    {2, "utimes", {"char *", "struct timeval *"}, {"path", "struct timeval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "adjtime", {"struct timeval *", "struct timeval *"}, {"delta", "struct timeval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, "setsid", {""}, {""}, "int"},
    {4, "quotactl", {"char *", "int", "int", "caddr_t"}, {"path", "cmd", "uid", "caddr_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {2, "nfssvc", {"int", "caddr_t"}, {"flag", "caddr_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "freebsd4_statfs", {"char *", "struct ostatfs *"}, {"path", "struct ostatfs *"}, "int"},
    {2, "freebsd4_fstatfs", {"int", "struct ostatfs *"}, {"fd", "struct ostatfs *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "lgetfh", {"char *", "struct fhandle *"}, {"fname", "struct fhandle *"}, "int"},
    {2, "getfh", {"char *", "struct fhandle *"}, {"fname", "struct fhandle *"}, "int"},
    {2, "getdomainname", {"char *", "int"}, {"domainname", "int"}, "int"},
    {2, "setdomainname", {"char *", "int"}, {"domainname", "int"}, "int"},
    {1, "uname", {"struct utsname *"}, {"struct utsname *"}, "int"},
    {2, "sysarch", {"int", "char *"}, {"op", "char *"}, "int"},
    {3, "rtprio", {"int", "pid_t", "struct rtprio *"}, {"function", "pid", "struct rtprio *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {5, "semsys", {"int", "int", "int", "int", "int"}, {"which", "a2", "a3", "a4", "int"}, "int"},
    {6, "msgsys", {"int", "int", "int", "int", "int", "int"}, {"which", "a2", "a3", "a4", "a5", "int"}, "int"},
    {4, "shmsys", {"int", "int", "int", "int"}, {"which", "a2", "a3", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {5, "freebsd6_pread", {"int", "void *", "size_t", "int", "off_t"}, {"fd", "buf", "nbyte", "pad", "off_t"}, "int"},
    {5, "freebsd6_pwrite", {"int", "const void *", "size_t", "int", "off_t"}, {"fd", "buf", "nbyte", "pad", "off_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "ntp_adjtime", {"struct timex *"}, {"struct timex *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {1, "setgid", {"gid_t"}, {"gid_t"}, "int"},
    {1, "setegid", {"gid_t"}, {"gid_t"}, "int"},
    {1, "seteuid", {"uid_t"}, {"uid_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {2, "stat", {"char *", "struct stat *"}, {"path", "struct stat *"}, "int"},
    {2, "fstat", {"int", "struct stat *"}, {"fd", "struct stat *"}, "int"},
    {2, "lstat", {"char *", "struct stat *"}, {"path", "struct stat *"}, "int"},
    {2, "pathconf", {"char *", "int"}, {"path", "int"}, "int"},
    {2, "fpathconf", {"int", "int"}, {"fd", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, "getrlimit", {""}, {""}, "int"},
    {0, "setrlimit", {""}, {""}, "int"},
    {4, "getdirentries", {"int", "char *", "u_int", "long *"}, {"fd", "buf", "count", "long *"}, "int"},
    {7, "freebsd6_mmap", {"caddr_t", "size_t", "int", "int", "int", "int", "off_t"}, {"addr", "len", "prot", "flags", "fd", "pad", "off_t"}, "int"},
    {1, "__syscall", {"int"}, {"int"}, "int"},
    {4, "freebsd6_lseek", {"int", "int", "off_t", "int"}, {"fd", "pad", "offset", "int"}, "int"},
    {3, "freebsd6_truncate", {"char *", "int", "off_t"}, {"path", "pad", "off_t"}, "int"},
    {3, "freebsd6_ftruncate", {"int", "int", "off_t"}, {"fd", "pad", "off_t"}, "int"},
    {0, "__sysctl", {""}, {""}, "int"},
    {2, "mlock", {"const void *", "size_t"}, {"addr", "size_t"}, "int"},
    {2, "munlock", {"const void *", "size_t"}, {"addr", "size_t"}, "int"},
    {1, "undelete", {"char *"}, {"char *"}, "int"},
    {2, "futimes", {"int", "struct timeval *"}, {"fd", "struct timeval *"}, "int"},
    {1, "getpgid", {"pid_t"}, {"pid_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "poll", {"struct pollfd *", "u_int", "int"}, {"fds", "nfds", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {4, "__semctl", {"int", "int", "int", "union semun *"}, {"semid", "semnum", "cmd", "union semun *"}, "int"},
    {3, "semget", {"key_t", "int", "int"}, {"key", "nsems", "int"}, "int"},
    {3, "semop", {"int", "struct sembuf *", "size_t"}, {"semid", "sops", "size_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "msgctl", {"int", "int", "struct msqid_ds *"}, {"msqid", "cmd", "struct msqid_ds *"}, "int"},
    {2, "msgget", {"key_t", "int"}, {"key", "int"}, "int"},
    {4, "msgsnd", {"int", "const void *", "size_t", "int"}, {"msqid", "msgp", "msgsz", "int"}, "int"},
    {5, "msgrcv", {"int", "void *", "size_t", "long", "int"}, {"msqid", "msgp", "msgsz", "msgtyp", "int"}, "int"},
    {3, "shmat", {"int", "const void *", "int"}, {"shmid", "shmaddr", "int"}, "int"},
    {3, "shmctl", {"int", "int", "struct shmid_ds *"}, {"shmid", "cmd", "struct shmid_ds *"}, "int"},
    {1, "shmdt", {"const void *"}, {"const void *"}, "int"},
    {3, "shmget", {"key_t", "size_t", "int"}, {"key", "size", "int"}, "int"},
    {2, "clock_gettime", {"clockid_t", "struct timespec *"}, {"clock_id", "struct timespec *"}, "int"},
    {2, "clock_settime", {"clockid_t", "const struct timespec *"}, {"clock_id", "const struct timespec *"}, "int"},
    {2, "clock_getres", {"clockid_t", "struct timespec *"}, {"clock_id", "struct timespec *"}, "int"},
    {3, "ktimer_create", {"clockid_t", "struct sigevent *", "int *"}, {"clock_id", "evp", "int *"}, "int"},
    {1, "ktimer_delete", {"int"}, {"int"}, "int"},
    {4, "ktimer_settime", {"int", "int", "const struct itimerspec *", "struct itimerspec *"}, {"timerid", "flags", "value", "struct itimerspec *"}, "int"},
    {2, "ktimer_gettime", {"int", "struct itimerspec *"}, {"timerid", "struct itimerspec *"}, "int"},
    {1, "ktimer_getoverrun", {"int"}, {"int"}, "int"},
    {2, "nanosleep", {"const struct timespec *", "struct timespec *"}, {"rqtp", "struct timespec *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {1, "ntp_gettime", {"struct ntptimeval *"}, {"struct ntptimeval *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "minherit", {"void *", "size_t", "int"}, {"addr", "len", "int"}, "int"},
    {1, "rfork", {"int"}, {"int"}, "int"},
    {3, "openbsd_poll", {"struct pollfd *", "u_int", "int"}, {"fds", "nfds", "int"}, "int"},
    {0, "issetugid", {""}, {""}, "int"},
    {3, "lchown", {"char *", "int", "int"}, {"path", "uid", "int"}, "int"},
    {1, "aio_read", {"struct aiocb *"}, {"struct aiocb *"}, "int"},
    {1, "aio_write", {"struct aiocb *"}, {"struct aiocb *"}, "int"},
    {4, "lio_listio", {"int", "struct aiocb *const *", "int", "struct sigevent *"}, {"mode", "acb_list", "nent", "struct sigevent *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {3, "getdents", {"int", "char *", "size_t"}, {"fd", "buf", "size_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {2, "lchmod", {"char *", "mode_t"}, {"path", "mode_t"}, "int"},
    {1, "netbsd_lchown", {"int"}, {"int"}, "int"},
    {2, "lutimes", {"char *", "struct timeval *"}, {"path", "struct timeval *"}, "int"},
    {1, "netbsd_msync", {"int"}, {"int"}, "int"},
    {2, "nstat", {"char *", "struct nstat *"}, {"path", "struct nstat *"}, "int"},
    {2, "nfstat", {"int", "struct nstat *"}, {"fd", "struct nstat *"}, "int"},
    {2, "nlstat", {"char *", "struct nstat *"}, {"path", "struct nstat *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {4, "preadv", {"int", "struct iovec *", "u_int", "off_t"}, {"fd", "iovp", "iovcnt", "off_t"}, "int"},
    {4, "pwritev", {"int", "struct iovec *", "u_int", "off_t"}, {"fd", "iovp", "iovcnt", "off_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {2, "freebsd4_fhstatfs", {"const struct fhandle *", "struct ostatfs *"}, {"u_fhp", "struct ostatfs *"}, "int"},
    {2, "fhopen", {"const struct fhandle *", "int"}, {"u_fhp", "int"}, "int"},
    {2, "fhstat", {"const struct fhandle *", "struct stat *"}, {"u_fhp", "struct stat *"}, "int"},
    {1, "modnext", {"int"}, {"int"}, "int"},
    {2, "modstat", {"int", "struct module_stat *"}, {"modid", "struct module_stat *"}, "int"},
    {1, "modfnext", {"int"}, {"int"}, "int"},
    {1, "modfind", {"const char *"}, {"const char *"}, "int"},
    {1, "kldload", {"const char *"}, {"const char *"}, "int"},
    {1, "kldunload", {"int"}, {"int"}, "int"},
    {1, "kldfind", {"const char *"}, {"const char *"}, "int"},
    {1, "kldnext", {"int"}, {"int"}, "int"},
    {2, "kldstat", {"int", "struct kld_file_stat *"}, {"fileid", "struct kld_file_stat *"}, "int"},
    {1, "kldfirstmod", {"int"}, {"int"}, "int"},
    {1, "getsid", {"pid_t"}, {"pid_t"}, "int"},
    {3, "setresuid", {"uid_t", "uid_t", "uid_t"}, {"ruid", "euid", "uid_t"}, "int"},
    {3, "setresgid", {"gid_t", "gid_t", "gid_t"}, {"rgid", "egid", "gid_t"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "aio_return", {"struct aiocb *"}, {"struct aiocb *"}, "int"},
    {3, "aio_suspend", {"struct aiocb *const *", "int", "const struct timespec *"}, {"aiocbp", "nent", "const struct timespec *"}, "int"},
    {2, "aio_cancel", {"int", "struct aiocb *"}, {"fd", "struct aiocb *"}, "int"},
    {1, "aio_error", {"struct aiocb *"}, {"struct aiocb *"}, "int"},
    {1, "oaio_read", {"struct oaiocb *"}, {"struct oaiocb *"}, "int"},
    {1, "oaio_write", {"struct oaiocb *"}, {"struct oaiocb *"}, "int"},
    {4, "olio_listio", {"int", "struct oaiocb *const *", "int", "struct osigevent *"}, {"mode", "acb_list", "nent", "struct osigevent *"}, "int"},
    {0, "yield", {""}, {""}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {1, "mlockall", {"int"}, {"int"}, "int"},
    {0, "munlockall", {""}, {""}, "int"},
    {2, "__getcwd", {"u_char *", "u_int"}, {"buf", "u_int"}, "int"},
    {2, "sched_setparam", {"pid_t", "const struct sched_param *"}, {"pid", "const struct sched_param *"}, "int"},
    {2, "sched_getparam", {"pid_t", "struct sched_param *"}, {"pid", "struct sched_param *"}, "int"},
    {3, "sched_setscheduler", {"pid_t", "int", "const struct sched_param *"}, {"pid", "policy", "const struct sched_param *"}, "int"},
    {1, "sched_getscheduler", {"pid_t"}, {"pid_t"}, "int"},
    {0, "sched_yield", {""}, {""}, "int"},
    {1, "sched_get_priority_max", {"int"}, {"int"}, "int"},
    {1, "sched_get_priority_min", {"int"}, {"int"}, "int"},
    {2, "sched_rr_get_interval", {"pid_t", "struct timespec *"}, {"pid", "struct timespec *"}, "int"},
    {2, "utrace", {"const void *", "size_t"}, {"addr", "size_t"}, "int"},
    {7, "freebsd4_sendfile", {"int", "int", "off_t", "size_t", "struct sf_hdtr *", "off_t *", "int"}, {"fd", "s", "offset", "nbytes", "hdtr", "sbytes", "int"}, "int"},
    {3, "kldsym", {"int", "int", "void *"}, {"fileid", "cmd", "void *"}, "int"},
    {1, "jail", {"struct jail *"}, {"struct jail *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "sigprocmask", {"int", "const sigset_t *", "sigset_t *"}, {"how", "set", "sigset_t *"}, "int"},
    {1, "sigsuspend", {"const sigset_t *"}, {"const sigset_t *"}, "int"},
    {3, "freebsd4_sigaction", {"int", "const struct sigaction *", "struct sigaction *"}, {"sig", "act", "struct sigaction *"}, "int"},
    {1, "sigpending", {"sigset_t *"}, {"sigset_t *"}, "int"},
    {1, "freebsd4_sigreturn", {"const struct"}, {"const struct"}, "int"},
    {3, "sigtimedwait", {"const sigset_t *", "siginfo_t *", "const struct timespec *"}, {"set", "info", "const struct timespec *"}, "int"},
    {2, "sigwaitinfo", {"const sigset_t *", "siginfo_t *"}, {"set", "siginfo_t *"}, "int"},
    {3, "__acl_get_file", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {3, "__acl_set_file", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {3, "__acl_get_fd", {"int", "acl_type_t", "struct acl *"}, {"filedes", "type", "struct acl *"}, "int"},
    {3, "__acl_set_fd", {"int", "acl_type_t", "struct acl *"}, {"filedes", "type", "struct acl *"}, "int"},
    {2, "__acl_delete_file", {"const char *", "acl_type_t"}, {"path", "acl_type_t"}, "int"},
    {2, "__acl_delete_fd", {"int", "acl_type_t"}, {"filedes", "acl_type_t"}, "int"},
    {3, "__acl_aclcheck_file", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {3, "__acl_aclcheck_fd", {"int", "acl_type_t", "struct acl *"}, {"filedes", "type", "struct acl *"}, "int"},
    {5, "extattrctl", {"const char *", "int", "const char *", "int", "const char *"}, {"path", "cmd", "filename", "attrnamespace", "const char *"}, "int"},
    {5, "extattr_set_file", {"const char *", "int", "const char *", "void *", "size_t"}, {"path", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {5, "extattr_get_file", {"const char *", "int", "const char *", "void *", "size_t"}, {"path", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {3, "extattr_delete_file", {"const char *", "int", "const char *"}, {"path", "attrnamespace", "const char *"}, "int"},
    {2, "aio_waitcomplete", {"struct aiocb **", "struct timespec *"}, {"aiocbp", "struct timespec *"}, "int"},
    {3, "getresuid", {"uid_t *", "uid_t *", "uid_t *"}, {"ruid", "euid", "uid_t *"}, "int"},
    {3, "getresgid", {"gid_t *", "gid_t *", "gid_t *"}, {"rgid", "egid", "gid_t *"}, "int"},
    {0, "kqueue", {""}, {""}, "int"},
    {6, "kevent", {"int", "struct kevent *", "int", "struct kevent *", "int", "const struct timespec *"}, {"fd", "changelist", "nchanges", "eventlist", "nevents", "const struct timespec *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {5, "extattr_set_fd", {"int", "int", "const char *", "void *", "size_t"}, {"fd", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {5, "extattr_get_fd", {"int", "int", "const char *", "void *", "size_t"}, {"fd", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {3, "extattr_delete_fd", {"int", "int", "const char *"}, {"fd", "attrnamespace", "const char *"}, "int"},
    {1, "__setugid", {"int"}, {"int"}, "int"},
    {2, "nfsclnt", {"int", "caddr_t"}, {"flag", "caddr_t"}, "int"},
    {2, "eaccess", {"char *", "int"}, {"path", "int"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {3, "nmount", {"struct iovec *", "unsigned int", "int"}, {"iovp", "iovcnt", "int"}, "int"},
    {0, "kse_exit", {""}, {""}, "int"},
    {1, "kse_wakeup", {"struct kse_mailbox *"}, {"struct kse_mailbox *"}, "int"},
    {2, "kse_create", {"struct kse_mailbox *", "int"}, {"mbx", "int"}, "int"},
    {3, "kse_thr_interrupt", {"struct kse_thr_mailbox *", "int", "long"}, {"tmbx", "cmd", "long"}, "int"},
    {1, "kse_release", {"struct timespec *"}, {"struct timespec *"}, "int"},
    {1, "__mac_get_proc", {"struct mac *"}, {"struct mac *"}, "int"},
    {1, "__mac_set_proc", {"struct mac *"}, {"struct mac *"}, "int"},
    {2, "__mac_get_fd", {"int", "struct mac *"}, {"fd", "struct mac *"}, "int"},
    {2, "__mac_get_file", {"const char *", "struct mac *"}, {"path_p", "struct mac *"}, "int"},
    {2, "__mac_set_fd", {"int", "struct mac *"}, {"fd", "struct mac *"}, "int"},
    {2, "__mac_set_file", {"const char *", "struct mac *"}, {"path_p", "struct mac *"}, "int"},
    {4, "kenv", {"int", "const char *", "char *", "int"}, {"what", "name", "value", "int"}, "int"},
    {2, "lchflags", {"const char *", "int"}, {"path", "int"}, "int"},
    {2, "uuidgen", {"struct uuid *", "int"}, {"store", "int"}, "int"},
    {7, "sendfile", {"int", "int", "off_t", "size_t", "struct sf_hdtr *", "off_t *", "int"}, {"fd", "s", "offset", "nbytes", "hdtr", "sbytes", "int"}, "int"},
    {3, "mac_syscall", {"const char *", "int", "void *"}, {"policy", "call", "void *"}, "int"},
    {3, "getfsstat", {"struct statfs *", "long", "int"}, {"buf", "bufsize", "int"}, "int"},
    {2, "statfs", {"char *", "struct statfs *"}, {"path", "struct statfs *"}, "int"},
    {2, "fstatfs", {"int", "struct statfs *"}, {"fd", "struct statfs *"}, "int"},
    {2, "fhstatfs", {"const struct fhandle *", "struct statfs *"}, {"u_fhp", "struct statfs *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {1, "ksem_close", {"semid_t"}, {"semid_t"}, "int"},
    {1, "ksem_post", {"semid_t"}, {"semid_t"}, "int"},
    {1, "ksem_wait", {"semid_t"}, {"semid_t"}, "int"},
    {1, "ksem_trywait", {"semid_t"}, {"semid_t"}, "int"},
    {2, "ksem_init", {"semid_t *", "unsigned int"}, {"idp", "unsigned int"}, "int"},
    {5, "ksem_open", {"semid_t *", "const char *", "int", "mode_t", "unsigned int"}, {"idp", "name", "oflag", "mode", "unsigned int"}, "int"},
    {1, "ksem_unlink", {"const char *"}, {"const char *"}, "int"},
    {2, "ksem_getvalue", {"semid_t", "int *"}, {"id", "int *"}, "int"},
    {1, "ksem_destroy", {"semid_t"}, {"semid_t"}, "int"},
    {2, "__mac_get_pid", {"pid_t", "struct mac *"}, {"pid", "struct mac *"}, "int"},
    {2, "__mac_get_link", {"const char *", "struct mac *"}, {"path_p", "struct mac *"}, "int"},
    {2, "__mac_set_link", {"const char *", "struct mac *"}, {"path_p", "struct mac *"}, "int"},
    {5, "extattr_set_link", {"const char *", "int", "const char *", "void *", "size_t"}, {"path", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {5, "extattr_get_link", {"const char *", "int", "const char *", "void *", "size_t"}, {"path", "attrnamespace", "attrname", "data", "size_t"}, "int"},
    {3, "extattr_delete_link", {"const char *", "int", "const char *"}, {"path", "attrnamespace", "const char *"}, "int"},
    {4, "__mac_execve", {"char *", "char **", "char **", "struct mac *"}, {"fname", "argv", "envv", "struct mac *"}, "int"},
    {3, "sigaction", {"int", "const struct sigaction *", "struct sigaction *"}, {"sig", "act", "struct sigaction *"}, "int"},
    {1, "sigreturn", {"const struct __ucontext *"}, {"const struct __ucontext *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {1, "getcontext", {"struct __ucontext *"}, {"struct __ucontext *"}, "int"},
    {1, "setcontext", {"const struct __ucontext *"}, {"const struct __ucontext *"}, "int"},
    {2, "swapcontext", {"struct __ucontext *", "const struct __ucontext *"}, {"oucp", "const struct __ucontext *"}, "int"},
    {1, "swapoff", {"const char *"}, {"const char *"}, "int"},
    {3, "__acl_get_link", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {3, "__acl_set_link", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {2, "__acl_delete_link", {"const char *", "acl_type_t"}, {"path", "acl_type_t"}, "int"},
    {3, "__acl_aclcheck_link", {"const char *", "acl_type_t", "struct acl *"}, {"path", "type", "struct acl *"}, "int"},
    {2, "sigwait", {"const sigset_t *", "int *"}, {"set", "int *"}, "int"},
    {3, "thr_create", {"ucontext_t *", "long *", "int"}, {"ctx", "id", "int"}, "int"},
    {1, "thr_exit", {"long *"}, {"long *"}, "int"},
    {1, "thr_self", {"long *"}, {"long *"}, "int"},
    {2, "thr_kill", {"long", "int"}, {"id", "int"}, "int"},
    {1, "_umtx_lock", {"struct umtx *"}, {"struct umtx *"}, "int"},
    {1, "_umtx_unlock", {"struct umtx *"}, {"struct umtx *"}, "int"},
    {1, "jail_attach", {"int"}, {"int"}, "int"},
    {4, "extattr_list_fd", {"int", "int", "void *", "size_t"}, {"fd", "attrnamespace", "data", "size_t"}, "int"},
    {4, "extattr_list_file", {"const char *", "int", "void *", "size_t"}, {"path", "attrnamespace", "data", "size_t"}, "int"},
    {4, "extattr_list_link", {"const char *", "int", "void *", "size_t"}, {"path", "attrnamespace", "data", "size_t"}, "int"},
    {2, "kse_switchin", {"struct kse_thr_mailbox *", "int"}, {"tmbx", "int"}, "int"},
    {2, "ksem_timedwait", {"semid_t", "const struct timespec *"}, {"id", "const struct timespec *"}, "int"},
    {1, "thr_suspend", {"const struct timespec *"}, {"const struct timespec *"}, "int"},
    {1, "thr_wake", {"long"}, {"long"}, "int"},
    {2, "kldunloadf", {"int", "int"}, {"fileid", "int"}, "int"},
    {2, "audit", {"const void *", "u_int"}, {"record", "u_int"}, "int"},
    {3, "auditon", {"int", "void *", "u_int"}, {"cmd", "data", "u_int"}, "int"},
    {1, "getauid", {"uid_t *"}, {"uid_t *"}, "int"},
    {1, "setauid", {"uid_t *"}, {"uid_t *"}, "int"},
    {1, "getaudit", {"struct auditinfo *"}, {"struct auditinfo *"}, "int"},
    {1, "setaudit", {"struct auditinfo *"}, {"struct auditinfo *"}, "int"},
    {2, "getaudit_addr", {"struct auditinfo_addr *", "u_int"}, {"auditinfo_addr", "u_int"}, "int"},
    {2, "setaudit_addr", {"struct auditinfo_addr *", "u_int"}, {"auditinfo_addr", "u_int"}, "int"},
    {1, "auditctl", {"char *"}, {"char *"}, "int"},
    {5, "_umtx_op", {"void *", "int", "u_long", "void *", "void *"}, {"obj", "op", "val", "uaddr1", "void *"}, "int"},
    {2, "thr_new", {"struct thr_param *", "int"}, {"param", "int"}, "int"},
    {3, "sigqueue", {"pid_t", "int", "void *"}, {"pid", "signum", "void *"}, "int"},
    {4, "kmq_open", {"const char *", "int", "mode_t", "const struct mq_attr *"}, {"path", "flags", "mode", "const struct mq_attr *"}, "int"},
    {3, "kmq_setattr", {"int", "const struct mq_attr *", "struct mq_attr *"}, {"mqd", "attr", "struct mq_attr *"}, "int"},
    {5, "kmq_timedreceive", {"int", "char *", "size_t", "unsigned *", "const struct timespec *"}, {"mqd", "msg_ptr", "msg_len", "msg_prio", "const struct timespec *"}, "int"},
    {5, "kmq_timedsend", {"int", "const char *", "size_t", "unsigned", "const struct timespec *"}, {"mqd", "msg_ptr", "msg_len", "msg_prio", "const struct timespec *"}, "int"},
    {2, "kmq_notify", {"int", "const struct sigevent *"}, {"mqd", "const struct sigevent *"}, "int"},
    {1, "kmq_unlink", {"const char *"}, {"const char *"}, "int"},
    {3, "abort2", {"const char *", "int", "void **"}, {"why", "nargs", "void **"}, "int"},
    {2, "thr_set_name", {"long", "const char *"}, {"id", "const char *"}, "int"},
    {2, "aio_fsync", {"int", "struct aiocb *"}, {"op", "struct aiocb *"}, "int"},
    {3, "rtprio_thread", {"int", "lwpid_t", "struct rtprio *"}, {"function", "lwpid", "struct rtprio *"}, "int"},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, NULL, {""}, {""}, NULL},
    {0, "", {""}, {""}, NULL},
    {2, "sctp_peeloff", {"int", "_t"}, {"sd", "_t"}, "int"},
    {7, "sctp_generic_sendmsg", {"int", "caddr_t", "int", "caddr_t", "__socklen_t", "struct sctp_sndrcvinfo *", "int"}, {"sd", "msg", "mlen", "to", "tolen", "sinfo", "int"}, "int"},
    {7, "sctp_generic_sendmsg_iov", {"int", "struct iovec *", "int", "caddr_t", "__socklen_t", "struct sctp_sndrcvinfo *", "int"}, {"sd", "iov", "iovlen", "to", "tolen", "sinfo", "int"}, "int"},
    {7, "sctp_generic_recvmsg", {"int", "struct iovec *", "int", "struct sockaddr *", "__socklen_t *", "struct sctp_sndrcvinfo *", "int *"}, {"sd", "iov", "iovlen", "from", "fromlenaddr", "sinfo", "int *"}, "int"},
    {4, "pread", {"int", "void *", "size_t", "off_t"}, {"fd", "buf", "nbyte", "off_t"}, "int"},
    {4, "pwrite", {"int", "const void *", "size_t", "off_t"}, {"fd", "buf", "nbyte", "off_t"}, "int"},
    {6, "mmap", {"caddr_t", "size_t", "int", "int", "int", "off_t"}, {"addr", "len", "prot", "flags", "fd", "off_t"}, "int"},
    {3, "lseek", {"int", "off_t", "int"}, {"fd", "offset", "int"}, "int"},
    {2, "truncate", {"char *", "off_t"}, {"path", "off_t"}, "int"},
    {2, "ftruncate", {"int", "off_t"}, {"fd", "off_t"}, "int"},
    {3, "thr_kill2", {"pid_t", "long", "int"}, {"pid", "id", "int"}, "int"},
    {1, "MAXSYSCALL", {"int"}, {"int"}, "int"}
  };
