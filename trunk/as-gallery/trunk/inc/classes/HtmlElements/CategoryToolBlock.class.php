<?php
class 					CategoryToolBlock extends Tag
{
	private 			$category;
	private 			$title;
	private 			$toolbar;
	private 			$image_tag;
	
	public function		__construct(Category &$category)
	{
		$this->category = $category;
		parent::__construct("div", "toolblock_container");
		$toolblock = new Tag('div', 'toolblock');
		
		/**
		 * Title
		 */
		$this->title = new TagBlock(
			"h3",
			new LinkTag($category->getName(), $category->getLink(), "title")
		);
		
		/**
		 * Toolbar
		 */
		$this->toolbar = new Tag("div", "toolbar");
		$ul = new Tag('ul');
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Edit", $category->getLink("edit"), "edit_category")
			)
		);
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Delete",
							$category->getLink("delete"),
							"delete_category",
							"return confirm('Do you really want to delete the categoty \"".$category->getName()."\" ? (this will also delete all the images it contains)')")
			)
		);
		$this->toolbar->append($ul);
		$this->toolbar->append(new Tag('div', 'clear'));
		
		/**
		 * Images
		 */
		$this->image_tag = new Tag("div", "image");
		$img = $category->getRandomImage();
		if ($img)
		{
			$this->image_tag->append(
				new LinkTag(
					new ImageTag(
						$category->getDir()."/".$category->getThumbDir()."/".$img->getImg(),
						$img->getImg(),
						$img->getTitle()
					),
					$category->getLink()
				)
			);
		}
		
		$toolblock->append($this->title);
		$toolblock->append($this->toolbar);
		$toolblock->append($this->image_tag);
		$this->append($toolblock);
	}
}
?>