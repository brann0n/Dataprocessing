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

        /// <summary>
        /// does conversion from the other object to this object.
        /// </summary>
        /// <param name="b">Database object</param>
        public static implicit operator WerkzameBeroepsbevolking(WBDataSet b)
        {
            DataProcessingEntities db = new DataProcessingEntities();
            WerkzameBeroepsbevolking item = new WerkzameBeroepsbevolking()
            {
                Id = b.Id,
                Kenmerken = db.WBKenmerkens.FirstOrDefault(n => n.Key == b.Kenmerken).Title,
                Perioden = db.WBPeriodens.FirstOrDefault(n => n.Key == b.Perioden).Title,
                WerkzameBeroepsbevolkingTotaal = b.WerkzameBeroepsbevolkingTotaal,
                TotaalCreatieveBeroepen = b.TotaalCreatieveBeroepen,
                Kunsten = b.Kunsten,
                MediaEnEntertainment = b.MediaEnEntertainment,
                CreatieveZakelijkeDienstverlening = b.CreatieveZakelijkeDienstverlening,
                OverigeCreatieveBeroepen = b.OverigeCreatieveBeroepen,
                WerkzPersMetNietCreatieveBeroep = b.WerkzPersMetNietCreatieveBeroep,
                WerkzPersMetBeroepOnbekend = b.WerkzPersMetBeroepOnbekend
            };
            return item;
        }
    }
}