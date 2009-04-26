<?php
class 					GalleryView extends Tag
{
	public function 	__construct($gallery_name)
	{
		parent::__construct("div");
		$this->setAttribute("id", urlencode($gallery_name));
	}
}
?>