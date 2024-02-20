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
                Nom = (string)record["Name"],
                Description = (string)record["City"],
                Prix = (string)record["Street"],
                Nombre_vente = (string)record["Number"],
                EcoScore = (string)record["EcoScore"],
                Categorie = (string)record["Categorie"],

            };
        }
    }
}
