using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BLL_Produit_Ecologique.Entities;

namespace Produit_Ecologique.Models
{
    public class ProduitListItemViewModels
    {

        [ScaffoldColumn(false)]
        public int Id_Produit { get; set; }
        [DisplayName("Nom du produit")]
        public string Nom { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Prix")]
        public decimal prix { get; set; }
        [DisplayName("Vendu")]
        public int Nombre_Vente { get; set; }

        public EcoScore EcoScore { get; set; }
        public string Categorie { get; set; }
        public IEnumerable<MediaListItemViewModels> Media { get; set; }
  

    }
}
