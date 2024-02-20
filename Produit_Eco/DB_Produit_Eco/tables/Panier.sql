CREATE TABLE [dbo].[Panier]
(
    [Id_Panier] INT IDENTITY NOT NULL PRIMARY KEY,
    [Id_Commande] INT NOT NULL,
    [Id_Produit] INT NOT NULL,
    [Quantite] INT NOT NULL,
    CONSTRAINT FK_Panier_Commande FOREIGN KEY (Id_Commande) REFERENCES Commande(Id_Commande),
    CONSTRAINT FK_Panier_Produit FOREIGN KEY (Id_Produit) REFERENCES Produit(Id_Produit)
)
