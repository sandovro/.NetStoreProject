CREATE TABLE Costumers(
	costumerId int PRIMARY KEY,
	costumerName varchar(50),
	costumerNumber varchar(50),
	costumerAddress varchar(50),
	costumerEmail varchar(50)
)

CREATE TABLE Products(
	productId int PRIMARY KEY,
	productName varchar(50),
	productPrice float,
	productDescription tinytext,
	productCategory varchar(50)
)

CREATE TABLE Stores(
	storeNumber int PRIMARY KEY,
	storeName varchar(50),
	storeAddress varchar(50)
)

CREATE TABLE Orders(
	orderNumber int PRIMARY KEY,
	costumerId int FOREIGN KEY REFERENCES Costumers(costumerId), --Foreign key reflecting costumerId or storeNumber
	storeNumber int FOREIGN KEY REFERENCES Stores(storeNumber),
	productId int FOREIGN KEY REFERENCES Products (productId)
)

CREATE TABLE LineItems(
	storeNumber int FOREIGN KEY REFERENCES Stores(storeNumber), -- Foreign key
	productId int FOREIGN KEY REFERENCES Products(productId), -- Foreign key
	quantity int
)