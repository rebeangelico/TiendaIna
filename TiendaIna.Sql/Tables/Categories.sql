CREATE TABLE [dbo].[Categories]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ParentCategoryId] INT NULL, 
    [Name] NVARCHAR(100) NOT NULL
    CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Categories]([Id])
)
