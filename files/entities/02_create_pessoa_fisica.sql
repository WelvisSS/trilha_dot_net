-- -----------------------------------------------------
-- Table `mydb`.`Pessoa_Fisica`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Pessoa_Fisica` (
  `cod_pessoa` INT NOT NULL,
  `cpf` VARCHAR(14) NULL,
  PRIMARY KEY (`cod_pessoa`))
ENGINE = InnoDB;
