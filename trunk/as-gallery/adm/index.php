<?php
require_once("../inc/config.php");
require_once("../inc/autoload.php");

//$g = new Gallery("hop", __ROOT);
//
//$g->init("Test", "img", "thumb");
//$cats = $g->getCategories();
//foreach ($cats as $cat)
//{
//	echo "Category: ".$cat->getName()."<hr />";
//	foreach ($cat->getImages() as $img)
//		echo " ==> ".$img->img."<br />";
//	echo "<hr />";
//}
//for ($i = 0; $i < 10; $i++)
//{
//	$c = new Category("hop-".$i);
//	$c->create();
//	$g->addCategory($c);
//}
//Errors::ShowCode($g->toXML());
//
//Errors::Debug("TEST TAGS");

$tag = new Tag("div", "toto");
//$tag->append("Hello !");

$child = new Tag("ul", "hop");
for ($i = 0; $i < 5; $i++)
{
	$child->append(new TagBlock("li", "Element$i", "haha"));
	$child->setAttribute("style", "border:1px solid yellow;");
}
$tag->append($child);

$menu = new Menu();
$menu->scanDir("../galleries");

Page::append($tag);
Page::append($menu);
Page::render();

//echo $tag->toHTML();

?>