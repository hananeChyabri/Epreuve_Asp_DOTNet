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
        //   private readonly IMediaRepository<Media> _mediaRepository;


        public ProduitService(IProduitRepository<DAL.Produit> produitrepository)
        {
            _produitrepository = produitrepository;

        }

        public IEnumerable<Produit> Get()
        {
           
            return _produitrepository.Get().Select(d => d.ToBLL());
        }

        public Produit Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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
