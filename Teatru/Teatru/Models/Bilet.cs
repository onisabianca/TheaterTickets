using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public string spectacol { get; set; }
        public int rand { get; set; }
        public int numar { get; set; }
        public DateTime data { get; set; }

    }
}
