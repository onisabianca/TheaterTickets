using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Data
{
    public class SpectacolRepository: GenericRepository<Spectacol>, ISpectacolRepository
    {
        protected readonly TeatruContext _context;
        public SpectacolRepository(TeatruContext context): base(context)
        {
            _context = context;
        }

    }
}
