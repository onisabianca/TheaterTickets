using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class ExporterFactory
    {
        public IExporter getExporter(String exporterType)
        {
            if(exporterType == null)
            {
                return null;
            }

            if(exporterType.Equals("csv"))
            {
                return new ExporterCSV();
            }
            else if(exporterType.Equals("json"))
            {
                return new ExporterJSON();
            }
            else if (exporterType.Equals("xml"))
            {
                return new ExporterXML();
            }

            return null;
        }
    }
}
