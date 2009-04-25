<?php
class 						FormSubmit extends FormInput 
{
	private 				$value;
	private 				$name;
	
	public function			__construct($name, $value)
	{
		$this->value = $value;
		$this->name = $name;
		parent::__construct("submit");
		$this->setValue($value);
	}
}
?>