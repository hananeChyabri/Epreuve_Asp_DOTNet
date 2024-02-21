using BLL_Produit_Ecologique.Mappers;
using Shared_Produit_Ecologique.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL = DAL_Produit_Ecologique.Services;

namespace BLL_Produit_Ecologique.Services
{
    public class CategorieService : ICategorieRepository<String>
    {
        private readonly DAL.CategorieService _categorierepository;



        public CategorieService(DAL.CategorieService categorierepository)
        {
            _categorierepository = categorierepository;

        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Get()
        {
            return _categorierepository.Get();

        }

        public string Get(string id)
        {
            throw new NotImplementedException();
        }

        public string Insert(string data)
        {
            throw new NotImplementedException();
        }

        public void Update(string data)
        {
            throw new NotImplementedException();
        }
    }
}

  