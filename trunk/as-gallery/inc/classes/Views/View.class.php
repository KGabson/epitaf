<?php
class 							View extends Tag
{
	protected					$menu;
	protected 					$head;
	protected 					$right;
	protected 					$foot;
	protected 					$toolbar;
	protected 					$title = "AS-Gallery";
	protected 					$nav = array();
	protected 					$nav_lvl = 0;
	protected 					$toolbar_actions = array();
	protected 					$toolbar_actions_lvl = 0;
	
	public function				__construct(Menu &$menu)
	{
		$this->menu = $menu;
		$this->head = new Tag("div");
		$this->head->setAttribute("id", "head");
		$this->right = new Tag("div");
		$this->right->setAttribute("id", "right");
		$this->foot = new Tag("div");
		$this->foot->setAttribute("id", "foot");
		$this->toolbar = new Tag("ul", "toolbar");
		$this->toolbar->setAttribute("id", "mainToolbar");
		$this->nav[$this->nav_lvl++] = new LinkTag($this->title, Page::getLink());
		$this->init();
		parent::__construct("div");
	}
	
	private function 			init()
	{
		$this->addToolbarAction(new LinkTag("Add a Gallery", Page::getURL(array("add_gallery"))));
		if (isset($_GET["gallery"]))
		{
			$gallery_name = urldecode($_GET["gallery"]);
			if (!$gallery = $this->menu->getGallery($gallery_name))
				return ;
			$this->nav[$this->nav_lvl++] = new LinkTag($gallery->getTitle(), Page::getLink(urlencode($gallery->getName())));
			$this->addToolbarAction(new LinkTag("Add a Category", $gallery->getLink("add_category")));
			/**
			 * Listing Categories
			 */
			if (!isset($_GET['category']))
			{
				foreach ($gallery->getCategories() as $category)
				{
					$this->right->append(new CategoryToolBlock($category));
				}
			}
			
			/**
			 * Listing Images
			 */
			else
			{
				$cat_name = urldecode($_GET['category']);
				if (!$category = $gallery->getCategory($cat_name))
					return ;
				$this->addToolbarAction(new LinkTag("Add an Image", $category->getLink("add_image")));
				$this->nav[$this->nav_lvl++] = new LinkTag(
					$category->getName(),
					$category->getLink()
				);
				$img_list = new Tag("ul", "list_images");
				foreach ($category->getImages() as $image)
				{
					$img_toolblock = new ImageToolBlock($image, $category);
					$img_list->append(new TagBlock("li", $img_toolblock));
				}
				$this->right->append($img_list);
			}
		}
		/**
		 * Listing Galleries
		 */
		else
		{
			//$this->toolbar_actions[$this->toolbar_actions_lvl++] = new LinkTag("Add a gallery", Page::getURL(array("add_gallery")));
			foreach ($this->menu->getGalleries() as $gallery)
			{
				$toolblock = new GalleryToolBlock($gallery);
				$this->right->append($toolblock);
			}
		}
	}
	
	private function 			addToolbarAction(LinkTag $link)
	{
		$this->toolbar_actions[$this->toolbar_actions_lvl++] = $link;
	}
	
	public function 			doToolbar()
	{
		foreach ($this->toolbar_actions as $link_tag)
		{
			if (!($link_tag instanceof LinkTag))
				continue;
			$this->toolbar->append(new TagBlock("li", $link_tag));
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
		$this->doToolbar();
		
		$this->append($this->head);
		$this->append($this->toolbar);
		$this->append($this->menu);
		$this->append($this->right);
		$this->append($this->foot);
	}
}
?>