<?php
class 						FormCheck extends FormInput 
{
	private 				$checked;
	private 				$label;
	
	public function 		__construct($name, $value, $label = "", $checked = false, $mandatory = false)
	{
		parent::__construct("checkbox", $name, $mandatory);
		$this->setFormType(FormTypes::BOOL);
		$this->value = $value;
		$this->checked = $checked;
		$this->label = $label;

		if (!empty($this->label))
			$this->append(new TagBlock("span", $this->label));
	}
	
	public function 		setChecked($checked)
	{
		$this->checked = ($checked) ? true : false;
	}
	
	public function 		isChecked()
	{
		return $this->checked;
	}
	
	public function 		check(&$value, &$error)
	{
		if (parent::check($value, $error) === false)
			return false;
		$this->checked = true;
		return true;
	}
	
	public function 		toHTML($indent = 0, $html_entities = true)
	{
		if ($this->checked)
			$this->setAttribute("checked", "checked");
		return parent::toHtml($indent, $html_entities);
	}
}
?>