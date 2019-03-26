using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
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

        public ActionResult Create()
        {
            return View();
        }
    }
}