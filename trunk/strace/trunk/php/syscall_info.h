
typedef struct s_sysinfo
{
  int   nbargs;
  char  *sysname;
  char  sysproto[8][128];
  char  *return_type;
}t_sysinfo;

t_sysinfo       SYSINFO[483] =
  {
    {0, "syscall", {"int anom"}, "int"},
    {1, "exit", {"int rval"}, "void"},
    {2, "fork", {NULL}, "int"},
    {3, "read", {"int fd", "void* buf", "size_t nbyte"}, "int"},
    {4, "write", {"int fd", "const void* buf", "size_t nbyte"}, "int"},
    {5, "open", {"char* path", "int flags", "int mode"}, "int"},
    {6, "close", {"int fd"}, "int"},
    {7, "wait4", {NULL}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {9, "link", {"char* path", "char* link"}, "int"},
    {10, "unlink", {"char* path"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {12, "chdir", {"char* path"}, "int"},
    {13, "fchdir", {"int fd"}, "int"},
    {14, "mknod", {"char* path", "int mode", "int dev"}, "int"},
    {15, "chmod", {"char* path", "int mode"}, "int"},
    {16, "chown", {"char* path", "int uid", "int gid"}, "int"},
    {17, "break", {"char* nsize"}, "int"},
    {18, "freebsd4_getfsstat", {"struct ostatfs* buf", "long bufsize", "int flags"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {20, "getpid", {NULL}, "int"},
    {21, "mount", {"char* type", "char* path", "int flags", "caddr_t data"}, "int"},
    {22, "unmount", {"char* path", "int flags"}, "int"},
    {23, "setuid", {"uid_t uid"}, "int"},
    {24, "getuid", {NULL}, "int"},
    {25, "geteuid", {NULL}, "int"},
    {26, "ptrace", {"int req", "pid_t pid", "caddr_t addr", "int data"}, "int"},
    {27, "recvmsg", {"int s", "struct msghdr* msg", "int flags"}, "int"},
    {28, "sendmsg", {"int s", "struct msghdr* msg", "int flags"}, "int"},
    {29, "recvfrom", {"int s", "caddr_t buf", "size_t len", "int flags", "struct sockaddr *__restrict from", "__socklen_t *__restrict fromlenaddr"}, "int"},
    {30, "accept", {"int s", "struct sockaddr *__restrict name", "__socklen_t *__restrict anamelen"}, "int"},
    {31, "getpeername", {"int fdes", "struct sockaddr *__restrict asa", "__socklen_t *__restrict alen"}, "int"},
    {32, "getsockname", {"int fdes", "struct sockaddr *__restrict asa", "__socklen_t *__restrict alen"}, "int"},
    {33, "access", {"char* path", "int flags"}, "int"},
    {34, "chflags", {"char* path", "int flags"}, "int"},
    {35, "fchflags", {"int fd", "int flags"}, "int"},
    {36, "sync", {NULL}, "int"},
    {37, "kill", {"int pid", "int signum"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {39, "getppid", {NULL}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {41, "dup", {"u_int fd"}, "int"},
    {42, "pipe", {NULL}, "int"},
    {43, "getegid", {NULL}, "int"},
    {44, "profil", {"caddr_t samples", "size_t size", "size_t offset", "u_int scale"}, "int"},
    {45, "ktrace", {"const char* fname", "int ops", "int facs", "int pid"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {47, "getgid", {NULL}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {49, "getlogin", {"char* namebuf", "u_int namelen"}, "int"},
    {50, "setlogin", {"char* namebuf"}, "int"},
    {51, "acct", {"char* path"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {53, "sigaltstack", {"stack_t* ss", "stack_t* oss"}, "int"},
    {54, "ioctl", {"int fd", "u_long com", "caddr_t data"}, "int"},
    {55, "reboot", {"int opt"}, "int"},
    {56, "revoke", {"char* path"}, "int"},
    {57, "symlink", {"char* path", "char* link"}, "int"},
    {58, "readlink", {"char* path", "char* buf", "int count"}, "int"},
    {59, "execve", {"char* fname", "char ** argv", "char ** envv"}, "int"},
    {60, "umask", {"int newmask"}, "int"},
    {61, "chroot", {"char* path"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {65, "msync", {"void* addr", "size_t len", "int flags"}, "int"},
    {66, "vfork", {NULL}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {69, "sbrk", {"int incr"}, "int"},
    {70, "sstk", {"int incr"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {72, "vadvise", {"int anom"}, "int"},
    {73, "munmap", {"void* addr", "size_t len"}, "int"},
    {74, "mprotect", {"const void* addr", "size_t len", "int prot"}, "int"},
    {75, "madvise", {"void* addr", "size_t len", "int behav"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {78, "mincore", {"const void* addr", "size_t len", "char* vec"}, "int"},
    {79, "getgroups", {"u_int gidsetsize", "gid_t* gidset"}, "int"},
    {80, "setgroups", {"u_int gidsetsize", "gid_t* gidset"}, "int"},
    {81, "getpgrp", {NULL}, "int"},
    {82, "setpgid", {"int pid", "int pgid"}, "int"},
    {83, "setitimer", {"u_int which", "struct itimerval* itv", "struct itimerval* oitv"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {85, "swapon", {"char* name"}, "int"},
    {86, "getitimer", {"u_int which", "struct itimerval* itv"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {89, "getdtablesize", {NULL}, "int"},
    {90, "dup2", {"u_int from", "u_int to"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {92, "fcntl", {"int fd", "int cmd", "long arg"}, "int"},
    {93, "select", {"int nd", "fd_set* in", "fd_set* ou", "fd_set* ex", "struct timeval* tv"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {95, "fsync", {"int fd"}, "int"},
    {96, "setpriority", {"int which", "int who", "int prio"}, "int"},
    {97, "socket", {"int domain", "int type", "int protocol"}, "int"},
    {98, "connect", {"int s", "caddr_t name", "int namelen"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {100, "getpriority", {"int which", "int who"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {104, "bind", {"int s", "caddr_t name", "int namelen"}, "int"},
    {105, "setsockopt", {"int s", "int level", "int name", "caddr_t val", "int valsize"}, "int"},
    {106, "listen", {"int s", "int backlog"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {116, "gettimeofday", {"struct timeval* tp", "struct timezone* tzp"}, "int"},
    {117, "getrusage", {"int who", "struct rusage* rusage"}, "int"},
    {118, "getsockopt", {"int s", "int level", "int name", "caddr_t val", "int* avalsize"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {120, "readv", {"int fd", "struct iovec* iovp", "u_int iovcnt"}, "int"},
    {121, "writev", {"int fd", "struct iovec* iovp", "u_int iovcnt"}, "int"},
    {122, "settimeofday", {"struct timeval* tv", "struct timezone* tzp"}, "int"},
    {123, "fchown", {"int fd", "int uid", "int gid"}, "int"},
    {124, "fchmod", {"int fd", "int mode"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {126, "setreuid", {"int ruid", "int euid"}, "int"},
    {127, "setregid", {"int rgid", "int egid"}, "int"},
    {128, "rename", {"char* from", "char* to"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {131, "flock", {"int fd", "int how"}, "int"},
    {132, "mkfifo", {"char* path", "int mode"}, "int"},
    {133, "sendto", {"int s", "caddr_t buf", "size_t len", "int flags", "caddr_t to", "int tolen"}, "int"},
    {134, "shutdown", {"int s", "int how"}, "int"},
    {135, "socketpair", {"int domain", "int type", "int protocol", "int* rsv"}, "int"},
    {136, "mkdir", {"char* path", "int mode"}, "int"},
    {137, "rmdir", {"char* path"}, "int"},
    {138, "utimes", {"char* path", "struct timeval* tptr"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {140, "adjtime", {"struct timeval* delta", "struct timeval* olddelta"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {147, "setsid", {NULL}, "int"},
    {148, "quotactl", {"char* path", "int cmd", "int uid", "caddr_t arg"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {155, "nfssvc", {"int flag", "caddr_t argp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {157, "freebsd4_statfs", {"char* path", "struct ostatfs* buf"}, "int"},
    {158, "freebsd4_fstatfs", {"int fd", "struct ostatfs* buf"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {160, "lgetfh", {"char* fname", "struct fhandle* fhp"}, "int"},
    {161, "getfh", {"char* fname", "struct fhandle* fhp"}, "int"},
    {162, "getdomainname", {"char* domainname", "int len"}, "int"},
    {163, "setdomainname", {"char* domainname", "int len"}, "int"},
    {164, "uname", {"struct utsname* name"}, "int"},
    {165, "sysarch", {"int op", "char* parms"}, "int"},
    {166, "rtprio", {"int function", "pid_t pid", "struct rtprio* rtp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {169, "semsys", {"int which", "int a2", "int a3", "int a4", "int a5"}, "int"},
    {170, "msgsys", {"int which", "int a2", "int a3", "int a4", "int a5", "int a6"}, "int"},
    {171, "shmsys", {"int which", "int a2", "int a3", "int a4"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {173, "freebsd6_pread", {"int fd", "void* buf", "size_t nbyte", "int pad", "off_t offset"}, "int"},
    {174, "freebsd6_pwrite", {"int fd", "const void* buf", "size_t nbyte", "int pad", "off_t offset"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {176, "ntp_adjtime", {"struct timex* tp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {181, "setgid", {"gid_t gid"}, "int"},
    {182, "setegid", {"gid_t egid"}, "int"},
    {183, "seteuid", {"uid_t euid"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {188, "stat", {"char* path", "struct stat* ub"}, "int"},
    {189, "fstat", {"int fd", "struct stat* sb"}, "int"},
    {190, "lstat", {"char* path", "struct stat* ub"}, "int"},
    {191, "pathconf", {"char* path", "int name"}, "int"},
    {192, "fpathconf", {"int fd", "int name"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {194, "getrlimit", {NULL}, "int"},
    {195, "setrlimit", {NULL}, "int"},
    {196, "getdirentries", {"int fd", "char* buf", "u_int count", "long* basep"}, "int"},
    {197, "freebsd6_mmap", {"caddr_t addr", "size_t len", "int prot", "int flags", "int fd", "int pad", "off_t pos"}, "int"},
    {198, "__syscall", {"int anom"}, "int"},
    {199, "freebsd6_lseek", {"int fd", "int pad", "off_t offset", "int whence"}, "int"},
    {200, "freebsd6_truncate", {"char* path", "int pad", "off_t length"}, "int"},
    {201, "freebsd6_ftruncate", {"int fd", "int pad", "off_t length"}, "int"},
    {202, "__sysctl", {NULL}, "int"},
    {203, "mlock", {"const void* addr", "size_t len"}, "int"},
    {204, "munlock", {"const void* addr", "size_t len"}, "int"},
    {205, "undelete", {"char* path"}, "int"},
    {206, "futimes", {"int fd", "struct timeval* tptr"}, "int"},
    {207, "getpgid", {"pid_t pid"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {209, "poll", {"struct pollfd* fds", "u_int nfds", "int timeout"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {220, "__semctl", {"int semid", "int semnum", "int cmd", "union semun* arg"}, "int"},
    {221, "semget", {"key_t key", "int nsems", "int semflg"}, "int"},
    {222, "semop", {"int semid", "struct sembuf* sops", "size_t nsops"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {224, "msgctl", {"int msqid", "int cmd", "struct msqid_ds* buf"}, "int"},
    {225, "msgget", {"key_t key", "int msgflg"}, "int"},
    {226, "msgsnd", {"int msqid", "const void* msgp", "size_t msgsz", "int msgflg"}, "int"},
    {227, "msgrcv", {"int msqid", "void* msgp", "size_t msgsz", "long msgtyp", "int msgflg"}, "int"},
    {228, "shmat", {"int shmid", "const void* shmaddr", "int shmflg"}, "int"},
    {229, "shmctl", {"int shmid", "int cmd", "struct shmid_ds* buf"}, "int"},
    {230, "shmdt", {"const void* shmaddr"}, "int"},
    {231, "shmget", {"key_t key", "size_t size", "int shmflg"}, "int"},
    {232, "clock_gettime", {"clockid_t clock_id", "struct timespec* tp"}, "int"},
    {233, "clock_settime", {"clockid_t clock_id", "const struct timespec* tp"}, "int"},
    {234, "clock_getres", {"clockid_t clock_id", "struct timespec* tp"}, "int"},
    {235, "ktimer_create", {"clockid_t clock_id", "struct sigevent* evp", "int* timerid"}, "int"},
    {236, "ktimer_delete", {"int timerid"}, "int"},
    {237, "ktimer_settime", {"int timerid", "int flags", "const struct itimerspec* value", "struct itimerspec* ovalue"}, "int"},
    {238, "ktimer_gettime", {"int timerid", "struct itimerspec* value"}, "int"},
    {239, "ktimer_getoverrun", {"int timerid"}, "int"},
    {240, "nanosleep", {"const struct timespec* rqtp", "struct timespec* rmtp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {248, "ntp_gettime", {"struct ntptimeval* ntvp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {250, "minherit", {"void* addr", "size_t len", "int inherit"}, "int"},
    {251, "rfork", {"int flags"}, "int"},
    {252, "openbsd_poll", {"struct pollfd* fds", "u_int nfds", "int timeout"}, "int"},
    {253, "issetugid", {NULL}, "int"},
    {254, "lchown", {"char* path", "int uid", "int gid"}, "int"},
    {255, "aio_read", {"struct aiocb* aiocbp"}, "int"},
    {256, "aio_write", {"struct aiocb* aiocbp"}, "int"},
    {257, "lio_listio", {"int mode", "struct aiocb *const* acb_list", "int nent", "struct sigevent* sig"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {272, "getdents", {"int fd", "char* buf", "size_t count"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {274, "lchmod", {"char* path", "mode_t mode"}, "int"},
    {275, "netbsd_lchown", {"int anom"}, "int"},
    {276, "lutimes", {"char* path", "struct timeval* tptr"}, "int"},
    {277, "netbsd_msync", {"int anom"}, "int"},
    {278, "nstat", {"char* path", "struct nstat* ub"}, "int"},
    {279, "nfstat", {"int fd", "struct nstat* sb"}, "int"},
    {280, "nlstat", {"char* path", "struct nstat* ub"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {289, "preadv", {"int fd", "struct iovec* iovp", "u_int iovcnt", "off_t offset"}, "int"},
    {290, "pwritev", {"int fd", "struct iovec* iovp", "u_int iovcnt", "off_t offset"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {297, "freebsd4_fhstatfs", {"const struct fhandle* u_fhp", "struct ostatfs* buf"}, "int"},
    {298, "fhopen", {"const struct fhandle* u_fhp", "int flags"}, "int"},
    {299, "fhstat", {"const struct fhandle* u_fhp", "struct stat* sb"}, "int"},
    {300, "modnext", {"int modid"}, "int"},
    {301, "modstat", {"int modid", "struct module_stat* stat"}, "int"},
    {302, "modfnext", {"int modid"}, "int"},
    {303, "modfind", {"const char* name"}, "int"},
    {304, "kldload", {"const char* file"}, "int"},
    {305, "kldunload", {"int fileid"}, "int"},
    {306, "kldfind", {"const char* file"}, "int"},
    {307, "kldnext", {"int fileid"}, "int"},
    {308, "kldstat", {"int fileid", "struct kld_file_stat* stat"}, "int"},
    {309, "kldfirstmod", {"int fileid"}, "int"},
    {310, "getsid", {"pid_t pid"}, "int"},
    {311, "setresuid", {"uid_t ruid", "uid_t euid", "uid_t suid"}, "int"},
    {312, "setresgid", {"gid_t rgid", "gid_t egid", "gid_t sgid"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {314, "aio_return", {"struct aiocb* aiocbp"}, "int"},
    {315, "aio_suspend", {"struct aiocb *const* aiocbp", "int nent", "const struct timespec* timeout"}, "int"},
    {316, "aio_cancel", {"int fd", "struct aiocb* aiocbp"}, "int"},
    {317, "aio_error", {"struct aiocb* aiocbp"}, "int"},
    {318, "oaio_read", {"struct oaiocb* aiocbp"}, "int"},
    {319, "oaio_write", {"struct oaiocb* aiocbp"}, "int"},
    {320, "olio_listio", {"int mode", "struct oaiocb *const* acb_list", "int nent", "struct osigevent* sig"}, "int"},
    {321, "yield", {NULL}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {324, "mlockall", {"int how"}, "int"},
    {325, "munlockall", {NULL}, "int"},
    {326, "__getcwd", {"u_char* buf", "u_int buflen"}, "int"},
    {327, "sched_setparam", {"pid_t pid", "const struct sched_param* param"}, "int"},
    {328, "sched_getparam", {"pid_t pid", "struct sched_param* param"}, "int"},
    {329, "sched_setscheduler", {"pid_t pid", "int policy", "const struct sched_param* param"}, "int"},
    {330, "sched_getscheduler", {"pid_t pid"}, "int"},
    {331, "sched_yield", {NULL}, "int"},
    {332, "sched_get_priority_max", {"int policy"}, "int"},
    {333, "sched_get_priority_min", {"int policy"}, "int"},
    {334, "sched_rr_get_interval", {"pid_t pid", "struct timespec* interval"}, "int"},
    {335, "utrace", {"const void* addr", "size_t len"}, "int"},
    {336, "freebsd4_sendfile", {"int fd", "int s", "off_t offset", "size_t nbytes", "struct sf_hdtr* hdtr", "off_t* sbytes", "int flags"}, "int"},
    {337, "kldsym", {"int fileid", "int cmd", "void* data"}, "int"},
    {338, "jail", {"struct jail* jail"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {340, "sigprocmask", {"int how", "const sigset_t* set", "sigset_t* oset"}, "int"},
    {341, "sigsuspend", {"const sigset_t* sigmask"}, "int"},
    {342, "freebsd4_sigaction", {"int sig", "const struct sigaction* act", "struct sigaction* oact"}, "int"},
    {343, "sigpending", {"sigset_t* set"}, "int"},
    {344, "freebsd4_sigreturn", {"const struct ucontext4* sigcntxp"}, "int"},
    {345, "sigtimedwait", {"const sigset_t* set", "siginfo_t* info", "const struct timespec* timeout"}, "int"},
    {346, "sigwaitinfo", {"const sigset_t* set", "siginfo_t* info"}, "int"},
    {347, "__acl_get_file", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {348, "__acl_set_file", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {349, "__acl_get_fd", {"int filedes", "acl_type_t type", "struct acl* aclp"}, "int"},
    {350, "__acl_set_fd", {"int filedes", "acl_type_t type", "struct acl* aclp"}, "int"},
    {351, "__acl_delete_file", {"const char* path", "acl_type_t type"}, "int"},
    {352, "__acl_delete_fd", {"int filedes", "acl_type_t type"}, "int"},
    {353, "__acl_aclcheck_file", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {354, "__acl_aclcheck_fd", {"int filedes", "acl_type_t type", "struct acl* aclp"}, "int"},
    {355, "extattrctl", {"const char* path", "int cmd", "const char* filename", "int attrnamespace", "const char* attrname"}, "int"},
    {356, "extattr_set_file", {"const char* path", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {357, "extattr_get_file", {"const char* path", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {358, "extattr_delete_file", {"const char* path", "int attrnamespace", "const char* attrname"}, "int"},
    {359, "aio_waitcomplete", {"struct aiocb ** aiocbp", "struct timespec* timeout"}, "int"},
    {360, "getresuid", {"uid_t* ruid", "uid_t* euid", "uid_t* suid"}, "int"},
    {361, "getresgid", {"gid_t* rgid", "gid_t* egid", "gid_t* sgid"}, "int"},
    {362, "kqueue", {NULL}, "int"},
    {363, "kevent", {"int fd", "struct kevent* changelist", "int nchanges", "struct kevent* eventlist", "int nevents", "const struct timespec* timeout"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {371, "extattr_set_fd", {"int fd", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {372, "extattr_get_fd", {"int fd", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {373, "extattr_delete_fd", {"int fd", "int attrnamespace", "const char* attrname"}, "int"},
    {374, "__setugid", {"int flag"}, "int"},
    {375, "nfsclnt", {"int flag", "caddr_t argp"}, "int"},
    {376, "eaccess", {"char* path", "int flags"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {378, "nmount", {"struct iovec* iovp", "unsigned int iovcnt", "int flags"}, "int"},
    {379, "kse_exit", {NULL}, "int"},
    {380, "kse_wakeup", {"struct kse_mailbox* mbx"}, "int"},
    {381, "kse_create", {"struct kse_mailbox* mbx", "int newgroup"}, "int"},
    {382, "kse_thr_interrupt", {"struct kse_thr_mailbox* tmbx", "int cmd", "long data"}, "int"},
    {383, "kse_release", {"struct timespec* timeout"}, "int"},
    {384, "__mac_get_proc", {"struct mac* mac_p"}, "int"},
    {385, "__mac_set_proc", {"struct mac* mac_p"}, "int"},
    {386, "__mac_get_fd", {"int fd", "struct mac* mac_p"}, "int"},
    {387, "__mac_get_file", {"const char* path_p", "struct mac* mac_p"}, "int"},
    {388, "__mac_set_fd", {"int fd", "struct mac* mac_p"}, "int"},
    {389, "__mac_set_file", {"const char* path_p", "struct mac* mac_p"}, "int"},
    {390, "kenv", {"int what", "const char* name", "char* value", "int len"}, "int"},
    {391, "lchflags", {"const char* path", "int flags"}, "int"},
    {392, "uuidgen", {"struct uuid* store", "int count"}, "int"},
    {393, "sendfile", {"int fd", "int s", "off_t offset", "size_t nbytes", "struct sf_hdtr* hdtr", "off_t* sbytes", "int flags"}, "int"},
    {394, "mac_syscall", {"const char* policy", "int call", "void* arg"}, "int"},
    {395, "getfsstat", {"struct statfs* buf", "long bufsize", "int flags"}, "int"},
    {396, "statfs", {"char* path", "struct statfs* buf"}, "int"},
    {397, "fstatfs", {"int fd", "struct statfs* buf"}, "int"},
    {398, "fhstatfs", {"const struct fhandle* u_fhp", "struct statfs* buf"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {400, "ksem_close", {"semid_t id"}, "int"},
    {401, "ksem_post", {"semid_t id"}, "int"},
    {402, "ksem_wait", {"semid_t id"}, "int"},
    {403, "ksem_trywait", {"semid_t id"}, "int"},
    {404, "ksem_init", {"semid_t* idp", "unsigned int value"}, "int"},
    {405, "ksem_open", {"semid_t* idp", "const char* name", "int oflag", "mode_t mode", "unsigned int value"}, "int"},
    {406, "ksem_unlink", {"const char* name"}, "int"},
    {407, "ksem_getvalue", {"semid_t id", "int* val"}, "int"},
    {408, "ksem_destroy", {"semid_t id"}, "int"},
    {409, "__mac_get_pid", {"pid_t pid", "struct mac* mac_p"}, "int"},
    {410, "__mac_get_link", {"const char* path_p", "struct mac* mac_p"}, "int"},
    {411, "__mac_set_link", {"const char* path_p", "struct mac* mac_p"}, "int"},
    {412, "extattr_set_link", {"const char* path", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {413, "extattr_get_link", {"const char* path", "int attrnamespace", "const char* attrname", "void* data", "size_t nbytes"}, "int"},
    {414, "extattr_delete_link", {"const char* path", "int attrnamespace", "const char* attrname"}, "int"},
    {415, "__mac_execve", {"char* fname", "char ** argv", "char ** envv", "struct mac* mac_p"}, "int"},
    {416, "sigaction", {"int sig", "const struct sigaction* act", "struct sigaction* oact"}, "int"},
    {417, "sigreturn", {"const struct __ucontext* sigcntxp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {421, "getcontext", {"struct __ucontext* ucp"}, "int"},
    {422, "setcontext", {"const struct __ucontext* ucp"}, "int"},
    {423, "swapcontext", {"struct __ucontext* oucp", "const struct __ucontext* ucp"}, "int"},
    {424, "swapoff", {"const char* name"}, "int"},
    {425, "__acl_get_link", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {426, "__acl_set_link", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {427, "__acl_delete_link", {"const char* path", "acl_type_t type"}, "int"},
    {428, "__acl_aclcheck_link", {"const char* path", "acl_type_t type", "struct acl* aclp"}, "int"},
    {429, "sigwait", {"const sigset_t* set", "int* sig"}, "int"},
    {430, "thr_create", {"ucontext_t* ctx", "long* id", "int flags"}, "int"},
    {431, "thr_exit", {"long* state"}, "int"},
    {432, "thr_self", {"long* id"}, "int"},
    {433, "thr_kill", {"long id", "int sig"}, "int"},
    {434, "_umtx_lock", {"struct umtx* umtx"}, "int"},
    {435, "_umtx_unlock", {"struct umtx* umtx"}, "int"},
    {436, "jail_attach", {"int jid"}, "int"},
    {437, "extattr_list_fd", {"int fd", "int attrnamespace", "void* data", "size_t nbytes"}, "int"},
    {438, "extattr_list_file", {"const char* path", "int attrnamespace", "void* data", "size_t nbytes"}, "int"},
    {439, "extattr_list_link", {"const char* path", "int attrnamespace", "void* data", "size_t nbytes"}, "int"},
    {440, "kse_switchin", {"struct kse_thr_mailbox* tmbx", "int flags"}, "int"},
    {441, "ksem_timedwait", {"semid_t id", "const struct timespec* abstime"}, "int"},
    {442, "thr_suspend", {"const struct timespec* timeout"}, "int"},
    {443, "thr_wake", {"long id"}, "int"},
    {444, "kldunloadf", {"int fileid", "int flags"}, "int"},
    {445, "audit", {"const void* record", "u_int length"}, "int"},
    {446, "auditon", {"int cmd", "void* data", "u_int length"}, "int"},
    {447, "getauid", {"uid_t* auid"}, "int"},
    {448, "setauid", {"uid_t* auid"}, "int"},
    {449, "getaudit", {"struct auditinfo* auditinfo"}, "int"},
    {450, "setaudit", {"struct auditinfo* auditinfo"}, "int"},
    {451, "getaudit_addr", {"struct auditinfo_addr* auditinfo_addr", "u_int length"}, "int"},
    {452, "setaudit_addr", {"struct auditinfo_addr* auditinfo_addr", "u_int length"}, "int"},
    {453, "auditctl", {"char* path"}, "int"},
    {454, "_umtx_op", {"void* obj", "int op", "u_long val", "void* uaddr1", "void* uaddr2"}, "int"},
    {455, "thr_new", {"struct thr_param* param", "int param_size"}, "int"},
    {456, "sigqueue", {"pid_t pid", "int signum", "void* value"}, "int"},
    {457, "kmq_open", {"const char* path", "int flags", "mode_t mode", "const struct mq_attr* attr"}, "int"},
    {458, "kmq_setattr", {"int mqd", "const struct mq_attr* attr", "struct mq_attr* oattr"}, "int"},
    {459, "kmq_timedreceive", {"int mqd", "char* msg_ptr", "size_t msg_len", "unsigned* msg_prio", "const struct timespec* abs_timeout"}, "int"},
    {460, "kmq_timedsend", {"int mqd", "const char* msg_ptr", "size_t msg_len", "unsigned msg_prio", "const struct timespec* abs_timeout"}, "int"},
    {461, "kmq_notify", {"int mqd", "const struct sigevent* sigev"}, "int"},
    {462, "kmq_unlink", {"const char* path"}, "int"},
    {463, "abort2", {"const char* why", "int nargs", "void ** args"}, "int"},
    {464, "thr_set_name", {"long id", "const char* name"}, "int"},
    {465, "aio_fsync", {"int op", "struct aiocb* aiocbp"}, "int"},
    {466, "rtprio_thread", {"int function", "lwpid_t lwpid", "struct rtprio* rtp"}, "int"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {NULL, "NULL", {NULL}, "NULL"},
    {471, "sctp_peeloff", {"int sd", "uint32_t name"}, "int"},
    {472, "sctp_generic_sendmsg", {"int sd", "caddr_t msg", "int mlen", "caddr_t to", "__socklen_t tolen", "struct sctp_sndrcvinfo* sinfo", "int flags"}, "int"},
    {473, "sctp_generic_sendmsg_iov", {"int sd", "struct iovec* iov", "int iovlen", "caddr_t to", "__socklen_t tolen", "struct sctp_sndrcvinfo* sinfo", "int flags"}, "int"},
    {474, "sctp_generic_recvmsg", {"int sd", "struct iovec* iov", "int iovlen", "struct sockaddr* from", "__socklen_t* fromlenaddr", "struct sctp_sndrcvinfo* sinfo", "int* msg_flags"}, "int"},
    {475, "pread", {"int fd", "void* buf", "size_t nbyte", "off_t offset"}, "int"},
    {476, "pwrite", {"int fd", "const void* buf", "size_t nbyte", "off_t offset"}, "int"},
    {477, "mmap", {"caddr_t addr", "size_t len", "int prot", "int flags", "int fd", "off_t pos"}, "int"},
    {478, "lseek", {"int fd", "off_t offset", "int whence"}, "int"},
    {479, "truncate", {"char* path", "off_t length"}, "int"},
    {480, "ftruncate", {"int fd", "off_t length"}, "int"},
    {481, "thr_kill2", {"pid_t pid", "long id", "int sig"}, "int"},
    {482, "MAXSYSCALL", {"int anom"}, "int"}
  };
