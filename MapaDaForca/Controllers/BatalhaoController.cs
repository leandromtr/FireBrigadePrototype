using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class BatalhaoController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IBatalhaoStore _batalhaoStore;

        public BatalhaoController(
            //UserManager<User> userManager,
            IBatalhaoStore batalhaoStore)
        {
            //_userManager = userManager;
            _batalhaoStore = batalhaoStore;
        }


        public ActionResult Index()
        {
            var batalhao = _batalhaoStore.GetAll();
            return View(batalhao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Batalhao batalhao)
        {
            var newBatalhao = _batalhaoStore.Save(batalhao);
            return new RedirectToActionResult("Edit", "Batalhao", new { @id = newBatalhao.Id });
        }


        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = _batalhaoStore.GetById(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(Batalhao batalhao)
        {
            var newBatalhao = _batalhaoStore.Save(batalhao);
            return new RedirectToActionResult("Edit", "Batalhao", new { @id = newBatalhao.Id });
        }


        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _batalhaoStore.Delete(id);
            return RedirectToAction("Index", "Batalhao");
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
    }
}