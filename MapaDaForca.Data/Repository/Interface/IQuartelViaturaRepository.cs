using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IQuartelViaturaRepository
    {
        IList<QuartelViatura> GetAll();

        QuartelViatura GetById(Guid id);

        QuartelViatura Create(QuartelViatura create);

        QuartelViatura Update(QuartelViatura update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}