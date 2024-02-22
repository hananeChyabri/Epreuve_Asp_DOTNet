using DAL_Produit_Ecologique.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Produit_Ecologique.Mappers
{
    internal static class Mapper
    {
        public static Produit ToProduit(this IDataRecord record)
        {
            if (record is null) return null;
            return new Produit()
            {
                Id_Produit = (int)record["Id_Produit"],
                Nom = (string)record["Nom"],
                Description = (string)record["Description"],
                Prix = (decimal)record["Prix"],
                Nombre_vente = (int)record["Nombre_vente"],
                EcoScore = (string)record["EcoScore"],
                Categorie = (string)record["Categorie"],

            };
        }

        public static Media ToMedia(this IDataRecord record)
        {
            if (record is null) return null;
            return new Media()
            {
                Id_Media = (int)record["Id_Media"],
                Id_Produit = (int)record["Id_Produit"],
                Url_Image = (string)record["url_image"],
      

            };
        }
    }
}
