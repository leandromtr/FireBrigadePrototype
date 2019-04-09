using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MapaDaForca.Controllers
{
    public class QuartelViaturaController : Controller
    {
        private readonly IQuartelViaturaStore _quartelViaturaStore;
        private readonly IViaturaStore _viaturaStore;

        public QuartelViaturaController(
            IQuartelViaturaStore quartelViaturaStore,
            IViaturaStore viaturaStore)
        {
            _quartelViaturaStore = quartelViaturaStore;
            _viaturaStore = viaturaStore;
        }

        [HttpGet]
        [Route("quartelviatura/{quartelId}")]
        public PartialViewResult QuartelViatura(Guid quartelId)
        {
            ViewBag.Viaturas = new SelectList(_viaturaStore.GetAll().ToList(), "Id", "Matricula");

            var quartelViaturas = new QuartelViaturaViewModel();
            quartelViaturas.QuartelViaturas = _quartelViaturaStore.GetByQuartelId(quartelId).ToList();
            quartelViaturas.Viaturas = _viaturaStore.GetAll().ToList();

            return PartialView("../QuartelViatura/_QuartelViatura", quartelViaturas);
        }


        [HttpPost]
        [Route("quartelviatura/create")]
        public JsonResult Create(QuartelViatura quartelViatura)
        {
            var newQuartelViatura = _quartelViaturaStore.Save(quartelViatura);
            return Json(new { success = true, message = "Viatura adicionada!", id = newQuartelViatura });
        }

        [HttpDelete]
        [Route("quartelviatura/delete")]
        public JsonResult Delete(Guid id)
        {
            //if (_quartelStore.GetByCompanhiaId(id).Any())
            //    return Json(new { success = false, message = "Esta companhia possui relações e não poderá ser excluída!" });

            _quartelViaturaStore.Delete(id);
            return Json(new { success = true, message = "Viatura removida!" });
        }
    }
}