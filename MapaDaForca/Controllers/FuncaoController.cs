using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly IFuncaoStore _funcaoStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;

        public FuncaoController(
            IFuncaoStore funcaoStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore)
        { 
            _funcaoStore = funcaoStore;
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
                return Json(new { success = true, message = "Função salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Função" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_bombeiroFuncaoStore.GetByFuncaoId(id).Any())
                return Json(new { success = false, message = "Este Função possui relações e não poderá ser excluída!" });

            if (_viaturaTipoFuncaoStore.GetByFuncaoId(id).Any())
                return Json(new { success = false, message = "Este Função possui relações e não poderá ser excluída!" });

            _funcaoStore.Delete(id);
            return Json(new { success = true, message = "Função excluído!" });
        }
    }
}