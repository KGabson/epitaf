#!/usr/local/bin/php
<?php

require_once("make_syscall_names.php");

define("SYSPROTO_H", "/usr/include/sys/sysproto.h");


//$args = parse_syscall_args(SYSPROTO_H);
//$tab_name = getSyscallNames();
//$tab = merge_name_args($args, $tab_name);


function	parse_syscall_args($path)
{
  $file = file_get_contents($path);
  $tab = split("};", $file);
  foreach ($tab as $k => $v)
    {
      $tab_args[] = get_args($v);
      $tab_ret[] = get_ret_value($v);
    }
  $args = merge_args_ret($tab_args, $tab_ret, $tab_name);
  return ($args);
}

function	merge_args_ret($tab_args, $tab_ret)
{
  foreach ($tab_args as $k => $v)
    {
      $args[$v["name"]]["proto"] = $v["proto"];
    }
  foreach ($tab_ret as $k => $v)
    {
      if (is_array($v))
	foreach ($v as $k => $v2)
	  if ($v2["name"])
	    $args[$v2["name"]]["return"] = $v2["return"];
    }
  return $args;
}

function	merge_name_args($args, $tab_name)
{
  foreach ($tab_name as $k => $v)
    {
      foreach ($args as $k2 => $v2)
	{
	  if ($v == $k2)
	    {
	      $tab[$k]["name"] = $k2;
	      $tab[$k]["proto"] = $v2["proto"];
	      $tab[$k]["return"] = $v2["return"];
	      $found = true;
	      break;
	    }
	  else
	    $found = false;
	}
      if ($found == false)
	{
	  $tab[$k]["name"] = $v;
	  if ($v == "exit")
	    {
	      $tab[$k]["proto"] = $args["sys_exit"]["proto"];
	      $tab[$k]["return"] = $args["sys_exit"]["return"];
	    }
	  else if ($v == "break")
	    {
	      $tab[$k]["proto"] = $args["obreak"]["proto"];
	      $tab[$k]["return"] = $args["obreak"]["return"];
	    }
	  else if ($v = "vadvise")
	    {
	      $tab[$k]["proto"] = $args["ovadvise"]["proto"];
	      $tab[$k]["return"] = $args["ovadvise"]["return"];
	    }
	  else
	    $tab[$k]["return"] = "NULL";
	}
    }
  return $tab;
}

function	get_args($piece_file)
{
  if (ereg("struct +([a-zA-Z0-9_]+)_args \{(.*)", $piece_file, $match))
    {
      $syscall_name = $match[1];
      $tab_proto = split("\n", $match[2]);
      foreach ($tab_proto as $k => $v)
	{
	  $tab_args = split(';', $v);
	  if (!empty($tab_args[1]) && ereg("([a-zA-Z_\* ]+) +(.*)", $tab_args[1], $prot))
	    {
	      $final_args["argtype"] = trim($prot[1]);
	      $final_args["argname"] = trim($prot[2]);
	      $proto[] = $final_args;
	    }
	}
      $args["proto"] = $proto;
      $args["name"] = $syscall_name;
    }
  return $args;
}

function	get_ret_value($piece_file)
{
  $t_line = split("\n", $piece_file);
  foreach ($t_line as $k => $v)
    {
      if (ereg("^([a-zA-Z]*)[\t\ ]*([a-zA-Z0-9_]+).*\);", $v, $match))
	{
	  $t_ret["name"] = $match[2];
	  $t_ret["return"] = $match[1];
	  $tab[] = $t_ret;
	}
    }
  return $tab;
}

?>