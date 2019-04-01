using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IPostoRepository
    {
        IList<Posto> GetAll();

        Posto GetById(Guid id);

        Posto Create(Posto create);

        Posto Update(Posto update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
