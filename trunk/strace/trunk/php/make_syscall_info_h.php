#!/usr/local/bin/php
<?php
require_once("parser.php");

make();

function	make()
{
  $args = parse_syscall_args(SYSPROTO_H);
  $tab_name = getSyscallNames();
  $info = merge_name_args($args, $tab_name);
  $size = get_size($info);
  $begin = get_static_begin($size["size_tab"] + 1, $size["max_size_proto"] + 1);
  $str_tab = get_ctab_syscall($info, $size["size_tab"]);
  $tt = $begin."".$str_tab."  };\n";
  file_put_contents("./syscall_info.h", $tt);

}

function	get_ctab_syscall($info, $size_tab)
{
  $nb = 0;
  foreach ($info as $k => $v)
    {
      if ($nb != $k)
	{
	  while ($nb < $k)
	    {
	      $nb++;
	      $line .= format_line("NULL", "NULL", "NULL", "NULL");
	    }
	}
      if ($nb < $size_tab)
	$line .= format_line(count($v["proto"]), $v["name"], $v["proto"], $v["return"]);
      else
	{
	  $line .= format_line(count($v["proto"]), $v["name"], $v["proto"], $v["return"], true);
	}
      $nb++;
    }
  return $line;
}

function	format_line($v1, $v2, $v3, $v4, $last_line = false)
{
  $proto = get_tab_arg($v3);
  $name = ($v2 == "NULL") ? $v2 : "\"$v2\"";
  $ret = ($v4 == "NULL") ? $v4 : "\"$v4\"";
  if ($last_line == false)
    $str = "    {".$v1.", ".$name.", ".$proto['tab_type'].", ".$proto['tab_name'].", ".$ret."},\n";
  else
    $str = "    {".$v1.", ".$name.", ".$proto['tab_type'].", ".$proto['tab_name'].", ".$ret."}\n";
  return $str;
}

function	get_tab_arg($proto)
{
  $tab_type .= "{";
  $tab_name .= "{";
  if (is_array($proto))
    foreach ($proto as $k => $v)
      {
	$tab_type .= ($k != count($proto) - 1) ? "\"".$v['argtype']."\", " : "\"".$v['argtype']."\"";
	$tab_name .= ($k != count($proto) - 1) ? "\"".$v['argname']."\", " : "\"".$v['argtype']."\"";
      }
  else
    {
      $tab_type = "{\"\"";
      $tab_name = "{\"\"";
    }
  $tab_type .= "}";
  $tab_name .= "}";
  $tab['tab_type'] = $tab_type;
  $tab['tab_name'] = $tab_name;
  return $tab;
}

function	get_static_begin($size_tab, $max_proto)
{
  $str = "
typedef struct s_sysinfo
{
  int   nbargs;
  char  *sysname;
  char  argtype[$max_proto][128];
  char	argname[$max_proto][128];
  char  *return_type;
}t_sysinfo;

t_sysinfo       SYSINFO[$size_tab] =
  {
";
  return $str;
}

function	get_size($info)
{
  $max = 0;
  foreach ($info as $k => $v)
    {
      if ($max < count($v["proto"]))
	$max = count($v["proto"]);
    }
  $tab["size_tab"] = $k;
  $tab["max_size_proto"] = $max;
  return $tab;
}

?>