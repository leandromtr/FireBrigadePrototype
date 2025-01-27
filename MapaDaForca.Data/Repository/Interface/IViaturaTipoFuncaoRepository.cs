using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IViaturaTipoFuncaoRepository
    {
        IList<ViaturaTipoFuncao> GetAll();

        IList<ViaturaTipoFuncao> GetByFuncaoId(Guid funcaoId);

        IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId);

        ViaturaTipoFuncao GetById(Guid id);

        ViaturaTipoFuncao Create(ViaturaTipoFuncao create);

        ViaturaTipoFuncao Update(ViaturaTipoFuncao update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}