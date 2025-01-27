using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Controllers
{
    [Authorize]
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

        [HttpPost]
        [Route("escalaturno/SaveYear")]
        public void SaveYear(int year)
        {
            _escalaTurnoStore.SaveYear(year);
        }


        [HttpPost]
        [Route("escalaturno/SaveByDate")]
        public JsonResult SaveByDate(DateTime dtEscalaTurno, Guid periodoDiurnoId, Guid periodoNoturnoId, int turnoDiurno, int turnoNoturno)
        {
            EscalaTurno escalaTurno = new EscalaTurno { Id = periodoDiurnoId, Turno = (Turno)turnoDiurno, DtEscalaTurno = dtEscalaTurno, PeriodoDiurno = true };
            _escalaTurnoStore.Save(escalaTurno);

            escalaTurno.Id = periodoNoturnoId;
            escalaTurno.Turno = (Turno)turnoNoturno;
            escalaTurno.PeriodoDiurno = false;
            _escalaTurnoStore.Save(escalaTurno);
            var escala = _escalaTurnoStore.GetByDtEscalaTurno(dtEscalaTurno);

            var diurnoId = escala.Where(x => x.PeriodoDiurno == true).FirstOrDefault().Id;
            var noturnoId = escala.Where(x => x.PeriodoDiurno == false).FirstOrDefault().Id;

            return Json(new { success = true, message = "Data salva com sucesso!", diurno = diurnoId, noturno = noturnoId });
        }


        [HttpGet]
        public JsonResult GetByData(DateTime dtEscalaTurno)
        {
            var escalaTurnos = _escalaTurnoStore.GetByDtEscalaTurno(dtEscalaTurno);
            return Json(new { escalaTurnos = escalaTurnos });
        }


        [HttpPost]
        public JsonResult GetEvents(DateTime calendarDate)
        {
            var events = new List<EventViewModel>();
            //var escalaTurnos = _escalaTurnoStore.GetAll().Where(x=> x.DtEscalaTurno.Month == calendarDate.Month);
            var escalaTurnos = _escalaTurnoStore.GetByMonthYear(calendarDate.Month, calendarDate.Year);

            foreach (var item in escalaTurnos)
            {
                events.Add(new EventViewModel()
                {
                    id = item.Id,
                    title = (item.PeriodoDiurno ? "D - " : "N - ") + item.Turno,
                    start = item.DtEscalaTurno
                });
            }
            return Json(events.ToArray());
        }
    }
}