using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IQuartelViaturaStore
    {
        IList<QuartelViatura> GetAll();

        IList<QuartelViatura> GetByQuartelId(Guid quartelId);

        QuartelViatura GetById(Guid id);

        QuartelViatura Save(QuartelViatura save);

        bool Delete(Guid id);
    }
}
