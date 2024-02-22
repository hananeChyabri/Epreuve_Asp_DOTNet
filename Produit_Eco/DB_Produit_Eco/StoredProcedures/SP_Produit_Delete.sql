CREATE PROCEDURE [dbo].[SP_Produit_Delete]
	@id_produit INT
AS
	DELETE FROM [Produit]
		WHERE [Id_Produit] = @id_produit
