using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class CompanhiaController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly ICompanhiaStore _companhiaStore;
        private readonly IBatalhaoStore _batalhaoStore;
        private readonly IQuartelStore _quartelStore;

        public CompanhiaController(
            ICompanhiaStore companhiaStore,
            IBatalhaoStore batalhaoStore,
            IQuartelStore quartelStore)
        {
            _companhiaStore = companhiaStore;
            _batalhaoStore = batalhaoStore;
            _quartelStore = quartelStore;
        }


        public ActionResult Index()
        {
            var companhia = _companhiaStore.GetAll();
            return View(companhia);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var companhia = new Companhia();
            companhia.Batalhoes = _batalhaoStore.GetAll();
            return View(companhia);
        }

        [HttpPost]
        public ActionResult Create(Companhia companhia)
        {
            var newCompanhia = _companhiaStore.Save(companhia);
            return new RedirectToActionResult("Detail", "Companhia", new { @id = newCompanhia.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Companhia criada com sucesso!";

            var companhia = _companhiaStore.GetById(id);
            companhia.Batalhoes = _batalhaoStore.GetAll();

            return View(companhia);
        }


        [HttpPost]
        public JsonResult Edit(Companhia companhia)
        {
            try
            {
                var newCompanhia = _companhiaStore.Save(companhia);
                return Json(new { success = true, message = "Companhia salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Companhia" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_quartelStore.GetByCompanhiaId(id).Any())
                return Json(new { success = false, message = "Esta companhia possui relações e não poderá ser excluída!" });

            _companhiaStore.Delete(id);
            return Json(new { success = true, message = "Companhia excluída!" });
        }
    }
}