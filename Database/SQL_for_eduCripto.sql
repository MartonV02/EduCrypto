CREATE DATABASE eduCrypto
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

USE eduCrypto;



CREATE table user_crypto (
  id int,
  walletNumber varchar (34) NOT NULL,
  cryptoType varchar (20) NOT NULL,
  cryptoValue decimal(15,2) NOT NULL,
  CONSTRAINT pk_user_crypto PRIMARY KEY (id),
  CONSTRAINT fk_walletNumerInFree FOREIGN KEY (walletNumber) REFERENCES user_finance(walletNumber),
  CONSTRAINT fk_walletNumerInGroup FOREIGN KEY (walletNumber) REFERENCES users_handling_for_groups(walletNumber),
);

CREATE table user_trade_history (
  id int,
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