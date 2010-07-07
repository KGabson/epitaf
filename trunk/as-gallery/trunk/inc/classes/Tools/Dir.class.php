<?php
class						Dir
{
	public static function 	Make($path, $mode = null, $recursive = null)
	{
		if (mkdir($path, $mode, $recursive) === false)
			throw new ErrorException("Could not create directory [".$path."]");
	}
	
	public static function 	Remove($dir, $recursive = false)
	{
		if (!is_dir($dir))
			return;
		if (!$recursive)
		{
			rmdir($dir);
		}
		else
		{
     		$objects = scandir($dir);
     		foreach ($objects as $object)
     		{
       			if ($object != "." && $object != "..")
       			{
         			if (filetype($dir."/".$object) == "dir")
         			{
         				Dir::Remove($dir."/".$object, true);
         			} 
         			else
         			{
         				unlink($dir."/".$object);
         			}
       			}
     		}
     		reset($objects);
     		rmdir($dir);
   		}
 	} 
}
?>