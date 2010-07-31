<?php
class 							FormTypes
{
	const 						STRING = 1;
	const 						ESCAPED_STRING = 2;
	const 						FILENAME = 3;
	const						DATE = 4;
	
	const 						NUMBER = 10;
	const 						BOOL = 11;

	const 						FILE = 20;
	
	private static 				$checkFunctions = array (
		self::STRING => 		"checkString",
		self::ESCAPED_STRING =>	"checkEscapedString",
		self::BOOL =>			"checkBool",
		self::DATE =>			"checkDate"
	);
	
	/**
	 * If given value DOES NOT match with these regexps using preg_match(), request will fail
	 */
	private static 				$checkRegexp = array (
		self::NUMBER =>			"![0-9]+!",
		self::DATE =>			"!^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$!"
	);
	
	/**
	 * If given value DOES match with these regexps using preg_match(), request will fail
	 */
	private static 				$failRegexp = array (
		self::FILENAME =>		"![^a-zA-Z0-9\.\_\-]!"
	);
	
	/**
	 * These regexp will be used with preg_replace as a pre-formating for the given value
	 * 		$replaceRegexp[<FormType>][0]: Search pattern
	 * 		$replaceRegexp[<FormType>][1]: Replace pattern
	 */
	private static 				$replaceRegexp = array (
		self::FILENAME =>		array(
			//Search pattern
			"![\s\)\(\*\^\%\$\#\@\!]!",
			//Replace pattern
			"_"
		),
		self::DATE =>			array(
			//Search pattern
			"!(\.|\s|\:|,)!",
			//Replace
			"/"
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
	
	private static function 	checkFile(&$value, &$error)
	{
		
	}
	
	private static function		checkDate(&$value, &$error)
	{
		$a_date = explode('/', $value);
		if (count($a_date) != 3)
		{
			$error = "Bad Format";
			return false;
		}
		$month = intval($a_date[0]);
		$day = intval($a_date[1]);
		$year = intval($a_date[2]);
		
		$err = array();
		if ($month < 1 || $month > 12)
		{
			$err[] = "month";
		}
		if ($day < 1 || $day > 31)
		{
			$err[] = "day";
		}
		if ($year < 0)
		{
			$err[] = "year";
		}
		if (count($err) != 0)
		{
			$error = "Bad format in ".implode(",", $err);
			return false;
		}
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