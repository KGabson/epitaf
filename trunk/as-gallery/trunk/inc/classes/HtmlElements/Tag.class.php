<?php
class					Tag
{
	private				$attributes = array();
	private				$children = array();
	private				$num_children = 0;
	
	protected 			$inline;
	protected 			$tagname;
	
	public function		__construct($tagname, $classname = "", $inline = false)
	{
		$this->tagname = $tagname;
		$this->inline = $inline;
		if (!empty($classname))
			$this->setAttribute("class", $classname);
	}
	
	public function		setAttribute($key, $value)
	{
		$this->attributes[$key] = $value;
	}
	
	public function 	getAttribute($key)
	{
		if (isset($this->attributes[$key]))
			return $this->attributes[$key];
		return false;
	}
	
	public function 	setClassName($classname)
	{
		$this->setAttribute("class", $classname);
	}
	
	public function 	getClassName()
	{
		return $this->getAttribute("class");
	}
	
	/**
	 * TODO: Prototype append and insert with mixed args such as :
	 * 		append(list $children)
	 * so we can append many Tags at a time
	 *
	 */
	public function		append(&$child)
	{
		$this->checkChild($child);
		$this->children[$this->num_children++] = $child;
	}
	
	public function		insert(&$child)
	{
		$this->checkChild($child);
		array_unshift($this->children, $child);
		$this->num_children++;
	}
	
	private function	checkChild(&$child)
	{
		if ($this->inline)
			throw new ErrorException("Inline tags cannot have children");
		if (!($child instanceof Tag))
			$child = strval($child);
	}
	
	public function		numChildren()
	{
		return $this->num_children;
	}
	
	public function		children()
	{
		return $this->children;
	}
	
	public function 	getFirstChild($tagname)
	{
		$res = false;
		if ($this->tagname == $tagname)
			return $this;
		foreach ($this->children as $child)
		{
			if (($child instanceof Tag) && ($res = $child->getFirstChild($tagname)))
				return $res;
		}
		return false;
	}
	
	public function		toHTML($indent = 0, $html_entities = true)
	{
		$str = '';
		$indent_str = (__COMPRESS_CODE === true) ? "" : "\t";
		$newline = (__COMPRESS_CODE === true) ? "" : "\n";
		
		/*
		var_dump($this);
		if ($html_entities === false)
			Errors::Debug("I am XML");
		else
			Errors::Debug("I am HTML");
		exit (0);*/
		
		$str .= str_repeat($indent_str, $indent);
		$str .= '<';
		$str .= $this->tagname;
		foreach ($this->attributes as $key => $value)
		{
			if (!is_string($value))
			{
				$value = strval($value);
			}
			if ($html_entities)
				$value = htmlentities($value);
			else
				$value = utf8_encode($value);
			$str .= ' '.$key.'="'.$value.'"';
		}
		if ($this->inline)
		{
			$str .= ' />'.$newline;
			return $str;
		}
		$str .= '>';
		foreach ($this->children as $key => $child)
		{
			if (is_string($child))
			{
				if ($html_entities)
					$str .= htmlentities($child);
				else
					$str .= utf8_encode($child);
			}
			else
				$str .= $newline.$child->toHTML($indent + 1, $html_entities).str_repeat($indent_str, ($key < $this->num_children - 1) ? $indent + 1 : $indent);
		}
		$str .= '</'.$this->tagname.'>'.$newline;
		return $str;
	}
}
?>