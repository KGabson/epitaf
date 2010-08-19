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
	protected 					$form_errors = array();
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
		$field->setLegend($input->getLegend());
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
		$this->append(new Tag('div', 'clear'));
	}
	
	public function 			addError($msg)
	{
		$this->form_errors[] = $msg;
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
		$files_to_upload = array();
		
		foreach ($this->elements as $name => $field)
		{
			if ($field->getInput()->getAttribute("disabled") == "disabled")
				continue;
			$error = "";
			if (!$field->getInput()->isFile() && isset($_POST[$name]) && ($field->getInput()->check(trim($_POST[$name]), $error) === false))
			{
				$field->setError($error);
				$this->num_errors++;
				continue;
			}
			else if ($field->getInput()->isFile() && isset($_FILES[$name]))
			{
				if ($field->getInput()->check($_FILES[$name], $error) === false)
				{
					$field->setError($error);
					$this->num_errors++;
					continue;
				}
				else
				{
					$final = $field->getInput()->getUploadDir()."/".$field->getInput()->getValue();
					while (!empty($_FILES[$name]['name']) && file_exists($final))
					{
						$filename = basename($final);
						$path = dirname($final);
						$aFilename = explode('.', $filename);
						$ext = (array_key_exists(1, $aFilename)) ? ".".$aFilename[count($aFilename) - 1] : "";
						$filename = basename($final, $ext);
						$final = $path."/".$filename."-".$ext;
						$field->getInput()->setValue($filename."-".$ext);
					}
					$files_to_upload[$field->getInput()->getTmpName()] = $final;
				}
			}
		}
		if ($this->num_errors == 0)
		{
			foreach ($files_to_upload as $tmp_name => $final)
			{
				move_uploaded_file($tmp_name, $final);
			}
			return true;
		}
		return false;
	}
	
	public function 			toHTML($indent = 0, $html_entities = true)
	{
		$this->append(new FormSubmit($this->name, "Submit"));
		if (!empty($this->form_errors))
		{
			$errorTag = new Tag("div", "error");
			foreach ($this->form_errors as $msg)
				$errorTag->append(new TagBlock("p", $msg));
			$this->insert($errorTag);
		}
		return parent::toHTML($indent, $html_entities);
	}
}
?>