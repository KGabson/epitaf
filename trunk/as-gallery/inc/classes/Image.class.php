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
		if (!$title)
		{
			Errors::Warning("Missing title parameter for image. Using \"Untitled\".");
			$title = "Untitled";
		}
		if (!$date)
			Errors::Warning("Missing date parameter for image $title");
		if (!$thumb)
			Errors::Warning("Missing thumb parameter for image $title");
		if (!$img)
			Errors::Warning("Missing img parameter for image $title");

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
	
	public function 	getLink()
	{
		$url = Page::getURL(array("image" => File::Basename($this->img, true)));
		return $url;
	}
	
	public function 	create(array $values = null)
	{
		
	}
	
}
?>