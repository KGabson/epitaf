<?php
require_once("../inc/config.php");

class						Errors
{
	public static function 	Warning($msg)
	{
		echo "WARNING: ".$msg."<br />";
	}
	
	public static function 	Debug($msg)
	{
		if (defined(__DEBUG) && (__DEBUG == true))
			echo "(DEBUG) >> ".$msg."<br />\n";
	}
	
	public static function 	ShowCode($msg)
	{
		echo "<pre>".htmlentities($msg)."</pre>";
	}
}
?>