using BLL_Produit_Ecologique.Entities;
using Produit_Ecologique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Produit_Ecologique.Repositories;
using Produit_Ecologique.Handlers;
using System.Reflection;

namespace Produit_Ecologique.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitRepository<Produit> _produitRepository;
        private readonly IMediaRepository<Media> _mediaRepository;
        private readonly PanierSessionManager _panierSessionManager;

        public ProduitController(IProduitRepository<Produit> produitRepository, IMediaRepository<Media> mediaRepository, PanierSessionManager panierSessionManager)
        {
            _produitRepository = produitRepository;
            _mediaRepository = mediaRepository;
            _panierSessionManager = panierSessionManager;
        }

        /*pour afficher aussi les plus popolaires*/
        // GET: ProduitController
        public ActionResult Index()
        {
            IEnumerable<ProduitListItemViewModels> model = _produitRepository.GetPlusPopulaire().Select(d => d.ToListItem());

            return View(model);
        }

        /*j'utilise l action getAllProduct pour afficher aussi le resulat du recherche*/
        // GET: ProduitController
        public ActionResult GetAllProduct(string? search)
        {
            IEnumerable<ProduitListItemViewModels> model = null;
            if (string.IsNullOrWhiteSpace(search))
            {
            model = _produitRepository.Get().Select(d => d.ToListItem());
                return View(model);
            }
            else
                model = _produitRepository.Get().Where(d => d.Nom == search).Select(d => d.ToListItem());

            return View(model);


        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            ProduitDetailsViewModel model = _produitRepository.Get(id).ToDetails();
            ViewBag.Id = id;
            return View(model);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProduitCreateForm form)
        {

            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Le formulaire ne correspond pas");
                if (!ModelState.IsValid) throw new Exception();
                int id = _produitRepository.Insert(form.ToBLL());
                await form.Image.SaveFile();
                _mediaRepository.Insert(new Media(0, form.Image.FileName, id));

                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }

        }



        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            ProduitEditForm model = _produitRepository.Get(id).ToEditForm();
            return View(model);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProduitEditForm form)
        {
            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Le formulaire ne correspond pas");
                if (!ModelState.IsValid) throw new Exception();
                _produitRepository.Update(form.ToBLL());
             
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View(form);
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            ProduitDeleteForm model = _produitRepository.Get(id).ToDelete();
            if (model is null)
            {
                TempData["Error"] = "Produit inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProduitDeleteForm form)
        {
            try
            {
                _produitRepository.Delete(id);
                TempData["Error"] = "Erreur de suppression...";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}
