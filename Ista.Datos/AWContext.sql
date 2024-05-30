IF SCHEMA_ID(N'SalesLT') IS NULL EXEC(N'CREATE SCHEMA [SalesLT];');
GO


CREATE TABLE [SalesLT].[Address] (
    [AddressID] int NOT NULL IDENTITY,
    [AddressLine1] nvarchar(60) NOT NULL,
    [AddressLine2] nvarchar(60) NOT NULL,
    [City] nvarchar(30) NOT NULL,
    [StateProvince] nvarchar(50) NOT NULL,
    [CountryRegion] nvarchar(50) NOT NULL,
    [PostalCode] nvarchar(15) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_Address_AddressID] PRIMARY KEY ([AddressID])
);
DECLARE @description AS sql_variant;
SET @description = N'Street address information for customers.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address';
SET @description = N'Primary key for Address records.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'AddressID';
SET @description = N'First street address line.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'AddressLine1';
SET @description = N'Second street address line.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'AddressLine2';
SET @description = N'Name of the city.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'City';
SET @description = N'Name of state or province.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'StateProvince';
SET @description = N'Postal code for the street address.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'PostalCode';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Address', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[Customer] (
    [CustomerID] int NOT NULL IDENTITY,
    [NameStyle] bit NOT NULL,
    [Title] nvarchar(8) NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Suffix] nvarchar(10) NOT NULL,
    [CompanyName] nvarchar(128) NOT NULL,
    [SalesPerson] nvarchar(256) NOT NULL,
    [EmailAddress] nvarchar(50) NOT NULL,
    [Phone] nvarchar(25) NOT NULL,
    [PasswordHash] varchar(128) NOT NULL,
    [PasswordSalt] varchar(10) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_Customer_CustomerID] PRIMARY KEY ([CustomerID])
);
DECLARE @description AS sql_variant;
SET @description = N'Customer information.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer';
SET @description = N'Primary key for Customer records.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'CustomerID';
SET @description = N'0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'NameStyle';
SET @description = N'A courtesy title. For example, Mr. or Ms.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'Title';
SET @description = N'First name of the person.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'FirstName';
SET @description = N'Middle name or middle initial of the person.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'MiddleName';
SET @description = N'Last name of the person.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'LastName';
SET @description = N'Surname suffix. For example, Sr. or Jr.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'Suffix';
SET @description = N'The customer''s organization.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'CompanyName';
SET @description = N'The customer''s sales person, an employee of AdventureWorks Cycles.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'SalesPerson';
SET @description = N'E-mail address for the person.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'EmailAddress';
SET @description = N'Phone number associated with the person.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'Phone';
SET @description = N'Password for the e-mail account.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'PasswordHash';
SET @description = N'Random value concatenated with the password string before the password is hashed.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'PasswordSalt';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Customer', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[ProductCategory] (
    [ProductCategoryID] int NOT NULL IDENTITY,
    [ParentProductCategoryID] int NULL,
    [Name] nvarchar(50) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_ProductCategory_ProductCategoryID] PRIMARY KEY ([ProductCategoryID]),
    CONSTRAINT [FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID] FOREIGN KEY ([ParentProductCategoryID]) REFERENCES [SalesLT].[ProductCategory] ([ProductCategoryID])
);
DECLARE @description AS sql_variant;
SET @description = N'High-level product categorization.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory';
SET @description = N'Primary key for ProductCategory records.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory', 'COLUMN', N'ProductCategoryID';
SET @description = N'Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory', 'COLUMN', N'ParentProductCategoryID';
SET @description = N'Category description.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory', 'COLUMN', N'Name';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductCategory', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[ProductDescription] (
    [ProductDescriptionID] int NOT NULL IDENTITY,
    [Description] nvarchar(400) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_ProductDescription_ProductDescriptionID] PRIMARY KEY ([ProductDescriptionID])
);
DECLARE @description AS sql_variant;
SET @description = N'Product descriptions in several languages.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductDescription';
SET @description = N'Primary key for ProductDescription records.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductDescription', 'COLUMN', N'ProductDescriptionID';
SET @description = N'Description of the product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductDescription', 'COLUMN', N'Description';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductDescription', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductDescription', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[ProductModel] (
    [ProductModelID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [CatalogDescription] xml NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_ProductModel_ProductModelID] PRIMARY KEY ([ProductModelID])
);
GO


