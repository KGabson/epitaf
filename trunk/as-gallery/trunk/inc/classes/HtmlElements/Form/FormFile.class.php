<?php
class 						FormFile extends FormInput
{
	private					$allowed_mime_types;
	private					$upload_dir;
	private					$tmp_name;
	
	public function 		__construct($name, $upload_dir, $mandatory, $classname = "")
	{
		parent::__construct("file", $name, $mandatory, "input", $classname, true);
		$this->form_type = FormTypes::FILE;
		$this->upload_dir = $upload_dir;
	}
	
	public function			setAllowedMimeTypes($mime_types)
	{
		if (is_string($mime_types))
		{
			$this->allowed_mime_types = array($mime_types);
		}
		else if (is_array($mime_types))
		{
			$this->allowed_mime_types = $mime_types;
		}
		else
		{
			Errors::Warning("Invalid argument for setAllowedMimeTypes");
		}
	}
	
	public function			getTmpName()
	{
		return $this->tmp_name;
	}
	
	public function			getUploadDir()
	{
		return $this->upload_dir;
	}
	
	public function			setUploadDir($dir)
	{
		return $this->upload_dir = $dir;
	}
	
	public function			check($value, &$error)
	{
		$saved_value = $this->value;
		if (parent::check($value, $error) === false)
			return false;
		$this->value = $saved_value;
		if (!is_array($value) || !isset($value['name']) || !isset($value['type']) || !isset($value['tmp_name']) || !isset($value['size']) || !isset($value['error']))
		{
			$error = "Bad POST Request";
			return false;
		}
		if ($value['error'] != UPLOAD_ERR_OK)
		{
			if (($this->mandatory && $value['error'] == UPLOAD_ERR_NO_FILE) || $value['error'] != UPLOAD_ERR_NO_FILE)
			{
				$error = $this->getErrorString($value['error']);
				return false;
			}
			else
			{
				return true;
			}
		}
		if (!empty($this->allowed_mime_types) && !in_array($value['type'], $this->allowed_mime_types))
		{
			$error = "Bad file type";
			return false;
		}
		if (!is_dir($this->upload_dir))
		{
			throw new ErrorException("Try to save uploaded file to invalid directory: [".$this->upload_dir."]");
			return false;
		}
		$this->tmp_name = $value['tmp_name'];
		$this->value = $value['name'];
		return true;
	}
	
	private function		getErrorString($err)
	{
		$err_str = "";
		switch ($err)
		{
			case UPLOAD_ERR_INI_SIZE:
				$err_str = "Uploaded file exceeds limitation";
				break;
			case UPLOAD_ERR_FORM_SIZE:
				$err_str = "Uploaded file exceeds limitation";
				break;
			case UPLOAD_ERR_PARTIAL:
				$err_str = "The uploaded file was only partially uploaded";
				break;
			case UPLOAD_ERR_NO_FILE:
				$err_str = "No file was uploaded";
				break;
			case UPLOAD_ERR_NO_TMP_DIR:
				$err_str = "Could not upload file to a temporary directory. This problem is only solvable by server administrator";
				break;
			case UPLOAD_ERR_CANT_WRITE:
				$err_str = "Failed to write file on server";
				break;
			case UPLOAD_ERR_EXTENSION:
				$err_str = "A PHP extension stopped the file upload";
				break;
			default:
				$err_str = "Undefined error";
				break;
		}
		return $err_str;
	}

}

?>