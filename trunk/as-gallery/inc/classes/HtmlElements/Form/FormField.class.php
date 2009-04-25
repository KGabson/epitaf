<?php
class 					FormField extends Tag
{
	private 			$label_tag;
	
	public function 	__construct($title, FormInput &$input = null)
	{
		parent::__construct("div");
		$this->label_tag = new TagBlock("label", $title);
		if ($id = $input->getAttribute("id"))
			$label_tag->setAttribute("for", $id);
		$this->append($this->label_tag);
		if ($input !== null)
			$this->append($input);
	}
}
?>