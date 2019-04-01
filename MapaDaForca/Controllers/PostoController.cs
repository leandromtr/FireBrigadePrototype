using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;


namespace MapaDaForca.Controllers
{
    public class PostoController : Controller
    {
        private readonly IPostoStore _postoStore;


        public PostoController(
            IPostoStore postoStore)
        {
            _postoStore = postoStore;
        }


        public ActionResult Index()
        {
            var posto = _postoStore.GetAll();
            return View(posto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Posto posto)
        {
            var newPosto = _postoStore.Save(posto);
            return new RedirectToActionResult("Detail", "Posto", new { @id = newPosto.Id });
        }


        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var model = _postoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(Posto posto)
        {
            try
            {
                var newPosto = _postoStore.Save(posto);
                return Json(new { success = true, message = "Posto salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Posto" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            //if (_companhiaStore.GetByPostoId(id).Any())
            //    return Json(new { success = false, message = "Este batalhão possui relações e não poderá ser excluído!" });

            _postoStore.Delete(id);
            return Json(new { success = true, message = "Posto excluído!" });
        }
    }
}