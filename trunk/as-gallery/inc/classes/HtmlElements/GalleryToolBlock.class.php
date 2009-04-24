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
		
		$this->title = new LinkTag($gallery->getTitle(), $gallery->getLink(), "title");
		
		$this->list_images = new Tag("ul", "images");
		$aImg = $gallery->getRandomImages();
		foreach ($aImg as $image)
		{
			//$this->append(new TagBlock("div", $image->img));
			//$img = new Tag("img", "", true);
			//$img->setAttribute();
			//var_dump($image)
			Errors::Dump($image);
			$this->list_images->append(new TagBlock("li", new ImageTag(__ROOT."/".$gallery->getDir()."/".$image->img, $image->title, $image->title)));
		}
		$this->append($this->title);
		$this->append($this->list_images);
		//$this->append($gallery->getTitle());
	}
}
?>