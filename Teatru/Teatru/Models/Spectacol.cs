using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class Spectacol
    {
        public Spectacol()
        {

        }
        public Spectacol(string titlu, string regizor, string actori, DateTime data, int nrBilete)
        {
            this.titlu = titlu;
            this.regizor = regizor;
            this.actori = actori;
            this.data = data;
            this.nrBilete = nrBilete;
        }
        public int ID { get; set; }
        public string titlu { get; set; }
        public string regizor { get; set; }
        public string actori { get; set; }
        public DateTime data { get; set; }
        public int nrBilete { get; set; }

    }
}
