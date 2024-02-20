CREATE PROCEDURE [dbo].[SP_Produit_GetAll]
AS
	SELECT	[Id_Produit],
			[Nom],
			[Description],
			[prix],
			[Nombre_vente],
			[EcoScore],
			[Categorie]
		FROM [Produit]