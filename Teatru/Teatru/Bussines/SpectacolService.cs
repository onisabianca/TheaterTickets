using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Models;

namespace Teatru.Bussines
{
    public class SpectacolService
    {
        private IUnitOfWork _unitOfWork;

        public SpectacolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Spectacol> getIndex()
        {
            return _unitOfWork.Spectacole.GetAll().Result.ToList();
        }

        public Task<Spectacol> getSpectacol(int? id)
        {
            if (id == null)
            {
                return null;
            }


            var spectacol = _unitOfWork.Spectacole.Get((int)id);

            if (spectacol == null)
            {
                return null;
            }
            return spectacol;
        }

        public async Task creareSpectacol(Spectacol spectacol)
        {
            await _unitOfWork.Spectacole.Add(spectacol);
        }

        public async Task<Spectacol> edit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var spectacol = await _unitOfWork.Spectacole.Get((int)id);
            if (spectacol == null)
            {
                return null;
            }
            return spectacol;
        }

        public async Task<Spectacol> editSpectacol(int id, Spectacol spectacol)
        {
            if (id != spectacol.ID)
            {
                return null;
            }

            try
            {
                _unitOfWork.Spectacole.Update(spectacol);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpectacolExists(spectacol.ID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return spectacol;

        }

        public async Task<Spectacol> delete(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var spectacol = await _unitOfWork.Spectacole.Get((int)id);
            if (spectacol == null)
            {
                return null;
            }

            return spectacol;
        }

        public async Task deleteConfirm(int id)
        {
            var spectacol = await _unitOfWork.Spectacole.Get(id);
            await _unitOfWork.Spectacole.Delete(spectacol);
        }

        public List<string> getNumeSpectacole()
        {
            List<Spectacol> listaSpectacole = _unitOfWork.Spectacole.GetAll().Result.ToList();
            List<string> numeSpectacole = new List<string>();
            foreach (var obj in listaSpectacole)
            {
                numeSpectacole.Add(obj.titlu);
            }
            return numeSpectacole;

        }

        private bool SpectacolExists(int id)
        {
            return _unitOfWork.GetTeatruContext().Spectacol.Any(e => e.ID == id);
        }

        public List<Spectacol> getSpectacole()
        {
            List<Spectacol> listaSpectacole = _unitOfWork.Spectacole.GetAll().Result.ToList();
            return listaSpectacole;

        }
    }
}

