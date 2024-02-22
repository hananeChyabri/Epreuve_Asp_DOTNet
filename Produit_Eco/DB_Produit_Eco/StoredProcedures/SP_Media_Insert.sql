CREATE PROCEDURE [dbo].[SP_Media_Insert]
    @url_image NVARCHAR(256),
    @Id_Produit INT
AS

    INSERT INTO Media (url_image, Id_Produit)
    OUTPUT [inserted].[Id_Produit]
    VALUES (@url_image, @Id_Produit);
