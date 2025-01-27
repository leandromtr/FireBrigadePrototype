using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IBatalhaoRepository
    {
        IList<Batalhao> GetAll();

        Batalhao GetById(Guid id);

        Batalhao Create(Batalhao create);

        Batalhao Update(Batalhao update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
