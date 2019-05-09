using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IQuartelViaturaRepository
    {
        IList<QuartelViatura> GetAll();

        IList<QuartelViatura> GetByQuartelId(Guid quartelId);

        IList<QuartelViatura> GetByViaturaId(Guid viaturaId);

        QuartelViatura GetById(Guid id);

        QuartelViatura Create(QuartelViatura create);

        QuartelViatura Update(QuartelViatura update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}