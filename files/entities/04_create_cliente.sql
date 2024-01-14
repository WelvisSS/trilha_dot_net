-- -----------------------------------------------------
-- Table `mydb`.`Clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Clientes` (
  `cod_cliente` INT NOT NULL,
  `cod_pessoa` VARCHAR(45) NULL,
  `nome` VARCHAR(100) NULL,
  PRIMARY KEY (`cod_cliente`))
ENGINE = InnoDB;
