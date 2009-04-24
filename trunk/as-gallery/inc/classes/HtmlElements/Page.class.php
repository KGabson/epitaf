<?php
class						Page
{
	private static 			$instance;
	
	private					$root;
	private					$head;
	private					$body;
	private 				$file;
	private 				$get;
	
	private function		__construct()
	{
		$this->root = new Tag("html");
		$this->head = new Tag("head");
		$this->body = new Tag("body");
		$this->file = basename($_SERVER['PHP_SELF']);
		$this->doGet();
		
		$this->root->append($this->head);
		$this->root->append($this->body);
	}
	
	private function 		doGet()
	{
		foreach ($_GET as $key => $value)
			$this->get[$key] = $value;
	}
	
	public static function 	getLink($gallery = "", $category = "", $image = "", $file = "")
	{
		$file = (empty($file)) ? self::instance()->file : $file;
		$url = $file;
		$url .= (!empty($gallery) || !empty($category) || !empty($image)) ? "?" : "";
		$url .= (!empty($gallery)) ? "gallery=".$gallery."&" : "";
		$url .= (!empty($category)) ? "category=".$category."&" : "";
		$url .= (!empty($image)) ? "image=".$image."&" : "";
		$url = ((!empty($gallery) || !empty($category) || !empty($image))) ? substr($url, 0, strlen($url) - 1) : $url;
		return $url;
	}
	
	public static function 	getURL($append_string = "")
	{
		$url = self::instance()->file;
		$vars = (empty($_SERVER['QUERY_STRING'])) ? "" : $_SERVER['QUERY_STRING'];
		$vars .= (empty($append_string)) ? $vars : ((empty($vars)) ? "&".$append_string : $append_string);
		$url = (empty($vars)) ? $url : $url."?".$vars;
	}
	
	public static function	instance()
	{
		if (self::$instance == null)
			self::$instance = new Page();
		return self::$instance;
	}
	
	public static function	setBodyAttribute($key, $value)
	{
		$me = self::instance();
		$me->body->setAttribute($key, $value);
	}
	
	public static function	render()
	{
		$me = self::instance();
		print $me->root->toHTML();
	}
	
	public static function	append($child)
	{
		$me = self::instance();
		$me->body->append($child);
	}
	
	public static function	includeCSS($href)
	{
		$me = self::instance();
		$link = new Tag("link", "", true);
		$link->setAttribute("rel", "stylesheet");
		$link->setAttribute("type", "text/css");
		$link->setAttribute("href", $href);
		$me->head->append($link);
	}
	
	public static function	includeScript($href, $type = "text/javascript")
	{
		$me = self::instance();
		$script = new Tag("script");
		$script->setAttribute("type", $type);
		$script->setAttribute("src", $href);
		$me->head->append($script);
	}
}
?>