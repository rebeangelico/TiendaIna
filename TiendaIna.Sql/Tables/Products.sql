CREATE TABLE [dbo].[Products]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BrandId] INT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[DescriptionShort] NVARCHAR(200) NULL,
	[Price] DECIMAL(18, 2) NULL,
	[Stock] INT NULL,
	[IsOutstanding] bit NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands]([Id])
)
