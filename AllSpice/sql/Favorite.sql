-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'When Last Updated',
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id),
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';