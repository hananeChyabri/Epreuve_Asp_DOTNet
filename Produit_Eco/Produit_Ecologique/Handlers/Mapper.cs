using BLL_Produit_Ecologique.Entities;
using Produit_Ecologique.Models;
using System.ComponentModel;

namespace Produit_Ecologique.Handlers
{
    public static class Mapper
    {

        public static ProduitListItemViewModels ToListItem(this Produit entity)
        {
            if (entity is null) return null;
            return new ProduitListItemViewModels()
            {
                Id_Produit = entity.Id_Produit,
                Nom = entity.Nom,
                Description = entity.Description,
                prix = entity.Prix,
                Nombre_Vente = entity.Nombre_vente,
                EcoScore = entity.EcoScore,
                Categorie = entity.Categorie,
                Media = entity.Media.Select(d => d.ToListItem())
            };
        }


        public static Produit ToBLL(this ProduitCreateForm entity)
        {
            if (entity is null) return null;
            return new Produit(

                0,
                entity.Nom,
                entity.Description,
                entity.Prix,
                0,
                entity.EcoScore,
                entity.Categorie);


        }

        public static ProduitEditForm ToEditForm(this Produit entity)
        {
            if (entity is null) return null;
            return new ProduitEditForm
            {
                Id_Produit = entity.Id_Produit,
                Nom = entity.Nom,
                Description = entity.Description,
                Prix = entity.Prix,
                EcoScore = entity.EcoScore,
                Categorie = entity.Categorie,
            };
        }

        public static Produit ToBLL(this ProduitEditForm entity)
        {
            if (entity is null) return null;
            return new Produit(

                entity.Id_Produit,
                entity.Nom,
                entity.Description,
                entity.Prix,
                0,
                entity.EcoScore,
                entity.Categorie);
        }

        public static ProduitDeleteForm ToDelete(this Produit entity)
        {
            if (entity is null) return null;
            return new ProduitDeleteForm()
            {
                Id_Produit = entity.Id_Produit,
                Nom = entity.Nom
            };
        }


        public static ProduitDetailsViewModel ToDetails(this Produit entity)
        {
            if (entity is null) return null;
            return new ProduitDetailsViewModel()
            {
                Id_Produit = entity.Id_Produit,
                Nom = entity.Nom,
                Description = entity.Description,
                Prix = entity.Prix,
                EcoScore = entity.EcoScore,
                Categorie = entity.Categorie,
                Media = entity.Media.Select(d => d.ToListItem())
            };
        }

        public static MediaListItemViewModels ToListItem(this Media entity)
        {
            if (entity is null) return null;
            return new MediaListItemViewModels()
            {

                url_image = entity.Url_Image,
       
            };
        }


        public static Media ToBLL(this MediaCreateForm entity)
        {
            if (entity is null) return null;
            return new Media(

               entity.Image.ToString());


        }
 


    }
}
