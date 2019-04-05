using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class QuartelViaturaController : Controller
    {
        private readonly IQuartelViaturaStore _quartelViatura;

        public QuartelViaturaController(
            IQuartelViaturaStore viaturaTipoFuncao)
        {
            _quartelViatura = viaturaTipoFuncao;
        }

        public IActionResult Index()
        {
            var quartelViatura = _quartelViatura.GetAll();
            return View(quartelViatura);
        }
    }
}