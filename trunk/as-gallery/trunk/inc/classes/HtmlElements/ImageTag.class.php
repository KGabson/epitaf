<?php
class 					ImageTag extends Tag
{
	public function 	__construct($path, $name = "", $title = "", $classname = "")
	{
		parent::__construct("img", $classname, true);
		$this->setAttribute("src", $path);
		$this->setAttribute("name", $name);
		$this->setAttribute("title", $title);
	}
}
?>