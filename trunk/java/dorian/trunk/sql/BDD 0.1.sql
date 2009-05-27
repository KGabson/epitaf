SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `mydb`;

-- -----------------------------------------------------
-- Table `mydb`.`step`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`step` (
  `id_step` INT NOT NULL ,
  `begin_date` DATE NULL ,
  `end_date` DATE NULL ,
  `title` VARCHAR(45) NULL ,
  `id_coordinate` INT NULL ,
  `resume` TEXT NULL ,
  PRIMARY KEY (`id_step`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`map_point`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`map_point` (
  `id_map_point` INT NOT NULL ,
  `x` INT NULL ,
  `y` INT NULL ,
  `orientation` INT NULL ,
  PRIMARY KEY (`id_map_point`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`narration`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`narration` (
  `id_narration` INT NOT NULL ,
  `title` VARCHAR(150) NULL ,
  `text` TEXT NULL ,
  `id_step` INT NULL ,
  PRIMARY KEY (`id_narration`) ,
  INDEX `fk_narration_step` (`id_step` ASC) ,
  CONSTRAINT `fk_narration_step`
    FOREIGN KEY (`id_step` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`step_has_map_point`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`step_has_map_point` (
  `id_step` INT NOT NULL ,
  `id_map_point` INT NOT NULL ,
  `order` INT NULL ,
  PRIMARY KEY (`id_step`, `id_map_point`) ,
  INDEX `fk_step_has_map_point_step` (`id_step` ASC) ,
  INDEX `fk_step_has_map_point_map_point` (`id_map_point` ASC) ,
  CONSTRAINT `fk_step_has_map_point_step`
    FOREIGN KEY (`id_step` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_step_has_map_point_map_point`
    FOREIGN KEY (`id_map_point` )
    REFERENCES `mydb`.`map_point` (`id_map_point` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `mydb`.`image`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`image` (
  `id_photo` INT NOT NULL ,
  `title` VARCHAR(150) NULL ,
  `legend` TEXT NULL ,
  `url` VARCHAR(255) NULL ,
  `id_step` INT NULL ,
  PRIMARY KEY (`id_photo`) ,
  INDEX `fk_image_step` (`id_step` ASC) ,
  CONSTRAINT `fk_image_step`
    FOREIGN KEY (`id_step` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`video`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`video` (
  `id_video` INT NOT NULL ,
  `title` VARCHAR(150) NULL ,
  `legend` TEXT NULL ,
  `url` VARCHAR(255) NULL ,
  `id_step` INT NULL ,
  PRIMARY KEY (`id_video`) ,
  INDEX `fk_video_step` (`id_step` ASC) ,
  CONSTRAINT `fk_video_step`
    FOREIGN KEY (`id_step` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`advice`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`advice` (
  `id_advice` INT NOT NULL ,
  `title` VARCHAR(150) NULL ,
  `text` TEXT NULL ,
  PRIMARY KEY (`id_advice`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`link`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`link` (
  `id_link` INT NOT NULL ,
  `title` VARCHAR(150) NULL ,
  `url` VARCHAR(255) NULL ,
  PRIMARY KEY (`id_link`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`user` (
  `id_user` INT NOT NULL ,
  `first_name` VARCHAR(45) NULL ,
  `last_name` VARCHAR(45) NULL ,
  `email` VARCHAR(100) NULL ,
  `login` VARCHAR(45) NULL ,
  `password` VARCHAR(45) NULL ,
  `gender` VARCHAR(5) NULL ,
  `is_admin` CHAR(1) NULL ,
  PRIMARY KEY (`id_user`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`category_photo_selection`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`category_photo_selection` (
  `id_category_photo_selection` INT NOT NULL ,
  `id_photo_selection` INT NULL ,
  `label` VARCHAR(100) NULL ,
  PRIMARY KEY (`id_category_photo_selection`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`photo_selection_has_image`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`photo_selection_has_image` (
  `id_image` INT NOT NULL ,
  `id_category_photo_selection` INT NULL ,
  PRIMARY KEY (`id_image`) ,
  INDEX `fk_photo_selection_has_image_image` (`id_image` ASC) ,
  INDEX `fk_photo_selection_has_image_category_photo_selection` (`id_category_photo_selection` ASC) ,
  CONSTRAINT `fk_photo_selection_has_image_image`
    FOREIGN KEY (`id_image` )
    REFERENCES `mydb`.`image` (`id_photo` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_photo_selection_has_image_category_photo_selection`
    FOREIGN KEY (`id_category_photo_selection` )
    REFERENCES `mydb`.`category_photo_selection` (`id_category_photo_selection` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `mydb`.`step_has_step`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`step_has_step` (
  `id_step` INT NOT NULL ,
  `id_parent` INT NOT NULL ,
  `order` INT NULL ,
  PRIMARY KEY (`id_step`, `id_parent`) ,
  INDEX `fk_step_has_step_step` (`id_step` ASC) ,
  INDEX `fk_step_has_step_step1` (`id_parent` ASC) ,
  CONSTRAINT `fk_step_has_step_step`
    FOREIGN KEY (`id_step` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_step_has_step_step1`
    FOREIGN KEY (`id_parent` )
    REFERENCES `mydb`.`step` (`id_step` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `mydb`.`comment`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`comment` (
  `id_comment` INT NOT NULL ,
  `username` VARCHAR(45) NULL ,
  `text` TEXT NULL ,
  `id_video` INT NULL ,
  `id_photo` INT NULL ,
  PRIMARY KEY (`id_comment`) ,
  INDEX `fk_comment_video` (`id_video` ASC) ,
  INDEX `fk_comment_image` (`id_photo` ASC) ,
  CONSTRAINT `fk_comment_video`
    FOREIGN KEY (`id_video` )
    REFERENCES `mydb`.`video` (`id_video` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comment_image`
    FOREIGN KEY (`id_photo` )
    REFERENCES `mydb`.`image` (`id_photo` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
