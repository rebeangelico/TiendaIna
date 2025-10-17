CREATE TABLE [dbo].[ProductImages]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductId] INT NOT NULL,
	[ImageId] INT NOT NULL,
	[OrderIndex] INT NOT NULL DEFAULT(0),
	CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id]),
	CONSTRAINT [FK_ProductImages_Images] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Images]([Id]),
)
