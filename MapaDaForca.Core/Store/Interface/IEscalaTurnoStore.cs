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

        EscalaTurno GetById(Guid id);

        EscalaTurno Save(EscalaTurno save);

        bool Delete(Guid id);
    }
}
