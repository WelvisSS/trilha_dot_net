-- -----------------------------------------------------
-- Table `mydb`.`Funcionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Funcionario` (
  `cod_funcionario` INT NOT NULL,
  `cod_pessoa` INT NULL,
  `nome` VARCHAR(100) NULL,
  `telefone` VARCHAR(11) NULL,
  PRIMARY KEY (`cod_funcionario`))
ENGINE = InnoDB;
