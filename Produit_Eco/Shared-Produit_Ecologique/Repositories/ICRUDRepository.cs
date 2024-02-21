using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Produit_Ecologique.Repositories
{
    public interface ICRUDRepository<TEntity, TId> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity data);
        void Update(TEntity data);
        void Delete(TId id);

    }
}
