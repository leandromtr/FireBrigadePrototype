﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    [Route("bombeiro")]
    public class BombeiroController : Controller
    {
        //private readonly UserManager<User> _userManager;
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IPostoStore _postoStore;
        private readonly IQuartelStore _quartelStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;
        private readonly IEscalaStore _escalaStore;
        private readonly IEscalaTipoStore _escalaTipoStore;


        public BombeiroController(
            IBombeiroStore bombeiroStore,
            IPostoStore postoStore,
            IQuartelStore quartelStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IFuncaoStore funcaoStore,
            IEscalaStore escalaStore,
            IEscalaTipoStore escalaTipoStore)
        {
            _bombeiroStore = bombeiroStore;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _funcaoStore = funcaoStore;
            _escalaStore = escalaStore;
            _escalaTipoStore = escalaTipoStore;
        }


        public ActionResult Index()
        {
            var bombeiro = _bombeiroStore.GetAll();
            var postos = new Posto();
            var quarteis = new Quartel();

            return View(bombeiro);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var bombeiro = new Bombeiro();

            bombeiro.Postos = _postoStore.GetAll();
            bombeiro.Quarteis = _quartelStore.GetAll();
            return View(bombeiro);

        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Bombeiro bombeiro)
        {
            var newBombeiro = _bombeiroStore.Save(bombeiro);
            return new RedirectToActionResult("Detail", "Bombeiro", new { @id = newBombeiro.Id, @message = true });
        }


        [HttpGet]
        [Route("{id}/detail/{message?}")]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Bombeiro criado com sucesso!";

            var bombeiro = new BombeiroViewModel();
            bombeiro.Bombeiro = _bombeiroStore.GetById(id);
            bombeiro.Bombeiro.Postos = _postoStore.GetAll();
            bombeiro.Bombeiro.Quarteis = _quartelStore.GetAll();
            bombeiro.BombeiroFuncoes = _bombeiroFuncaoStore.GetByBombeiroId(id).ToList();

            var bombeiroFuncao = new BombeiroFuncaoViewModel();
            bombeiroFuncao.BombeiroId = id;
            bombeiroFuncao.BombeiroFuncoes = _bombeiroFuncaoStore.GetByBombeiroId(id).ToList();
            bombeiroFuncao.Funcoes = _funcaoStore.GetAll().ToList();
            bombeiro.BombeiroFuncaoViewModel = bombeiroFuncao;

            return View(bombeiro);
        }

        [HttpGet]
        [Route("{id}/escala")]
        public ActionResult Escala(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Bombeiro criado com sucesso!";

            var bombeiroEscalaViewModel = new BombeiroEscalaViewModel();
            bombeiroEscalaViewModel.Funcoes = new List<Funcao>();

            bombeiroEscalaViewModel.Bombeiro = _bombeiroStore.GetById(id);
            bombeiroEscalaViewModel.Quarteis = _quartelStore.GetAll().ToList();
            bombeiroEscalaViewModel.EscalaTipos = _escalaTipoStore.GetAll().ToList();

            var bombeiroFuncoes = _bombeiroFuncaoStore.GetByBombeiroId(id).ToList();
            foreach(var bombeiroFuncao in bombeiroFuncoes)
            {
                var funcao = _funcaoStore.GetById(bombeiroFuncao.FuncaoId);
                bombeiroEscalaViewModel.Funcoes.Add(funcao);
            }

            return View(bombeiroEscalaViewModel);
        }


        [HttpPost]
        [Route("edit")]
        public JsonResult Edit(Bombeiro bombeiro)
        {
            try
            {
                var newBombeiro = _bombeiroStore.Save(bombeiro);
                return Json(new { success = true, message = "Bombeiro salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao salvar este Bombeiro" });
            }
        }


        [HttpDelete]
        [Route("{id}/delete")]
        public JsonResult Delete(Guid id)
        {
            if (_bombeiroFuncaoStore.GetByBombeiroId(id).Any())
                return Json(new { success = false, message = "Este bombeiro possui relações e não poderá ser excluído!" });

            if (_escalaStore.GetByBombeiroId(id).Any())
                return Json(new { success = false, message = "Este bombeiro possui relações e não poderá ser excluído!" });

            _bombeiroStore.Delete(id);
            return Json(new { success = true, message = "Bombeiro excluído!" });
        }


        [HttpPost]
        [Route("saveyear")]
        public void SaveYear(Guid bombeiroId, int year)
        {
            _escalaStore.SaveYear(bombeiroId, year);
        }


        [HttpPost]
        public JsonResult GetEvents(Guid bombeiroId, DateTime calendarDate)
        {
            var events = new List<EventViewModel>();
            var escalas = _escalaStore.GetByBombeiroIdAndMonthYear(bombeiroId, calendarDate.Month, calendarDate.Year);

            foreach (var item in escalas)
            {
                events.Add(new EventViewModel()
                {
                    id = item.Id,
                    title = (item.PeriodoDiurno ? "Diurno - " : "Noturno - ") + item.Funcao.Nome.ToString() + " - " +  item.Quartel.Nome.ToString(),
                    start = item.DtEscala
                });
            }
            return Json(events.ToArray());
        }


        [HttpPost]
        [Route("getescalabydata")]
        public JsonResult GetEscalaByData(Guid bombeiroId, DateTime dtEscala)
        {
            var escala = _escalaStore.GetByBombeiroIdAndDtEscala(bombeiroId, dtEscala);
            return Json(new { escala = escala });
        }


        [HttpPost]
        [Route("SaveBombeiroEscala")]
        public JsonResult SaveBombeiroEscala(DateTime dtEscala, Guid escalaId, Guid bombeiroId, Guid funcaoId, Guid quartelId, Guid escalaTipoId, bool periodoDiurno)
        {
            var escala = _escalaStore.GetByBombeiroIdAndDtEscala(bombeiroId, dtEscala);
            if (escala == null)
                escala = new Escala();

            escala.BombeiroId = bombeiroId;
            escala.DtEscala = dtEscala;
            escala.FuncaoId = funcaoId;
            escala.QuartelId = quartelId;
            escala.EscalaTipoId = escalaTipoId;
            escala.PeriodoDiurno = periodoDiurno;

            var newBombeiroEscala =  _escalaStore.Save(escala);
            string title = (newBombeiroEscala.PeriodoDiurno ? "Diurno - " : "Noturno - ") + _funcaoStore.GetById(funcaoId).Nome + " - " + _quartelStore.GetById(quartelId).Nome;

            return Json(new { success = true, message = "Data salva com sucesso!", id= newBombeiroEscala.Id , title = title });
        }


        [HttpDelete]
        [Route("deleteescala/{id}")]
        public JsonResult DeleteEscala(Guid id)
        {
            _escalaStore.Delete(id);
            return Json(new { success = true, message = "Data da Escala excluída!" });
        }
    }
}