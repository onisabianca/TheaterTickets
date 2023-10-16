using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class ExporterXML : IExporter
    {
        public string export(List<Bilet> bilets)
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Bilete>";

            foreach (Bilet bilet in bilets)
            {
                xml += "<Spectacol>" + bilet.spectacol + "</Spectacol>" + "<Rand>" + bilet.rand + "</Rand>"+ "<Numar>" + bilet.numar + "</Numar>"+ "<Data>" + bilet.data + "</Data>";
            }
             
            return xml+ "</Bilete>";
        }
    }
}
