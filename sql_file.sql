CREATE SCHEMA bank;

CREATE TABLE `bank`.`client` (
  `clientID` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `idCardNumber` INT NOT NULL,
  `code` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`clientID`));

CREATE TABLE `bank`.`account` (
    `accountID` INT NOT NULL,
    `clientID` INT NOT NULL,
    `type` VARCHAR(45) NOT NULL,
    `balance` DOUBLE NOT NULL,
    `creationDate` DATETIME NULL,
    PRIMARY KEY (`accountID`),
    INDEX `FK_clientID_idx` (`clientID` ASC),
    CONSTRAINT `FK_clientID` FOREIGN KEY (`clientID`)
        REFERENCES `bank`.`client` (`clientID`)
        ON DELETE CASCADE ON UPDATE CASCADE
);


