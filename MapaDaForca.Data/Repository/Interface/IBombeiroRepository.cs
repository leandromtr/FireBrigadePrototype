using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IBombeiroRepository
    {
        IList<Bombeiro> GetAll();

        IList<Bombeiro> GetByPostoId(Guid postoId);

        IList<Bombeiro> GetByQuartelId(Guid quartelId);

        Bombeiro GetById(Guid id);

        Bombeiro Create(Bombeiro create);

        Bombeiro Update(Bombeiro update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
