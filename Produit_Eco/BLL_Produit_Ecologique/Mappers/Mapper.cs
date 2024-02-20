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

        public static BLL.Categorie ToBLL(this DAL.Categorie entity)
        {
            if (entity is null) return null;
            return new BLL.Categorie(
                entity.idCategorie
                );

        }
    }
}
