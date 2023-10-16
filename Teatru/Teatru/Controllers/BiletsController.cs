using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teatru.Bussines;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Controllers
{
    public class BiletsController : Controller
    {
        BiletService biletService;
        private IUnitOfWork _unitOfWork;
        SpectacolService spectacolService;

        public BiletsController(TeatruContext teatruContext)
        {
            _unitOfWork = new UnitOfWork(teatruContext, new BileteRepository(teatruContext), new SpectacolRepository(teatruContext));
            biletService = new BiletService(_unitOfWork);
            spectacolService = new SpectacolService(_unitOfWork);
        }

        // GET: Bilets
        public IActionResult Index()
        {
            return View(biletService.getIndex());
        }

        public IActionResult Index2(string searchString)
        {
            List<Bilet> listaBileteSpectacol = biletService.getBileteForSpectacol(searchString);
            ViewData["bileteSpectacol"] = listaBileteSpectacol;
            return View(listaBileteSpectacol);
        }

        // GET: Bilets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var bilet = await biletService.getBilet(id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilets/Create
        public IActionResult Create()
        {
            List<string> numeSpectacole = spectacolService.getNumeSpectacole();
            ViewData["numeSpectacole"] = numeSpectacole;
            ViewData["length"] = numeSpectacole.Count();

            return View();
        }

        // POST: Bilets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,spectacol,rand,numar,data")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                await biletService.createBilet(bilet);
                return RedirectToAction(nameof(Index));

            }
            return View(bilet);
        }

        // GET: Bilets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var bilet = await biletService.edit(id);
            if (bilet == null)
            {
                return NotFound();
            }
            return View(bilet);
        }

        // POST: Bilets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,spectacol,rand,numar,data")] Bilet bilet)
        {
            Bilet bilet1 = null;
            if (ModelState.IsValid)
            {
                bilet1=await biletService.editBilet(id, bilet);
                if (bilet1 == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            if (bilet1 == null)
            {
                return NotFound();
            }
            return View(bilet1);
        }

        // GET: Bilets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var bilet = await biletService.delete(id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await biletService.deleteConfirm(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet, DisableRequestSizeLimit]
        public IActionResult DownloadFile(string tip)
        {
            string fisier = biletService.exportBilete(tip);

            byte[] fileBytes = Encoding.ASCII.GetBytes(fisier);
            string fileName = "bilete." + tip;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

    }
}