CREATE TABLE [SalesLT].[CustomerAddress] (
    [CustomerID] int NOT NULL,
    [AddressID] int NOT NULL,
    [AddressType] nvarchar(50) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_CustomerAddress_CustomerID_AddressID] PRIMARY KEY ([CustomerID], [AddressID]),
    CONSTRAINT [FK_CustomerAddress_Address_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [SalesLT].[Address] ([AddressID]),
    CONSTRAINT [FK_CustomerAddress_Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [SalesLT].[Customer] ([CustomerID])
);
DECLARE @description AS sql_variant;
SET @description = N'Cross-reference table mapping customers to their address(es).';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress';
SET @description = N'Primary key. Foreign key to Customer.CustomerID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress', 'COLUMN', N'CustomerID';
SET @description = N'Primary key. Foreign key to Address.AddressID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress', 'COLUMN', N'AddressID';
SET @description = N'The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress', 'COLUMN', N'AddressType';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'CustomerAddress', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[SalesOrderHeader] (
    [SalesOrderID] int NOT NULL IDENTITY,
    [RevisionNumber] tinyint NOT NULL,
    [OrderDate] datetime NOT NULL DEFAULT ((getdate())),
    [DueDate] datetime NOT NULL,
    [ShipDate] datetime NULL,
    [Status] tinyint NOT NULL DEFAULT CAST(1 AS tinyint),
    [OnlineOrderFlag] bit NOT NULL DEFAULT CAST(1 AS bit),
    [SalesOrderNumber] AS (isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***')),
    [PurchaseOrderNumber] nvarchar(25) NOT NULL,
    [AccountNumber] nvarchar(15) NOT NULL,
    [CustomerID] int NOT NULL,
    [ShipToAddressID] int NULL,
    [BillToAddressID] int NULL,
    [ShipMethod] nvarchar(50) NOT NULL,
    [CreditCardApprovalCode] varchar(15) NOT NULL,
    [SubTotal] money NOT NULL,
    [TaxAmt] money NOT NULL,
    [Freight] money NOT NULL,
    [TotalDue] AS (isnull(([SubTotal]+[TaxAmt])+[Freight],(0))),
    [Comment] nvarchar(max) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_SalesOrderHeader_SalesOrderID] PRIMARY KEY ([SalesOrderID]),
    CONSTRAINT [FK_SalesOrderHeader_Address_BillTo_AddressID] FOREIGN KEY ([BillToAddressID]) REFERENCES [SalesLT].[Address] ([AddressID]),
    CONSTRAINT [FK_SalesOrderHeader_Address_ShipTo_AddressID] FOREIGN KEY ([ShipToAddressID]) REFERENCES [SalesLT].[Address] ([AddressID]),
    CONSTRAINT [FK_SalesOrderHeader_Customer_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [SalesLT].[Customer] ([CustomerID])
);
DECLARE @description AS sql_variant;
SET @description = N'General sales order information.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader';
SET @description = N'Primary key.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'SalesOrderID';
SET @description = N'Incremental number to track changes to the sales order over time.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'RevisionNumber';
SET @description = N'Dates the sales order was created.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'OrderDate';
SET @description = N'Date the order is due to the customer.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'DueDate';
SET @description = N'Date the order was shipped to the customer.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'ShipDate';
SET @description = N'Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'Status';
SET @description = N'0 = Order placed by sales person. 1 = Order placed online by customer.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'OnlineOrderFlag';
SET @description = N'Unique sales order identification number.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'SalesOrderNumber';
SET @description = N'Customer purchase order number reference. ';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'PurchaseOrderNumber';
SET @description = N'Financial accounting number reference.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'AccountNumber';
SET @description = N'Customer identification number. Foreign key to Customer.CustomerID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'CustomerID';
SET @description = N'The ID of the location to send goods.  Foreign key to the Address table.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'ShipToAddressID';
SET @description = N'The ID of the location to send invoices.  Foreign key to the Address table.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'BillToAddressID';
SET @description = N'Shipping method. Foreign key to ShipMethod.ShipMethodID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'ShipMethod';
SET @description = N'Approval code provided by the credit card company.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'CreditCardApprovalCode';
SET @description = N'Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'SubTotal';
SET @description = N'Tax amount.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'TaxAmt';
SET @description = N'Shipping cost.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'Freight';
SET @description = N'Total due from customer. Computed as Subtotal + TaxAmt + Freight.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'TotalDue';
SET @description = N'Sales representative comments.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'Comment';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderHeader', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[Product] (
    [ProductID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [ProductNumber] nvarchar(25) NOT NULL,
    [Color] nvarchar(15) NOT NULL,
    [StandardCost] money NOT NULL,
    [ListPrice] money NOT NULL,
    [Size] nvarchar(5) NOT NULL,
    [Weight] decimal(8,2) NULL,
    [ProductCategoryID] int NULL,
    [ProductModelID] int NULL,
    [SellStartDate] datetime NOT NULL,
    [SellEndDate] datetime NULL,
    [DiscontinuedDate] datetime NULL,
    [ThumbNailPhoto] varbinary(max) NOT NULL,
    [ThumbnailPhotoFileName] nvarchar(50) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_Product_ProductID] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Product_ProductCategory_ProductCategoryID] FOREIGN KEY ([ProductCategoryID]) REFERENCES [SalesLT].[ProductCategory] ([ProductCategoryID]),
    CONSTRAINT [FK_Product_ProductModel_ProductModelID] FOREIGN KEY ([ProductModelID]) REFERENCES [SalesLT].[ProductModel] ([ProductModelID])
);
DECLARE @description AS sql_variant;
SET @description = N'Products sold or used in the manfacturing of sold products.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product';
SET @description = N'Primary key for Product records.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ProductID';
SET @description = N'Name of the product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'Name';
SET @description = N'Unique product identification number.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ProductNumber';
SET @description = N'Product color.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'Color';
SET @description = N'Standard cost of the product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'StandardCost';
SET @description = N'Selling price.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ListPrice';
SET @description = N'Product size.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'Size';
SET @description = N'Product weight.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'Weight';
SET @description = N'Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. ';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ProductCategoryID';
SET @description = N'Product is a member of this product model. Foreign key to ProductModel.ProductModelID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ProductModelID';
SET @description = N'Date the product was available for sale.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'SellStartDate';
SET @description = N'Date the product was no longer available for sale.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'SellEndDate';
SET @description = N'Date the product was discontinued.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'DiscontinuedDate';
SET @description = N'Small image of the product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ThumbNailPhoto';
SET @description = N'Small image file name.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ThumbnailPhotoFileName';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'Product', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[ProductModelProductDescription] (
    [ProductModelID] int NOT NULL,
    [ProductDescriptionID] int NOT NULL,
    [Culture] nchar(6) NOT NULL,
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture] PRIMARY KEY ([ProductModelID], [ProductDescriptionID], [Culture]),
    CONSTRAINT [FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID] FOREIGN KEY ([ProductDescriptionID]) REFERENCES [SalesLT].[ProductDescription] ([ProductDescriptionID]),
    CONSTRAINT [FK_ProductModelProductDescription_ProductModel_ProductModelID] FOREIGN KEY ([ProductModelID]) REFERENCES [SalesLT].[ProductModel] ([ProductModelID])
);
DECLARE @description AS sql_variant;
SET @description = N'Cross-reference table mapping product descriptions and the language the description is written in.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductModelProductDescription';
SET @description = N'Primary key. Foreign key to ProductModel.ProductModelID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductModelProductDescription', 'COLUMN', N'ProductModelID';
SET @description = N'Primary key. Foreign key to ProductDescription.ProductDescriptionID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductModelProductDescription', 'COLUMN', N'ProductDescriptionID';
SET @description = N'The culture for which the description is written';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductModelProductDescription', 'COLUMN', N'Culture';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'ProductModelProductDescription', 'COLUMN', N'ModifiedDate';
GO


