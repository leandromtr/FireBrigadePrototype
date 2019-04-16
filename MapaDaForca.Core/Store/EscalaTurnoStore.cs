using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class EscalaTurnoStore : IEscalaTurnoStore
    {
        private readonly IEscalaTurnoRepository _repository;

        public EscalaTurnoStore(
            IEscalaTurnoRepository repository)
        {
            _repository = repository;
        }

        public IList<EscalaTurno> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<EscalaTurno> GetByDtEscalaTurno(DateTime dtEscalaTurno)
        {
            return _repository.GetByDtEscalaTurno(dtEscalaTurno).ToList();
        }

        public IList<EscalaTurno> GetByTurno(Turno turno)
        {
            return _repository.GetByTurno(turno).ToList();
        }

        public IList<EscalaTurno> GetByMonthYear(int month, int year)
        {
            return _repository.GetByMonthYear(month, year).ToList();
        }

        public EscalaTurno GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public EscalaTurno Save(EscalaTurno save)
        {
            EscalaTurno saved = null;
            var escalaTurno = _repository.IsExistingByDateAndTurno(save.DtEscalaTurno, save.PeriodoDiurno);
            if (escalaTurno != null)
                save.Id = escalaTurno.Id;

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

        public void SaveYear(int year)
        {
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            Random random = new Random();
            var escalaTurno = new EscalaTurno();

            for (DateTime dt = firstDay; dt <= lastDay; dt = dt.AddDays(1))
            {
                escalaTurno.Id = Guid.Empty;
                escalaTurno.DtEscalaTurno = dt;
                escalaTurno.PeriodoDiurno = true;
                escalaTurno.Turno = (Turno)random.Next(1, 4);
                Save(escalaTurno);

                escalaTurno.Id = Guid.Empty;
                escalaTurno.PeriodoDiurno = false;
                escalaTurno.Turno = (Turno)random.Next(1, 4);
                Save(escalaTurno);
            }
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
