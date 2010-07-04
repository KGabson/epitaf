<?php
class 						FormBean extends FormView
{
	private 				$bean_object;
	private 				$bean_classname;
	private 				$bean_properties;
	private 				$bean_methods;
	private 				$binded_inputs;
	
	public function 		__construct($name, &$bind_object, $action = "")
	{
		$this->bean_object = $bind_object;
		$this->bean_classname = get_class($this->bean_object);
		$this->bean_properties = get_class_vars($this->bean_classname);
		$this->bean_methods = get_class_methods($this->bean_classname);
		parent::__construct($name, $action);
	}
	
	public function 	 	bindValue(FormInput &$input, $obj_var, $title = "")
	{
		$tmp = strtoupper(substr($obj_var, 0, 1)).substr($obj_var, 1, strlen($obj_var));
		$getter = "get".$tmp;
		$setter = "set".$tmp;
		if (!in_array($getter, $this->bean_methods))
			throw new ErrorException("Missing getter method for property $obj_var ($getter) in class ".$this->bean_classname);
		if (!in_array($setter, $this->bean_methods))
			throw new ErrorException("Missing setter method for property $obj_var ($setter) in class ".$this->bean_classname);
		if (isset($this->binded_inputs[$obj_var]))
			throw new ErrorException("Property $obj_var is already associated with a FormInput : ".$this->binded_inputs[$obj_var]->getName());
		if ($val = $this->bean_object->$getter())
			$input->setValue($val);
		$this->binded_inputs[$obj_var] = array();
		$this->binded_inputs[$obj_var]["input"] = $input;
		$this->binded_inputs[$obj_var]["getter"] = $getter;
		$this->binded_inputs[$obj_var]["setter"] = $setter;
		$this->addInput($input, $title);
	}
	
	public function 		check()
	{
		if (($good = parent::check()) === false)
			return false;
		foreach ($this->binded_inputs as $obj_var => $input_info)
			$this->bean_object->$input_info["setter"]($input_info["input"]->getValue());
		return true;
	}
}
?>