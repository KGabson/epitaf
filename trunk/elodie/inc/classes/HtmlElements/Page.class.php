<?php
class						Page
{
	private static 			$instance;
	
	private					$root;
	private					$head;
	private					$body;
	
	private function		__construct()
	{
		$this->root = new Tag("html");
		$this->head = new Tag("head");
		$this->body = new Tag("body");
		
		$this->root->append($this->head);
		$this->root->append($this->body);
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