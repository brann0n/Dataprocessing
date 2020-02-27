using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataProcessingWebAPI.Models
{
    public class WerkzameBeroepsbevolking
    {
        public int Id { get; set; }
        public string Kenmerken { get; set; }
        public string Perioden { get; set; }
        public Nullable<int> WerkzameBeroepsbevolkingTotaal { get; set; }
        public Nullable<int> TotaalCreatieveBeroepen { get; set; }
        public Nullable<int> Kunsten { get; set; }
        public Nullable<int> MediaEnEntertainment { get; set; }
        public Nullable<int> CreatieveZakelijkeDienstverlening { get; set; }
        public Nullable<int> OverigeCreatieveBeroepen { get; set; }
        public Nullable<int> WerkzPersMetNietCreatieveBeroep { get; set; }
        public Nullable<int> WerkzPersMetBeroepOnbekend { get; set; }
    }
}