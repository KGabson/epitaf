<?php
class					Tag
{
	private				$attributes = array();
	private				$children = array();
	private				$num_children = 0;
	
	private				$inline;
	private				$tagname;
	
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
	
	public function		toHTML($indent = 0)
	{
		$str = '';
		
		$str .= str_repeat("\t", $indent);
		$str .= '<';
		$str .= $this->tagname;
		foreach ($this->attributes as $key => $value)
		{
			$str .= ' '.$key.'="'.$value.'"';
		}
		if ($this->inline)
		{
			$str .= ' />'."\n";
			return $str;
		}
		$str .= '>'."\n";
		foreach ($this->children as $child)
		{
			if (is_string($child))
				$str .= str_repeat("\t", $indent + 1).$child."\n";
			else
				$str .= $child->toHTML($indent + 1);
		}
		$str .= str_repeat("\t", $indent).'</'.$this->tagname.'>'."\n";
		return $str;
	}
}
?>