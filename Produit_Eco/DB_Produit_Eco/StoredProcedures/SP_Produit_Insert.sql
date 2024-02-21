CREATE PROCEDURE [dbo].[SP_Produit_Insert]
    @nom NVARCHAR(64),
    @description NVARCHAR(64),
    @prix DECIMAL(10, 2),
    @nombreVente INT,
    @ecoScore CHAR,
    @categorie NVARCHAR(64)
AS
    INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
	OUTPUT [inserted].[Id_Produit]
    VALUES (@nom, @description, @prix, @nombreVente, @ecoScore, @categorie)
