using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IViaturaTipoFuncaoStore
    {
        IList<ViaturaTipoFuncao> GetAll();

        IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId);

        ViaturaTipoFuncao GetById(Guid id);

        ViaturaTipoFuncao Save(ViaturaTipoFuncao save);

        bool Delete(Guid id);
    }
}
