using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingDataImporter.Models.AD
{
    class TypedDataSetModel
    {
        public int ID { get; set; }
        public string Geslacht { get; set; }
        public string Herkomst { get; set; }
        public string Perioden { get; set; }
        public double? Alcoholgebruik_1 { get; set; }
        public double? BingeDrinken_2 { get; set; }
        public double? CannabisOoitGebruikt_3 { get; set; }
        public double? CannabisActiefGebruik_4 { get; set; }
        public double? TotaalGebruik_5 { get; set; }
        public double? XTC_6 { get; set; }
        public double? Cocaine_7 { get; set; }
    }
}
