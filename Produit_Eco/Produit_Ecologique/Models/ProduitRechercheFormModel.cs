using BLL_Produit_Ecologique.Entities;

namespace Produit_Ecologique.Models
{
    public class ProduitRechercheFormModel
    {
        // Champ de recherche par nom
        public string Nom { get; set; }

        // Champ de sélection pour les catégories
        public int? Id_Categorie { get; set; } 
        public List<Categorie> Categories { get; set; } // Liste des catégories disponibles
    }
}
