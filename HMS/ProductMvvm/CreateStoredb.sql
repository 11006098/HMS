USE [master]
GO

/****** Object:  Database [storedb]    Script Date: 07/29/2010 10:51:09 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'xstoredb')
DROP DATABASE [xstoredb]
GO

USE [master]
GO

/****** Object:  Database [storedb]    Script Date: 07/29/2010 10:51:09 ******/
CREATE DATABASE [xstoredb];
GO


USE [xstoredb]
GO

CREATE TYPE T_smallstring FROM varchar(50)
CREATE TYPE T_medstring FROM varchar(200)
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [T_smallstring] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
	([CategoryID] ASC)
)
GO

 CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ModelNumber] [T_smallstring] NOT NULL UNIQUE,
	[ModelName] [T_smallstring] NOT NULL UNIQUE,
	[UnitCost] [money] NULL,
	[Description] [T_medstring] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
	([ProductID] ASC),
);

ALTER TABLE dbo.Products
	ADD CONSTRAINT [FK_Products_Categories]
	FOREIGN KEY(CategoryID)
	REFERENCES dbo.Categories(CategoryID);

GO


CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
    SELECT C.CategoryName, P.ProductId, P.ModelNumber, P.ModelName, P.UnitCost, P.Description
    From dbo.Products AS P
	JOIN dbo.Categories AS C
	  ON P.CategoryID = C.CategoryID
END
GO


CREATE PROCEDURE [dbo].[UpdateProduct]
(
  @ProductId int,
  @CategoryName nvarchar(50),
  @ModelNumber nvarchar(50),
  @ModelName nvarchar(50),
  @UnitCost money,
  @Description nvarchar(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
    IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName=@CategoryName)
    BEGIN
        INSERT INTO dbo.Categories (CategoryName) VALUES (@CategoryName)
    END
    UPDATE dbo.Products
    SET ModelNumber=@ModelNumber,
		ModelName=@ModelName, UnitCost=@UnitCost, Description=@Description,
		CategoryID=(SELECT CategoryID FROM dbo.Categories WHERE CategoryName=@CategoryName)
	WHERE ProductId=@ProductId
	COMMIT TRANSACTION    
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
		ROLLBACK
END CATCH
GO

CREATE PROCEDURE [dbo].[DeleteProduct]
(
  @ProductId int
 )
AS
BEGIN TRY
    BEGIN TRANSACTION
	DECLARE @CatId int
	SET @CatId = (SELECT CategoryID FROM Products WHERE @ProductId=ProductId);
	IF @CatId IS NOT NULL
	    BEGIN
			DELETE FROM dbo.Products WHERE ProductId = @ProductId;
			IF (SELECT COUNT(*) FROM dbo.Products WHERE CategoryID = @CatId) = 0
				DELETE FROM dbo.Categories WHERE CategoryID = @CatId;
	    END
	COMMIT	    
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    ROLLBACK
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
           @ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH
GO

--DROP PROC AddProduct
--GO
CREATE PROCEDURE [dbo].[AddProduct]
(
  @CategoryName nvarchar(50),
  @ModelNumber nvarchar(50),
  @ModelName nvarchar(50),
  @UnitCost money,
  @Description nvarchar(200),
  @ProductId int OUTPUT
)
AS
BEGIN TRY
	BEGIN TRANSACTION
    IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName=@CategoryName)
    BEGIN
        INSERT INTO dbo.Categories (CategoryName) VALUES (@CategoryName);
    END

    DECLARE @CatID int
    SET @CatID = (SELECT CategoryID FROM dbo.Categories WHERE CategoryName=@CategoryName);
    INSERT dbo.Products (CategoryID, ModelNumber, ModelName, UnitCost, Description) 
    VALUES (@CatID, @ModelNumber, @ModelName, @UnitCost, @Description );
    COMMIT TRANSACTION
    SET @ProductId = SCOPE_IDENTITY();
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    ROLLBACK
    -- Raise an error with the details of the exception
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
           @ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH

GO


