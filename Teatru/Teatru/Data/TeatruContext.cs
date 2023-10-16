using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teatru.Models;

namespace Teatru.Data
{
    public class TeatruContext : DbContext
    {
        public TeatruContext (DbContextOptions<TeatruContext> options)
            : base(options)
        {
        }

        public DbSet<Teatru.Models.Bilet> Bilet { get; set; }

        public DbSet<Teatru.Models.Spectacol> Spectacol { get; set; }
    }
}
