using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Models;
using System.Text.Encodings.Web;

namespace Teatru.Bussines
{
    public class BiletService
    {
        private IUnitOfWork _unitOfWork;
        ExporterFactory exporterFactory = new ExporterFactory();


        public BiletService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Bilet> getIndex()
        {
            return _unitOfWork.Bilete.GetAll().Result.ToList();
        }

        public Task<Bilet> getBilet(int? id)
        {
            if (id == null)
            {
                return null;
            }


            var bilet = _unitOfWork.Bilete.Get((int)id);
            
            if (bilet == null)
            {
                return null;
            }
            return bilet;
        }

        public async Task createBilet(Bilet bilet)
        {
            if (isBiletAvailable(bilet.spectacol) == true)
            {
                await _unitOfWork.Bilete.Add(bilet);
            }
        }

        public bool isBiletAvailable(string numeSpectacol)
        {
           List<Spectacol> spectacole = _unitOfWork.Spectacole.GetAll().Result.ToList();
           int nrBileteDisponibile = 0;

            foreach (var obj in spectacole)
            {
                if(obj.titlu.Equals(numeSpectacol))
                {
                    nrBileteDisponibile = obj.nrBilete;
                }
            }

            if(nrBileteDisponibile==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<Bilet> edit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var bilet = await _unitOfWork.Bilete.Get((int)id);
            if (bilet == null)
            {
                return null;
            }
            return bilet;
        }

        public async Task<Bilet> editBilet(int id, Bilet bilet)
        {
            if (id != bilet.ID)
            {
                return null;
            }

            try
            {
                _unitOfWork.Bilete.Update(bilet);                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(bilet.ID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return bilet;

        }

        public async Task<Bilet> delete(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var bilet = await _unitOfWork.Bilete.Get((int)id);
            if (bilet == null)
            {
                return null;
            }

            return bilet;
        }

        public async Task deleteConfirm(int id)
        {
            var bilet = await _unitOfWork.Bilete.Get(id);
            await _unitOfWork.Bilete.Delete(bilet);
        }

        public List<Bilet> getBileteForSpectacol(string nume)
        {
            List<Bilet> listaBilete = _unitOfWork.Bilete.GetAll().Result.ToList();
            List<Bilet> bileteSpectacol = new List<Bilet>();

            foreach (var obj in listaBilete)
            {
                if(obj.spectacol.Contains(nume))
                bileteSpectacol.Add(obj);
            }
            return bileteSpectacol;

        }

        private bool BiletExists(int id)
        {
            return _unitOfWork.GetTeatruContext().Bilet.Any(e => e.ID == id);
        }

        public string exportBilete(string tip)
        {
            List<Bilet> listaBilete = _unitOfWork.Bilete.GetAll().Result.ToList();

            IExporter exporter = exporterFactory.getExporter(tip);
            string bilete=exporter.export(listaBilete);

            return bilete;
        }
    }
}
