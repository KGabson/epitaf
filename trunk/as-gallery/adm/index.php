<?php
require_once("../inc/config.php");
require_once("../inc/autoload.php");

//Errors::Dump(get_class("FormTypes"));
//$t = ;
//Errors::Debug();
//Errors::Debug("MEMORY USAGE::".memory_get_usage());
//Errors::Debug(FormTypes::FILE);


/*class Test
{
	public $var = "toto";
}

class Other
{
	private $test;
	private $array = array();
	private $num = 0;
	
	public function __construct(Test &$test)
	{
		$this->test = $test;
	}
	
	public function addTest(Test &$test)
	{
		$this->array[$this->num] = $test;
		$this->array[$this->num]->var = "Element ".$this->num;
		$this->num++;
	}
	
	public function doAction()
	{
		$this->test->var = "Changed !!!!";
	}
}

$test = new Test();
Errors::Debug($test->var);
$other = new Other($test);
$other->doAction();
Errors::Debug($test->var);

$test1 = new Test();
$test2 = new Test();
$test3 = new Test();

Errors::Debug($test1->var);
Errors::Debug($test2->var);
Errors::Debug($test3->var);

$other->addTest($test1);
$other->addTest($test2);
$other->addTest($test3);

Errors::Debug($test1->var);
Errors::Debug($test2->var);
Errors::Debug($test3->var);*/

$menu = new Menu();
$menu->scanDir("../galleries");
//Errors::Debug("MEMORY USAGE::".memory_get_usage());

$view = new View($menu);
$view->render();

//$form = new FormView();
//Errors::Dump($form);
//$t = new FormString("hop");
//$form->addInput(new FormString("test"), "Test");
//Page::append($menu);
//Page::append($root);
Page::append($view);
//Page::append($form);
//var_dump(Page::instance());
Page::render();
?>