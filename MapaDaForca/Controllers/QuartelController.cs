using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class QuartelController : Controller
    {
        private readonly ICompanhiaStore _companhiaStore;
        private readonly IQuartelStore _quartelStore;

        public QuartelController(
            ICompanhiaStore companhiaStore,
            IQuartelStore quartelStore)
        {
            _quartelStore = quartelStore;
            _companhiaStore = companhiaStore;
        }


        public ActionResult Index()
        {
            var quartel = _quartelStore.GetAll();
            return View(quartel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var quartel = new Quartel();
            quartel.Companhias = _companhiaStore.GetAll();
            return View(quartel);
        }

        [HttpPost]
        public ActionResult Create(Quartel quartel)
        {
            var newQuartel= _quartelStore.Save(quartel);
            return new RedirectToActionResult("Detail", "Quartel", new { @id = newQuartel.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Quartel criado com sucesso!";

            var quartel = _quartelStore.GetById(id);
            quartel.Companhias = _companhiaStore.GetAll();

            return View(quartel);
        }


        [HttpPost]
        public JsonResult Edit(Quartel quartel)
        {
            try
            {
                var newQuartel = _quartelStore.Save(quartel);
                return Json(new { success = true, message = "Quartel salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Quartel" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            //if (_companhiaStore.GetByBatalhaoId(id).Any())
            //    return Json(new { success = false, message = "Este Quartel possui relações e não poderá ser excluído!" });

            _quartelStore.Delete(id);
            return Json(new { success = true, message = "Quartel excluído!" });
        }
    }
}