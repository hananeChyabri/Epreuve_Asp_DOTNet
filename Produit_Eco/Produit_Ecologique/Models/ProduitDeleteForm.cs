using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Produit_Ecologique.Models
{
    public class ProduitDeleteForm
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int Id_Produit { get; set; }

        [DisplayName("Nom ")]
        public string Nom { get; set; }
    }
}
