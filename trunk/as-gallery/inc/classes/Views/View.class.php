<?php
class 							View extends Tag
{
	protected					$menu;
	protected 					$head;
	protected 					$right;
	protected 					$foot;
	protected 					$title = "AS-Gallery";
	protected 					$nav = array();
	protected 					$nav_lvl = 0;
	
	public function				__construct(Menu &$menu)
	{
		$this->menu = $menu;
		$this->head = new Tag("div");
		$this->head->setAttribute("id", "head");
		$this->right = new Tag("div");
		$this->right->setAttribute("id", "right");
		$this->foot = new Tag("div");
		$this->foot->setAttribute("id", "foot");
		$this->nav[$this->nav_lvl++] = new LinkTag($this->title, Page::getLink());
		$this->init();
		parent::__construct("div");
	}
	
	private function 			init()
	{
		if (isset($_GET["gallery"]))
		{
			$gallery_name = urldecode($_GET["gallery"]);
			if (!$gallery = $this->menu->getGallery($gallery_name))
				return ;
			$this->nav[$this->nav_lvl++] = new LinkTag($gallery->getTitle(), Page::getLink(urlencode($gallery->getName())));
			/**
			 * Listing Categories
			 */
			if (!isset($_GET['category']))
			{
				
			}
			
			/**
			 * Listing Images
			 */
			else
			{
				$cat_name = urldecode($_GET['category']);
				if (!$category = $gallery->getCategory($cat_name))
					return ;
				$this->nav[$this->nav_lvl++] = new LinkTag($category->getName(), Page::getLink(urlencode($gallery->getName()), urlencode($category->getName())));
			}
		}
		/**
		 * Listing Galleries
		 */
		else
		{
			foreach ($this->menu->getGalleries() as $gallery)
			{
				$toolblock = new GalleryToolBlock($gallery);
				$this->right->append($toolblock);
			}
		}
	}
	
	private function 			doHead()
	{
		$title = new Tag("h1");
		$sep = " / ";
		foreach ($this->nav as $lvl => $link)
		{
			$title->append($link);
			if ($lvl < $this->nav_lvl - 1)
				$title->append($sep);
		}
		$this->head->append($title);
	}
	
	public function 			render()
	{
		$this->doHead();
		$this->append($this->head);
		$this->append($this->menu);
		$this->append($this->right);
		$this->append($this->foot);
	}
}
?>