/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [Categorie] ([Categorie])
VALUES ('Électronique');

INSERT INTO [Categorie] ([Categorie])
VALUES ('Mode');

INSERT INTO [Categorie] ([Categorie])
VALUES ('Jardinage');

INSERT INTO [Categorie] ([Categorie])
VALUES ('Alimentation');

INSERT INTO [Categorie] ([Categorie])
VALUES ('Sports et Loisirs');


INSERT INTO [EcoScore] ([EcoScore])
VALUES ('A');

INSERT INTO [EcoScore] ([EcoScore])
VALUES ('B');

INSERT INTO [EcoScore] ([EcoScore])
VALUES ('C');

INSERT INTO [EcoScore] ([EcoScore])
VALUES ('D');

INSERT INTO [EcoScore] ([EcoScore])
VALUES ('E');

INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
VALUES ('Téléphone', 'Smartphone haut de gamme', 599.99, 100, 'A', 'Électronique');

INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
VALUES ('Chemise', 'Chemise en coton biologique', 39.99, 50, 'B', 'Mode');

INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
VALUES ('Arrosoir', 'Arrosoir en plastique recyclé', 12.99, 20, 'C', 'Jardinage');

INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
VALUES ('Miel bio', 'Miel biologique provenant d abeilles élevées de manière responsable', 9.99, 30, 'A', 'Alimentation');


INSERT INTO [Produit] ([Nom], [Description], [Prix], [Nombre_vente], [EcoScore], [Categorie])
VALUES ('Tapis de yoga', 'Tapis de yoga en caoutchouc naturel', 29.99, 40, 'B', 'Sports et Loisirs');


INSERT INTO Media (url_image, Id_Produit) VALUES ('phone1.jpg', 1);
INSERT INTO Media (url_image, Id_Produit) VALUES ('phone2.jpg', 1);
INSERT INTO Media (url_image, Id_Produit) VALUES ('phone3.jpg', 1);
INSERT INTO Media (url_image, Id_Produit) VALUES ('chemise.jpg', 2);
INSERT INTO Media (url_image, Id_Produit) VALUES ('chemise2.jpg', 2);
INSERT INTO Media (url_image, Id_Produit) VALUES ('chemise3.jpg', 2);
INSERT INTO Media (url_image, Id_Produit) VALUES ('arrosoir.jpg', 3);
INSERT INTO Media (url_image, Id_Produit) VALUES ('miel.jpg', 4);
INSERT INTO Media (url_image, Id_Produit) VALUES ('tapis1.jpg', 5);
