/*####################################################################
  ## script to create FirbirdSql version of the Northwind test DB
  ####################################################################*/

/*DROP USER IF EXISTS 'LinqUser'@'%'; */
/*DELETE FROM mysql.user WHERE User='LinqUser';*/
/*DROP USER 'LinqUser'@'%';*/


/*## create user LinqUser, password: 'linq2'
CREATE USER 'LinqUser'@'%'
  IDENTIFIED BY PASSWORD '*247E8BFCE2F07F00D7FD773390A282540001077B';*/

/*## give our new user full permissions on new database:
GRANT ALL ON Northwind.*  TO 'LinqUser'@'%';
FLUSH PRIVILEGES;*/

DROP TRIGGER Trg_Orders_Insert;
DROP TRIGGER Trg_Employees_Insert;
DROP TRIGGER Trg_Shippers_Insert;
DROP TRIGGER Trg_Products_Insert;
DROP TRIGGER Trg_Suppliers_Insert;
DROP TRIGGER Trg_Categories_Insert;
DROP TRIGGER Trg_Region_Insert;

DROP GENERATOR Gen_Orders_OrderID;
DROP GENERATOR Gen_Employees_EmployeeID;
DROP GENERATOR Gen_Shippers_ShipperID;
DROP GENERATOR Gen_Products_ProductID;
DROP GENERATOR Gen_Suppliers_SupplierID;
DROP GENERATOR Gen_Categories_CategoryID;
DROP GENERATOR Gen_Region_RegionID;

DROP TABLE "Order Details";
DROP TABLE Orders;
DROP TABLE EmployeeTerritories;
DROP TABLE Employees;
DROP TABLE Shippers;
DROP TABLE Customers;
DROP TABLE Products;
DROP TABLE Suppliers;
DROP TABLE Categories;
DROP TABLE Territories;
DROP TABLE Region;

/*####################################################################
  ## create tables
  ####################################################################*/

CREATE TABLE Region (
  RegionID INTEGER NOT NULL,
  RegionDescription VARCHAR(50) NOT NULL,
  PRIMARY KEY(RegionID)
)
;

CREATE TABLE Territories (
  TerritoryID VARCHAR(20) NOT NULL,
  TerritoryDescription VARCHAR(50) NOT NULL,
  RegionID INTEGER NOT NULL,
  PRIMARY KEY(TerritoryID)
)
;

alter table Territories
   add constraint FK_Terr_Region foreign key (RegionID)
      references Region (RegionID);

/*####################################################################*/
CREATE TABLE Categories (
  CategoryID INTEGER  NOT NULL,
  CategoryName VARCHAR(15) NOT NULL,
  Description BLOB SUB_TYPE 1,
  Picture BLOB,
  PRIMARY KEY(CategoryID)
)
;

CREATE TABLE Suppliers (
  SupplierID INTEGER  NOT NULL,
  CompanyName VARCHAR(40) DEFAULT '' NOT NULL,
  ContactName VARCHAR(30),
  ContactTitle VARCHAR(30),
  Address VARCHAR(60),
  City VARCHAR(15),
  Region VARCHAR(15),
  PostalCode VARCHAR(10),
  Country VARCHAR(15),
  Phone VARCHAR(24),
  Fax VARCHAR(24),
  PRIMARY KEY(SupplierID)
)
;

/*####################################################################*/
CREATE TABLE Products (
  ProductID INTEGER NOT NULL,
  ProductName VARCHAR(40) DEFAULT '' NOT NULL,
  SupplierID INTEGER,
  CategoryID INTEGER,
  QuantityPerUnit VARCHAR(20),
  UnitPrice DECIMAL,
  UnitsInStock SMALLINT,
  UnitsOnOrder SMALLINT,
  ReorderLevel SMALLINT,
  Discontinued SMALLINT NOT NULL,
  PRIMARY KEY(ProductID)
);

alter table Products
   add constraint FK_prod_catg foreign key (CategoryID)
      references Categories (CategoryID);
alter table Products
   add constraint FK_prod_supp foreign key (SupplierID)
      references Suppliers (SupplierID);

/*####################################################################*/
CREATE TABLE Customers (
  CustomerID VARCHAR(5) NOT NULL,
  CompanyName VARCHAR(40) DEFAULT '' NOT NULL,
  ContactName VARCHAR(30),
  ContactTitle VARCHAR(30),
  Address VARCHAR(60),
  City VARCHAR(15),
  Region VARCHAR(15),
  PostalCode VARCHAR(10),
  Country VARCHAR(15),
  Phone VARCHAR(24),
  Fax VARCHAR(24),
  PRIMARY KEY(CustomerID)
)
;

/*####################################################################*/
CREATE TABLE Shippers (
  ShipperID INTEGER NOT NULL,
  CompanyName VARCHAR(40) NOT NULL,
  Phone VARCHAR(24),
  PRIMARY KEY(ShipperID)
)
;

