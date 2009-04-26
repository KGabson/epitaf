<?php
require_once("config.php");

function __autoload($className)
{
	findClass_r(__ROOT, $className);
}

function findClass_r($dir, $className)
{
	$ret = false;
	if (!is_dir($dir))
		return false;
	$fd = opendir($dir);
	if (!$fd)
		return false;
	while (($file = readdir($fd)) !== false)
	{
		if ($file[0] == '.')
			continue;
		if (is_dir($dir."/".$file))
		{
			if (findClass_r($dir."/".$file, $className))
			{
				$ret = true;
				break;
			}
		}
		else if ($file == $className.".class.php")
		{
			//echo "Including => ".$dir."/".$className.".class.php"."<br />";
			require_once($dir."/".$className.".class.php");
			$ret = true;
			break;
		}
	}
	closedir($fd);
	return $ret;
}
?>