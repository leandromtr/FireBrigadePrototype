using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IQuartelRepository
    {
        IList<Quartel> GetAll();

        IList<Quartel> GetByCompanhiaId(Guid companhiaId);

        Quartel GetById(Guid id);

        Quartel Create(Quartel create);

        Quartel Update(Quartel update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
