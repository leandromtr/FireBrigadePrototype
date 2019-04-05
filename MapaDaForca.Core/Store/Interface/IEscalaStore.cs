using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IEscalaStore
    {
        IList<Escala> GetAll();

        IList<Escala> GetByBombeiroId(Guid bombeiroId);

        IList<Escala> GetByFuncaoId(Guid viaturaTipoId);

        IList<Escala> GetByEscalaTipoId(Guid viaturaTipoId);

        IList<Escala> GetByQuartelId(Guid viaturaTipoId);

        Escala GetById(Guid id);

        Escala Save(Escala save);

        bool Delete(Guid id);
    }
}
