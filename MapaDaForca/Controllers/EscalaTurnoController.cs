using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class EscalaTurnoController : Controller
    {
        private readonly IEscalaTurnoStore _escalaTurnoStore;

        public EscalaTurnoController(
            IEscalaTurnoStore escalaTurnoStore)
        {
            _escalaTurnoStore = escalaTurnoStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("escalaturno/getbydata")]
        public JsonResult GetByData(DateTime dtEscalaTurno)
        {
            var escalaTurnos = _escalaTurnoStore.GetByDtEscalaTurno(dtEscalaTurno);
            return Json(new { escalaTurnos = escalaTurnos });
        }
    }
}