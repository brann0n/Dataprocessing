using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingDataImporter.Models.WB
{
    class TypedDataSetModel
    {
        public int ID { get; set; }
        public string Kenmerken { get; set; }
        public string Perioden { get; set; }
        public int? WerkzameBeroepsbevolkingTotaal_1 { get; set; }
        public int? TotaalCreatieveBeroepen_2 { get; set; }
        public int? Kunsten_3 { get; set; }
        public int? MediaEnEntertainment_4 { get; set; }
        public int? CreatieveZakelijkeDienstverlening_5 { get; set; }
        public int? OverigeCreatieveBeroepen_6 { get; set; }
        public int? WerkzPersMetNietCreatiefBeroep_7 { get; set; }
        public int? WerkzPersMetBeroepOnbekend_8 { get; set; }
    }
}
