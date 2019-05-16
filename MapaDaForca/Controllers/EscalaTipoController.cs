using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    [Authorize]

    public class EscalaTipoController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IEscalaTipoStore _escalaTipoStore;
        private readonly IEscalaStore _escalaStore;


        public EscalaTipoController(
            IEscalaTipoStore escalaTipoStore,
            IEscalaStore escalaStore)
        {
            _escalaTipoStore = escalaTipoStore;
            _escalaStore = escalaStore;
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
                ViewData["MessageCreate"] = "Tipo da Ausência criado com sucesso!";

            var model = _escalaTipoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Edit(EscalaTipo escalaTipo)
        {
            try
            {
                var newEscalaTipo = _escalaTipoStore.Save(escalaTipo);
                return Json(new { success = true, message = "Tipo da Ausência guardado com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar este Tipo da Ausência" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            if (_escalaStore.GetByEscalaTipoId(id).Any())
                return Json(new { success = false, message = "Este Tipo da Ausência possui relações e não poderá ser eliminado!" });

            _escalaTipoStore.Delete(id);
            return Json(new { success = true, message = "Tipo da Ausência eliminado!" });
        }
    }
}