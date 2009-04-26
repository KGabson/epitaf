<?php
class 							FormView extends Tag
{	
	protected 					$elements = array();
	protected 					$name;
	protected 					$action;
	protected 					$method;
	protected 					$submit;
	protected 					$has_files = false;
	protected 					$submited = false;
	protected 					$num_errors = 0;
	
	public function 			__construct($name, $action = "", $method = "post")
	{
		$this->name = $name;
		$this->action = $action;
		$this->method = $method;
		parent::__construct("form");
		$this->setAttribute("action", $this->action);
		$this->setAttribute("method", $this->method);
		
	}
	
	public function 			addInput(FormInput &$input, $title = "")
	{
		$field = new FormField($input, $title);
		$this->addFormField($field);
	}
	
	public function 			addFormField(FormField &$field)
	{
		if (!$this->has_files && ($field->getInput()->getFormType() == FormTypes::FILE))
		{
			$this->setAttribute("enctype", "multipart/form-data");
			$this->has_files = true;
		}
		$this->elements[$field->getInput()->getName()] = $field;
		$this->append($this->elements[$field->getInput()->getName()]);
	}
	
	public function 			isSubmitted()
	{
		return $this->submited;
	}
	
	public function 			check()
	{
		if (empty($_POST[$this->name]))
			return false;
		$this->submited = true;
		$this->num_errors = 0;
		foreach ($this->elements as $name => $field)
		{
			$error = "";
			if ($field->getInput()->check($_POST[$name], $error) === false)
			{
				$field->setError($error);
				$this->num_errors++;
				continue;
			}
		}
		if ($this->num_errors == 0)
			return true;
		return false;
	}
}
?>