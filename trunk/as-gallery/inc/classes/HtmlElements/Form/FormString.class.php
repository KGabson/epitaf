<?php
class 							FormString extends FormInput 
{
	public function 			__construct($name, $mandatory = false, $value = null)
	{
		parent::__construct("text", $name, $mandatory);
	}
}
?>