/*####################################################################*/
CREATE TABLE Employees (
  EmployeeID INTEGER NOT NULL,
  LastName VARCHAR(20) NOT NULL,
  FirstName VARCHAR(10) NOT NULL,
  Title VARCHAR(30),
  BirthDate TIMESTAMP,
  HireDate TIMESTAMP,
  Address VARCHAR(60),
  City VARCHAR(15),
  Region VARCHAR(15),
  PostalCode VARCHAR(10),
  Country VARCHAR(15),
  HomePhone VARCHAR(24),
  Photo BLOB,
  Notes BLOB SUB_TYPE 1,
  TitleOfCourtesy VARCHAR(25),
  PhotoPath VARCHAR (255),
  Extension VARCHAR(5),
  ReportsTo INTEGER,
  PRIMARY KEY(EmployeeID)
)
;

alter table Employees
   add constraint FK_Emp_ReportsToEmp foreign key (ReportsTo)
      references Employees (EmployeeID);

/*####################################################################*/
CREATE TABLE EmployeeTerritories (
  EmployeeID INTEGER NOT NULL,
  TerritoryID VARCHAR(20) NOT NULL,
  PRIMARY KEY(EmployeeID,TerritoryID)
)
;

alter table EmployeeTerritories
   add constraint FK_empTerr_emp foreign key (EmployeeID)
      references Employees (EmployeeID);
alter table EmployeeTerritories
   add constraint FK_empTerr_terr foreign key (TerritoryID)
      references Territories (TerritoryID);


/*####################################################################*/
CREATE TABLE Orders (
  OrderID INTEGER NOT NULL,
  CustomerID VARCHAR(5),
  EmployeeID INTEGER,
  OrderDate TIMESTAMP,
  RequiredDate TIMESTAMP,
  ShippedDate TIMESTAMP,
  ShipVia INTEGER,
  Freight DECIMAL,
  ShipName VARCHAR(40),
  ShipAddress VARCHAR(60),
  ShipCity VARCHAR(15),
  ShipRegion VARCHAR(15),
  ShipPostalCode VARCHAR(10),
  ShipCountry VARCHAR(15),
  PRIMARY KEY(OrderID)
)
;

alter table Orders
   add constraint FK_orders_cust foreign key (CustomerID)
      references Customers (CustomerID);
alter table Orders
   add constraint FK_orders_emp foreign key (EmployeeID)
      references Employees (EmployeeID);
alter table Orders
   add constraint FK_orders_ship foreign key (ShipVia)
      references Shippers (ShipperID);

/*####################################################################*/
CREATE TABLE "Order Details" (
  OrderID INTEGER NOT NULL,
  ProductID INTEGER NOT NULL,
  UnitPrice DECIMAL NOT NULL,
  Quantity SMALLINT NOT NULL,
  Discount FLOAT NOT NULL,
  PRIMARY KEY(OrderID,ProductID)
)
;

alter table "Order Details"
   add constraint FK_orderDet_ord foreign key (OrderID)
      references Orders (OrderID);
alter table "Order Details"
   add constraint FK_orderDet_prod foreign key (ProductID)
      references Products (ProductID);

CREATE GENERATOR Gen_Region_RegionID;

SET TERM ^ ;
CREATE TRIGGER Trg_Region_Insert for Region
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.RegionID = GEN_ID(GEN_Region_RegionID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Categories_CategoryID;

SET TERM ^ ;
CREATE TRIGGER Trg_Categories_Insert for Categories
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.CategoryID = GEN_ID(Gen_Categories_CategoryID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Suppliers_SupplierID;

SET TERM ^ ;
CREATE TRIGGER Trg_Suppliers_Insert for Suppliers
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.SupplierID = GEN_ID(Gen_Suppliers_SupplierID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Products_ProductID;

SET TERM ^ ;
CREATE TRIGGER Trg_Products_Insert for Products
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.ProductID = GEN_ID(Gen_Products_ProductID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Shippers_ShipperID;

SET TERM ^ ;
CREATE TRIGGER Trg_Shippers_Insert for Shippers
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.ShipperID = GEN_ID(Gen_Shippers_ShipperID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Employees_EmployeeID;

SET TERM ^ ;
CREATE TRIGGER Trg_Employees_Insert for Employees
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.EmployeeID = GEN_ID(Gen_Employees_EmployeeID, 1);
END^
SET TERM ; ^


CREATE GENERATOR Gen_Orders_OrderID;

SET TERM ^ ;
CREATE TRIGGER Trg_Orders_Insert for Orders
    ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
    NEW.OrderID = GEN_ID(Gen_Orders_OrderID, 1);
END^
SET TERM ; ^











/*####################################################################
  ## populate tables with seed data
  ####################################################################*/
set generator Gen_Region_RegionID to 0;
set generator Gen_Categories_CategoryID to 0;
set generator Gen_Suppliers_SupplierID to 0;
set generator Gen_Products_ProductID to 0;
set generator Gen_Shippers_ShipperID to 0;
set generator Gen_Employees_EmployeeID to 0;
set generator Gen_Orders_OrderID to 0;

