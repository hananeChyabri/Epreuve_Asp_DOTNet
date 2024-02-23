using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using BLL_Produit_Ecologique.Entities;

namespace Produit_Ecologique.Models
{
    public class ProduitEditForm
    {
        [HiddenInput]
        public int Id_Produit { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le nom du produit est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom du produit doit être composé de minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le nom du produit doit être composé de maximum 100 caractères.")]
        public string Nom { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "La description du produit est obligatoire.")]
        [MinLength(2, ErrorMessage = "La description du produit doit être composée de minimum 2 caractères.")]
        [MaxLength(255, ErrorMessage = "La description du produit doit être composée de maximum 255 caractères.")]
        public string Description { get; set; }

        [DisplayName("Prix")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Le prix du produit est obligatoire.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix du produit doit être supérieur à zéro.")]
        public decimal Prix { get; set; }

        [DisplayName("EcoScore")]
        [Required(ErrorMessage = "L'EcoScore du produit est obligatoire.")]
        public EcoScore EcoScore { get; set; }

        [DisplayName("Catégorie")]
      
        public string Categorie { get; set; }

    }
}
