using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IEscalaTurnoRepository
    {
        IList<EscalaTurno> GetAll();

        IList<EscalaTurno> GetByDtEscalaTurno(DateTime dtEscalaTurno);

        EscalaTurno GetById(Guid id);

        EscalaTurno Create(EscalaTurno create);

        EscalaTurno Update(EscalaTurno update);

        bool Delete(Guid id);

        bool IsExisting(DateTime dtEscalaTurno, bool periodoDiurno);
    }
}
