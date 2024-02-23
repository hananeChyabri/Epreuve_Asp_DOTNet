using BLL_Produit_Ecologique.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Produit_Ecologique.Handlers
{
    public class PanierSessionManager : SessionManager
    {
        public PanierSessionManager(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var produit in Panier)
                {
                    total += produit.Prix;
                }
                return total;
            }
        }
        public IEnumerable<Produit> Panier
        {
            get
            {
                if (_session.GetString(nameof(Panier)) is null)
                    Panier = new List<Produit>();
                return JsonSerializer.Deserialize<Produit[]>(_session.GetString(nameof(Panier)));
            }
            private set
            {
                _session.SetString(nameof(Panier), JsonSerializer.Serialize(value));
            }
        }

            public void AddProduct(Produit produit)
        {
            List<Produit> produits = new List<Produit>(Panier);
            produits.Add(produit);
            Panier = produits;

        }

        public IEnumerable<Produit> GetProduct()
        {
            return Panier;

        }

        public decimal GetTotal()
        {
            return Total;
        }


    }   
}

