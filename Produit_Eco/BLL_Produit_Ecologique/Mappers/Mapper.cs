using BLL_Produit_Ecologique.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BLL = BLL_Produit_Ecologique.Entities;
using DAL = DAL_Produit_Ecologique.Entities;

namespace BLL_Produit_Ecologique.Mappers
{
    internal static class Mapper
    {

        public static BLL.Produit ToBLL(this DAL.Produit entity)
        {
            if (entity is null) return null;
            return new BLL.Produit(
                entity.Id_Produit,
                entity.Nom,
                entity.Description,
                entity.Prix,
                entity.Nombre_vente,
                (BLL.EcoScore)Enum.Parse(typeof(BLL.EcoScore), entity.EcoScore),
                entity.Categorie
                );
      

        }

        public static DAL.Produit ToDAL(this BLL.Produit entity)
        {
            if (entity is null) return null;
            return new DAL.Produit()
            {
                Id_Produit = entity.Id_Produit,
                Nom = entity.Nom,
                Description = entity.Description,
                Prix = entity.Prix,
                Nombre_vente = entity.Nombre_vente,
                EcoScore = entity.EcoScore.ToString(),
                Categorie = entity.Categorie,
             

            };
        }


        public static BLL.Categorie ToBLL(this string categorie)
        {
            if (categorie is null) return null;
            return new BLL.Categorie(
                categorie
                );

        }
    }
}
