using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class DispositivoMinimoController : Controller
    {
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IPostoStore _postoStore;
        private readonly IQuartelStore _quartelStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;
        private readonly IEscalaStore _escalaStore;
        private readonly IEscalaTipoStore _escalaTipoStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;

        public DispositivoMinimoController(
            IBombeiroStore bombeiroStore,
            IPostoStore postoStore,
            IQuartelStore quartelStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IFuncaoStore funcaoStore,
            IEscalaStore escalaStore,
            IEscalaTipoStore escalaTipoStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore)
        {
            _bombeiroStore = bombeiroStore;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _funcaoStore = funcaoStore;
            _escalaStore = escalaStore;
            _escalaTipoStore = escalaTipoStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
        }

        public IActionResult Index()
        {
            var escala = new Escala();
            escala.Quarteis = _quartelStore.GetAll();


            return View(escala);
        }


        //[HttpPost]
        //public JsonResult GetDispositivoMinimo(DateTime calendarDate)
        //{
        //    var events = new List<EventViewModel>();

        //    var viaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByQuartelId(new Guid("64d91ea9-2252-4731-9ed8-762937ca140a"));
        //    var aaa = viaturaTipoFuncoes.GroupBy(
        //        p => p.Id,
        //        p => p.Quantidade,
        //        (key, g) => new { Id = key, Quantidade = g.ToList() });




        //    foreach (var viaturaTipoFuncao in viaturaTipoFuncoes.GroupBy(x => x.Id).Select())
        //    {

        //    }

        //    foreach (var item in escalaTurnos)
        //    {
        //        events.Add(new EventViewModel()
        //        {
        //            id = item.Id,
        //            title = (item.PeriodoDiurno ? "D - " : "N - ") + item.Turno,
        //            start = item.DtEscalaTurno
        //        });
        //    }
        //    return Json(events.ToArray());
        //}
    }
}