-- Active: 1666715483154@@SG-gamy-nylon-9663-6841-mysql-master.servers.mongodirector.com@3306@genshinImpact

CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'When Last Updated',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(255) NOT NULL,
  img VARCHAR(255) NOT NULL,
  category VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

SELECT * FROM recipes;

SELECT
  rec.*,
  a.*
  FROM recipes rec
  JOIN accounts a ON a.id = rec.creatorId;

SELECT
  rec.*,
  a.*
  FROM recipes rec
  JOIN accounts a ON a.id = rec.creatorId
  WHERE rec.id = 1;

UPDATE recipes SET title = @Title, instructions = @Instructions, img = @Img, category = @Category WHERE id = @Id;

DROP Table recipes;