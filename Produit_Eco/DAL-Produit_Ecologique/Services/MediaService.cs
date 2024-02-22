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
    public class MediaService : BaseService, IMediaRepository<Media>
    {
        public MediaService(IConfiguration configuration) : base(configuration, "DBProduitEcologique")
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Media> Get()
        {
            throw new NotImplementedException();
        }

        public Media Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Media> GetByProduit(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Media] WHERE [Id_Produit] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToMedia();
                        }
                    }
                }
            }
        }

        public int Insert(Media data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Media_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id_Produit", data.Id_Produit);
                    command.Parameters.AddWithValue("url_image", data.Url_Image);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Media data)
        {
            throw new NotImplementedException();
        }
    }
}
