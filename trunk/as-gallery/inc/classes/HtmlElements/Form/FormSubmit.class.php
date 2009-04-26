<?php
class 						FormSubmit extends FormInput 
{
	protected  				$value;
	protected  				$name;
	
	public function			__construct($name, $value)
	{
		$this->value = $value;
		$this->name = $name;
		parent::__construct("submit", $name);
		$this->setValue($value);
	}
}
?>