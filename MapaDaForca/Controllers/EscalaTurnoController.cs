using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MapaDaForca.Controllers
{
    public class EventViewModel
    {
        public Guid id { get; set; }

        public String title { get; set; }

        public DateTime start { get; set; }
    }

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
            return View(_escalaTurnoStore.GetAll().ToList());
        }

        [HttpPost]
        [Route("escalaturno/SaveYear")]
        public void PopulateYear(int year)
        {
            _escalaTurnoStore.SaveYear(year);
        }


        [HttpPost]
        [Route("escalaturno/SaveByDate")]
        public JsonResult SaveByDate(DateTime dtEscalaTurno, Guid periodoDiurnoId, Guid periodoNoturnoId, int turnoDiurno, int turnoNoturno)
        {
            EscalaTurno escalaTurno = new EscalaTurno { Id = periodoDiurnoId, Turno = turnoDiurno, DtEscalaTurno = dtEscalaTurno, PeriodoDiurno = true };
            _escalaTurnoStore.Save(escalaTurno);

            escalaTurno.Id = periodoNoturnoId;
            escalaTurno.Turno = turnoNoturno;
            escalaTurno.PeriodoDiurno = false;
            _escalaTurnoStore.Save(escalaTurno);
            return Json(new { success = true, message = "Data salva com sucesso!" });
        }

        //[HttpPost]
        //public ActionResult ListA()
        //{
        //    var escalaTurnos = _escalaTurnoStore.GetAll();

        //    var epoch = new DateTime(1970, 1, 1);

        //    //var ctx = new AdventureWorksEntities();
        //    //var data = ctx.SalesOrderHeaders
        //    //.Where(i => startDate <= i.OrderDate && i.OrderDate <= endDate)
        //    //.GroupBy(i => i.OrderDate)
        //    //.Select(i => new { OrderDate = i.Key, Sales = i.FirstOrDefault() }).Take(20).ToList();

        //    //return Json(new { escalaTurnos = escalaTurnos });

        //    string json = @"{
        //              "popularity": 3.518962,
        //              "production_companies": [
        //                {
        //                  "name": "value1",
        //                  "id": 4
        //                },
        //                {
        //                  "name": "value2",
        //                  "id": 562
        //                },
        //                {
        //                  "name": "value13",
        //                  "id": 14654
        //                },
        //                {
        //                  "name": "value4",
        //                  "id": 19177
        //                },
        //                {
        //                  "name": "value5",
        //                  "id": 23243
        //                }
        //              ]
        //            }";
        //Movie Data = JsonConvert.DeserializeObject<Movie>(json);

        //return Data;

        //    //var aaa= Json(escalaTurnos.Select(i => new
        //    //{
        //    //    //title = (i.Sales.Customer != null) ? i.Sales.Customer.AccountNumber : “Untitled”,
        //    //    //start = i.OrderDate.ToShortDateString(),
        //    //    //allDay = true
        //    //    title = "Untitled sdddd",
        //    //    start = i.DtEscalaTurno.ToShortDateString(),
        //    //    allDay = true
        //    //}));
        //    return json;
        //}

        [HttpGet]
        [Route("escalaturno/getEvents")]
        public JsonResult GetByData(DateTime dtEscalaTurno)
        {
            var escalaTurnos = _escalaTurnoStore.GetByDtEscalaTurno(dtEscalaTurno);
            return Json(new { escalaTurnos = escalaTurnos });
        }




        public JsonResult GetEvents1()
        {
            var events = new List<EventViewModel>();
            var escalaTurnos = _escalaTurnoStore.GetAll().Take(100);

            foreach (var item in escalaTurnos)
            {
                events.Add(new EventViewModel()
                {
                    id = item.Id,
                    title = (item.PeriodoDiurno ? "D - Turno": "N - Turno") + " " + item.Turno.ToString(),
                    start = item.DtEscalaTurno
                });
            }
            return Json(events.ToArray());
        }

        //public JsonResult GetEvents1()
        //{
        //    DateTime start = DateTime.Today.AddDays(1);
        //    DateTime end = DateTime.Today.AddDays(1);
        //    return Json(GenerateEvents(start, end, 1));
        //}


        //private EventViewModel[] GenerateEvents(DateTime start, DateTime end, int startId)
        //{
        //    var viewModel = new EventViewModel();
        //    var events = new List<EventViewModel>();
        //    var endId = startId + 5;

        //    for (var i = startId; i <= endId; i++)
        //    {
        //        events.Add(new EventViewModel()
        //        {
        //            id = new Guid(),
        //            title = "Event " + i,
        //            start = start,
        //            end = end,
        //            allDay = false
        //        });

        //        start = start.AddDays(7);
        //        end = end.AddDays(7);
        //    }

        //    return events.ToArray();
        //}
    }
}