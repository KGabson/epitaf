<?php
class 				Image extends Tag
{
	private 			$date;
	private 			$title;
	private 			$desc;
	private 			$thumb;
	private 			$img;
	
	public function 	__construct($date = "", $title = "", $desc = "", $thumb = "", $img = "")
	{
		parent::__construct("image");
		$this->init($date, $title, $desc, $thumb, $img);
	}
	
	public function 	init($date, $title, $desc, $thumb, $img)
	{
		/*if (!$title)
		{
			Errors::Warning("Missing title parameter for image. Using \"Untitled\".");
			$title = "Untitled";
		}
		if (!$date)
			Errors::Warning("Missing date parameter for image $title");
		if (!$thumb)
			Errors::Warning("Missing thumb parameter for image $title");
		if (!$img)
			Errors::Warning("Missing img parameter for image $title");*/

		if (!$title)
			$title = "Untitled";
		$this->date = $date;
		$this->title = $title;
		$this->desc = $desc;
		$this->thumb = $thumb;
		$this->img = $img;
	}
	
	public function 	getTitle()
	{
		return $this->title;
	}
	
	public function 	setTitle($title)
	{
		$this->title = $title;
	}
	
	public function 	getDate()
	{
		return $this->date;
	}
	
	public function 	setDate($date)
	{
		$this->date = $date;
	}
	
	public function 	getDesc()
	{
		return $this->desc;
	}
	
	public function 	setDesc($desc)
	{
		$this->desc = $desc;
	}
	
	public function 	getThumb()
	{
		return $this->thumb;
	}
	
	public function 	setThumb($thumb)
	{
		$this->thumb = $thumb;
	}
	
	public function 	getImg()
	{
		return $this->img;
	}
	
	public function 	setImg($img)
	{
		$this->img = $img;
	}
	
	public function 	getLink($gallery_name, $category_name, $action = "")
	{
		//$url = Page::getURL(array("image" => urlencode($this->img)));
		$url = Page::getLink($gallery_name, $category_name, $this->img, $action);
		return $url;
	}
	
	public function 	toHTML($indent = 0)
	{
		$this->append(new TagBlock("title", $this->title));
		$this->append(new TagBlock("date", $this->date));
		$this->append(new TagBlock("desc", $this->desc));
		$this->append(new TagBlock("thumb", $this->thumb));
		$this->append(new TagBlock("img", $this->img));
		return parent::toHTML($indent);
	}
	
}
?>