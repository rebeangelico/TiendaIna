CREATE TABLE [dbo].[ProductsCategories]
(
	[ProductId] INT NOT NULL , 
    [CategoryId] INT NOT NULL, 
    PRIMARY KEY ([ProductId], [CategoryId]),
    CONSTRAINT [FK_ProductsCategories_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id]),
    CONSTRAINT [FK_ProductsCategories_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories]([Id])
)
