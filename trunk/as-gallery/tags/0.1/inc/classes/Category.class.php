<?php
class 						Category extends XMLNode implements ICreator
{
	private 				$name;
	private 				$images = array();
	private 				$nb_images = 0;
	private 				$gallery;
	
	public function 		__construct($name = "", Gallery &$gallery = null)
	{
		$this->name = $name;
		$this->gallery = ($gallery == null) ? new Gallery("none", "") : $gallery;
		$this->images = array();
	}
	
	public function 		getName()
	{
		return $this->name;
	}
	
	public function 		setName($name)
	{
		$this->name = $name;
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
		if ($this->nb_images == 1)
			return $this->images[0];
		$n = rand(0, $this->nb_images - 1);
		return ($this->images[$n]);
	}
	
	public function 		getLink($action = "")
	{
		$url = Page::getLink(urlencode($this->gallery->getName()), urlencode($this->name), "", $action);
		return $url;
	}


	public function 		create(array $values = null)
	{
		$this->root = new SimpleXMLElement("<category></category>");
		$this->root->addAttribute("name", $this->name);
	}

	public function 		loadFromXML(SimpleXMLElement $category)
	{
		$this->root = $category;
		
		foreach ($this->root->image as $image)
		{
			$a_img = array();
			$this->images[$this->nb_images++] = new Image($image->date, $image->title, $image->desc, $image->thumb, $image->img);
		}
		
	}
}
?>