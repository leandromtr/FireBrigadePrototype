using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class ViaturaTipoFuncaoController : Controller
    {
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncao;

        public ViaturaTipoFuncaoController(
            IViaturaTipoFuncaoStore viaturaTipoFuncao)
        {
            _viaturaTipoFuncao = viaturaTipoFuncao;
        }

        public IActionResult Index()
        {
            var viaturaTipoFuncao = _viaturaTipoFuncao.GetAll();
            return View(viaturaTipoFuncao);
        }
    }
}