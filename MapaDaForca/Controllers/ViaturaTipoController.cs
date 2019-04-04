using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;


namespace MapaDaForca.Controllers
{
    public class ViaturaTipoController : Controller
    {
        private readonly IViaturaTipoStore _viaturaTipoStore;


        public ViaturaTipoController(
            IViaturaTipoStore viaturaTipoStore)
        {
            _viaturaTipoStore = viaturaTipoStore;
        }


        public ActionResult Index()
        {
            var viaturaTipo = _viaturaTipoStore.GetAll();
            return View(viaturaTipo);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViaturaTipo batalhao)
        {
            var newViaturaTipo = _viaturaTipoStore.Save(batalhao);
            return new RedirectToActionResult("Detail", "ViaturaTipo", new { @id = newViaturaTipo.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Tipo da Viatura criado com sucesso!";

            var model = _viaturaTipoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(ViaturaTipo viaturaTipo)
        {
            try
            {
                var newBatalhao = _viaturaTipoStore.Save(viaturaTipo);
                return Json(new { success = true, message = "Tipo da Viatura salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Tipo da Viatura" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            //if (_viaturaTipoStore.GetByTipoViaturaId(id).Any())
            //    return Json(new { success = false, message = "Este Tipo da Viatura possui relações e não poderá ser excluído!" });

            _viaturaTipoStore.Delete(id);
            return Json(new { success = true, message = "Tipo da Viatura excluído!" });
        }
    }
}