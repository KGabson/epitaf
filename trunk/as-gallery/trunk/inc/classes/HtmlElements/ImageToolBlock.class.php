<?php
class 					ImageToolBlock extends Tag
{
	private 			$title;
	private 			$toolbar;
	private 			$category;
	private 			$image;
	private 			$image_tag;
	
	public function		__construct(Image &$image, Category &$category)
	{
		$this->category = $category;
		parent::__construct("div", "toolblock");
		
		/**
		 * Title
		 */
		$this->title = new TagBlock(
			"h3",
			new LinkTag($image->getTitle(), $image->getLink($this->category->getParentGallery()->getName(), $this->category->getName()), "title")
		);
		
		/**
		 * Toolbar
		 */
		$this->toolbar = new Tag("div", "toolbar");
		$ul = new Tag('ul');
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Edit",
							$image->getLink($this->category->getParentGallery()->getName(), $this->category->getName(), "edit"),
							"edit_image")
			)
		);
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Delete",
							$image->getLink($this->category->getParentGallery()->getName(), $this->category->getName(), "delete"),
							"delete_image",
							"return confirm('Do you really want to delete image \"".$image->getImg()."\"')")
			)
		);
		$this->toolbar->append($ul);
		$this->toolbar->append(new Tag('div', 'clear'));
		
		/**
		 * Images
		 */
		$this->image_tag = new Tag("div", "image");
		$this->image_tag->append(
			new LinkTag(
				new ImageTag(
					$category->getDir()."/".$category->getThumbDir()."/".$image->getImg(),
					$image->getImg(),
					$image->getTitle()
				),
				$image->getLink($this->category->getParentGallery()->getName(), $this->category->getName())
			)
		);
		
		$this->append($this->title);
		$this->append($this->toolbar);
		$this->append($this->image_tag);
	}
}
?>