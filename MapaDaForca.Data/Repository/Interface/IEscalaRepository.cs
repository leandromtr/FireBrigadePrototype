﻿using MapaDaForca.Data.Data;
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

        Escala Create(Escala create);

        Escala Update(Escala update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}