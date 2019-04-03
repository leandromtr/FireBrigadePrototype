using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IEscalaTurnoStore
    {
        IList<EscalaTurno> GetAll();

        EscalaTurno GetById(Guid id);

        EscalaTurno Save(EscalaTurno save);

        bool Delete(Guid id);
    }
}
