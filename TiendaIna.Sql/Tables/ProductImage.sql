CREATE TABLE [dbo].[ProductImages]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] INT NOT NULL,
	[OrderIndex] INT NOT NULL DEFAULT(0),
	[Data] VARBINARY(MAX) NULL, 
    [CdnUrl] NVARCHAR(1000) NULL, 
    [SmallData] VARBINARY(MAX) NULL, 
    [SmallCdnUrl] NVARCHAR(1000) NULL, 
    [MimeType] VARCHAR(100) NULL
	CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id]),
)
