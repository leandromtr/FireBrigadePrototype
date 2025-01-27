using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MapaDaForca.Controllers
{
    [Authorize]
    public class FuncaoController : Controller
    {
        private readonly IFuncaoStore _funcaoStore;
        private readonly IEscalaStore _escalaStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;

        public FuncaoController(
            IFuncaoStore funcaoStore,
            IEscalaStore escalaStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore)
        {
            _funcaoStore = funcaoStore;
            _escalaStore = escalaStore;
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
        }


        public ActionResult Index()
        {
            var funcao = _funcaoStore.GetAll();
            return View(funcao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Funcao funcao)
        {
            var newFuncao = _funcaoStore.Save(funcao);
            return new RedirectToActionResult("Detail", "Funcao", new { @id = newFuncao.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Funcao criada com sucesso!";

            var model = _funcaoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(Funcao funcao)
        {
            try
            {
                var newFuncao = _funcaoStore.Save(funcao);
                return Json(new { success = true, message = "Função guardada com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar esta Função" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_bombeiroFuncaoStore.GetByFuncaoId(id).Any())
                return Json(new { success = false, message = "Esta Função possui relações e não poderá ser eliminada!" });

            if (_viaturaTipoFuncaoStore.GetByFuncaoId(id).Any())
                return Json(new { success = false, message = "Esta Função possui relações e não poderá ser eliminada!" });

            if (_escalaStore.GetByFuncaoId(id).Any())
                return Json(new { success = false, message = "Esta Função possui relações e não poderá ser eliminada!" });

            _funcaoStore.Delete(id);
            return Json(new { success = true, message = "Função eliminada!" });
        }
    }
}