CREATE TABLE [SalesLT].[SalesOrderDetail] (
    [SalesOrderID] int NOT NULL,
    [SalesOrderDetailID] int NOT NULL IDENTITY,
    [OrderQty] smallint NOT NULL,
    [ProductID] int NOT NULL,
    [UnitPrice] money NOT NULL,
    [UnitPriceDiscount] money NOT NULL,
    [LineTotal] AS (isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))),
    [rowguid] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [ModifiedDate] datetime NOT NULL DEFAULT ((getdate())),
    CONSTRAINT [PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID] PRIMARY KEY ([SalesOrderID], [SalesOrderDetailID]),
    CONSTRAINT [FK_SalesOrderDetail_Product_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [SalesLT].[Product] ([ProductID]),
    CONSTRAINT [FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID] FOREIGN KEY ([SalesOrderID]) REFERENCES [SalesLT].[SalesOrderHeader] ([SalesOrderID]) ON DELETE CASCADE
);
DECLARE @description AS sql_variant;
SET @description = N'Individual products associated with a specific sales order. See SalesOrderHeader.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail';
SET @description = N'Primary key. Foreign key to SalesOrderHeader.SalesOrderID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'SalesOrderID';
SET @description = N'Primary key. One incremental unique number per product sold.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'SalesOrderDetailID';
SET @description = N'Quantity ordered per product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'OrderQty';
SET @description = N'Product sold to customer. Foreign key to Product.ProductID.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'ProductID';
SET @description = N'Selling price of a single product.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'UnitPrice';
SET @description = N'Discount amount.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'UnitPriceDiscount';
SET @description = N'Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'LineTotal';
SET @description = N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'rowguid';
SET @description = N'Date and time the record was last updated.';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'SalesLT', 'TABLE', N'SalesOrderDetail', 'COLUMN', N'ModifiedDate';
GO


