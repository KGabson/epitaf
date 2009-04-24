<?php
require_once("../inc/config.php");
require_once("../inc/autoload.php");

$menu = new Menu();
$menu->scanDir("../galleries");

$view = new View($menu);
$view->render();

//Page::append($menu);
//Page::append($root);
Page::append($view);
//var_dump(Page::instance());
Page::render();
?>