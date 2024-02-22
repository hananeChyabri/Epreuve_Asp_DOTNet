using BLL_Produit_Ecologique.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Produit_Ecologique.Models
{
    public class ProduitDetailsViewModel
    {
        [ScaffoldColumn(false)]
        public int Id_Produit { get; set; }
        public string Nom { get; set; }
    
        public string Description { get; set; }

        public decimal Prix { get; set; }
    
        public int Nombre_Vente { get; set; }

        public EcoScore EcoScore { get; set; }
        public string Categorie { get; set; }

        public IEnumerable<MediaListItemViewModels> Media { get; set; }
    
    }
}
