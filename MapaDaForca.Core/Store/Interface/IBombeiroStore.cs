using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IBombeiroStore
    {
        IList<Bombeiro> GetAll();

        IList<Bombeiro> GetByPostoId(Guid postoId);

        IList<Bombeiro> GetByQuartelId(Guid postoId);

        Bombeiro GetById(Guid id);

        Bombeiro Save(Bombeiro save);

        bool Delete(Guid id);
    }
}