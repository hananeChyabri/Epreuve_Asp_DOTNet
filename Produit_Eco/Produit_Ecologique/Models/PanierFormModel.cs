using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Produit_Ecologique.Models
{
    public class PanierFormModel
    {
        [ScaffoldColumn(false)]
        public int Id_Produit { get; set; }
        [DisplayName("Nom du produit")]
        public string Nom { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Prix")]
        public decimal Prix { get; set; }

        public int Quantite { get; set; }

        public decimal Total { get; set; }

    }
}
