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
		if (isset($_GET['add_gallery']))
		{
			/**
			 * Gallery creation Form
			 */
			$this->makeGalleryForm();
			return ;
		}
		if (isset($_GET["gallery"]))
		{
			$gallery_name = urldecode($_GET["gallery"]);
			if (!$gallery = $this->menu->getGallery($gallery_name))
				return ;
			//Errors::ShowCode($gallery->toXML());
			$this->nav[$this->nav_lvl++] = new LinkTag($gallery->getTitle(), Page::getLink($gallery->getName()));
			$this->addToolbarAction(new LinkTag("Edit this gallery", $gallery->getLink("edit")));
			$this->addToolbarAction(new LinkTag("Add a Category", $gallery->getLink("add_category")));
			
			/**
			 * Gallery edition Form
			 */
			if (isset($_GET["edit"]) && !isset($_GET["category"]) && !isset($_GET["image"]))
			{
				$this->makeGalleryForm($gallery);
				return ;
			}
			
			/**
			 * Category creation Form
			 */
			if (isset($_GET['add_category']))
			{
				$this->makeCategoryForm($gallery);
				return ;
			}
			
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
				//echo "hop => $cat_name";
				if (!$category = $gallery->getCategory($cat_name))
					return ;
				if (isset($_GET['edit']) && !isset($_GET["image"]))
				{
					/**
					 * Category edition Form
					 */
					//echo "lalala";
					$this->makeCategoryForm($gallery, $category);
					return ;
				}
				$this->addToolbarAction(new LinkTag("Edit this category", $category->getLink("edit")));
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
	
	private function 			makeGalleryForm(Gallery &$gallery = null)
	{
		$new = ($gallery == null) ? true : false;
		$gallery = ($gallery == null) ? new Gallery("", __ROOT."/galleries") : $gallery;
		$g_form = new FormBean("gallery", $gallery);
		$name_input = new FormString("name", true);
		$name_input->setFormType(FormTypes::FILENAME);
		if (!$new)
			$name_input->setAttribute("disabled", "disabled");
		$g_form->bindValue($name_input, "name", "Identifier");
		$g_form->bindValue(new FormString("title", true), "title", "Title");
		$g_form->bindValue(new FormCheck("random", "random", "", true), "random", "Randomize pictures ?");
		if ($g_form->check())
		{
			if ($new && $gallery->exists())
				$g_form->addError("There is already a gallery named '".$gallery->getName()."'. Please choose another identifier.");
			else
			{
				$gallery->save();
				Page::redirect(Page::getLink($gallery->getName(), "", "", "edit"));
			}
		}
		$this->right->append($g_form);
	}
	
	private function 			makeCategoryForm(Gallery &$gallery, Category $category = null)
	{
		$new = ($category == null) ? true : false;
		$old_name = ($category == null) ? false : $category->getName();
		$category = ($category == null) ? new Category("", $category) : $category;
		$c_form = new FormBean("category", $category);
		$c_form->bindValue(new FormString("name", true), "name", "Name");
		if ($c_form->check())
		{
			if ($new && $gallery->getCategory($category->getName()))
				$c_form->addError("Category of the same name already exists");
			else
			{
				//$gallery->updateCategory()
				if ($new)
					$gallery->addCategory($category);
				else
					$gallery->updateCategory($old_name, $category);
				$gallery->save();
				Page::redirect(Page::getLink($gallery->getName(), $category->getName(), "", "edit"));
			}
		}
		$this->right->append($c_form);
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