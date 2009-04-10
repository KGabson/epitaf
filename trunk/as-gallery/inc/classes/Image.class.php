<?php
class 				Image extends XMLNode implements ICreator 
{
	private 			$date;
	private 			$title;
	private 			$desc;
	private 			$thumb;
	private 			$img;
	
	public function 	__construct($date, $title, $desc, $thumb, $img)
	{
		$this->date = $date;
		$this->title = $title;
		$this->desc = $desc;
		$this->thumb = $thumb;
		$this->img = $img;
	}

	public function 	__get($var)
	{
		if (!isset($this->$var))
			return false;
		return $this->$var;
	}
}
?>