use information_schema;

DROP DATABASE eduCrypto;

CREATE DATABASE eduCrypto
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

USE eduCrypto;


CREATE table users_handling(
id int,
userName varchar(100) NOT NULL,
password varchar(100) NOT NULL,
email varchar (100) NOT NULL,
fullName varchar (100) NOT NULL,
birthDate date NOT NULL,
xpLevel int NOT NULL,

CONSTRAINT pk_users_handling PRIMARY KEY (id)
);

CREATE table user_finance(
  userId int NOT NULL,
  walletNumber varchar (34) NOT NULL Unique,
  money decimal (15,2) NOT NULL,
  
  CONSTRAINT pk_user_finance PRIMARY KEY (userId),
  CONSTRAINT fk_user_finance_userId FOREIGN KEY (userId) REFERENCES users_handling(id)
);

CREATE TABLE groups(
    id int NOT NULL AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    startBudget decimal (15,2) NOT NULL,

    CONSTRAINT pk_groups PRIMARY KEY(id)
  );

CREATE TABLE users_for_groups(
  id int NOT NULL AUTO_INCREMENT,
  userId int NOT NULL ,
  groupId int NOT NULL,
  accesLevel varchar(50) NOT NULL,
  groupWalletNumber varchar(34) NOT NULL Unique,
  money decimal (15,2) NOT NULL,

  CONSTRAINT pk_users_for_groups PRIMARY KEY(id),
  CONSTRAINT fk_users_for_groups_userId FOREIGN KEY(userId) REFERENCES users_handling(id),
  CONSTRAINT fk_users_for_groups_groupId FOREIGN KEY(groupId) REFERENCES groups(id)
  );

CREATE table user_crypto(
  id int NOT NULL AUTO_INCREMENT,
  walletNumber varchar (34),
  cryptoId int NOT NULL,
  cryptoValue decimal(15,2) NOT NULL,
  groupWalletNumber varchar (34),
    
  CONSTRAINT pk_user_crypto PRIMARY KEY (id),
  CONSTRAINT fk_user_crypto_walletNumber FOREIGN KEY (walletNumber) REFERENCES user_finance(walletNumber),
  CONSTRAINT fk_user_crypto_groupWalletNumber FOREIGN KEY (groupWalletNumber) REFERENCES users_for_groups(groupWalletNumber),
  CONSTRAINT fk_user_crypto_cryptoId FOREIGN KEY (cryptoId) REFERENCES cryptcurrencies(id)
);

CREATE table user_trade_history(
  id int NOT NULL AUTO_INCREMENT,
  userId int NOT NULL,
  tradeDate date NOT NULL,
  spentId int NOT NULL,
  spentValue decimal(15,2) NOT NULL,
  boughtId int NOT NULL,
  boughtValue decimal(15,2) NOT NULL,
  groupId int,
  
  CONSTRAINT pk_user_trade_history PRIMARY KEY (id),
  CONSTRAINT fk_user_trade_history_userId FOREIGN KEY (userId) REFERENCES users_handling(id),
  CONSTRAINT fk_user_trade_history_groupId FOREIGN KEY (groupId) REFERENCES groups(id),
  CONSTRAINT fk_user_trade_history_spentId FOREIGN KEY (spentId) REFERENCES cryptcurrencies(id),
  CONSTRAINT fk_user_trade_history_boughtId FOREIGN KEY (boughtId) REFERENCES cryptcurrencies(id),
);

CREATE table cryptcurrencies(
  id int NOT NULL UNIQUE,
  name varchar (20) NOT NULL,
  short varchar (5) NOT NULL,
  price decimal (15,2) NOT NULL,
  dayPercent decimal (4,2) NOT NULL,
  weekPercent decimal (4,2) NOT NULL,
  marvetCap decimal (15,2) NOT NULL,
  volume decimal (15,2) NOT NULL,
  circulatingSupply decimal (15,2) NOT NULL,

  CONSTRAINT pk_cryptcurrencies PRIMARY KEY (id),
  );



