using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Produit_Ecologique.Entities
{
    public class Categorie
    {
        public string idCategorie { get; set; }

        public Categorie(string idCategorie)
        {
            this.idCategorie = idCategorie;
        }
    }
}
