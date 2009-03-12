#!/usr/bin/php                                                                                                                                                                                                                                                                        
<?php

parse_definition("struct", "/usr/include/sys/signal.h");
parse_definition("union", "/usr/include/sys/signal.h");

function	parse_definition($what, $file)
{
  $d_file = file_get_contents($file);
  $tab_struct = split("\n", $d_file);
  for ($i = 0; $i < count($tab_struct); $i++)
    {
      $v = $tab_struct[$i];
      if (ereg("^$what ([a-zA-Z_]+) {", $v, $match))
	{
	  //	  $struct[$match[1]][] = $v;
	  for ($j = $i + 1; !ereg("^};", $tab_struct[$j]); $j++)
	    {
	      if (ereg("([a-zA-Z_]+)[ \t]+([\(\)*a-zA-Z_ ,]+;)", trim($tab_struct[$j]), $found))
		$struct[$match[1]][] = $found[1]." ".$found[2];
	    }
	}
    }
  var_dump($struct);
}
?>
