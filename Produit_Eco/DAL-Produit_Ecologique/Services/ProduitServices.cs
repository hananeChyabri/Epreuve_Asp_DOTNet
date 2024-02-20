using DAL_Produit_Ecologique.Entities;
using DAL_Produit_Ecologique.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shared_Produit_Ecologique.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Produit_Ecologique.Services
{
    public class ProduitService : BaseService, IProduitRepository<Produit>
    {
        public ProduitService(IConfiguration configuration) : base(configuration, "DBProduitEcologique")
        {
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produit> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_GetPlusPopulaires";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToProduit();
                        }
                    }
                }

            }
        }

        public Produit Get(int id)
        {
          
            throw new NotImplementedException();
        }

        public int Insert(Produit data)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Produit data)
        {
            throw new NotImplementedException();
        }
    }
}
