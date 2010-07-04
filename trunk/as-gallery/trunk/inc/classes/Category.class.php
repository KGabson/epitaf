<?php
class 						Category extends Tag
{
	private 				$name;
	private 				$images = array();
	private 				$nb_images = 0;
	private 				$gallery;
	
	public function 		__construct($name = "", Gallery &$gallery = null)
	{
		//$this->name = $name;
		parent::__construct("category");
		$this->setName($name);
		$this->gallery = ($gallery == null) ? new Gallery("none", "") : $gallery;
		$this->images = array();
		$this->nb_images = 0;
	}
	
	public function 		getParentGallery()
	{
		return $this->gallery;
	}
	
	public function 		getName()
	{
		return $this->name;
	}
	
	public function 		setName($name)
	{
		$this->name = $name;
		$this->setAttribute("name", $this->name);
	}
	
	public function 		getImages()
	{
		return $this->images;
	}
	
	public function 		getDir()
	{
		return $this->gallery->getDir();
	}
	
	public function 		getThumbDir()
	{
		return $this->gallery->getThumbDir();
	}
	
	public function 		getImageDir()
	{
		return $this->gallery->getImageDir();
	}
	
	public function 		getRandomImage()
	{
		if (!$this->nb_images)
			return false;
		$keys = array_keys($this->images);
		if ($this->nb_images == 1)
			return $this->images[$keys[0]];
		$n = rand(0, $this->nb_images - 1);
		return ($this->images[$keys[$n]]);
	}
	
	public function 		getImageNamed($image_file_name)
	{
		if (array_key_exists($image_file_name, $this->images))
			return $this->images[$image_file_name];
		return false;
	}
	
	public function 		addImage(Image &$image)
	{
		if (!$image->getImg())
			throw new ErrorException("Given image has not filename");
		
		if (!array_key_exists($image->getImg(), $this->images))
			$this->nb_images++;
		$this->images[$image->getImg()] = $image;
	}
	
	public function 		updateImage($image_file, Image &$image)
	{
		if (isset($this->images[$image_file]))
			unset($this->images[$image_file]);
		//$this->images[] = $image;
		$this->images[$image->getImg()] = $image;
	}
	
	public function 		getLink($action = "")
	{
		$url = Page::getLink($this->gallery->getName(), $this->name, "", $action);
		return $url;
	}

	public function 		loadFromXML(SimpleXMLElement $category)
	{
		//$root = $category;
		if (!$category["name"])
			throw new ErrorException("Given Category XML has no name attribute");
		$this->setName(strval($category["name"]));
		foreach ($category->image as $image)
		{
			$this->addImage(
				new Image(
					strval($image->date),
					strval($image->title),
					strval($image->desc),
					strval($image->thumb),
					strval($image->img)
				)
			);
		}
		
	}
	
	public function 		toHTML($indent = 0)
	{
		foreach ($this->images as $image)
			$this->append($image);
		return parent::toHTML($indent);
	}
}
?>