using BLL_Produit_Ecologique.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produit_Ecologique.Handlers;
using Produit_Ecologique.Models;
using Shared_Produit_Ecologique.Repositories;

namespace Produit_Ecologique.Controllers
{
    public class PanierController : Controller
    {
        private readonly IProduitRepository<Produit> _produitRepository;
        private readonly PanierSessionManager _panierSessionManager;

        public PanierController(IProduitRepository<Produit> produitRepository, PanierSessionManager panierSessionManager)
        {
            _produitRepository = produitRepository;
            _panierSessionManager = panierSessionManager;
        }


        public ActionResult AddToCart(int id)
        {
            Produit produit = _produitRepository.Get(id);
            _panierSessionManager.AddProduct(produit);
            return RedirectToAction("Index", "produit");


        }

        // GET: PanierController
        public ActionResult Index()
        {
            IEnumerable<PanierFormModel> model = _panierSessionManager.GetProduct().Select(d => d.ToPanier());


            return View(model);
        }

        // GET: PanierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PanierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PanierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PanierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PanierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
