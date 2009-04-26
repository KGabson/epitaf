<?php
class 							FormTypes
{
	const 						STRING = 1;
	const 						ESCAPED_STRING = 2;
	const 						FILENAME = 3;
	
	const 						NUMBER = 10;
	const 						BOOL = 11;

	const 						FILE = 20;
	
	private static 				$checkFunctions = array (
		self::STRING => 		"checkString",
		self::ESCAPED_STRING =>	"checkEscapedString",
		self::BOOL =>			"checkBool"
	);
	
	private static 				$checkRegexp = array (
		self::NUMBER =>			"![0-9]+!",
	);
	
	private static 				$failRegexp = array (
		self::FILENAME =>		"![^a-zA-Z0-9\.\_\-]!"
	);
	
	private static 				$replaceRegexp = array (
		self::FILENAME =>		array(
			//Search pattern
			"!\s!",
			//Replace pattern
			"_"
		)
	);
	
	private static function 	checkString(&$value, &$error)
	{
		$value = strval($value);
		return true;
	}
	
	private static function 	checkEscapedString(&$value, &$error)
	{
		$value = htmlentities($value);
		return true;
	}
	
	private static function 	checkBool(&$value, &$error)
	{
		$value = (!$value) ? 0 : 1;
		return true;
	}
	
	public static function 		check($form_type, &$value, &$error)
	{
		if (isset(self::$replaceRegexp[$form_type]))
			$value = preg_replace(self::$replaceRegexp[$form_type][0], self::$replaceRegexp[$form_type][1], $value);
		if (isset(self::$checkRegexp[$form_type]) && !preg_match(self::$checkRegexp[$form_type], $value))
		{
			$error = "Bad format";
			return false;
		}
		if (isset(self::$failRegexp[$form_type]) && preg_match(self::$failRegexp[$form_type], $value))
		{
			$error = "Bad format";
			return false;
		}
		
		if (isset(self::$checkFunctions[$form_type]))
		{
			$fct = self::$checkFunctions[$form_type];
			if (self::$fct($value, $error) === false)
				return false;
		}
		return true;
	}
	}
?>