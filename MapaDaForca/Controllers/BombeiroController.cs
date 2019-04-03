using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class BombeiroController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IPostoStore _postoStore;
        private readonly IQuartelStore _quartelStore;


        public BombeiroController(
            IBombeiroStore bombeiroStore,
            IPostoStore postoStore,
            IQuartelStore quartelStore)
        {
            _bombeiroStore = bombeiroStore;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
        }


        public ActionResult Index()
        {
            var bombeiro = _bombeiroStore.GetAll();
            var postos = new Posto();
            var quarteis = new Quartel();

            return View(bombeiro);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var bombeiro = new Bombeiro();

            bombeiro.Postos = _postoStore.GetAll();
            bombeiro.Quarteis = _quartelStore.GetAll();
            return View(bombeiro);

        }

        [HttpPost]
        public ActionResult Create(Bombeiro bombeiro)
        {
            var newBombeiro = _bombeiroStore.Save(bombeiro);
            return new RedirectToActionResult("Detail", "Bombeiro", new { @id = newBombeiro.Id });
        }


        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var bombeiro = _bombeiroStore.GetById(id);

            bombeiro.Postos = _postoStore.GetAll();
            bombeiro.Quarteis = _quartelStore.GetAll();
            return View(bombeiro);
        }


        [HttpPost]
        public JsonResult Edit(Bombeiro bombeiro)
        {
            try
            {
                var newBombeiro = _bombeiroStore.Save(bombeiro);
                return Json(new { success = true, message = "Bombeiro salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Bombeiro" });
            }
        }


        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            //if (_companhiaStore.GetByBombeiroId(id).Any())
            //    return Json(new { success = false, message = "Este batalhão possui relações e não poderá ser excluído!" });

            _bombeiroStore.Delete(id);
            return Json(new { success = true, message = "Bombeiro excluído!" });
        }
    }
}