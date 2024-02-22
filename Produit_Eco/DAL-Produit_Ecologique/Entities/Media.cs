using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Produit_Ecologique.Entities
{
    public class Media
    {
        public int Id_Media { get; set; }
        public string Url_Image {  get; set; }
        public int Id_Produit {  get; set; }
    }
}
