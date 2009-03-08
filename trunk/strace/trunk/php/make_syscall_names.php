#!/usr/local/bin/php
<?php
define("SYSCALLS_H", "/usr/include/sys/syscall.h");


function getSyscallNames()
{
  if (!file_exists(SYSCALLS_H))
    dieError(SYSCALLS_H.": No such file.");


  $strfile = file_get_contents(SYSCALLS_H);
  $aFile = split("\n", $strfile);
  $aSyscallNames = array();
  foreach ($aFile as $line)
    {
      if (ereg("#define[[:space:]]*SYS_", $line))
	{
	  $newline = ereg_replace("^#define[[:space:]]*SYS_([[:alnum:]_\-]*)[[:space:]]*([0-9]*)$", "\\1:\\2", $line);
	  if (empty($newline))
	    dieError("Regexp error while retrieving syscall name: line = [$line]");
	  $aLine = split(":", $newline);
	  if (count($aLine) != 2)
	    dieError("Error while spliting [$newline]");
	  $aSyscallNames[$aLine[1]] = $aLine[0];
	}
    }

  return $aSyscallNames;
}

function dieError($msg)
{
  die("ERROR: $msg\n");
}

//var_dump(getSyscallNames());
$syscalls = getSyscallNames();
$filname = "syscall_names.h";

if (($max_syscalls = array_search("MAXSYSCALL", $syscalls)) < 0)
    dieError("No such index: MAXSYSCALL");

$strfile = "
#ifndef __SYSCALL_NAMES__
# define __SYSCALL_NAMES__
# include <sys/syscall.h>

char *SYSCALL_NAMES[SYS_MAXSYSCALL + 1] = {
";

echo "We have $max_syscalls MAXSYSCALL.\n";
for ($i = 0; $i < $max_syscalls; $i++)
  {
    if (isset($syscalls[$i]))
      {
	$strfile .= "\t\"".$syscalls[$i]."\",\n";
      }
    else
      {
	$strfile .= "\t0,\n";
      }
  }
$strfile .= "\t0
};

#endif
";

if (!file_put_contents($filname, $strfile))
  dieError("file_put_contents error");
//echo "Here is your array :\n".$strfile;
?>