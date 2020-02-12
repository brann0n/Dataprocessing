using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingDataImporter.Models
{
    class OdataReceiver<T>
    {
        public List<T> value { get; set; }
        public OdataReceiver()
        {
            value = new List<T>();
        }
    }
}
