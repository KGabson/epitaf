<?php
class 							FormString extends FormInput 
{
	private 					$max_chars = 0;
	private 					$min_chars = 0;
	
	public function 			__construct($name, $mandatory = false, $value = null)
	{
		parent::__construct("text", $name, $mandatory);
		if ($value)
			$this->setValue($value);
	}
	
	public function 			setMaxChars($limit)
	{
		$this->max_chars = $limit;
	}
	
	public function 			setMinChars($limit)
	{
		$this->min_chars = $limit;
	}
	
	public function 			check(&$value, &$error)
	{
		if (parent::check($value, $error) === false)
			return false;
		if ($this->min_chars > 0 && strlen($value) < $this->min_chars)
		{
			$error = "Please enter at least ".$this->min_chars." characters";
			return false;
		}
		if ($this->max_chars > 0 && strlen($value) > $this->min_chars)
		{
			$error = "Please enter less than ".($this->max_chars + 1)." characters";
			return false;
		}
		return true;
	}
}
?>