-- -----------------------------------------------------
-- Table `mydb`.`Pessoa_Juridica`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Pessoa_Juridica` (
  `cod_pessoa` INT NOT NULL,
  `cnpj` VARCHAR(18) NULL,
  PRIMARY KEY (`cod_pessoa`))
ENGINE = InnoDB;
