using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Bussines;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpectacolAPIController : ControllerBase
    {
        SpectacolService spectacolService;
        private IUnitOfWork _unitOfWork;

        public SpectacolAPIController(TeatruContext teatruContext)
        {
            _unitOfWork = new UnitOfWork(teatruContext, new BileteRepository(teatruContext), new SpectacolRepository(teatruContext));
            spectacolService = new SpectacolService(_unitOfWork);
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Spectacol> Get()
        {
            List<Spectacol> listaSpectacole = spectacolService.getSpectacole();
            return listaSpectacole.ToArray();
        }
    }
}
