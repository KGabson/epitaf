<?php
class						Dir
{
	public static function 	Make($path, $mode = null, $recursive = null)
	{
		if (mkdir($path, $mode, $recursive) === false)
			throw new ErrorException("Could not create directory [".$path."]");
	}
}
?>