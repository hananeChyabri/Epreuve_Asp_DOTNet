using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Produit_Ecologique.Repositories
{
    public interface IProduitRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : class
    {
     
        IEnumerable<TEntity> GetPlusPopulaire();


    }
}
