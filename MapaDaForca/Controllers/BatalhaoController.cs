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
    [Route("batalhao")]
    public class BatalhaoController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IBatalhaoStore _batalhaoStore;
        private readonly ICompanhiaStore _companhiaStore;


        public BatalhaoController(
            IBatalhaoStore batalhaoStore,
            ICompanhiaStore companhiaStore)
        {
            _batalhaoStore = batalhaoStore;
            _companhiaStore = companhiaStore;
        }


        public ActionResult Index()
        {
            var batalhao = _batalhaoStore.GetAll();
            return View(batalhao);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Batalhao batalhao)
        {
            var newBatalhao = _batalhaoStore.Save(batalhao);
            return new RedirectToActionResult("Detail", "Batalhao", new { @id = newBatalhao.Id, @message =true });
        }


        [HttpGet]
        [Route("{id}/detail/{message?}")]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Batalhao criado com sucesso!";

            var model = _batalhaoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        [Route("edit")]
        public JsonResult Edit(Batalhao batalhao)
        {
            try
            {
                var newBatalhao = _batalhaoStore.Save(batalhao);
                return Json(new { success = true, message = "Batalhão guardado com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar este Batalhão" });
            }
        }


        [HttpDelete]
        [Route("{id}/delete")]
        public JsonResult Delete(Guid id)
        {
            if (_companhiaStore.GetByBatalhaoId(id).Any())
                return Json(new { success = false, message = "Este batalhão possui relações e não poderá ser eliminado!" });

            _batalhaoStore.Delete(id);
            return Json(new { success = true, message = "Batalhão eliminado!" });
        }
    }
}