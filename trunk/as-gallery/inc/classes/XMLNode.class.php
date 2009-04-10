<?php
class 					XMLNode
{
	protected 			$root;
	
	public function 	toXML()
	{
		if (!$this->root)
			return false;
		return $this->root->asXML();
	}
}
?>