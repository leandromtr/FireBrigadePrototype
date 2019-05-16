using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MapaDaForca.Controllers
{
    [Authorize]
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
            var quartelViaturas = new QuartelViaturaViewModel();
            quartelViaturas.QuartelId = quartelId;
            quartelViaturas.QuartelViaturas = _quartelViaturaStore.GetByQuartelId(quartelId).ToList();
            quartelViaturas.Viaturas = _viaturaStore.GetAll().ToList();

            return PartialView("../QuartelViatura/_QuartelViatura", quartelViaturas);
        }

        //[HttpGet]        
        //public PartialViewResult QuartelViaturaLine(Guid quartelViaturaId)
        //{
        //    quartelViaturaId = new Guid("23a9e5f4-daed-4d4d-b759-781f6d85e273");
        //    QuartelViatura quartelViatura = _quartelViaturaStore.GetById(quartelViaturaId);

        //    return PartialView("../QuartelViatura/_QuartelViaturaLine", quartelViatura);
        //}

        //[HttpPost]        
        //public PartialViewResult QuartelViaturaLine()
        //{
        //    //quartelViaturaId = new Guid("23a9e5f4-daed-4d4d-b759-781f6d85e273");
        //    //var quartelViatura = _quartelViaturaStore.GetById(quartelViaturaId);

        //    return PartialView("../QuartelViatura/_QuartelViaturaLine"/*, quartelViatura*/);
        //}


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
            //    return Json(new { success = false, message = "Esta companhia possui relações e não poderá ser eliminada!" });

            _quartelViaturaStore.Delete(id);
            return Json(new { success = true, message = "Viatura removida!" });
        }
    }
}