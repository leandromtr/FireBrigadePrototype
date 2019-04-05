using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;
using MapaDaForca.ViewModel;

namespace MapaDaForca.Controllers
{
    public class ViaturaTipoController : Controller
    {
        private readonly IViaturaTipoStore _viaturaTipoStore;
        private readonly IViaturaStore _viaturaStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;


        public ViaturaTipoController(
            IViaturaTipoStore viaturaTipoStore,
            IViaturaStore viaturaStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore)
        {
            _viaturaTipoStore = viaturaTipoStore;
            _viaturaStore = viaturaStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
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

            var viaturaTipo = new ViaturaTipoViewModel();
            viaturaTipo.ViaturaTipo = _viaturaTipoStore.GetById(id);
            viaturaTipo.ViaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByViaturaTipoId(id).ToList();

            return View(viaturaTipo);
            //var model = _viaturaTipoStore.GetById(id);
            //return View(model);
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
            if (_viaturaStore.GetByViaturaTipoId(id).Any())
                return Json(new { success = false, message = "Esta Viatura possui relações e não poderá ser excluída!" });

            _viaturaTipoStore.Delete(id);
            return Json(new { success = true, message = "Tipo da Viatura excluído!" });
        }
    }
}