USE [Supermarket]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ProducerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[OriginCountry] [nvarchar](20) NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[ProducerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Barcode] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ProducerID] [int] NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReceipt]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReceipt](
	[ProductReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_ProductReceipt] PRIMARY KEY CLUSTERED 
(
	[ProductReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[CashierID] [int] NOT NULL,
	[IssueDate] [date] NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitOfMeasure] [nvarchar](10) NOT NULL,
	[SupplyDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[PurchasePrice] [decimal](18, 4) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[UserType] [nvarchar](20) NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Producer] FOREIGN KEY([ProducerID])
REFERENCES [dbo].[Producer] ([ProducerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Producer]
GO
ALTER TABLE [dbo].[ProductReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ProductReceipt_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductReceipt] CHECK CONSTRAINT [FK_ProductReceipt_Product]
GO
ALTER TABLE [dbo].[ProductReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ProductReceipt_Receipt] FOREIGN KEY([ReceiptID])
REFERENCES [dbo].[Receipt] ([ReceiptID])
GO
ALTER TABLE [dbo].[ProductReceipt] CHECK CONSTRAINT [FK_ProductReceipt_Receipt]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Cashier] FOREIGN KEY([CashierID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Cashier]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory] 
	@name NVARCHAR(30),
	@categoryID int output
AS
BEGIN 
	INSERT INTO [Category]([Name]) values(@name)
	select @categoryID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddProducer]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProducer]
	@name nvarchar(20),
	@originCountry	nvarchar(20),
	@producerID int output
AS 
BEGIN 
insert into [Producer]([Name], [OriginCountry]) values(@name, @originCountry)
	select @producerID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct] 
	@name nvarchar(30), 
	@barcode nvarchar(50),
	@categoryID int,
	@producerID int,
	@productID int output
AS 
BEGIN 
	insert into [Product]([Name], [Barcode],[CategoryID],[ProducerID]) values(@name, @barcode,@categoryID,@producerID)
	select @productID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddProductReceipt]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddProductReceipt]
	@receiptID int,
	@productID int,
	@quantity int,
	@subtotal decimal,
	@productReceiptID int out
AS
BEGIN 
	insert into [ProductReceipt]([ReceiptID], [ProductID],[Quantity],[Subtotal]) values(@receiptID, @productID,@quantity,@subtotal)
	select @productReceiptID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddReceipt]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddReceipt]
	@cashierID int,
	@issueDate date,
	@totalAmount decimal,
	@receiptID int out
AS
BEGIN 
	insert into [Receipt]([CashierID], [IssueDate],[TotalAmount]) values(@cashierID, @issueDate,@totalAmount)
	select @receiptID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@username NVARCHAR(30),
	@password NVARCHAR(20),
	@userType NVARCHAR(20),
	@userID int output 
AS 
BEGIN 
	insert into [User]([Username], [Password],[UserType]) values(@username, @password,@userType)
	select @userID=SCOPE_IDENTITY()
