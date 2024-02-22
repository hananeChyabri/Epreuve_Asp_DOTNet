using Shared_Produit_Ecologique.Repositories;
using DAL = DAL_Produit_Ecologique.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BLL_Produit_Ecologique.Mappers;
using BLL_Produit_Ecologique.Entities;
using System.Linq;

namespace BLL_Produit_Ecologique.Services
{

    public class MediaService : IMediaRepository<Media>
    {
        private readonly IMediaRepository<DAL.Media> _mediarepository;
        //   private readonly IMediaRepository<Media> _mediaRepository;


        public MediaService(IMediaRepository<DAL.Media> mediarepository)
        {
            _mediarepository = mediarepository;

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
       
            return _mediarepository.GetByProduit(id).Select(d => d.ToBLL());

        }

        public int Insert(Media data)
        {
            return _mediarepository.Insert(data.ToDAL());
        }

        public void Update(Media data)
        {
            throw new NotImplementedException();
        }
    }
} 
