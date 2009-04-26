<?php
class 					XMLNode
{
	protected 			$root;
	
	public function 	__construct($tagname)
	{
		$this->root = new SimpleXMLElement($tagname);
	}
	
	public function 	toXML()
	{
		if (!$this->root)
			return false;
		return $this->root->asXML();
	}
}
?>