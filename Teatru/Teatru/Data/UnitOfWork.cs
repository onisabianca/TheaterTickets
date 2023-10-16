using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TeatruContext _context;
        public ISpectacolRepository Spectacole { get; }

        public IBiletRepository Bilete { get; }

        public UnitOfWork(TeatruContext teatruDbContext,
            ISpectacolRepository spectacoleRepository)
        {
            this._context = teatruDbContext;
            this.Spectacole = spectacoleRepository;
        }

        public UnitOfWork(TeatruContext teatruDbContext,
            IBiletRepository bileteRepository)
        {
            this._context = teatruDbContext;
            this.Bilete = bileteRepository;
        }

        public UnitOfWork(TeatruContext teatruDbContext,
            IBiletRepository bileteRepository,
            ISpectacolRepository spectacoleRepository)
        {
            this._context = teatruDbContext;
            this.Bilete = bileteRepository;
            this.Spectacole = spectacoleRepository;
        }

        public TeatruContext GetTeatruContext()
        {
            return _context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}