CREATE SCHEMA bank;

CREATE TABLE `bank`.`client` (
  `clientID` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `idCardNumber` INT NOT NULL,
  `code` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`clientID`));

CREATE TABLE `bank`.`account` (
    `accountID` INT NOT NULL AUTO_INCREMENT,
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

CREATE TABLE `bank`.`employee` (
  `employeeID` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `username` VARCHAR(45) NOT NULL UNIQUE,
  `password` VARCHAR(45) NOT NULL,
  `isAdmin` INT NOT NULL,
  PRIMARY KEY (`employeeID`));

CREATE TABLE `bank`.`log` (
  `logDate` DATETIME NOT NULL,
  `employeeID` INT NOT NULL,
  `report` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`logDate`),
  INDEX `FK_employeeID_idx` (`employeeID` ASC),
  CONSTRAINT `FK_employeeID`
    FOREIGN KEY (`employeeID`)
    REFERENCES `bank`.`employee` (`employeeID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

INSERT INTO `bank`.`employee` (`name`, `username`, `password`, `isAdmin`) VALUES ('Name1', 'emp1', '1234', '0');
INSERT INTO `bank`.`employee` (`name`, `username`, `password`, `isAdmin`) VALUES ('Name2', 'emp2', '1234', '0');
INSERT INTO `bank`.`employee` (`name`, `username`, `password`, `isAdmin`) VALUES ('Name', 'adm1', '12345', '1');

INSERT INTO `bank`.`client` (`name`, `idCardNumber`, `code`, `address`) VALUES ('Marian Salvan', '2141', 'crq3124', 'Far Away');
INSERT INTO `bank`.`client` (`name`, `idCardNumber`, `code`, `address`) VALUES ('Ana Pop', '5155', 'dqwe31', 'Beyond The Misty Mountains');
INSERT INTO `bank`.`client` (`name`, `idCardNumber`, `code`, `address`) VALUES ('Dana Vacariu', '6161', 'eqwe123', 'Narnia');
INSERT INTO `bank`.`client` (`name`, `idCardNumber`, `code`, `address`) VALUES ('Gabriel Zamfir', '0314', 'hth376', 'Hogwarts');

INSERT INTO `bank`.`account` (`accountID`, `type`, `balance`, `creationDate`) VALUES ('1', 'spending', '10000', '2017-03-21');
INSERT INTO `bank`.`account` (`accountID`, `type`, `balance`, `creationDate`) VALUES ('2', 'saving', '5000', '2016-12-07');
INSERT INTO `bank`.`account` (`accountID`, `type`, `balance`, `creationDate`) VALUES ('3', 'checking', '6969', '2017-01-15');
INSERT INTO `bank`.`account` (`accountID`, `type`, `balance`, `creationDate`) VALUES ('4', 'checking', '43000', '2017-02-27');

INSERT INTO `bank`.`log` (`logDate`, `employeeID`, `report`) VALUES ('2017-03-22 00:00:00','1', 'inserted client');
INSERT INTO `bank`.`log` (`logDate`, `employeeID`, `report`) VALUES ('2017-03-23 00:00:00','2', 'delete client');
INSERT INTO `bank`.`log` (`logDate`, `employeeID`, `report`) VALUES ('2017-03-24 00:00:00','1', 'updated client');
INSERT INTO `bank`.`log` (`logDate`, `employeeID`, `report`) VALUES ('2017-03-25 00:00:00','3', 'inserted client');
