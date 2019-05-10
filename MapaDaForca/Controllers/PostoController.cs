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
        private readonly IBombeiroStore _bombeiroStore;


        public PostoController(
            IPostoStore postoStore,
            IBombeiroStore bombeiroStore)
        {
            _postoStore = postoStore;
            _bombeiroStore = bombeiroStore;
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
            return new RedirectToActionResult("Detail", "Posto", new { @id = newPosto.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Posto criado com sucesso!";

            var model = _postoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(Posto posto)
        {
            try
            {
                var newPosto = _postoStore.Save(posto);
                return Json(new { success = true, message = "Posto guardado com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar este Posto" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_bombeiroStore.GetByPostoId(id).Any())
                return Json(new { success = false, message = "Este Posto possui relações e não poderá ser eliminado!" });

            _postoStore.Delete(id);
            return Json(new { success = true, message = "Posto eliminado!" });
        }
    }
}