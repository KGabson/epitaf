<?php
class					GDImage
{
	private				$path;
	
	private				$createFctByType = array(
		IMAGETYPE_JPEG	=> "imagecreatefromjpeg",
		IMAGETYPE_PNG	=> "imagecreatefrompng",
		IMAGETYPE_GIF	=> "imagecreatefromgif"
	);
	
	private				$saveFctByType = array(
		IMAGETYPE_JPEG	=> "imagejpeg",
		IMAGETYPE_PNG	=> "imagepng",
		IMAGETYPE_GIF	=> "imagegif"
	);
	
	public function		__construct($image_path)
	{
		if (!file_exists($image_path))
		{
			throw new ErrorException("No such image : ".$image_path);
			return;
		}
		$this->path = $image_path;
	}
	
	public function		resize($new_width, $new_height, $to_destination_file = null)
	{
		list($width, $height, $type, $attr) = getimagesize($this->path);
		if ($width < $new_width && $height < $new_height)
			return true;
		if (!array_key_exists($type, $this->createFctByType))
		{
			Errors::Warning("Could not determine imagecreate function for type ".$type);
			return false;
		}
		$fd = $this->createFctByType[$type]($this->path);
		
		$xCoef = $new_width / $width;
		$yCoef = $new_height / $height;
		$coef = ($width > $height) ? $xCoef : $yCoef;
		$new_width = $width * $coef;
		$new_height = $height * $coef;
		
		/*
		if ($width > $height)
		{
			$new_height = $height * ($new_height / $width);
		}
		if ($width < $height)
		{
			$new_width = $width * ($new_width / $height);
		}
		if ($width == $height)
		{
			$thumb_w=$new_w;
			$thumb_h=$new_h;
		}
		*/
		
		$image_resized = imagecreatetruecolor($new_width, $new_height);
		imagecopyresampled($image_resized, $fd, 0, 0, 0, 0, $new_width, $new_height, $width, $height);
		
		$to_destination_file = ($to_destination_file == null) ? $this->path : $to_destination_file;
		
		$this->saveFctByType[$type]($image_resized, $to_destination_file);
		
		imagedestroy($fd);
		imagedestroy($image_resized);
	}
}
?>