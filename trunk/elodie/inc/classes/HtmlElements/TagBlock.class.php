<?php
class					TagBlock extends Tag
{
	public function		__construct($tagname, $content, $classname = "")
	{
		parent::__construct($tagname, $classname);
		$this->append($content);
	}
}
?>