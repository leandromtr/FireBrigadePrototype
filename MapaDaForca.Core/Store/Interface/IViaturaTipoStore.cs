using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IViaturaTipoStore
    {
        IList<ViaturaTipo> GetAll();

        ViaturaTipo GetById(Guid id);

        ViaturaTipo Save(ViaturaTipo save);

        bool Delete(Guid id);
    }
}
