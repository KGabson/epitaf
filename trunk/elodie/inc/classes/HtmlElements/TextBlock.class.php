<?php
class						TextBlock extends Tag
{
	public function			__construct($content, $format = false, $is_code = false)
	{
		if ($format || $is_code)
			$content = htmlentities($content);
		$tagname = ($is_code) ? "span" : "pre";
		parent::__construct($tagname);
		$this->append($content);
	}
}
?>