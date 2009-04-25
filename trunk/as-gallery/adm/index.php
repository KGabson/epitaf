<?php
require_once("../inc/config.php");
require_once("../inc/autoload.php");

//Errors::Dump(get_class("FormTypes"));
//$t = ;
//Errors::Debug();
//Errors::Debug("MEMORY USAGE::".memory_get_usage());
$menu = new Menu();
$menu->scanDir("../galleries");
//Errors::Debug("MEMORY USAGE::".memory_get_usage());

$view = new View($menu);
$view->render();

//$form = new FormView();
//$form->addFormField("Test", new FormString("test"));
//Page::append($menu);
//Page::append($root);
Page::append($view);
//Page::append($form);
//var_dump(Page::instance());
Page::render();
?>