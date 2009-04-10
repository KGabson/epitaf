<?php
class 						Category extends XMLNode implements ICreator
{
	private 				$name;
	private 				$images = array();
	
	public function 		__construct($name)
	{
		$this->name = $name;
		$this->images = array();
	}
	
	public function 		getName()
	{
		return $this->name;
	}
	
	public function 		getImages()
	{
		return $this->images;
	}

	public function 		create(array $values = null)
	{
		$this->root = new SimpleXMLElement("<category></category>");
		$this->root->addAttribute("name", $this->name);
	}

	public function 		loadFromXML(SimpleXMLElement $root)
	{
		$image_data = array();
		$this->root = $root;
		foreach ($this->root->children() as $node_value => $image)
		{
			$image_data["date"] = false;
			$image_data["title"] = false;
			$image_data["desc"] = false;
			$image_data["thumb"] = false;
			$image_data["img"] = false;
			
			if ($node_value != "image")
				continue;
			foreach ($image->children() as $node_name => $value)
			{
				if (!isset($image_data[$node_name]))
					continue;
				$image_data[$node_name] = $value;
			}
			if ($image_data["img"] == false)
			{
				Errors::Warning("Missing img parameter");
				continue;
			}
			foreach ($image_data as $key => $val)
			{
				if ($val === false)
					Errors::Warning("Missing $key parameter for category [".$this->name."]");
			}
			$img_name = strval($image_data["img"]);
			if (array_key_exists($img_name, $this->images))
				Errors::Warning("Double definition for image ".$image_data["img"]." in category ".$this->name);
			else
				$this->images[] = new Image($image_data["date"], $image_data["title"], $image_data["desc"], $image_data["thumb"], $image_data["img"]);
		}
	}
}
?>