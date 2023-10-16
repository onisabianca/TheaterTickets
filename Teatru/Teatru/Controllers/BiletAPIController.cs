using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatru.Bussines;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BiletAPIController : ControllerBase
    {
        BiletService biletService;
        private IUnitOfWork _unitOfWork;
        SpectacolService spectacolService;
        public BiletAPIController(TeatruContext teatruContext)
        {
            _unitOfWork = new UnitOfWork(teatruContext, new BileteRepository(teatruContext), new SpectacolRepository(teatruContext));
            biletService = new BiletService(_unitOfWork);
            spectacolService = new SpectacolService(_unitOfWork);
        }

        [HttpGet]
        public IEnumerable<Bilet> Get(string spectacol)
        {
            List<Bilet> listaBileteSpectacol = biletService.getBileteForSpectacol(spectacol);

            IEnumerable<Bilet> sortedBilets =
            from bilet in listaBileteSpectacol
            orderby bilet.data ascending
            select bilet;

            return sortedBilets.ToArray();
        }
    }
}
