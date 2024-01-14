-- -----------------------------------------------------
-- Table `mydb`.`Solicitacoes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Solicitacoes` (
  `cod_solicitacao` INT NOT NULL,
  `cod_cliente` INT NULL,
  `timestamp` VARCHAR(45) NULL,
  `valor_solicitado` FLOAT NULL,
  `Solicitacoescol` VARCHAR(45) NULL,
  PRIMARY KEY (`cod_solicitacao`))
ENGINE = InnoDB;