END
	 
	
GO
/****** Object:  StoredProcedure [dbo].[DeleteProducer]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProducer]
	@producerID int
AS 
BEGIN 
UPDATE [Producer]
	SET isDeleted=1
	WHERE [ProducerID]=@producerID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@userID int 
AS 
BEGIN
	UPDATE [User]
	SET isDeleted=1
	WHERE [UserID]=@userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCashiers]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCashiers]
AS
BEGIN 
	SELECT [UserID], [Username], [Password], [Usertype] from dbo.[User]
	WHERE [UserType]='Cashier'
END
			
	
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategories] 

AS 
BEGIN 
	SELECT CategoryID, [Name] from [Category]
	WHERE isDeleted is NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducers]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducers]
AS 
BEGIN 
SELECT ProducerID, [Name], [OriginCountry],[isDeleted] FROM [Producer]
	WHERE [isDeleted] IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts] 
AS
BEGIN 
SELECT prod.ProductID,prod.Name,prod.Barcode,c.CategoryID,c.Name,p.ProducerID,p.Name,p.OriginCountry FROM Product prod
INNER JOIN Producer p ON prod.ProducerID=p.ProducerID
INNER JOIN Category c ON prod.CategoryID=c.CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStocks]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllStocks]
	
As
Begin 
	Select StockID, ProductID, Quantity, UnitOfMeasure, SupplyDate, ExpirationDate, PurchasePrice, SellingPrice from Stock
	WHERE [isDeleted] is NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllUsers]
AS
BEGIN
SELECT UserID, [Username], [Password],[UserType],[isDeleted] FROM [User]
	WHERE [isDeleted] IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetLargestReceipt]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLargestReceipt]
    @date DATE
AS
BEGIN
    SELECT TOP 1 
        r.ReceiptID,
        r.CashierID,
        r.IssueDate,
        r.TotalAmount 
    FROM 
        Receipt r
    WHERE 
        CAST(r.IssueDate AS DATE) = @date
    ORDER BY 
        r.TotalAmount DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByID]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetProductByID]
	@productID int
As
Begin 
	SELECT prod.Name,prod.Barcode,c.CategoryID,c.Name,p.ProducerID,p.Name,p.OriginCountry FROM Product prod
INNER JOIN Producer p ON prod.ProducerID=p.ProducerID
INNER JOIN Category c ON prod.CategoryID=c.CategoryID
Where prod.ProductID=@productID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByReceiptID]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByReceiptID]
    @receiptID int
AS
BEGIN
    SELECT 
        pr.ProductReceiptID,
        pr.ProductID,
        pr.ReceiptID,
        pr.Subtotal,
        pr.Quantity
    FROM 
        ProductReceipt pr
    WHERE 
        pr.ReceiptID = @receiptID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByProducer]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProductsByProducer]
	@producerID int
AS
BEGIN 
	SELECT prod.ProductID,prod.Name,prod.Barcode,c.CategoryID,c.Name,p.ProducerID,p.Name,p.OriginCountry FROM Product prod
INNER JOIN Producer p ON prod.ProducerID=p.ProducerID
INNER JOIN Category c ON prod.CategoryID=c.CategoryID
WHERE prod.ProducerID=@producerID
END
GO
/****** Object:  StoredProcedure [dbo].[GetTotalAmountPerDayUser]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTotalAmountPerDayUser]
	@cashierID int,
	@date DATE
AS
BEGIN 
	SELECT r.IssueDate, SUM(pr.Subtotal) from Receipt r
	JOIN ProductReceipt pr ON r.ReceiptID=pr.ReceiptID
	WHERE
		r.CashierID=@cashierID AND MONTH(r.IssueDate)=MONTH(@date) AND YEAR(r.IssueDate)=YEAR(@date)
	GROUP BY r.IssueDate
	ORDER BY r.IssueDate
END
			
	
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategory] 
	@categoryID int,
	@name NVARCHAR(30)
AS
BEGIN 
	UPDATE [Category]
	set [Name]=@name
	where [CategoryID]=@categoryID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducer]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProducer]
	@producerID int,
	@name nvarchar(20),
	@originCountry nvarchar(20)
AS 
BEGIN 
update [Producer]
	set [Name]=@name,
		[OriginCountry]=@originCountry
	where [ProducerID]=@producerID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateStock]
	@stockID int,
	@quantity int
AS
BEGIN 
	DECLARE @CurrentQuantity INT;
	
	SELECT @CurrentQuantity = [Quantity]
    FROM Stock
    WHERE [StockID] = @stockID;
    
	SET @CurrentQuantity = @CurrentQuantity - @Quantity;
	
	UPDATE Stock
    SET [Quantity] = @CurrentQuantity
    WHERE [StockID] = @StockID;
	IF @CurrentQuantity = 0
    BEGIN
        UPDATE Stock
        SET [isDeleted] = 1
        WHERE [StockID] = @stockID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStockQuantity]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateStockQuantity]
	@stockID int,
	@quantity int
AS
BEGIN 
	DECLARE @CurrentQuantity INT;
	
	SELECT @CurrentQuantity = [Quantity]
    FROM Stock
    WHERE [StockID] = @stockID;
    
	SET @CurrentQuantity = @CurrentQuantity - @Quantity;
	
	UPDATE Stock
    SET [Quantity] = @CurrentQuantity
    WHERE [StockID] = @StockID;
	IF @CurrentQuantity = 0
    BEGIN
        UPDATE Stock
        SET [isDeleted] = 1
        WHERE [StockID] = @stockID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@userID int,
	@username NVARCHAR(30),
	@password NVARCHAR(20),
	@userType NVARCHAR(20)
AS
BEGIN 
	update [User]
	set [Username]=@username,
		[Password]=@password,
		[UserType]=@userType
	where [UserID]=@userID
END
GO
/****** Object:  StoredProcedure [dbo].[UserAuthentication]    Script Date: 6/3/2024 11:00:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserAuthentication]
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [UserID],[UserType]
    FROM [User]
    WHERE [Username] = @username AND [Password] = @password;

END
GO
