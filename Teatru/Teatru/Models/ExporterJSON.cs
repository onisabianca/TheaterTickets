using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class ExporterJSON : IExporter
    {
        public string export(List<Bilet> bilets)
        {
            string json = string.Empty;
            json += "{\"bilete\":[";

            foreach (Bilet bilet in bilets)
            {
                json += "{\"Spectacol\":\"" + bilet.spectacol + "\", \"Rand\":\"" + bilet.rand + "\", \"Numar\":\"" + bilet.numar + "\", \"Data\":\"" + bilet.data + "\"},";
            }

            json += "]}";

            return json;
        }
    }
}
