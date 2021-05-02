using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ZoneSV
    {
        public int ID { get; set; }
        public string ZoneName { get; set; }

        public virtual List<DepSV> DepSVs { get; set; }
    }
}
