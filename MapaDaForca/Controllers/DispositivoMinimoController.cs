using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Controllers
{
    [Authorize]
    [Route("dispositivoMinimo")]

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
        private readonly IEscalaTurnoStore _escalaTurnoStore;

        public DispositivoMinimoController(
            IBombeiroStore bombeiroStore,
            IPostoStore postoStore,
            IQuartelStore quartelStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IFuncaoStore funcaoStore,
            IEscalaStore escalaStore,
            IEscalaTipoStore escalaTipoStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore,
            IEscalaTurnoStore escalaTurnoStore)
        {
            _bombeiroStore = bombeiroStore;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _funcaoStore = funcaoStore;
            _escalaStore = escalaStore;
            _escalaTipoStore = escalaTipoStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
            _escalaTurnoStore = escalaTurnoStore;
        }

        public IActionResult Index()
        {
            var escala = new Escala();
            escala.Quarteis = _quartelStore.GetAll();


            return View(escala);
        }


        [HttpPost]
        public JsonResult GetDispositivoMinimoByQuartel(Guid quartelId, bool periodoDiurno, DateTime calendarDate)
        {
            var events = new List<EventViewModel>();
            //var viaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByQuartelId(new Guid("64d91ea9-2252-4731-9ed8-762937ca140a"));
            var viaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByQuartelId(quartelId);

            List<QuantidadeFuncaoViewModel> result = viaturaTipoFuncoes
                .GroupBy(l => l.FuncaoId)
                .Select(x => new QuantidadeFuncaoViewModel
                {
                    FuncaoId = x.First().FuncaoId,
                    FuncaoNome = x.First().Funcao.Nome,
                    Quantidade = x.Sum(c => c.Quantidade),
                }).ToList();

            DateTime firstDay = new DateTime(calendarDate.Year, calendarDate.Month, 1);
            DateTime lastDay = new DateTime(calendarDate.Year, calendarDate.Month, DateTime.DaysInMonth(calendarDate.Year, calendarDate.Month));

            var escalasPeriodo = _escalaStore.GetByQuartelIdAndMonthYearAndPeriodoDiurno(quartelId, calendarDate.Month, calendarDate.Year, periodoDiurno).ToList();
            escalasPeriodo = escalasPeriodo.Where(x => x.EscalaTipoId == Guid.Empty).ToList();


            for (DateTime dt = firstDay; dt <= lastDay; dt = dt.AddDays(1))
            {
                foreach (var funcao in result)
                {
                    //var qtdeFuncao = _escalaStore.GetQuantityToDispositivoMinimo(quartelId, funcao.FuncaoId, dt, periodoDiurno);                  
                    var qtdeFuncao = escalasPeriodo.Count(x =>
                        x.FuncaoId == funcao.FuncaoId &&
                        x.DtEscala == dt &&
                        x.PeriodoDiurno == periodoDiurno
                        );

                    var className = "event-ok";
                    if (((funcao.Quantidade * -1) + qtdeFuncao) > 0)
                        className = "event-positive";

                    if ((funcao.Quantidade * -1) + qtdeFuncao < 0)
                        className = "event-negative";

                    events.Add(new EventViewModel()
                    {
                        id = new Guid(),
                        title = funcao.FuncaoNome.PadRight(10).Substring(0, 5) + "  " + ((funcao.Quantidade * -1) + qtdeFuncao),
                        start = dt,
                        className = className
                    });
                }
            }
            return Json(events.ToArray());
        }




        [HttpPost]
        [Route("getBombeirosFuncao")]
        public PartialViewResult getBombeirosFuncao(Guid quartelId, bool periodoDiurno, DateTime dtEscala)
        {
            var escalas = _escalaStore.GetByQuartelIdAndDtEscalaAndPeriodoDiurno(quartelId, dtEscala, periodoDiurno).ToList();

            var bombeiros = _bombeiroStore.GetAll().OrderBy(x => x.Nome).ToList();
            var funcoes = _funcaoStore.GetAll().OrderBy(x => x.Nome).ToList();

            escalas.ForEach(e => e.Bombeiro = bombeiros.FirstOrDefault(b => b.Id == e.BombeiroId.ToString()));
            escalas.ForEach(e => e.Funcao = funcoes.FirstOrDefault(f => f.Id == e.FuncaoId));

            //var funcaoBombeiros = new List<FuncaoBombeirosViewModel>();

            //List<string> funcoess = funcaoBombeiros.Select(m => m.Funcao.Nome).Distinct().ToList();

            ////var bombeirosByDataAndQuartelViewModel = new BombeirosByDataAndQuartelViewModel();
            ////bombeirosByDataAndQuartelViewModel.dtEscala = (string)dtEscala.ToString("d");
            ////bombeirosByDataAndQuartelViewModel.quartel = _quartelStore.GetById(quartelId);

            return PartialView("../DispositivoMinimo/_BombeiroFuncao", escalas);
        }
    }
}