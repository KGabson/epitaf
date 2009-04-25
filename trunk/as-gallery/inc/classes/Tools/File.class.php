<?php
class						File
{
	public static function 	Basename($filepath, $remove_extension = false)
	{
		$last_dot = strrpos($filepath, '.');
		$ext = substr($filepath, $last_dot, strlen($filepath));
		$filepath = basename($filepath, ($remove_extension) ? $ext : null);
		return $filepath;
	}
}
?>