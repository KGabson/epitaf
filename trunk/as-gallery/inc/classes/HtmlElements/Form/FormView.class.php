<?php
class 							FormView extends Tag
{
	private 					$elements = array();
	private 					$name;
	private 					$action;
	private 					$method;
	private 					$submit;
	private 					$has_files = false;
	
	public function 			__construct($action = "", $method = "post")
	{
		$this->action = $action;
		$this->method = $method;
		parent::__construct("form");
		$this->setAttribute("action", $this->action);
		$this->setAttribute("method", $this->method);
		
	}
	
	public function 			addFormField($title, FormInput &$input)
	{
		if (!$this->has_files && $input->getFormType() == FormTypes::FILE)
		{
			$this->setAttribute("enctype", "multipart/form-data");
			$this->has_files = true;
		}
		$this->elements[$input->getName()] = new FormField($title, $input);
		$this->append($this->elements[$input->getName()]);
	}
	
	public function 			check()
	{
		
	}
}
?>