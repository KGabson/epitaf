<?php
class					Gallery extends XMLNode implements ICreator 
{
	private 			$name;
	private 			$file;
	private 			$dir;
	private 			$exists = false;
	private				$title = false;
	private				$imageDir = false;
	private				$thumbDir = false;
	private				$random = false;

	private 			$categories = array();

	
	public function 	__construct($filename_whithout_exension, $dir)
	{
		$this->name = $filename_whithout_exension;
		$this->dir = $dir;
		$this->file = $this->name.".xml";
		$this->exists = file_exists($this->dir."/".$this->file);
	}
	
	public function 	getCategories()
	{
		return $this->categories;
	}
	
	public function  	getCategory($category_name)
	{
		if (isset($this->categories[$category_name]))
			return $this->categories[$category_name];
		return false;
	}
	
	public function 	getTitle()
	{
		return $this->title;
	}
	
	public function 	getName()
	{
		return $this->name;
	}
	
	public function 	getDir()
	{
		return $this->dir;
	}
	
	public function 	getImageDir()
	{
		return $this->imageDir;
	}
	
	public function 	getThumbDir()
	{
		return $this->thumbDir;
	}
	
	public function 	getRandom()
	{
		return $this->random;
	}
	
	public function 	getRandomImages()
	{
		$aImages = array();
		foreach ($this->categories as $cat)
		{
			$aImages[] = $cat->getRandomImage();
		}
		return $aImages;
	}
	
	public function 	getLink($action = "")
	{
		$url = Page::getLink(urlencode($this->name), "", "", $action);
		return $url;
	}
	
	public function 	init($title, $imageDir, $thumbDir, $random = true)
	{
		if ($this->exists)
			throw new ErrorException("Could not create gallery named ".$this->file.". Gallery already exists.");
		$this->title = $title;
		$this->imageDir = $imageDir;
		$this->thumbDir = $thumbDir;
		$this->random = $random;
		
		//Creating XML root node
		$this->root = new SimpleXMLElement("<gallery></gallery>");
		$this->root->addAttribute("title", $this->title);
		$this->root->addAttribute("thumbDir", $this->thumbDir);
		$this->root->addAttribute("imageDir", $this->imageDir);
		$this->root->addAttribute("random", $this->random);
	}

	public function 	create(array $values = null)
	{
		if ($values == null)
			throw new ErrorException("Missing \$values parameter in create() function");
		if ($this->exists)
			throw new ErrorException("Could not create gallery named ".$this->file.". Gallery already exists.");
		
		$this->init($values['title'], $values['imageDir'], $values['thumbDir'], $values['random']);
	}
	
	public function 	load()
	{
		if (!$this->exists)
			return false;
		if (($this->root = simplexml_load_file($this->dir."/".$this->file)) === FALSE)
			throw new ErrorException("Could not load ".$this->dir."/".$this->file);
		if (!$this->root["title"])
			throw new ErrorException("No title for gallery ".$this->dir."/".$this->file);
		if (!$this->root["imageDir"])
			throw new ErrorException("No imageDir for gallery ".$this->dir."/".$this->file);
		if (!$this->root["thumbDir"])
			throw new ErrorException("No thumbDir for gallery ".$this->dir."/".$this->file);
		if (!$this->root["random"])
			$this->random = false;
		else
			$this->random = $this->root["random"];
		$this->title = strval($this->root["title"]);
		$this->imageDir = strval($this->root["imageDir"]);
		$this->thumbDir = strval($this->root["thumbDir"]);
		//Errors::Debug($this->thumbDir);
		foreach ($this->root->category as $category)
		{
			if (!$category["name"])
			{
				Errors::Warning("Could not find a name for category ".$this->dir."/".$this->file);
				continue;
			}
			$cat_name = strval($category["name"]);
			$this->categories[$cat_name] = new Category($cat_name, $this);
			$this->categories[$cat_name]->loadFromXML($category);
		}
		return true;
	}
	
	public function 	addCategory(Category $cat)
	{
		if (isset($this->categories[$cat->getName()]))
			throw new ErrorException("Category [".$cat->getName()."] already exists for gallery ".$this->name);
		$this->categories[$cat->getName()] = $cat;
		$xmlcat = $this->root->addChild("category");
		$xmlcat->addAttribute("name", $cat->getName());
	}
	
	public static function		getTitleFromFilename($filename)
	{
		$filename = trim($filename);
		$filename = preg_replace("!(.*)\.xml!", "$1", $filename);
		$filename = preg_replace("![^a-zA-Z0-9]!", " ", $filename);
		$a = split(" ", $filename);
		foreach ($a as $key => $str)
			$a[$key] = strtoupper($str[0]).substr($str, 1);
		return (implode(" ", $a));
	}
	
}
?>