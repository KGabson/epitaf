<?php
class					LinkTag extends Tag
{
	public function		__construct($content, $href, $class = "", $onclick = "")
	{
		parent::__construct("a", $class);
		$this->setAttribute("href", $href);
		if (!empty($onclick))
			$this->setAttribute("onclick", $onclick);
		$this->append($content);
	}
}
?>