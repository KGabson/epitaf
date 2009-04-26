<?php
class 					FormField extends Tag
{
	private 			$label_tag;
	private 			$error;
	private 			$legend;
	private 			$input;
	
	public function 	__construct(FormInput &$input, $title = "")
	{
		parent::__construct("div");
		if (!empty($title))
		{
			$this->label_tag = new TagBlock("label", $title);
			if ($id = $input->getAttribute("id"))
				$label_tag->setAttribute("for", $id);
			$this->append($this->label_tag);
		}
		$this->input = $input;
		$this->append($this->input);
	}
	
	public function 	setLegend($str)
	{
		$this->legend = $str;
	}
	
	public function 	setError($str)
	{
		$this->error = $str;
	}
	
	public function 	getInput()
	{
		return $this->input;
	}
	
	public function 	toHTML($indent = 0)
	{
		if (!empty($this->legend))
			$this->append(new TagBlock("div", $this->legend, "legend"));
		if (!empty($this->error))
		{
			$this->label_tag->setClassName("error");
			$this->label_tag->insert(new TagBlock("span", $this->error));
		}
		return parent::toHTML($indent);
	}
}
?>