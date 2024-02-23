using BLL_Produit_Ecologique.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produit_Ecologique.Models
{
    public class ProduitCreateForm
    {
        [DisplayName("Nom du produit")]
        [Required(ErrorMessage = "Le nom du produit est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom du produit doit comporter au moins 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le nom du produit ne peut pas dépasser 64 caractères.")]
        public string Nom { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "La description du produit est obligatoire.")]
        [MinLength(2, ErrorMessage = "La description du produit doit comporter au moins 3 caractères.")]
        [MaxLength(256, ErrorMessage = "La description du produit ne peut pas dépasser 256 caractères.")]
        public string Description { get; set; }

        [DisplayName("Prix")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Le prix du produit est obligatoire.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix du produit doit être supérieur à zéro.")]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "Le score écologique du produit est obligatoire.")]
        public EcoScore EcoScore { get; set; }

        [Required(ErrorMessage = "La catégorie du produit est obligatoire.")]
        public string Categorie { get; set; }

        [DisplayName("Affiche")]
        public IFormFile Image { get; set; }
    }
}
