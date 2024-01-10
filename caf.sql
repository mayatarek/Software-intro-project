Create Table Product
(
ProductID INTEGER NOT NULL,
ProductName VARCHAR(50) NOT NULL,
ProductPrice INTEGER NOT NULL,
PRIMARY KEY (ProductID, ProductName,ProductPrice)
);

CREATE TABLE Cart
(
    CartID INT,
    itemnumber INTEGER IDENTITY(1,1),
    ProductID INTEGER,
    ProductName VARCHAR(50),
    ProductPrice INTEGER,
	PRIMARY KEY (CartID,itemnumber),
    FOREIGN KEY (ProductID, ProductName, ProductPrice) REFERENCES Product(ProductID, ProductName, ProductPrice)
);

CREATE TABLE An_Order
(
    OrderID INT PRIMARY KEY IDENTITY(1,1),
	itemnumber INTEGER,
    CartID INTEGER,
    TotalCost INTEGER,
	ProductID INTEGER,
    ProductName VARCHAR(50),
    ProductPrice INTEGER,
    FOREIGN KEY (CartID,itemnumber) REFERENCES Cart(CartID,itemnumber),
	FOREIGN KEY (ProductID, ProductName, ProductPrice) REFERENCES Product(ProductID, ProductName, ProductPrice)
);

insert into cart (CartID, ProductID, ProductName, ProductPrice) values (1, 1, 'Cheese lays chips', 7);
insert into cart (CartID, ProductID, ProductName, ProductPrice) values (1, 3, 'Coffee', 15);
Insert into An_Order (TotalCost, ProductID, ProductPrice, ProductName) values (46, 1, 7, 'Cheese lays chips')

insert into An_Order (CartID, TotalCost) values (1, 14);

CREATE table Cart2 AS
SELECT *
FROM Cart;

SELECT *
INTO Cart2
FROM Cart;

select * from V;

SELECT *
INTO Cart2
FROM Cart;

drop table An_Order;
drop table cart;
drop table product;

delete from An_Order;
delete from cart;
delete from product;

insert into product (ProductID, ProductName, ProductPrice) values (1, 'Cheese lays chips', 7);
insert into product (ProductID, ProductName, ProductPrice)values (2, 'Cheetos flaming hot', 7);
insert into product(ProductID, ProductName, ProductPrice) values (3, 'Coffee', 15);
insert into product(ProductID, ProductName, ProductPrice) values (4, 'Orange Juice', 8);
insert into product (ProductID, ProductName, ProductPrice)values (5, 'Kabab lays chips', 7);
insert into product (ProductID, ProductName, ProductPrice)values (6, 'Lollipop', 3);
insert into product (ProductID, ProductName, ProductPrice)values (7, 'Strawberry gum', 9);
insert into product (ProductID, ProductName, ProductPrice)values (8, 'Vegetables Indomie', 7);
insert into product (ProductID, ProductName, ProductPrice) values (9, 'KitKat', 12);
insert into product (ProductID, ProductName, ProductPrice)values (10, 'Snickers', 14);
insert into product(ProductID, ProductName, ProductPrice) values (11, 'Kinder', 20);
insert into product(ProductID, ProductName, ProductPrice) values (12, 'OREO', 10);
insert into product (ProductID, ProductName, ProductPrice)values (13, 'CocaCola', 22);
insert into product (ProductID, ProductName, ProductPrice)values (14, 'CocaCola Can', 11);
insert into product (ProductID, ProductName, ProductPrice)values (15, 'CocaCola Glass', 15);
insert into product (ProductID, ProductName, ProductPrice)values (16, 'Doritos cheese', 10);
insert into product (ProductID, ProductName, ProductPrice)values (17, 'Doritos Black', 16);
insert into product (ProductID, ProductName, ProductPrice)values (18, ' Cheetos flaming hot lemon', 10);
insert into product (ProductID, ProductName, ProductPrice)values (19, ' Panditas', 18);
insert into product (ProductID, ProductName, ProductPrice)values (20, ' HARIBO Golden', 18);
insert into product (ProductID, ProductName, ProductPrice)values (21, ' Mini OREO', 21);
insert into product (ProductID, ProductName, ProductPrice)values (22, ' Noodels', 45);
insert into product (ProductID, ProductName, ProductPrice)values (23, ' Zero Pepsi', 19);
insert into product (ProductID, ProductName, ProductPrice)values (24, ' TODAY', 5);
insert into product (ProductID, ProductName, ProductPrice)values (25, ' HARIBO Berries', 12);
insert into product (ProductID, ProductName, ProductPrice)values (26, ' Trident', 10);
insert into product (ProductID, ProductName, ProductPrice)values (27, ' King Cone', 17);
insert into product (ProductID, ProductName, ProductPrice)values (28, ' Mocha', 26);
insert into product (ProductID, ProductName, ProductPrice)values (29, ' Korean Barbecue', 10);
insert into product (ProductID, ProductName, ProductPrice)values (30, ' lays salt and vinegar', 10);