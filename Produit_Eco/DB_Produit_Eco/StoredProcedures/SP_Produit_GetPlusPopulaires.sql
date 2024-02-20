CREATE PROCEDURE [dbo].[SP_Produit_GetPlusPopulaires]
AS
BEGIN
  SELECT [Id_Produit], [Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie]
  FROM [Produit]
  WHERE [Nombre_vente] > (SELECT AVG(Nombre_vente) FROM Produit);
END
