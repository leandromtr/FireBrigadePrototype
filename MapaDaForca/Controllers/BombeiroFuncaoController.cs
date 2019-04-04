using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class BombeiroFuncaoController : Controller
    {
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;

        public BombeiroFuncaoController(
            IBombeiroFuncaoStore bombeiroFuncaoStore)
        {
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
        }

        public IActionResult Index()
        {
            var posto = _bombeiroFuncaoStore.GetAll();
            return View(posto);
        }        
    }
}