CREATE PROCEDURE [dbo].[SP_Produit_GetById]
    @id_Produit INT
AS
    SELECT [Id_Produit],
           [Nom],
           [Description],
           [prix],
           [Nombre_vente],
           [EcoScore],
           [Categorie]
    FROM [dbo].[Produit]
    WHERE [Id_Produit] = @id_Produit;
