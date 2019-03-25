using MapaDaForca.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository.Base
{
    public class BaseRepository
    {
        protected MapaDaForcaDbContext DbContext { get; }

        protected DbContextOptions<MapaDaForcaDbContext> Options { get; }

        public BaseRepository(DbContextOptions<MapaDaForcaDbContext> options)
        {
            Options = options;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