CREATE UNIQUE INDEX [AK_Address_rowguid] ON [SalesLT].[Address] ([rowguid]);
GO


CREATE INDEX [IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion] ON [SalesLT].[Address] ([AddressLine1], [AddressLine2], [City], [StateProvince], [PostalCode], [CountryRegion]);
GO


CREATE INDEX [IX_Address_StateProvince] ON [SalesLT].[Address] ([StateProvince]);
GO


CREATE UNIQUE INDEX [AK_Customer_rowguid] ON [SalesLT].[Customer] ([rowguid]);
GO


CREATE INDEX [IX_Customer_EmailAddress] ON [SalesLT].[Customer] ([EmailAddress]);
GO


CREATE UNIQUE INDEX [AK_CustomerAddress_rowguid] ON [SalesLT].[CustomerAddress] ([rowguid]);
GO


CREATE INDEX [IX_CustomerAddress_AddressID] ON [SalesLT].[CustomerAddress] ([AddressID]);
GO


CREATE UNIQUE INDEX [AK_Product_Name] ON [SalesLT].[Product] ([Name]);
GO


CREATE UNIQUE INDEX [AK_Product_ProductNumber] ON [SalesLT].[Product] ([ProductNumber]);
GO


CREATE UNIQUE INDEX [AK_Product_rowguid] ON [SalesLT].[Product] ([rowguid]);
GO


CREATE INDEX [IX_Product_ProductCategoryID] ON [SalesLT].[Product] ([ProductCategoryID]);
GO


CREATE INDEX [IX_Product_ProductModelID] ON [SalesLT].[Product] ([ProductModelID]);
GO


CREATE UNIQUE INDEX [AK_ProductCategory_Name] ON [SalesLT].[ProductCategory] ([Name]);
GO


CREATE UNIQUE INDEX [AK_ProductCategory_rowguid] ON [SalesLT].[ProductCategory] ([rowguid]);
GO


CREATE INDEX [IX_ProductCategory_ParentProductCategoryID] ON [SalesLT].[ProductCategory] ([ParentProductCategoryID]);
GO


CREATE UNIQUE INDEX [AK_ProductDescription_rowguid] ON [SalesLT].[ProductDescription] ([rowguid]);
GO


CREATE UNIQUE INDEX [AK_ProductModel_Name] ON [SalesLT].[ProductModel] ([Name]);
GO


CREATE UNIQUE INDEX [AK_ProductModel_rowguid] ON [SalesLT].[ProductModel] ([rowguid]);
GO


CREATE INDEX [PXML_ProductModel_CatalogDescription] ON [SalesLT].[ProductModel] ([CatalogDescription]);
GO


CREATE UNIQUE INDEX [AK_ProductModelProductDescription_rowguid] ON [SalesLT].[ProductModelProductDescription] ([rowguid]);
GO


CREATE INDEX [IX_ProductModelProductDescription_ProductDescriptionID] ON [SalesLT].[ProductModelProductDescription] ([ProductDescriptionID]);
GO


CREATE UNIQUE INDEX [AK_SalesOrderDetail_rowguid] ON [SalesLT].[SalesOrderDetail] ([rowguid]);
GO


CREATE INDEX [IX_SalesOrderDetail_ProductID] ON [SalesLT].[SalesOrderDetail] ([ProductID]);
GO


CREATE UNIQUE INDEX [AK_SalesOrderHeader_rowguid] ON [SalesLT].[SalesOrderHeader] ([rowguid]);
GO


CREATE UNIQUE INDEX [AK_SalesOrderHeader_SalesOrderNumber] ON [SalesLT].[SalesOrderHeader] ([SalesOrderNumber]);
GO


CREATE INDEX [IX_SalesOrderHeader_BillToAddressID] ON [SalesLT].[SalesOrderHeader] ([BillToAddressID]);
GO


CREATE INDEX [IX_SalesOrderHeader_CustomerID] ON [SalesLT].[SalesOrderHeader] ([CustomerID]);
GO


CREATE INDEX [IX_SalesOrderHeader_ShipToAddressID] ON [SalesLT].[SalesOrderHeader] ([ShipToAddressID]);
GO