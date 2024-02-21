using DAL_Produit_Ecologique.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared_Produit_Ecologique.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Produit_Ecologique.Services
{
    public class CategorieService : BaseService, ICategorieRepository<string>
    {
        public CategorieService(IConfiguration configuration) : base(configuration, "DBProduitEcologique")
        {
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Categorie_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader["Categorie"].ToString();
                        }
                    }
                }
            }
        }
        public string Get(string id)
        {
            throw new NotImplementedException();
        }

        public string Insert(string data)
        {
            throw new NotImplementedException();
        }

        public void Update( string data)
        {
            throw new NotImplementedException();
        }
    }
}
