using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IViaturaRepository
    {
        IList<Viatura> GetAll();

        Viatura GetById(Guid id);

        Viatura Create(Viatura create);

        Viatura Update(Viatura update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}