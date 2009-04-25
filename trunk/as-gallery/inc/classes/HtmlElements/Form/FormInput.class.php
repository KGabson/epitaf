<?php
class 						FormInput extends Tag
{
	protected 				$name;
	protected 				$mandatory;
	protected 				$value;
	protected 				$type;
	protected 				$form_type;
	
	public function 		__construct($type, $name, $mandatory = false, $tagname = "input", $classname = "", $inline = true)
	{
		parent::__construct($tagname, $classname, $inline);
		$this->type = $type;
		$this->name = $name;
		$this->mandatory = $mandatory;
		$this->form_type = FormTypes::STRING;
		$this->setAttribute("type", $this->type);
	}
	
	public function 		setFormType($form_type)
	{
		$this->form_type = $form_type;
	}
	
	public function 		getFormType()
	{
		return $this->getFormType();
	}
	
	public function 		setValue($value)
	{
		$this->value = $value;
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
	
	public function			check(&$value, &$error)
	{
		if (FormTypes::check($this->form_type, $value, $error) === false)
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
				$this->append($this->value);
		}
		return parent::toHTML($indent);
	}
}
?>