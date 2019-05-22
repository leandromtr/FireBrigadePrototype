using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IEscalaRepository
    {
        IList<Escala> GetAll();

        Escala GetById(Guid id);

        IList<Escala> GetByBombeiroId(Guid bombeiroId);

        IList<Escala> GetByEscalaTipoId(Guid escalaTipoId);

        IList<Escala> GetByFuncaoId(Guid funcaoId);

        IList<Escala> GetByQuartelId(Guid quartelId);
       
        IList<Escala> GetByBombeiroIdAndMonthYear(Guid bombeiroId, int month, int year);

        IList<Escala> GetByBombeiroIdAndYear(Guid bombeiroId, int year);

        IList<Escala> GetByQuartelIdAndDtEscala(Guid quartelId, DateTime dtEscala);

        IList<Escala> GetByQuartelIdAndDtEscalaAndPeriodoDiurno(Guid quartelId, DateTime dtEscala, bool periodoDiurno);

        IList<Escala> GetByQuartelIdAndMonthYearAndPeriodoDiurno(Guid quartelId, int month, int year, bool periodoDiurno);

        Escala GetByBombeiroIdAndDtEscala(Guid bombeiroId, DateTime dtEscala);

        Escala Create(Escala create);

        Escala Update(Escala update);

        int GetQuantityToDispositivoMinimo(Guid quartelId, Guid funcaoId, DateTime dtEscala, bool periodoDiurno);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
