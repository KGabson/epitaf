<?php
class						TextBlock extends Tag
{
	public function			__construct($tagname, $content, $classname = "")
	{
		parent::__construct($tagname, $classname);
		$this->append($content);
	}
}
?>