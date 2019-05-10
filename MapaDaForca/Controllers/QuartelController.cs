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
    [Route("quartel")]
    public class QuartelController : Controller
    {
        private readonly ICompanhiaStore _companhiaStore;
        private readonly IEscalaStore _escalaStore;
        private readonly IQuartelStore _quartelStore;
        private readonly IQuartelViaturaStore _quartelViaturaStore;
        private readonly IViaturaStore _viaturaStore;
        private readonly IBatalhaoStore _batalhaoStore;
        private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;
        private readonly IBombeiroStore _bombeiroStore;

        public QuartelController(
            ICompanhiaStore companhiaStore,
            IEscalaStore escalaStore,
            IQuartelStore quartelStore,
            IQuartelViaturaStore quartelViaturaStore,
            IViaturaStore viaturaStore,
            IBatalhaoStore batalhaoStore,
            IViaturaTipoFuncaoStore viaturaTipoFuncaoStore,
            IBombeiroStore bombeiroStore)
        {
            _companhiaStore = companhiaStore;
            _escalaStore = escalaStore;
            _quartelStore = quartelStore;
            _quartelViaturaStore = quartelViaturaStore;
            _viaturaStore = viaturaStore;
            _batalhaoStore = batalhaoStore;
            _viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
            _bombeiroStore = bombeiroStore;
        }


        public ActionResult Index()
        {
            var quartel = _quartelStore.GetAll();
            return View(quartel);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var quartel = new Quartel();
            quartel.Companhias = _companhiaStore.GetAll();
            return View(quartel);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Quartel quartel)
        {
            var newQuartel= _quartelStore.Save(quartel);
            return new RedirectToActionResult("Detail", "Quartel", new { @id = newQuartel.Id, @message = true });
        }


        [HttpGet]
        [Route("{id}/detail/{message?}")]
        public ActionResult Detail(Guid id, bool message)
        {
            if (message)
                ViewData["MessageCreate"] = "Quartel criado com sucesso!";

            var quartel = new QuartelViewModel();
            quartel.Quartel = _quartelStore.GetById(id);
            quartel.Quartel.Companhias = _companhiaStore.GetAll();

            var quartelViatura = new QuartelViaturaViewModel();
            quartelViatura.QuartelId = id;
            quartelViatura.QuartelViaturas = _quartelViaturaStore.GetByQuartelId(id).ToList();
            quartelViatura.Viaturas=_viaturaStore.GetAll().ToList();
            quartel.QuartelViaturaViewModel = quartelViatura;

            return View(quartel);
        }


        [HttpPost]
        [Route("edit")]
        public JsonResult Edit(Quartel quartel)
        {
            try
            {
                var newQuartel = _quartelStore.Save(quartel);
                return Json(new { success = true, message = "Quartel guardado com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erro ao guardar este Quartel" });
            }
        }


        [HttpDelete]
        [Route("{id}/delete")]
        public JsonResult Delete(Guid id)
        {
            if (_escalaStore.GetByQuartelId(id).Any())
                return Json(new { success = false, message = "Este Quartel possui relações e não poderá ser eliminado!" });

            if (_bombeiroStore.GetByQuartelId(id).Any())
                return Json(new { success = false, message = "Este Quartel possui relações e não poderá ser eliminado!" });

            _quartelViaturaStore.DeleteByQuartelId(id);
            _quartelStore.Delete(id);
            return Json(new { success = true, message = "Quartel eliminado!" });
        }


        [HttpGet]
        [Route("quartelmapa")]
        public ActionResult QuartelMapa()
        {
            var quarteis= _quartelStore.GetAll();
            var quarteisViewModel = new List<QuartelViewModel>();

            foreach (var quartel in quarteis)
            {
                var quartelViewModel = new QuartelViewModel();
                quartelViewModel.Quartel = _quartelStore.GetById(quartel.Id);

                var viaturaTipoFuncoes = _viaturaTipoFuncaoStore.GetByQuartelId(quartel.Id);
                quartelViewModel.QuantidadeFuncoesViewModel = viaturaTipoFuncoes
                    .GroupBy(l => l.FuncaoId)
                    .Select(x => new QuantidadeFuncaoViewModel
                    {
                        FuncaoId = x.First().FuncaoId,
                        FuncaoNome = x.First().Funcao.Nome,
                        Quantidade = x.Sum(c => c.Quantidade),
                    }).ToList();

                var quartelViatura = new QuartelViaturaViewModel();
                quartelViatura.QuartelViaturas = _quartelViaturaStore.GetByQuartelId(quartel.Id).ToList();
                //quartelViatura.Viaturas = _viaturaStore.GetAll().ToList();
                quartelViewModel.QuartelViaturaViewModel = quartelViatura;
                quartelViewModel.Bombeiros = _bombeiroStore.GetByQuartelId(quartel.Id);
                quarteisViewModel.Add(quartelViewModel);
            }

            var batalhoes = _batalhaoStore.GetAll();
            var companhias = _companhiaStore.GetAll();
            quarteisViewModel.ForEach(q => q.Quartel.Companhia = companhias.FirstOrDefault(c => c.Id == q.Quartel.CompanhiaId));
            quarteisViewModel.ForEach(q => q.Quartel.Companhia.Batalhao = batalhoes.FirstOrDefault(b => b.Id == q.Quartel.Companhia.BatalhaoId));

            return View(quarteisViewModel);
        }
    }
}