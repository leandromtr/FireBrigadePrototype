using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class ViaturaTipoFuncaoStore : IViaturaTipoFuncaoStore
    {
        private readonly IViaturaTipoFuncaoRepository _repository;
        private readonly IFuncaoStore _funcaoStore;
        //private readonly IViaturaTipoFuncaoStore _viaturaTipoFuncaoStore;
        private readonly IViaturaStore _viaturaStore;
        private readonly IQuartelViaturaStore _quartelViaturaStore;

        public ViaturaTipoFuncaoStore(
            IViaturaTipoFuncaoRepository repository,
            IFuncaoStore funcaoStore,
            //IViaturaTipoFuncaoStore viaturaTipoFuncaoStore
            IViaturaStore viaturaStore,
            IQuartelViaturaStore quartelViaturaStore
            )
        {
            _repository = repository;
            _funcaoStore = funcaoStore;
            //_viaturaTipoFuncaoStore = viaturaTipoFuncaoStore;
            _viaturaStore = viaturaStore;
            _quartelViaturaStore = quartelViaturaStore;
        }

        public IList<ViaturaTipoFuncao> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public IList<ViaturaTipoFuncao> GetByFuncaoId(Guid funcaoId)
        {
            return _repository.GetByFuncaoId(funcaoId).ToList();
        }

        public IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId)
        {
            var viaturaTipos = _repository.GetByViaturaTipoId(viaturaTipoId).ToList();
            var funcoes = _funcaoStore.GetAll().ToList();

            viaturaTipos.ForEach(v => v.Funcao = funcoes.FirstOrDefault(f => f.Id == v.FuncaoId));

            return viaturaTipos;
        }

        public ViaturaTipoFuncao GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public ViaturaTipoFuncao Save(ViaturaTipoFuncao save)
        {
            ViaturaTipoFuncao saved = null;

            if (_repository.IsExisting(save.Id))
            {
                saved = _repository.Update(save);
            }
            else
            {
                saved = _repository.Create(save);
            }

            return saved;
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public void DeleteByViaturaTipoId(Guid viaturaTipoId)
        {
            var requests = _repository.GetByViaturaTipoId(viaturaTipoId);
            foreach (var item in requests)
            {
                _repository.Delete(item.Id);
            }
        }

        public IList<ViaturaTipoFuncao> GetByQuartelId(Guid quartelId)
        {
            //var quartel = GetById(id);
            var quartelViaturas = _quartelViaturaStore.GetByQuartelId(quartelId);
            var viaturas = new List<Viatura>();
            var viaturatipoFuncoesGrouped = new List<ViaturaTipoFuncao>();

            foreach (var quartelViatura in quartelViaturas)
            {
                viaturas.Add(_viaturaStore.GetById(quartelViatura.ViaturaId));
            }

            foreach (var viatura in viaturas.Where(x => x.Operacional == true))
            {
                var viaturatipoFuncoes = GetByViaturaTipoId(viatura.ViaturaTipoId);

                foreach (var item in viaturatipoFuncoes)
                {
                    viaturatipoFuncoesGrouped.Add(item);
                }
            }

            ////List<ViaturaTipoFuncao> data = viaturatipoFuncoes.GroupBy(x => x.ViaturaTipoId)
            ////    .Select(x => new { quantidade x.Sum(y => y.Quantidade) }).ToList


            ////var data = viaturatipoFuncoes.GroupBy(x => x.ViaturaTipoId).Select(y => new { Id = y.Key, Quantidade = y.Sum(e => e.Quantidade)});

            //foreach (var viaturaTipoFuncao in viaturatipoFuncoes.GroupBy(x => x.Id).Select(y => new { Id = y.Key., Quantidade = y.Sum(e => e.Quantidade) }))
            //{
            //    var vTF = new ViaturaTipoFuncao()
            //    {
            //        Id = viaturaTipoFuncao.Id,
            //        Quantidade = viaturaTipoFuncao.Quantidade,
            //    };
            //    viaturatipoFuncoesGrouped.Add(vTF);
            //}

            //var viaturatipoFuncoes = _viaturaTipoFuncaoStore.GetAll();


            //DateTime firstDay = new DateTime(year, month, 1);
            //DateTime lastDay = new DateTime(year, month + 1, 1);           

            //for (DateTime dt = firstDay; dt <= lastDay; dt = dt.AddDays(1))
            //{

            //}

            return viaturatipoFuncoesGrouped;
        }
    }
}
