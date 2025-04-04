﻿using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IEscalaStore
    {
        IList<Escala> GetAll();

        IList<Escala> GetByBombeiroId(Guid bombeiroId);

        IList<Escala> GetByFuncaoId(Guid viaturaTipoId);

        IList<Escala> GetByEscalaTipoId(Guid viaturaTipoId);

        IList<Escala> GetByQuartelId(Guid viaturaTipoId);

        IList<Escala> GetByBombeiroIdAndMonthYear(Guid bombeiroId, int month, int year);

        IList<Escala> GetByBombeiroIdAndYear(Guid bombeiroId, int year);

        IList<Escala> GetByQuartelIdAndDtEscala(Guid quartelId, DateTime dtEscala);

        IList<Escala> GetByQuartelIdAndDtEscalaAndPeriodoDiurno(Guid quartelId, DateTime dtEscala, bool periodoDiurno);

        IList<Escala> GetByQuartelIdAndMonthYearAndPeriodoDiurno(Guid quartelId, int month, int year, bool periodoDiurno);

        Escala GetByBombeiroIdAndDtEscala(Guid bombeiroId, DateTime dtEscala);

        Escala GetById(Guid id);

        Escala Save(Escala save);

        void SaveYear(Guid bombeiroId, int year);

        bool Delete(Guid id);

        int GetQuantityToDispositivoMinimo(Guid quartelId, Guid funcaoId, DateTime dtEscala, bool periodoDiurno);

    }
}
