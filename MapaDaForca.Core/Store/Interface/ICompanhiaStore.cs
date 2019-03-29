using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface ICompanhiaStore
    {
        IList<Companhia> GetAll();

        IList<Companhia> GetByBatalhaoId(Guid batalhaoId);

        Companhia GetById(Guid id);

        Companhia Save(Companhia save);

        bool Delete(Guid id);
    }
}
