using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Produit_Ecologique.Repositories
{
 
    public interface ICategorieRepository<TEntity> : ICRUDRepository<TEntity, string> where TEntity : class
    {

    }
}
