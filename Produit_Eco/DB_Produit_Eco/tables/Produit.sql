CREATE TABLE [dbo].[Produit]
(
    [Id_Produit] INT IDENTITY NOT NULL PRIMARY KEY,
    [Nom] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255) NOT NULL,
    [prix] DECIMAL(10, 2) NOT NULL,
    [Nombre_vente] INT NOT NULL,
    [EcoScore] NVARCHAR(1) NOT NULL,
    [Categorie] NVARCHAR(64) NOT NULL,
    CONSTRAINT [FK_Produit_EcoScore] FOREIGN KEY ([EcoScore]) REFERENCES [EcoScore]([EcoScore]),
    CONSTRAINT [FK_Produit_Categorie] FOREIGN KEY ([Categorie]) REFERENCES [Categorie]([Categorie]),

)
