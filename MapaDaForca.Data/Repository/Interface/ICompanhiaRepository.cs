using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface ICompanhiaRepository
    {
        IList<Companhia> GetAll();

        IList<Companhia> GetByBatalhaoId(Guid batalhaoId);

        Companhia GetById(Guid id);

        Companhia Create(Companhia create);

        Companhia Update(Companhia update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
