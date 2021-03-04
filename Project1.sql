CREATE TABLE customers (
	customerId INT IDENTITY,
	firstName NVARCHAR(255) NOT NULL,
	lastName NVARCHAR(255) NOT NULL,
	phone NVARCHAR(25) NOT NULL,
	email NVARCHAR(255) NOT NULL,
	zip NVARCHAR(5) NOT NULL
	CONSTRAINT PK_cust PRIMARY KEY (customerId)
);

CREATE TABLE stores (
	storeId INT IDENTITY,
	storeName NVARCHAR(255) NOT NULL
	CONSTRAINT PK_stores PRIMARY KEY (storeId)
);

CREATE TABLE products (
	productId INT IDENTITY,
	productName NVARCHAR(255) NOT NULL,
	unitPrice DECIMAL(6, 2) NOT NULL
	CONSTRAINT PK_products PRIMARY KEY (productId)
);

CREATE TABLE inventories (
	storeId INT IDENTITY,
	productId INT NOT NULL,
	onHand INT NOT NULL
	CONSTRAINT CPK_inv PRIMARY KEY (storeId, productId)
);

CREATE TABLE orders (
	orderId INT IDENTITY,
	customerId INT NOT NULL,
	storeId INT NOT NULL,
	orderDate DATETIME NOT NULL,
	subtotal DECIMAL(8, 2) NOT NULL
	CONSTRAINT PK_orders PRIMARY KEY (orderId)
);

CREATE TABLE order_details (
	orderId INT NOT NULL,
	productId INT NOT NULL,
	quantity INT NOT NULL
	CONSTRAINT CPK_od PRIMARY KEY (orderId, productId)
);

ALTER TABLE inventories ADD CONSTRAINT
	FK_inv1 FOREIGN KEY (storeId) REFERENCES stores (storeId);

ALTER TABLE inventories ADD CONSTRAINT
	FK_inv2 FOREIGN KEY (productId) REFERENCES products (productId);

ALTER TABLE orders ADD CONSTRAINT
	FK_orders1 FOREIGN KEY (customerId) REFERENCES customers (customerId);

ALTER TABLE orders ADD CONSTRAINT
	FK_orders2 FOREIGN KEY (storeId) REFERENCES stores (storeId);

ALTER TABLE order_details ADD CONSTRAINT
	FK_od1 FOREIGN KEY (orderId) REFERENCES orders (orderId);

ALTER TABLE order_details ADD CONSTRAINT
	FK_od2 FOREIGN KEY (productId) REFERENCES products (productId);

INSERT INTO customers (firstName, lastName, phone, email, zip) VALUES
	('Jean', 'King', '4569872231', 'aef@hotmail.com', 12345),
	('Wendy', 'Franco', '4569879988', 'aisemaew@gmail.com', 23453),
	('Jeff', 'Young', '4569872233', 'aiefmae@ymail.com', 78978),
	('Eric', 'Lee', '4569871144', '77@aol.com', 12345),
	('Keith', 'Murphy', '4569879632', 'sup@yo.com', 55555);

INSERT INTO stores (storeName) VALUES
	('The Slithy Toves'), 
	('The Vorpal Blade'), 
	('The Tumtum Tree');

INSERT INTO products (productName, unitPrice) VALUES
	('To Kill a Mockingbird', 10.99),
	('Pride and Prejudice', 9.99),
	('Pride and Prejudice and Zombies', 11.99), 
	('The Great Gatsby', 4.99),
	('Brave New World', 8.99),
	('1984', 6.99),
	('Jane Eyre', 10.99),
	('Crime and Punishment', 8.99),
	('Call of the Wild', 8.99),
	('Moby Dick', 9.99),
	('The Lion, the Witch and the Wardrobe', 9.99), 
	('Frankenstein', 8.99);

INSERT INTO orders (customerId, storeId, orderDate, subtotal) VALUES
	(1, 3, '2021-02-11 00:00:00', 102.91),
	(2, 2, '2021-01-19 00:00:00', 126.87),
	(3, 1, '2021-02-21 00:00:00', 168.83),
	(4, 2, '2021-01-10 00:00:00', 169.81),
	(5, 2, '2021-02-12 00:00:00', 288.63),
	(2, 1, '2021-02-15 00:00:00', 206.77),
	(5, 3, '2021-01-02 00:00:00', 167.86);

INSERT INTO order_details (orderId, productId, quantity) VALUES
	(1, 1, 5),
	(1, 3, 4),
	(2, 5, 3),
	(2, 10, 10),
	(3, 7, 8),
	(3, 9, 9),
	(4, 11, 8),
	(4, 2, 7),
	(4, 4, 4),
	(5, 6, 22), 
	(5, 8, 15),
	(6, 8, 10),
	(6, 9, 13),
	(7, 3, 14);

SET IDENTITY_INSERT inventories ON;

INSERT INTO inventories (storeId, productId, onHand) VALUES 
	(1, 1, 33),
	(1, 3, 22),
	(1, 4, 30),
	(1, 6, 50),
	(1, 8, 44), 
	(2, 2, 44),
	(2, 5, 30),
	(2, 7, 50),
	(2, 9, 33),
	(2, 10, 17),
	(3, 11, 47),
	(3, 12, 18);

SET IDENTITY_INSERT inventories OFF;

-- GetOrderHistoryByStoreId
SELECT s.storeId, s.storeName, o.orderId, o.customerId, o.orderDate
	FROM stores s INNER JOIN orders o ON s.storeId = o.storeId
	WHERE s.storeId = 3; -- input

-- GetOrderDetailsByOrderId
SELECT o.orderId, o.customerId, o.orderDate, o.storeId, od.productId, od.quantity
	FROM orders o INNER JOIN order_details od ON o.orderId = od.orderId
	WHERE o.orderId = 2; -- input

-- GetOrderHistoryByCustomerId
SELECT c.customerId, c.firstName, c.lastName, o.orderId, o.storeId, o.orderDate, od.productId, od.quantity
	FROM customers c INNER JOIN orders o ON c.customerId = o.customerId
	INNER JOIN order_details od ON o.orderId = od.orderId
	WHERE c.customerId = 1; -- input