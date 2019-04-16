using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IEscalaTurnoStore
    {
        IList<EscalaTurno> GetAll();

        IList<EscalaTurno> GetByDtEscalaTurno(DateTime dtEscalaTurno);

        IList<EscalaTurno> GetByMonthYear(int month, int year);

        EscalaTurno GetById(Guid id);

        EscalaTurno Save(EscalaTurno save);

        void SaveYear(int year);

        bool Delete(Guid id);
    }
}
