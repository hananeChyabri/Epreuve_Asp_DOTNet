using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Produit_Ecologique.Repositories;
using BLL_Produit_Ecologique.Entities;
using Produit_Ecologique.Models;
using Produit_Ecologique.Handlers;

namespace Produit_Ecologique.Controllers
{
    public class MediaController : Controller
    {
        private readonly IMediaRepository<Media> _mediaRepository;
      

        public MediaController(IMediaRepository<Media> mediaRepository)
        {
            _mediaRepository = mediaRepository;
        
        }
        // GET: MediaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MediaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaController/Create/id_produit
        public ActionResult Create(int id_produit)
        {
          
            return View();
        }

        // POST: MediaController/Create/id_produit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id_produit,MediaCreateForm form)
        {

            try
            {
                if (form is null) ModelState.AddModelError(nameof(form), "Le formulaire ne correspond pas");
                if (!ModelState.IsValid) throw new Exception();

                await form.Image.SaveFile();
                _mediaRepository.Insert(new Media(0, form.Image.FileName, id_produit));

                return RedirectToAction(nameof(Details), new { id_produit });
            }
            catch
            {
                return View();
            }

        }

        // GET: MediaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaController/Edit/5
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

        // GET: MediaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaController/Delete/5
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
