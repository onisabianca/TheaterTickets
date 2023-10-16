using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Data;
using Teatru.Models;
namespace Teatru.Data
{
    public class BileteRepository : GenericRepository<Bilet>, IBiletRepository
    {
        public BileteRepository(TeatruContext context) : base(context)
        {

        }
    }
}
