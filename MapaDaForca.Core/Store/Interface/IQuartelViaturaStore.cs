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

        IList<QuartelViatura> GetByViaturaId(Guid viaturaId);

        QuartelViatura GetById(Guid id);

        QuartelViatura Save(QuartelViatura save);

        bool Delete(Guid id);

        void DeleteByQuartelId(Guid quartelId);
    }
}
