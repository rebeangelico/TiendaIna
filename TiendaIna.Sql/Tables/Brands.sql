CREATE TABLE [dbo].[Brands]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ImageId] INT NULL,
    [Name] VARCHAR(100) NOT NULL,
    CONSTRAINT [FK_Brands_Image] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Images]([Id])
)
