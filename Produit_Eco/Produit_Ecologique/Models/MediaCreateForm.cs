using System.ComponentModel;

namespace Produit_Ecologique.Models
{
    public class MediaCreateForm
    {
        [DisplayName("Affiche")]
        public IFormFile Image { get; set; }
    }
}
