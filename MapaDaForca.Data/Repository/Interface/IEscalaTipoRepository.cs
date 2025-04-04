﻿using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IEscalaTipoRepository
    {
        IList<EscalaTipo> GetAll();

        EscalaTipo GetById(Guid id);

        EscalaTipo Create(EscalaTipo create);

        EscalaTipo Update(EscalaTipo update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
