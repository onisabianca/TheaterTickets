using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class ExporterCSV : IExporter
    {
        public string export(List<Bilet> bilets)
        {
            string csv = string.Empty;
            csv += "Spectacol,";
            csv += "Rand,";
            csv += "Numar,";
            csv += "Data";
            csv += "\r\n";

            foreach(Bilet bilet in bilets)
            {
                csv += bilet.spectacol+","+bilet.rand+","+bilet.numar+","+bilet.data+"\r\n";
            }

            return csv;
        }
    }
}
