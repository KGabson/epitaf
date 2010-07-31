<?php

require_once("../inc/config.php");
require_once("../inc/autoload.php");

$menu = new Menu();

/**
 * Disabling auto scan for the moment...
 */
//$menu->scanDir("../galleries");

$default_gallery = new Gallery("gallery", "..");
if (!$default_gallery->load())
	Errors::Warning("No such gallery");
$menu->addGallery($default_gallery);

$view = new View($menu);
$view->render();

Page::append($view);

Page::render();
?>