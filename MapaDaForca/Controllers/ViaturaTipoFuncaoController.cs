using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MapaDaForca.Controllers
{
    public class ViaturaTipoFuncaoController : Controller
    {
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;

        public ViaturaTipoFuncaoController(
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore,
            IFuncaoStore funcaoStore)
        {
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
            _funcaoStore = funcaoStore;
        }

        [HttpGet]
        [Route("viaturatipofuncao/{viaturatipoId}")]
        public PartialViewResult ViaturaTipoFuncao(Guid viaturaTipoId)
        {            
            var viaturaTipoFuncaoViewModel = new ViaturaTipoFuncaoViewModel();
            viaturaTipoFuncaoViewModel.ViaturaTipoId = viaturaTipoId;
            viaturaTipoFuncaoViewModel.ViaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByViaturaTipoId(viaturaTipoId).ToList();
            viaturaTipoFuncaoViewModel.Funcoes = _funcaoStore.GetAll().ToList();

            return PartialView("../ViaturaTipoFuncao/_ViaturaTipoFuncao", viaturaTipoFuncaoViewModel);
        }

        [HttpPost]
        [Route("viaturatipofuncao/create")]
        public JsonResult Create(ViaturaTipoFuncao viaturaTipoFuncao)
        {
            var newViaturaTipoFuncao = _viaturaTipoFuncaoStore.Save(viaturaTipoFuncao);
            return Json(new { success = true, message = "Função do Tipo da Viatura adicionado!", id = newViaturaTipoFuncao });
        }

        [HttpDelete]
        [Route("viaturatipofuncao/delete")]
        public JsonResult Delete(Guid id)
        {
            //if (_quartelStore.GetByCompanhiaId(id).Any())
            //    return Json(new { success = false, message = "Esta companhia possui relações e não poderá ser excluída!" });

            _viaturaTipoFuncaoStore.Delete(id);
            return Json(new { success = true, message = "Função do Tipo da Viatura removido!" });
        }
    }
}