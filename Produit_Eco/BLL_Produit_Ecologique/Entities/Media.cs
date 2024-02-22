using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Produit_Ecologique.Entities
{
    public class Media
    {
      

        public int Id_Media {  get; set; }
        public string Url_Image { get; set; }
        public int Id_Produit { get; set; }


        public Media(int id_Media, string url_Image, int id_Produit)
        {
            Id_Media = id_Media;
            Url_Image = url_Image;
            Id_Produit = id_Produit;
        }
        public Media(string url_Image)
        {
       
            Url_Image = url_Image;
     
        }
    }

}
