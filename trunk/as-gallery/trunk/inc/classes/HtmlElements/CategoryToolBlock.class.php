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
		parent::__construct("div", "toolblock");
		
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
		$this->toolbar = new Tag("ul", "toolbar");
		$this->toolbar->append(
			new TagBlock(
				"li", 
				new LinkTag("Edit", $category->getLink("edit"), "edit_category")
			)
		);
		$this->toolbar->append(
			new TagBlock(
				"li", 
				new LinkTag("Delete",
							$category->getLink("delete"),
							"delete_category",
							"return confirm('Do you really want to delete the categoty \"".$category->getName()."\" ? (this will also delete all the images that it contains)')")
			)
		);
		
		/**
		 * Images
		 */
		$this->image_tag = new Tag("div", "image");
		$img = $category->getRandomImage();
		if ($img)
		{
			$this->image_tag->append(
				new ImageTag(
					$category->getDir()."/".$category->getThumbDir()."/".$img->getImg(),
					$img->getImg(),
					$img->getTitle()
				)
			);
		}
		
		$this->append($this->title);
		$this->append($this->toolbar);
		$this->append($this->image_tag);
	}
}
?>