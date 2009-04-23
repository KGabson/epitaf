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
	
	public function		addGalleryLink($title, $href)
	{
		$elm = new TagBlock("li", new LinkTag($title, $href));
		$elm->getFirstChild("toto");
		$this->galleries_tags[$title] = $elm;
		$this->htmlroot->append($this->galleries_tags[$title]);
	}
	
	public function 	addCategoryLink($gallery_name, Category $category, $href)
	{
		if (!isset($this->galleries_tags[$gallery_name]))
		{
			Errors::Warning("Undefined gallery \"$gallery_name\"");
			return false;
		}
		$catroot = $this->galleries_tags[$gallery_name]->getFirstChild("ul");
		if (!$existing)
		{
			$catroot = new Tag("ul", "category");
			$this->galleries_tags[$gallery_name]->append($catroot);
		}
		$elm = new TagBlock("li", new LinkTag($category->getName(), $href));
		$catroot->append($elm);
		//$this->galleries_tags[$gallery_name]->append();
		return true;
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
			$this->xmltree[$matches[1]] = $gallery;
			$this->addGalleryLink($matches[1], "#");
			foreach ($gallery->getCategories() as $category)
			{
				$this->addCategoryLink($matches[1], $category, "#");
			}
		}
	}
}
?>