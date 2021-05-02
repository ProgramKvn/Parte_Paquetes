using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class DepSV
    {
        public int ID { get; set; }
        public string DepName { get; set; }
        public string ISOCode { get; set; }
        public int ZONESV_ID { get; set; }
        public virtual List<MunSV> Municipios { get; set; }
    }
}
