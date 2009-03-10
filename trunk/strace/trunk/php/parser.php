#!/usr/bin/php
<?php

function	parse_syscall_args($path)
{
  $file = file_get_contents($path);
  $tab = split("};", $file); 
  foreach ($tab as $k => $v)
    {
      $tab_args[] = get_args($v);
      $tab_ret[] = get_ret_value($v);
    }
  $args = merge_tab($tab_args, $tab_ret);

  return ($args);
}

function	merge_tab($tab_args, $tab_ret)
{
  //var_dump($tab_args);
  foreach ($tab_args as $k => $v)
    {
      //      var_dump($v);
    }
}

function	get_args($piece_file)
{
  if (ereg("struct     (.*)_args \{(.*)", $piece_file, $match))
    {
      $syscall_name = $match[1];
      var_dump($syscall_name);
      if (strlen($match[1]) > 20)
	var_dump($match);
      $tab_proto = split("\n", $match[2]);
      foreach ($tab_proto as $k => $v)
	{
	  $tab_args = split(';', $v);
	  //	  var_dump($tab_args);
	  if (!empty($tab_args[1]))
	    $proto[] = $tab_args[1];
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
      if (ereg("(.*) *(.*)\(.*\);", $v, $match))
	{
	  $t_ret[$match[2]] = $match[1];
	}
    }
  return $t_ret;
}

parse_syscall_args("/usr/include/sys/sysproto.h");

?>