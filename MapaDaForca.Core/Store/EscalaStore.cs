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

        public EscalaStore(
            IEscalaRepository repository,
            IBombeiroStore bombeiroStore,
            IEscalaTurnoStore escalaTurnoStore)
        {
            _repository = repository;
            _bombeiroStore = bombeiroStore;
            _escalaTurnoStore = escalaTurnoStore;
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

        public IList<Escala> GetByBombeiroAndMonthYear(Guid bombeiroId, int month, int year)
        {
            return _repository.GetByBombeiroAndMonthYear(bombeiroId, month, year).ToList();
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
            var escalaTurnos = _escalaTurnoStore.GetByTurno(bombeiro.Turno).ToList();
            var escala = new Escala() {
                BombeiroId = bombeiro.Id,
                FuncaoId = new Guid("5b103770-d975-4242-a222-db07974f63b7"),
                QuartelId = bombeiro.QuartelId,
                EscalaTipoId = new Guid(), // FUNCAO PRINCIPAL
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
    }
}
