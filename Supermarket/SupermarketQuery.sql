CREATE DATABASE marketDB

CREATE TABLE msProduct( 
 ProductID INT IDENTITY PRIMARY KEY,
 ProductName VARCHAR (25),
 Price INT NOT NULL,
 Quantity INT NOT NULL
 )

SELECT * FROM msProduct


