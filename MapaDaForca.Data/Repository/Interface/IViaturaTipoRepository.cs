using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IViaturaTipoRepository
    {
        IList<ViaturaTipo> GetAll();

        ViaturaTipo GetById(Guid id);

        ViaturaTipo Create(ViaturaTipo create);

        ViaturaTipo Update(ViaturaTipo update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}