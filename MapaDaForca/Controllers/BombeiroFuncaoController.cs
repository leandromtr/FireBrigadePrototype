using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MapaDaForca.Controllers
{
    [Authorize]

    public class BombeiroFuncaoController : Controller
    {
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;

        public BombeiroFuncaoController(
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IFuncaoStore funcaoStore)
        {
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _funcaoStore = funcaoStore;
        }

        public IActionResult Index()
        {
            var posto = _bombeiroFuncaoStore.GetAll();
            return View(posto);
        }

        [HttpGet]
        [Route("bombeirofuncao/{bombeiroId}")]
        public PartialViewResult ViaturaTipoFuncao(Guid bombeiroId)
        {
            var bombeiroFuncaoViewModel = new BombeiroFuncaoViewModel();
            bombeiroFuncaoViewModel.BombeiroId = bombeiroId;
            bombeiroFuncaoViewModel.BombeiroFuncoes = _bombeiroFuncaoStore.GetByBombeiroId(bombeiroId).ToList();
            bombeiroFuncaoViewModel.Funcoes = _funcaoStore.GetAll().ToList();

            return PartialView("../BombeiroFuncao/_BombeiroFuncao", bombeiroFuncaoViewModel);
        }

        [HttpPost]
        [Route("bombeirofuncao/create")]
        public JsonResult Create(BombeiroFuncao bombeiroFuncao)
        {
            var newBombeiroFuncao = _bombeiroFuncaoStore.Save(bombeiroFuncao);
            return Json(new { success = true, message = "Função do Bombeiro adicionada!", id = newBombeiroFuncao });
        }

        [HttpDelete]
        [Route("bombeirofuncao/delete")]
        public JsonResult Delete(Guid id)
        {
            //if (_quartelStore.GetByCompanhiaId(id).Any())
            //    return Json(new { success = false, message = "Esta companhia possui relações e não poderá ser eliminada!" });

            _bombeiroFuncaoStore.Delete(id);
            return Json(new { success = true, message = "Função do Bombeiro removida!" });
        }
    }
}