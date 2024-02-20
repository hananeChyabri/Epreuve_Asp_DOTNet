using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Produit_Ecologique.Entities
{
    public class Produit
    {

        private List<Media> _media;
        public int Id_Produit { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int Nombre_vente { get; set; }
        public EcoScore EcoScore { get; set; }
        public string Categorie { get; set; }

        public Media[] Media
        {
            get
            {
                return _media?.ToArray() ?? new Media[0];
            }
        }

        public Produit(int id_Produit, string nom, string description, decimal prix, int nombre_vente, EcoScore ecoScore, string categorie)
        {
            Id_Produit = id_Produit;
            Nom = nom;
            Description = description;
            Prix = prix;
            Nombre_vente = nombre_vente;
            EcoScore = ecoScore;
            Categorie = categorie;
        }


        public Produit()
        {
            // Initialize collections to prevent null reference exceptions
            _media = new List<Media>();
        }

    }
}
