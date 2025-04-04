﻿using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IViaturaTipoFuncaoStore
    {
        IList<ViaturaTipoFuncao> GetAll();

        IList<ViaturaTipoFuncao> GetByFuncaoId(Guid funcaoId);

        IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId);

        ViaturaTipoFuncao GetById(Guid id);

        ViaturaTipoFuncao Save(ViaturaTipoFuncao save);

        bool Delete(Guid id);

        void DeleteByViaturaTipoId(Guid viaturaTipoId);

        IList<ViaturaTipoFuncao> GetByQuartelId(Guid quartelId);
    }
}
