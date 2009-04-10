<?php
class					Menu extends Tag
{
	private				$elements = array();
	private				$root;
	private				$title = "";
	
	public function 	__construct()
	{
		parent::__construct("div");
		$this->setAttribute("id", "mainMenu");
		$this->root = new Tag("ul");
		$this->append($this->root);
	}
	
	public function		addElement($title, $href)
	{
		$elm = new TagBlock("li", new LinkTag($title, $href));
		$this->root->append($elm);
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
			if (!preg_match("!.*\.xml!", $elm))
			{
				Errors::Debug("Menu::scanDir: [$path] This file should not be here: [$elm]");
				continue;
			}
			$this->addElement(Gallery::getTitleFromFilename($elm), $path."/".$elm);
		}
	}
}
?>