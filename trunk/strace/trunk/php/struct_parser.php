#!/usr/local/bin/php
<?php

$what = "(struct|union)";

define("SIGNAL_H", "/usr/include/sys/signal.h");
define("MAX_OFFSET", 1000);

define("DCLRT_PATTERN", "^$what ([a-zA-Z_]+) {");
define("IMP_TYPEDEF_PATTERN", "$what {");

get_all_structures();

function	get_all_structures()
{
  global $what;
  $file = file_get_contents(SIGNAL_H);
  $tab_lines = split("\n", $file);
  $structs = parse_definition($tab_lines);
  //  var_dump($structs);
}

function	parse_definition($tab_lines)
{
  global $what;
  for ($i = 0; $i < count($tab_lines); $i++)
    {
      if (ereg(DCLRT_PATTERN, $tab_lines[$i], $match))
	{
	  print "struct name = ".$match[2]."\n";
	  $tmp = get_definition($tab_lines, $match[2], $i);
	  foreach ($tmp as $k => $v)
	    {
	      $structs[$k] = $v;
	    }
	}
    }
  return $structs;
}

function	get_definition($tab_lines, $struct_name, $offset_s, $offset_e = MAX_OFFSET)
{
  global $what;
  for ($i = $offset_s + 1; !ereg("^};", $tab_lines[$i]) && $i < $offset_e; $i++)
    {
      if (ereg("([a-zA-Z_]+)[ \t]+([\(\)*a-zA-Z_ ,0-9]+;)", trim($tab_lines[$i]), $found))
	{
	  //	  echo "found proto struct : ".$struct_name."\t".$found[1]." ".$found[2]."\n";
	  $struct[$struct_name][] = $found[1]." ".$found[2];
	}
      else if (ereg(IMP_TYPEDEF_PATTERN, trim($tab_lines[$i])))
	{
	  for ($j = $i + 1; !ereg("[ \t]+} +([a-zA-Z_]+);", $tab_lines[$j], $typedef_name); $j++);
	  $tmp = get_definition($tab_lines, $typedef_name[1], $i + 1, $j);
	  echo "in struct : " . $typedef_name[1] ."\n";
	  $struct_name[$typedef_name[1]] = $tmp[$typedef_name[1]];
	}
    }
  return $struct;
}
?>
