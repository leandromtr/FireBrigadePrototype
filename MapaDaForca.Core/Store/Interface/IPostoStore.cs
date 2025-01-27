using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IPostoStore
    {
        IList<Posto> GetAll();

        Posto GetById(Guid id);

        Posto Save(Posto save);

        bool Delete(Guid id);
    }
}
