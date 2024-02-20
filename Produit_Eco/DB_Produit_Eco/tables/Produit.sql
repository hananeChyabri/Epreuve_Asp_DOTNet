CREATE TABLE [dbo].[Produit]
(
    [Id_Produit] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nom] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255) NOT NULL,
    [url_image] NVARCHAR(512) NOT NULL,
    [prix] DECIMAL(10, 2) NOT NULL,
    [Nombre_vente] INT NULL
)
