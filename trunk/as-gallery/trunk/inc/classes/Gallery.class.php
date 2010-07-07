<?php
class					Gallery extends XMLRoot
{
	private 			$name;
	private 			$file;
	private 			$dir;
	private 			$exists = false;
	private 			$created = false;
	private				$title = false;
	private				$imageDir = false;
	private				$thumbDir = false;
	private				$random = false;

	private 			$categories = array();
	private 			$num_categories = 0;

	
	public function 	__construct($filename_whithout_exension = "", $dir = "")
	{
		parent::__construct("gallery");
		//$this->name = $filename_whithout_exension;
		$this->dir = $dir;
		$this->setName($filename_whithout_exension);
		/*if ($this->name)
		{
			$this->file = $this->name.".xml";
			$this->exists = file_exists($this->dir."/".$this->file);
		}*/
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
	
	public function 	setTitle($title)
	{
		$this->title = $title;
		//$root["title"] = $title;
		$this->setAttribute("title", $this->title);
	}
	
	public function 	getName()
	{
		return $this->name;
	}
	
	public function 	setName($name)
	{
		$this->name = $name;
		$this->file = $this->name.".xml";
		$this->exists = file_exists($this->dir."/".$this->name);
		$this->setAttribute("name", $this->name);
	}
	
	public function 	getDir()
	{
		return $this->dir;
	}
	
	public function 	getImageDir()
	{
		return $this->imageDir;
	}
	
	public function 	setImageDir($img_dir)
	{
		$this->imageDir = $img_dir;
		$this->setAttribute("imageDir", $this->imageDir);
	}
	
	public function 	getThumbDir()
	{
		return $this->thumbDir;
	}
	
	public function 	setThumbDir($thumb_dir)
	{
		$this->thumbDir = $thumb_dir;
		$this->setAttribute("thumbDir", $this->thumbDir);
	}
	
	public function 	getRandom()
	{
		return $this->random;
	}
	
	public function 	setRandom($random)
	{
		$this->random = ($random) ? true : false;
		$this->setAttribute("random", strval($this->random));
	}
	
	public function 	exists()
	{
		return $this->exists;
	}
	
	public function 	getRandomImages()
	{
		$aImages = array();
		foreach ($this->categories as $cat)
		{
			if ($img = $cat->getRandomImage())
				$aImages[] = $img;
		}
		return $aImages;
	}
	
	public function 	getLink($action = "")
	{
		$url = Page::getLink($this->name, "", "", $action);
		return $url;
	}
	
	public function 	init($title, $imageDir, $thumbDir, $random = true)
	{
		$this->setTitle($title);
		$this->setImageDir($imageDir);
		$this->setThumbDir($thumbDir);
		$this->setRandom($random);
		//if ($this->exists)
			//throw new ErrorException("Could not create gallery named ".$this->file.". Gallery already exists.");
		//$this->title = $title;
		//$this->imageDir = $imageDir;
		//$this->thumbDir = $thumbDir;
		//$this->random = $random;
		//if (!$this->file)
			//$this->file = $this->name.".xml";
		
		//Creating XML root node
		//if (!$this->root)
		//{
			//$this->root = new SimpleXMLElement("<gallery></gallery>");
		//$this->setAttribute("title", $this->title);
		//$this->setAttribute("thumbDir", $this->thumbDir);
		//$this->setAttribute("imageDir", $this->imageDir);
		//$this->setAttribute("random", $this->random);
		//}
		$this->created = true;
	}

	public function 	create()
	{
		if (!$this->name)
			throw new ErrorException("Could not create this gallery, it has no name");
		if (!$this->title)
			Errors::Warning("Gallery named '".$this->name."' has no title");
		if (!$this->imageDir)
			$this->imageDir = $this->name;
		if (!$this->thumbDir)
			$this->thumbDir = $this->imageDir."/thumbs";
		$this->init($this->title, $this->imageDir, $this->thumbDir, $this->random);
		if (file_exists($this->dir."/".$this->file))
			throw new ErrorException("Could not create gallery named ".$this->file.". Gallery of the same name already exists.");
	}
	
	public function 	load()
	{
		if (!$this->exists)
			return false;
		if (($root = simplexml_load_file($this->dir."/".$this->file)) === FALSE)
			throw new ErrorException("Could not load ".$this->dir."/".$this->file);
		if (!$root["title"])
			throw new ErrorException("No title for gallery ".$this->dir."/".$this->file);
		if (!$root["imageDir"])
			throw new ErrorException("No imageDir for gallery ".$this->dir."/".$this->file);
		if (!$root["thumbDir"])
			throw new ErrorException("No thumbDir for gallery ".$this->dir."/".$this->file);
		$random = true;
		if (!$root["random"])
			$random = false;
		else
			$this->random = $root["random"];
		$this->init(strval($root["title"]), strval($root["imageDir"]), strval($root["thumbDir"]), $random);
		foreach ($root->category as $category)
		{
			if (!$category["name"])
			{
				Errors::Warning("Could not find a name for category ".$this->dir."/".$this->file);
				continue;
			}
			//Errors::Debug("Found category: ".$category["name"]);
			$cat_name = strval($category["name"]);
			$this->categories[$cat_name] = new Category($cat_name, $this);
			$this->categories[$cat_name]->loadFromXML($category);
		}
		return true;
	}
	
	public function 	save()
	{
		if (!$this->created)
			$this->create();
			
		/**
		 * Creating directories
		 */
		if (!is_dir($this->dir))
			Directory::Make($this->dir, 0755);
		if (!is_dir($this->dir."/".$this->imageDir))
		{
			Dir::Make($this->dir."/".$this->imageDir, 0755);
			Dir::Make($this->dir."/".$this->thumbDir, 0755);
		}
		/**
		 * Creating or updating XML file
		 */
		$str = $this->toXML();
		File::PutContents($this->dir."/".$this->file, $str);
	}
	
	public function		delete()
	{
		if (!$this->created)
		{
			return;
		}
		Dir::Remove($this->dir."/".$this->imageDir, true);
		unlink($this->dir."/".$this->file);
	}
	
	public function 	addCategory(Category $cat)
	{
		if (!$cat->getName())
			throw new ErrorException("Given Category has no name");
		if (isset($this->categories[$cat->getName()]))
			throw new ErrorException("Category [".$cat->getName()."] already exists for gallery ".$this->name);
		if (!$this->created)
			$this->create();
		$this->categories[$cat->getName()] = $cat;
		//$xmlcat = $root->addChild("category");
		//$xmlcat->addAttribute("name", $cat->getName());
	}
	
	public function 	removeCategory($category_name)
	{
		if (!array_key_exists($category_name, $this->categories))
			return;
		unset($this->categories[$category_name]);
	}
	
	public function		updateCategory($category_name, Category &$category)
	{
		if (!isset($this->categories[$category_name]))
			return false;
		if (!$this->created)
			return false;
		if (!$category->getName())
			throw new ErrorException("Given Category as no name");
		if ($category_name != $category->getName())
		{
			//$pos = array_search($category_name, $this->categories);
			
			$keys = array_keys($this->categories);
			$pos = array_search($category_name, $keys);
			Tools::array_insert($this->categories, $pos, array($category->getName(), $category));
			unset($this->categories[$category_name]);
		}
		$this->categories[$category->getName()] = $category;
		/*foreach ($root->categories as $cat)
		{
			if (strval($cat["name"]) == $category->getName())
				$cat->setAttribute
		}*/
	}
	
	public function 	toXML()
	{
		foreach ($this->categories as $category)
			$this->append($category);
		return parent::toXML();
	}
	
	/*public static function		getTitleFromFilename($filename)
	{
		$filename = trim($filename);
		$filename = preg_replace("!(.*)\.xml!", "$1", $filename);
		$filename = preg_replace("![^a-zA-Z0-9]!", " ", $filename);
		$a = split(" ", $filename);
		foreach ($a as $key => $str)
			$a[$key] = strtoupper($str[0]).substr($str, 1);
		return (implode(" ", $a));
	}*/
	
}
?>