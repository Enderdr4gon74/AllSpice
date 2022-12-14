-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'When Last Updated',
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL,
  recipeId int NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

INSERT INTO ingredients(name, quantity, recipeId)
    VALUES(@Name, @Quantity, @RecipeId);
    SELECT LAST_INSERT_ID();


SELECT
  i.*,
  a.*
  FROM ingredients i
  JOIN accounts a ON a.id = i.creatorId
  WHERE i.recipeId = 35;

SELECT * FROM ingredients WHERE id = 1;

DROP TABLE ingredients