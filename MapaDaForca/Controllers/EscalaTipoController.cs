using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class EscalaTipoController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IEscalaTipoStore _escalaTipoStore;
        //private readonly IEscalaStore _escalaStore;


        public EscalaTipoController(
            IEscalaTipoStore escalaTipoStore)
          //  IEscalaStore escalaStore)
        {
            _escalaTipoStore = escalaTipoStore;
       //     _escalaStore = escalaStore;
        }


        public ActionResult Index()
        {
            var escalaTipo = _escalaTipoStore.GetAll();
            return View(escalaTipo);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EscalaTipo escalaTipo)
        {
            var newEscalaTipo = _escalaTipoStore.Save(escalaTipo);
            return new RedirectToActionResult("Detail", "EscalaTipo", new { @id = newEscalaTipo.Id, @message = true });
        }


        [HttpGet]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Tipo da Escala criado com sucesso!";

            var model = _escalaTipoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(EscalaTipo escalaTipo)
        {
            try
            {
                var newEscalaTipo = _escalaTipoStore.Save(escalaTipo);
                return Json(new { success = true, message = "Tipo da Escala salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Tipo da Escala" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            //if (_companhiaStore.GetByEscalaTipoId(id).Any())
            //    return Json(new { success = false, message = "Este batalhão possui relações e não poderá ser excluído!" });

            _escalaTipoStore.Delete(id);
            return Json(new { success = true, message = "Tipo da Escala excluído!" });
        }
    }
}