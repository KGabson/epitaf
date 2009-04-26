<?php
class 					GalleryToolBlock extends Tag
{
	private 			$gallery;
	private 			$title;
	private 			$toolbar;
	private 			$list_images;
	
	public function		__construct(Gallery &$gallery)
	{
		$this->gallery = $gallery;
		parent::__construct("div", "toolblock");
		
		/**
		 * Title
		 */
		$this->title = new TagBlock(
			"h2",
			new LinkTag($gallery->getTitle(), $gallery->getLink(), "title")
		);
		
		/**
		 * Toolbar
		 */
		$this->toolbar = new Tag("ul", "toolbar");
		$this->toolbar->append(
			new TagBlock(
				"li", 
				new LinkTag("Edit", $gallery->getLink("edit"))
			)
		);
		$this->toolbar->append(
			new TagBlock(
				"li", 
				new LinkTag("Delete", $gallery->getLink("delete"))
			)
		);
		
		/**
		 * Images
		 */
		$this->list_images = new Tag("ul", "images");
		$aImg = $gallery->getRandomImages();
		foreach ($aImg as $image)
		{
			$this->list_images->append(
				new TagBlock(
					"li",
					new ImageTag(
						$gallery->getDir()."/".$gallery->getThumbDir()."/".$image->img,
						$image->title,
						$image->title
					) //ImageTag
				) //TagBlock
			); //append
		}
		
		$this->append($this->title);
		$this->append($this->toolbar);
		$this->append($this->list_images);
	}
}
?>