<?php
class 					XMLRoot extends Tag
{
	private				$xml_head = '<?xml version="1.0" encoding="UTF-8"?>';
	
	public function 	__construct($name)
	{
		parent::__construct($name);
	}
	
	public function 	toXML()
	{
		$str = $this->xml_head."\n";
		
		$str .= $this->toHTML(0, true);
		return $str;
	}
}
?>