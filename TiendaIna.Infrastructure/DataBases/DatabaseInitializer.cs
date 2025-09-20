using Microsoft.Data.SqlClient;


namespace TiendaIna.Infrastructure.DataBases {
    public class DatabaseInitializer {
        public void CreateCategoryTable(string connectionString) {
            var query = @"CREATE TABLE [dbo].[Category] (
            [Id] INT IDENTITY(1,1) NOT NULL,
            [Name] NVARCHAR(128) NULL,
            [ParentCategoryId] INT NULL,
            [CreatedDateUtc] DATETIME2(5) NOT NULL DEFAULT SYSUTCDATETIME(),
            CONSTRAINT [CRIX_Category_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
            CONSTRAINT [FK_Category_Parent] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Category]([Id])
        );";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

}