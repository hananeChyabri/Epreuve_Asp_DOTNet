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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_Delete";
                    command.Parameters.AddWithValue("id_produit", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                }
            }
        }

        public IEnumerable<Produit> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_GetAll";
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_GetById";
                    command.Parameters.AddWithValue("id_produit", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToProduit();
                        throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                    }
                }
            }
        }

        public IEnumerable<Produit> GetPlusPopulaire()
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

        public int Insert(Produit data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", data.Nom);
                    command.Parameters.AddWithValue("description", data.Description);
                    command.Parameters.AddWithValue("prix", data.Prix);
                    command.Parameters.AddWithValue("nombreVente", data.Nombre_vente);
                    command.Parameters.AddWithValue("EcoScore", data.EcoScore);
                    command.Parameters.AddWithValue("categorie", data.Categorie);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Produit entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Produit_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_produit", entity.Id_Produit);
                    command.Parameters.AddWithValue("nom", entity.Nom);
                    command.Parameters.AddWithValue("description", entity.Description);
                    command.Parameters.AddWithValue("prix", entity.Prix);
                    command.Parameters.AddWithValue("ecoScore", entity.EcoScore);
                    command.Parameters.AddWithValue("categorie", entity.Categorie);
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                 
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id_Produit), $"L'identifiant {entity.Id_Produit} ne correspond à aucune valeur");
                }

            }
        }
    }
}
