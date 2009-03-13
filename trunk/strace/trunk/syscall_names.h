
#ifndef __SYSCALL_NAMES__
# define __SYSCALL_NAMES__
# include <sys/syscall.h>

char *SYSCALL_NAMES[SYS_MAXSYSCALL + 1] = {
	"syscall",
	"exit",
	"fork",
	"read",
	"write",
	"open",
	"close",
	"wait4",
	0,
	"link",
	"unlink",
	0,
	"chdir",
	"fchdir",
	"mknod",
	"chmod",
	"chown",
	"break",
	"freebsd4_getfsstat",
	0,
	"getpid",
	"mount",
	"unmount",
	"setuid",
	"getuid",
	"geteuid",
	"ptrace",
	"recvmsg",
	"sendmsg",
	"recvfrom",
	"accept",
	"getpeername",
	"getsockname",
	"access",
	"chflags",
	"fchflags",
	"sync",
	"kill",
	0,
	"getppid",
	0,
	"dup",
	"pipe",
	"getegid",
	"profil",
	"ktrace",
	0,
	"getgid",
	0,
	"getlogin",
	"setlogin",
	"acct",
	0,
	"sigaltstack",
	"ioctl",
	"reboot",
	"revoke",
	"symlink",
	"readlink",
	"execve",
	"umask",
	"chroot",
	0,
	0,
	0,
	"msync",
	"vfork",
	0,
	0,
	"sbrk",
	"sstk",
	0,
	"vadvise",
	"munmap",
	"mprotect",
	"madvise",
	0,
	0,
	"mincore",
	"getgroups",
	"setgroups",
	"getpgrp",
	"setpgid",
	"setitimer",
	0,
	"swapon",
	"getitimer",
	0,
	0,
	"getdtablesize",
	"dup2",
	0,
	"fcntl",
	"select",
	0,
	"fsync",
	"setpriority",
	"socket",
	"connect",
	0,
	"getpriority",
	0,
	0,
	0,
	"bind",
	"setsockopt",
	"listen",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"gettimeofday",
	"getrusage",
	"getsockopt",
	0,
	"readv",
	"writev",
	"settimeofday",
	"fchown",
	"fchmod",
	0,
	"setreuid",
	"setregid",
	"rename",
	0,
	0,
	"flock",
	"mkfifo",
	"sendto",
	"shutdown",
	"socketpair",
	"mkdir",
	"rmdir",
	"utimes",
	0,
	"adjtime",
	0,
	0,
	0,
	0,
	0,
	0,
	"setsid",
	"quotactl",
	0,
	0,
	0,
	0,
	0,
	0,
	"nfssvc",
	0,
	"freebsd4_statfs",
	"freebsd4_fstatfs",
	0,
	"lgetfh",
	"getfh",
	"getdomainname",
	"setdomainname",
	"uname",
	"sysarch",
	"rtprio",
	0,
	0,
	"semsys",
	"msgsys",
	"shmsys",
	0,
	"freebsd6_pread",
	"freebsd6_pwrite",
	0,
	"ntp_adjtime",
	0,
	0,
	0,
	0,
	"setgid",
	"setegid",
	"seteuid",
	0,
	0,
	0,
	0,
	"stat",
	"fstat",
	"lstat",
	"pathconf",
	"fpathconf",
	0,
	"getrlimit",
	"setrlimit",
	"getdirentries",
	"freebsd6_mmap",
	"__syscall",
	"freebsd6_lseek",
	"freebsd6_truncate",
	"freebsd6_ftruncate",
	"__sysctl",
	"mlock",
	"munlock",
	"undelete",
	"futimes",
	"getpgid",
	0,
	"poll",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"__semctl",
	"semget",
	"semop",
	0,
	"msgctl",
	"msgget",
	"msgsnd",
	"msgrcv",
	"shmat",
	"shmctl",
	"shmdt",
	"shmget",
	"clock_gettime",
	"clock_settime",
	"clock_getres",
	"ktimer_create",
	"ktimer_delete",
	"ktimer_settime",
	"ktimer_gettime",
	"ktimer_getoverrun",
	"nanosleep",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"ntp_gettime",
	0,
	"minherit",
	"rfork",
	"openbsd_poll",
	"issetugid",
	"lchown",
	"aio_read",
	"aio_write",
	"lio_listio",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"getdents",
	0,
	"lchmod",
	"netbsd_lchown",
	"lutimes",
	"netbsd_msync",
	"nstat",
	"nfstat",
	"nlstat",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"preadv",
	"pwritev",
	0,
	0,
	0,
	0,
	0,
	0,
	"freebsd4_fhstatfs",
	"fhopen",
	"fhstat",
	"modnext",
	"modstat",
	"modfnext",
	"modfind",
	"kldload",
	"kldunload",
	"kldfind",
	"kldnext",
	"kldstat",
	"kldfirstmod",
	"getsid",
	"setresuid",
	"setresgid",
	0,
	"aio_return",
	"aio_suspend",
	"aio_cancel",
	"aio_error",
	"oaio_read",
	"oaio_write",
	"olio_listio",
	"yield",
	0,
	0,
	"mlockall",
	"munlockall",
	"__getcwd",
	"sched_setparam",
	"sched_getparam",
	"sched_setscheduler",
	"sched_getscheduler",
	"sched_yield",
	"sched_get_priority_max",
	"sched_get_priority_min",
	"sched_rr_get_interval",
	"utrace",
	"freebsd4_sendfile",
	"kldsym",
	"jail",
	0,
	"sigprocmask",
	"sigsuspend",
	"freebsd4_sigaction",
	"sigpending",
	"freebsd4_sigreturn",
	"sigtimedwait",
	"sigwaitinfo",
	"__acl_get_file",
	"__acl_set_file",
	"__acl_get_fd",
	"__acl_set_fd",
	"__acl_delete_file",
	"__acl_delete_fd",
	"__acl_aclcheck_file",
	"__acl_aclcheck_fd",
	"extattrctl",
	"extattr_set_file",
	"extattr_get_file",
	"extattr_delete_file",
	"aio_waitcomplete",
	"getresuid",
	"getresgid",
	"kqueue",
	"kevent",
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	"extattr_set_fd",
	"extattr_get_fd",
	"extattr_delete_fd",
	"__setugid",
	"nfsclnt",
	"eaccess",
	0,
	"nmount",
	"kse_exit",
	"kse_wakeup",
	"kse_create",
	"kse_thr_interrupt",
	"kse_release",
	"__mac_get_proc",
	"__mac_set_proc",
	"__mac_get_fd",
	"__mac_get_file",
	"__mac_set_fd",
	"__mac_set_file",
	"kenv",
	"lchflags",
	"uuidgen",
	"sendfile",
	"mac_syscall",
	"getfsstat",
	"statfs",
	"fstatfs",
	"fhstatfs",
	0,
	"ksem_close",
	"ksem_post",
	"ksem_wait",
	"ksem_trywait",
	"ksem_init",
	"ksem_open",
	"ksem_unlink",
	"ksem_getvalue",
	"ksem_destroy",
	"__mac_get_pid",
	"__mac_get_link",
	"__mac_set_link",
	"extattr_set_link",
	"extattr_get_link",
	"extattr_delete_link",
	"__mac_execve",
	"sigaction",
	"sigreturn",
	0,
	0,
	0,
	"getcontext",
	"setcontext",
	"swapcontext",
	"swapoff",
	"__acl_get_link",
	"__acl_set_link",
	"__acl_delete_link",
	"__acl_aclcheck_link",
	"sigwait",
	"thr_create",
	"thr_exit",
	"thr_self",
	"thr_kill",
	"_umtx_lock",
	"_umtx_unlock",
	"jail_attach",
	"extattr_list_fd",
	"extattr_list_file",
	"extattr_list_link",
	"kse_switchin",
	"ksem_timedwait",
	"thr_suspend",
	"thr_wake",
	"kldunloadf",
	"audit",
	"auditon",
	"getauid",
	"setauid",
	"getaudit",
	"setaudit",
	"getaudit_addr",
	"setaudit_addr",
	"auditctl",
	"_umtx_op",
	"thr_new",
	"sigqueue",
	"kmq_open",
	"kmq_setattr",
	"kmq_timedreceive",
	"kmq_timedsend",
	"kmq_notify",
	"kmq_unlink",
	"abort2",
	"thr_set_name",
	"aio_fsync",
	"rtprio_thread",
	0,
	0,
	0,
	0,
	"sctp_peeloff",
	"sctp_generic_sendmsg",
	"sctp_generic_sendmsg_iov",
	"sctp_generic_recvmsg",
	"pread",
	"pwrite",
	"mmap",
	"lseek",
	"truncate",
	"ftruncate",
	"thr_kill2",
	0
};

#endif
