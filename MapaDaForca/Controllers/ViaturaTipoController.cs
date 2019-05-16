using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace MapaDaForca.Controllers
{
    [Authorize]
    public class ViaturaTipoController : Controller
    {
        private readonly IViaturaTipoStore _viaturaTipoStore;
        private readonly IViaturaStore _viaturaStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;


        public ViaturaTipoController(
            IViaturaTipoStore viaturaTipoStore,
            IViaturaStore viaturaStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore,
            IFuncaoStore funcaoStore)
        {
            _viaturaTipoStore = viaturaTipoStore;
            _viaturaStore = viaturaStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
            _funcaoStore = funcaoStore;
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

            var viaturaTipoFuncao = new ViaturaTipoFuncaoViewModel();
            viaturaTipoFuncao.ViaturaTipoId = id;
            viaturaTipoFuncao.ViaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByViaturaTipoId(id).ToList();
            viaturaTipoFuncao.Funcoes = _funcaoStore.GetAll().ToList();

            viaturaTipo.ViaturaTipoFuncaoViewModel = viaturaTipoFuncao;

            return View(viaturaTipo);
            
        }


        [HttpPost]
        public JsonResult Edit(ViaturaTipo viaturaTipo)
        {
            try
            {
                var newBatalhao = _viaturaTipoStore.Save(viaturaTipo);
                return Json(new { success = true, message = "Tipo da Viatura guardado com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar este Tipo da Viatura" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_viaturaStore.GetByViaturaTipoId(id).Any())
                return Json(new { success = false, message = "Este Tipo da Viatura possui relações e não poderá ser eliminado!" });

            _viaturaTipoFuncaoStore.DeleteByViaturaTipoId(id);
            _viaturaTipoStore.Delete(id);
            return Json(new { success = true, message = "Tipo da Viatura eliminado!" });
        }
    }
}