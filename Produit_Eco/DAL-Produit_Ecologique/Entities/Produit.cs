﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Produit_Ecologique.Entities
{
    public class Produit
    {
        public int Id_Produit { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Prix { get; set; }
        public string Nombre_vente { get; set; }
        public string EcoScore { get; set; }
        public string Categorie { get; set;}
    }
}
