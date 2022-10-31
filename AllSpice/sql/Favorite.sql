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

SELECT
      rec.*,
      fav.id AS FavoritesId,
      a.*
      FROM favorites fav
      JOIN recipes rec ON rec.id = fav.recipeId
      JOIN accounts a ON a.id = rec.creatorId
      WHERE fav.accountId = "633cb69e37340e48a68947c1"
      GROUP BY fav.id;

SELECT * FROM favorites fav WHERE fav.accountId = "633cb69e37340e48a68947c1";