using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MapaDaForca.Controllers
{
    [Authorize]
    public class ViaturaController : Controller
    {
        private readonly IViaturaStore _viaturaStore;
        private readonly IViaturaTipoStore _viaturaTipoStore;
        private readonly IQuartelViaturaStore _quartelViaturaStore;

        public ViaturaController(
            IViaturaStore viaturaStore,
            IViaturaTipoStore viaturaTipoStore,
            IQuartelViaturaStore quartelViaturaStore)
        {
            _viaturaStore = viaturaStore;
            _viaturaTipoStore = viaturaTipoStore;
            _quartelViaturaStore = quartelViaturaStore;
        }


        public ActionResult Index()
        {
            var viatura = _viaturaStore.GetAll();
            return View(viatura);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viatura = new Viatura();
            viatura.ViaturaTipos = _viaturaTipoStore.GetAll();
            return View(viatura);
        }

        [HttpPost]
        public ActionResult Create(Viatura viatura)
        {
            var newViatura = _viaturaStore.Save(viatura);
            return new RedirectToActionResult("Detail", "Viatura", new { @id = newViatura.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Viatura criada com sucesso!";

            var viatura = _viaturaStore.GetById(id);
            viatura.ViaturaTipos = _viaturaTipoStore.GetAll();

            return View(viatura);
        }


        [HttpPost]
        public JsonResult Edit(Viatura viatura)
        {
            try
            {
                var newViatura = _viaturaStore.Save(viatura);
                return Json(new { success = true, message = "Viatura salva com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar esta Viatura" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_quartelViaturaStore.GetByViaturaId(id).Any())
                return Json(new { success = false, message = "Esta Viatura possui relações e não poderá ser eliminada!" });

            _viaturaStore.Delete(id);
            return Json(new { success = true, message = "Viatura eliminada!" });
        }
    }
}