using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class BombeiroFuncaoStore : IBombeiroFuncaoStore
    {
        private readonly IBombeiroFuncaoRepository _repository;
        private readonly IFuncaoStore _funcaoStore;
        //private readonly ICompanhiaRepository _companhiaRepository;

        public BombeiroFuncaoStore(
            IBombeiroFuncaoRepository repository,
            IFuncaoStore funcaoStore)
        {
            _repository = repository;
            _funcaoStore = funcaoStore;
            //_companhiaRepository = companhiaRepository;
        }

        public IList<BombeiroFuncao> GetAll()
        {
            return _repository.GetAll().ToList(); ;
        }

        public IList<BombeiroFuncao> GetByBombeiroId(Guid bombeiroId)
        {
            var bombeiros = _repository.GetByBombeiroId(bombeiroId).ToList();
            var funcoes = _funcaoStore.GetAll().ToList();

            bombeiros.ForEach(b => b.Funcao = funcoes.FirstOrDefault(f => f.Id == b.FuncaoId));

            return bombeiros;
        }

        public IList<BombeiroFuncao> GetByFuncaoId(Guid funcaoId)
        {
            return _repository.GetByFuncaoId(funcaoId).ToList();
        }

        public BombeiroFuncao GetById(Guid id)
        {
            return _repository.GetById(id);
        }


        public BombeiroFuncao GetPrincipalByBombeiroId(Guid bombeiroId)
        {
            var bombeiroFuncao = _repository.GetByBombeiroId(bombeiroId).Where(x => x.FuncaoPrincipal == true).FirstOrDefault();
            bombeiroFuncao.Funcao = _funcaoStore.GetById(bombeiroFuncao.FuncaoId);

            return bombeiroFuncao;
        }

        public BombeiroFuncao Save(BombeiroFuncao save)
        {
            BombeiroFuncao saved = null;

            if (_repository.IsExisting(save.Id))
            {
                saved = _repository.Update(save);
            }
            else
            {
                var bombeiroFuncoes = GetByBombeiroId(save.BombeiroId);
                if (bombeiroFuncoes.Count() == 0)
                {
                    save.FuncaoPrincipal = true;
                }
                else
                {
                    if (save.FuncaoPrincipal == true)
                    {
                        foreach (var bombeiroFuncao in bombeiroFuncoes)
                        {
                            bombeiroFuncao.FuncaoPrincipal = false;
                            _repository.Update(bombeiroFuncao);
                        }
                    }
                }
                saved = _repository.Create(save);
            }

            return saved;
        }

        public bool Delete(Guid id)
        {
            var bombeiroFuncao = GetById(id);

            if (bombeiroFuncao.FuncaoPrincipal == true)
            {
                var bombeiroFuncoesPrincipal = GetByBombeiroId(bombeiroFuncao.BombeiroId).Where(x => x.FuncaoPrincipal == false).FirstOrDefault();
                if (bombeiroFuncoesPrincipal != null)
                {
                    bombeiroFuncoesPrincipal.FuncaoPrincipal = true;
                    _repository.Update(bombeiroFuncoesPrincipal);
                }
            }

            return _repository.Delete(id);
        }
    }
}
