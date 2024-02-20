CREATE PROCEDURE [dbo].[SP_Produit_GetPlusPopulaires]
AS
BEGIN
    SELECT [Id_Produit],
           [Nom],
           [Description],
           [prix],
           [Nombre_vente],
           [EcoScore],
           [Categorie]
    FROM [Produit]
    WHERE [Nombre_vente] > 10;
END
