-- -----------------------------------------------------
-- Table `mydb`.`Servico`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Servico` (
  `cod_servico` INT NOT NULL,
  `cod_solicitacao` INT NULL,
  `cod_funcionario` INT NULL,
  `tipo` VARCHAR(20) NULL,
  `valor` FLOAT NULL,
  `quantidade` INT NULL,
  `timestamp` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`cod_servico`))
ENGINE = InnoDB;
