using Shared_Produit_Ecologique.Repositories;
using DAL = DAL_Produit_Ecologique.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL_Produit_Ecologique.Mappers;
using BLL_Produit_Ecologique.Entities;

namespace BLL_Produit_Ecologique.Services
{
    public class ProduitService : IProduitRepository<Produit>
    {
        private readonly IProduitRepository<DAL.Produit> _produitrepository;
        private readonly IMediaRepository<Media> _mediaRepository;


        public ProduitService(IProduitRepository<DAL.Produit> produitrepository, IMediaRepository<Media> mediaRepository)
        {
            _produitrepository = produitrepository;
            _mediaRepository = mediaRepository;
        }

        public IEnumerable<Produit> Get()
        {
            return _produitrepository.Get().Select(d =>
            {
                Produit result = d.ToBLL();
                IEnumerable<Media> medias = _mediaRepository.GetByProduit(result.Id_Produit);
                result.AddMedias(medias);

                return result;
            });
        }

        public Produit Get(int id)
        {

            Produit entity = _produitrepository.Get(id).ToBLL();
            IEnumerable<Media> medias = _mediaRepository.GetByProduit(id);
            entity.AddMedias(medias);
            return entity;
        }

        public void Delete(int id)
        {
            _produitrepository.Delete(id);
        }

        public int Insert(Produit data)
        {
            return _produitrepository.Insert(data.ToDAL());
        }

        public void Update(Produit data)
        {
            _produitrepository.Update(data.ToDAL());
        }

        public IEnumerable<Produit> GetPlusPopulaire()
        {
     

            return _produitrepository.GetPlusPopulaire().Select(d =>
            {
                Produit result = d.ToBLL();
                IEnumerable<Media> medias = _mediaRepository.GetByProduit(result.Id_Produit);
                result.AddMedias(medias);

                return result;
            });

        }
    }
}
