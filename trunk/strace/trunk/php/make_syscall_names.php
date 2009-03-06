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


?>