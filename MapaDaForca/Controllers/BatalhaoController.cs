using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class BatalhaoController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IBatalhaoStore _batalhaoStore;
        private readonly ICompanhiaStore _companhiaStore;


        public BatalhaoController(
            IBatalhaoStore batalhaoStore,
            ICompanhiaStore companhiaStore)
        {
            _batalhaoStore = batalhaoStore;
            _companhiaStore = companhiaStore;
        }


        public ActionResult Index()
        {
            var batalhao = _batalhaoStore.GetAll();
            return View(batalhao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Batalhao batalhao)
        {
            var newBatalhao = _batalhaoStore.Save(batalhao);
            return new RedirectToActionResult("Detail", "Batalhao", new { @id = newBatalhao.Id });
        }


        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var model = _batalhaoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(Batalhao batalhao)
        {
            try
            {
                var newBatalhao = _batalhaoStore.Save(batalhao);
                return Json(new { success = true, message = "Batalhão salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Batalhão" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_companhiaStore.GetByBatalhaoId(id).Any())
                return Json(new { success = false, message = "Este batalhão possui relações e não poderá ser excluído!" });

            _batalhaoStore.Delete(id);
            return Json(new { success = true, message = "Batalhão excluído!" });
        }
    }
}