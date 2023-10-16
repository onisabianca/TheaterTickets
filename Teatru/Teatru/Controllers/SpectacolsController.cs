using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teatru.Bussines;
using Teatru.Data;
using Teatru.Models;

namespace Teatru.Controllers
{
    public class SpectacolsController : Controller
    {

        SpectacolService spectacolService;
        private IUnitOfWork _unitOfWork;

        public SpectacolsController(TeatruContext teatruContext)
        {
            _unitOfWork = new UnitOfWork(teatruContext, new SpectacolRepository(teatruContext));
            spectacolService = new SpectacolService(_unitOfWork);
        }

        // GET: Spectacols
        public IActionResult Index()
        {
            return View(spectacolService.getIndex());
        }

        // GET: Spectacols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var spectacol = await spectacolService.getSpectacol(id);
            if (spectacol == null)
            {
                return NotFound();
            }

            return View(spectacol);
        }

        // GET: Spectacols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spectacols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,titlu,regizor,actori,data,nrBilete")] Spectacol spectacol)
        {
            if (ModelState.IsValid)
            {
                await spectacolService.creareSpectacol(spectacol);
                return RedirectToAction(nameof(Index));

            }
            return View(spectacol);
        }

        // GET: Spectacols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var spectacol = await spectacolService.edit(id);
            if (spectacol == null)
            {
                return NotFound();
            }
            return View(spectacol);
        }

        // POST: Spectacols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,titlu,regizor,actori,data,nrBilete")] Spectacol spectacol)
        {
            Spectacol spectacol1 = null;
            if (ModelState.IsValid)
            {
                spectacol1 = await spectacolService.editSpectacol(id, spectacol);
                if (spectacol1 == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            if (spectacol1 == null)
            {
                return NotFound();
            }
            return View(spectacol1);
        }

        // GET: Spectacols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var spectacol = await spectacolService.delete(id);
            if (spectacol == null)
            {
                return NotFound();
            }

            return View(spectacol);
        }

        // POST: Spectacols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await spectacolService.deleteConfirm(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
