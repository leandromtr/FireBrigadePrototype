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
    [Route("escala")]

    public class EscalaController : Controller
    {
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IPostoStore _postoStore;
        private readonly IQuartelStore _quartelStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IFuncaoStore _funcaoStore;
        private readonly IEscalaStore _escalaStore;
        private readonly IEscalaTipoStore _escalaTipoStore;

        public EscalaController(
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

        public IActionResult Index()
        {
            var escala = new Escala();
            escala.Quarteis = _quartelStore.GetAll();

            return View(escala);
        }



        [HttpPost]
        [Route("getBombeirosByDataAndQuartel")]
        public PartialViewResult GetBombeirosByDataAndQuartel(Guid quartelId, DateTime dtEscala)
        {            
            var escalas = _escalaStore.GetByQuartelIdAndDtEscala(quartelId, dtEscala).ToList();
            var bombeiros = _bombeiroStore.GetAll().OrderBy(x => x.Nome).ToList();
            var funcoes = _funcaoStore.GetAll().OrderBy(x => x.Nome).ToList();

            escalas.ForEach(e => e.Bombeiro = bombeiros.FirstOrDefault(b => b.Id == e.BombeiroId));
            escalas.ForEach(e => e.Funcao = funcoes.FirstOrDefault(f => f.Id == e.FuncaoId));

            //var bombeirosByDataAndQuartelViewModel = new BombeirosByDataAndQuartelViewModel();

            //bombeirosByDataAndQuartelViewModel.dtEscala = (string)dtEscala.ToString("d");
            //bombeirosByDataAndQuartelViewModel.quartel = _quartelStore.GetById(quartelId);


            return PartialView("../Escala/_BombeirosByDataAndQuartel", escalas);
        }
    }
}