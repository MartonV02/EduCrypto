CREATE DATABASE eduCrypto
	CHARACTER SET utf8
	COLLATE utf8_hungarian_ci;

use eduCrypto;



CREATE table user_crypto (
  id int,
  walletNumber varchar (34) NOT NULL,
  cryptoType varchar (20) NOT NULL,
  cryptoValue float NOT NULL,
  CONSTRAINT pk_user_crypto PRIMARY KEY (id),
  CONSTRAINT fk_walletNumerInFree FOREIGN KEY (walletNumber) REFERENCES user_finance(walletNumber),
  CONSTRAINT fk_walletNumerInGroup FOREIGN KEY (walletNumber) REFERENCES users_handling_for_groups(walletNumber),
);