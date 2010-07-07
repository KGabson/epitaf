<?php
class 						FormInput extends Tag
{
	protected 				$name;
	protected				$legend;
	protected 				$mandatory;
	protected 				$value;
	protected 				$type;
	protected 				$form_type;
	protected 				$check_callback;
	
	public function 		__construct($type, $name, $mandatory = false, $tagname = "input", $classname = "", $inline = true)
	{
		parent::__construct($tagname, $classname, $inline);
		$this->type = $type;
		$this->name = $name;
		$this->mandatory = $mandatory;
		//$this->form_type = FormTypes::STRING;
		if (!empty($type))
			$this->setAttribute("type", $this->type);
		$this->setAttribute("name", $name);
	}
	
	public function 		setFormType($form_type)
	{
		$this->form_type = $form_type;
	}
	
	public function 		getFormType()
	{
		return $this->form_type;
	}
	
	public function 		setValue($value)
	{
		$this->value = $value;
	}
	
	public function 		getLegend()
	{
		return $this->legend;
	}
	
	public function			setLegend($legend)
	{
		$this->legend = $legend;
	}
	
	public function 		getValue()
	{
		return $this->value;
	}
	
	public function 		getName()
	{
		return $this->name;
	}
	
	public function			getType()
	{
		return $this->type;
	}
	
	public function 		isFile()
	{
		return ($this->form_type == FormTypes::FILE);
	}
	
	/**
	 * Set a callback function that will be called by check()
	 * Must be prototyped like this :
	 * 		function callback(&$value, &$error);
	 *
	 * @param unknown_type $fct
	 */
	public function 		setCheckCallback($fct)
	{
		$this->check_callback = $fct;
	}
	
	public function			check($value, &$error)
	{
		if ($this->check_callback && $this->check_callback($value, $error) === false)
			return false;
		if ($this->mandatory && empty($value))
		{
			$error = "Mandatory field";
			return false;
		}
		if (!empty($value) && FormTypes::check($this->form_type, $value, $error) === false)
			return false;
		$this->value = $value;
	}
	
	public function 		toHtml($indent = 0)
	{
		if (!empty($this->value))
		{
			if ($this->inline)
				$this->setAttribute("value", $this->value);
			else
			{
				$this->append($this->value);
			}
		}
		return parent::toHTML($indent);
	}
}
?>