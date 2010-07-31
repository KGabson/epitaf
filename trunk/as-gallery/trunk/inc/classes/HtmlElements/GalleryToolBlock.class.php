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
		$this->toolbar = new Tag("div", "toolbar");
		$ul = new tag('ul');
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Edit", $gallery->getLink("edit"), "edit_gallery")
			)
		);
		$ul->append(
			new TagBlock(
				"li", 
				new LinkTag("Delete",
							$gallery->getLink("delete"),
							"delete_gallery",
							"return confirm('Do you really want to delete gallery \"".$gallery->getTitle()."\" ? (This will delete all categories and images that it contains)')")
			)
		);
		$this->toolbar->append($ul);
		$this->toolbar->append(new Tag('div', 'clear'));
		
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
						$gallery->getDir()."/".$gallery->getThumbDir()."/".$image->getImg(),
						$image->getTitle(),
						$image->getTitle()
					) //ImageTag
				) //TagBlock
			); //append
		}
		
		$this->append($this->title);
		$this->append($this->toolbar);
		$this->append($this->list_images);
		$this->append(new Tag('div', 'clear'));
	}
}
?>