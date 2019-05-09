using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class EscalaStore : IEscalaStore
    {
        private readonly IEscalaRepository _repository;
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IEscalaTurnoStore _escalaTurnoStore;
        private readonly IBombeiroFuncaoStore _bombeiroFuncaoStore;
        private readonly IQuartelStore _quartelStore;
        private readonly IFuncaoStore _funcaoStore;

        public EscalaStore(
            IEscalaRepository repository,
            IBombeiroStore bombeiroStore,
            IEscalaTurnoStore escalaTurnoStore,
            IBombeiroFuncaoStore bombeiroFuncaoStore,
            IQuartelStore quartelStore,
            IFuncaoStore funcaoStore)
        {
            _repository = repository;
            _bombeiroStore = bombeiroStore;
            _escalaTurnoStore = escalaTurnoStore;
            _bombeiroFuncaoStore = bombeiroFuncaoStore;
            _quartelStore = quartelStore;
            _funcaoStore = funcaoStore;
            //_companhiaRepository = companhiaRepository;
        }

        public IList<Escala> GetAll()
        {
            return _repository.GetAll().ToList(); ;
        }

        public IList<Escala> GetByBombeiroId(Guid bombeiroId)
        {
            return _repository.GetByBombeiroId(bombeiroId).ToList();
        }

        public IList<Escala> GetByEscalaTipoId(Guid escalaTipoId)
        {
            return _repository.GetByEscalaTipoId(escalaTipoId).ToList();
        }

        public IList<Escala> GetByFuncaoId(Guid funcaoId)
        {
            return _repository.GetByFuncaoId(funcaoId).ToList();
        }

        public IList<Escala> GetByQuartelId(Guid quartelId)
        {
            return _repository.GetByQuartelId(quartelId).ToList();
        }

        public IList<Escala> GetByBombeiroIdAndMonthYear(Guid bombeiroId, int month, int year)
        {
            //var bombeiro = _repository.GetByBombeiroId(bombeiroId).ToList();
            var funcoes = _funcaoStore.GetAll().ToList();
            var quarteis = _quartelStore.GetAll().ToList();

            var escalas = _repository.GetByBombeiroIdAndMonthYear(bombeiroId, month, year).ToList();

            escalas.ForEach(e => e.Funcao = funcoes.FirstOrDefault(f => f.Id == e.FuncaoId));
            escalas.ForEach(e => e.Quartel = quarteis.FirstOrDefault(q => q.Id == e.QuartelId));

            return escalas;
        }

        public IList<Escala> GetByQuartelIdAndDtEscala(Guid quartelId, DateTime dtEscala)
        {
            return _repository.GetByQuartelIdAndDtEscala(quartelId, dtEscala);
        }

        public IList<Escala> GetByQuartelIdAndDtEscalaAndPeriodoDiurno(Guid quartelId, DateTime dtEscala, bool periodoDiurno)
        {
            return _repository.GetByQuartelIdAndDtEscalaAndPeriodoDiurno(quartelId, dtEscala, periodoDiurno);
        }

        //IList<Escala> GetByQuartelIdAndMonthYearAndPeriodoDiurno(Guid quartelId, int month, int year, bool periodoDiurno)
        //{
        //    return _repository.GetByQuartelIdAndMonthYearAndPeriodoDiurno(quartelId, month, year, periodoDiurno);
        //}

        public Escala GetByBombeiroIdAndDtEscala(Guid bombeiroId, DateTime dtEscala)
        {
            return _repository.GetByBombeiroIdAndDtEscala(bombeiroId, dtEscala);
        }

        public Escala GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Escala Save(Escala save)
        {
            Escala saved = null;

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

        public void SaveYear(Guid bombeiroId, int year)
        {
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);

            var bombeiro = _bombeiroStore.GetById(bombeiroId);
            var bombeiroFuncao = _bombeiroFuncaoStore.GetPrincipalByBombeiroId(bombeiroId);
            var escalaTurnos = _escalaTurnoStore.GetByTurno(bombeiro.Turno).ToList();
            var escala = new Escala() {
                BombeiroId = bombeiro.Id,
                FuncaoId = bombeiroFuncao.FuncaoId,
                QuartelId = bombeiro.QuartelId,
                EscalaTipoId = Guid.Empty, // FUNCAO PRINCIPAL
            };

            foreach (var escalaTurno in escalaTurnos)
            {
                escala.Id = new Guid();
                escala.DtEscala = escalaTurno.DtEscalaTurno;
                escala.PeriodoDiurno = escalaTurno.PeriodoDiurno;
                Save(escala);
            }
        }


        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }


        public int GetQuantityToDispositivoMinimo(Guid quartelId, Guid funcaoId, DateTime dtEscala, bool periodoDiurno)
        {
            return _repository.GetQuantityToDispositivoMinimo(quartelId, funcaoId, dtEscala, periodoDiurno);
        }

        IList<Escala> IEscalaStore.GetByQuartelIdAndMonthYearAndPeriodoDiurno(Guid quartelId, int month, int year, bool periodoDiurno)
        {
            return _repository.GetByQuartelIdAndMonthYearAndPeriodoDiurno(quartelId, month, year, periodoDiurno);
        }
    }
}
