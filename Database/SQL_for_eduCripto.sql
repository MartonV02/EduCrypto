CREATE DATABASE eduCrypto
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

USE eduCrypto;


CREATE table users_handling (
id int,
userName varchar(100) NOT NULL,
password varchar(100) NOT NULL,
email varchar (100) NOT NULL,
fullName varchar (100) NOT NULL,
birthDate date NOT NULL,
xpLevel int NOT NULL,
CONSTRAINT pk_users_handling PRIMARY KEY (id)
);

CREATE table user_finance (
userId int NOT NULL,
walletNumber varchar (200) NOT NULL,
money float NOT NULL,
CONSTRAINT	pk_user_finance PRIMARY KEY (userId),
CONSTRAINT fk_user_trade_history FOREIGN KEY (userId)
);

CREATE table user_crypto (
  id int NOT NULL AUTO_INCREMENT,
  walletNumber varchar (34) NOT NULL,
  cryptoType varchar (20) NOT NULL,
  cryptoValue decimal(15,2) NOT NULL,
  CONSTRAINT pk_user_crypto PRIMARY KEY (id),
  CONSTRAINT fk_walletNumerInFree FOREIGN KEY (walletNumber) REFERENCES user_finance(walletNumber),
  CONSTRAINT fk_walletNumerInGroup FOREIGN KEY (walletNumber) REFERENCES users_handling_for_groups(walletNumber),
);

CREATE table user_trade_history (
  id int NOT NULL AUTO_INCREMENT,
  userId int NOT NULL,
  tradeDate date NOT NULL,
  spentType varchar(20) NOT NULL,
  spentValue decimal(15,2) NOT NULL,
  boughtType varchar(20) NOT NULL,
  boughtValue decimal(15,2) NOT NULL,
  groupId int,
  
  CONSTRAINT pk_user_trade_history PRIMARY KEY (id),
  CONSTRAINT fk_userId FOREIGN KEY (userId) REFERENCES users_handling(id),
  CONSTRAINT fk_groupId FOREIGN KEY (groupId) REFERENCES groups(id),
);

CREATE TABLE groups(
    id int NOT NULL AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    startBudget decimal,

    CONSTRAINT pk_groups PRIMARY KEY(id)
  );

CREATE TABLE users_for_groups(
  id int NOT NULL AUTO_INCREMENT,
  userId int NOT NULL ,
  groupId int NOT NULL,
  accesLevel varchar(50) NOT NULL,
  groupWalletNumber varchar(200) NOT NULL,
  balance decimal,

  CONSTRAINT pk_users_for_groups PRIMARY KEY(id),
  CONSTRAINT fk_userId FOREIGN KEY(userId) REFERENCES users_handling(id),
  CONSTRAINT fk_groupId FOREIGN KEY(groupId) REFERENCES groups(id)
  );

