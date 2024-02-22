using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Produit_Ecologique.Repositories
{
    public interface IMediaRepository<TEntity> : ICRUDRepository<TEntity, int> where TEntity : class
    {
        IEnumerable<TEntity> GetByProduit(int id);
    }
}
