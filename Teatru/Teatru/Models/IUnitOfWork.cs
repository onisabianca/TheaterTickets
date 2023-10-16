using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Data;

namespace Teatru.Models
{
    public interface IUnitOfWork: IDisposable
    {
        IBiletRepository Bilete { get; }
        ISpectacolRepository Spectacole { get; }

        TeatruContext GetTeatruContext();
        int Complete();
    }
}
