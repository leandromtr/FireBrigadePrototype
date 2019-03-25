using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IBatalhaoStore
    {
        IList<Batalhao> GetAll();

        Batalhao GetById(Guid id);
        
        Batalhao Save(Batalhao save, string userId);

        bool Delete(Guid id);
    }
}
