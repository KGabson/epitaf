<?php
class					Menu extends Tag
{
	private				$elements = array();
	private 			$galleries_tags = array();
	private				$htmlroot;
	private 			$xmltree = array();
	private				$title = "";
	
	public function 	__construct()
	{
		parent::__construct("div");
		$this->setAttribute("id", "mainMenu");
		$this->htmlroot = new Tag("ul");
		$this->append($this->htmlroot);
	}
	
	public function		addGalleryLink($name, $title, $href)
	{
		$elm = new TagBlock(
			"li",
			new LinkTag(
				$title,
				$href,
				(isset($_GET['gallery']) && urldecode($_GET['gallery']) == $name) ?
					"selected" : ""
			)
		);
		$elm->getFirstChild("toto");
		$this->galleries_tags[$name] = $elm;
		$this->htmlroot->append($this->galleries_tags[$name]);
	}
	
	public function 	addCategoryLink($gallery_name, Category $category)
	{
		if (!isset($this->galleries_tags[$gallery_name]))
		{
			Errors::Warning("Undefined gallery \"$gallery_name\"");
			return false;
		}
		$catroot = $this->galleries_tags[$gallery_name]->getFirstChild("ul");
		if (!$catroot)
		{
			$catroot = new Tag("ul", "category");
			$this->galleries_tags[$gallery_name]->append($catroot);
		}
		$elm = new TagBlock(
			"li", 
			new LinkTag(
				$category->getName(),
				$category->getLink(),
				(isset($_GET["category"]) && urldecode($_GET["category"]) == $category->getName()) ?
					"selected" : ""
				)
			);
		$catroot->append($elm);
		return true;
	}
	
	public function 	addGallery(Gallery &$gallery)
	{
		if (!$gallery->getName())
			throw new ErrorException("Given gallery has no name");
		if (!$gallery->getTitle())
			throw new ErrorException("Gallery '".$gallery->getName()."' has no title");
		$this->xmltree[$gallery->getName()] = $gallery;
		$this->addGalleryLink($gallery->getName(), $gallery->getTitle(), $gallery->getLink());
		foreach ($gallery->getCategories() as $category)
			$this->addCategoryLink($gallery->getName(), $category);
	}
	
	public function 	getGalleries()
	{
		return $this->xmltree;
	}
	
	public function 	getGallery($gallery_name)
	{
		if (isset($this->xmltree[$gallery_name]))
			return $this->xmltree[$gallery_name];
		return false;
	}
	
	public function		scanDir($path)
	{
		if (!is_dir($path))
			throw new ErrorException("$path: No such directory");
		$hd = opendir($path);
		while ($elm = readdir($hd))
		{
			if ($elm[0] == '.')
				continue;
			$matches = array();
			if (!preg_match("!(.*)\.xml!", $elm, $matches))
				continue;
			$gallery = new Gallery($matches[1], $path);
			$gallery->load();
			$this->addGallery($gallery);
			/*$this->xmltree[$matches[1]] = $gallery;
			$this->addGalleryLink($matches[1], $gallery->getTitle(), Page::getLink(urlencode($matches[1])));
			//echo "ok => ".$gallery->getTitle();
			foreach ($gallery->getCategories() as $category)
			{
				//echo $matches[1]."==";
				//echo "lala";
				$this->addCategoryLink($matches[1], $category);
			}*/
		}
	}
}
?>