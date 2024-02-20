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
            };
        }

    }
}
