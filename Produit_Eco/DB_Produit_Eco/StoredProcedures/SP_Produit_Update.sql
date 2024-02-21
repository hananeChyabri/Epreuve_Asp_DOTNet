CREATE PROCEDURE [dbo].[SP_Produit_Update]
    @id_Produit INT,
    @nom NVARCHAR(100),
    @description NVARCHAR(255),
    @prix DECIMAL(10, 2),
    @ecoScore CHAR,
    @categorie NVARCHAR(64)
AS
    UPDATE [dbo].[Produit]
    SET [Nom] = @nom,
        [Description] = @description,
        [prix] = @prix,
        [EcoScore] = @ecoScore,
        [Categorie] = @categorie
    WHERE [Id_Produit] = @id_Produit
