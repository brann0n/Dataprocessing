using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataProcessingWebAPI.Models
{
    public class AlcoholEnDrugs
    {
        public int Id { get; set; }
        public string Geslacht { get; set; }
        public string Herkomst { get; set; }
        public string Perioden { get; set; }
        public Nullable<double> Alcoholgebruik { get; set; }
        public Nullable<double> BingeDrinken { get; set; }
        public Nullable<double> CannabisOoitGebruikt { get; set; }
        public Nullable<double> CannabisActiefGebruik { get; set; }
        public Nullable<double> TotaalGebruik { get; set; }
        public Nullable<double> XTC { get; set; }
        public Nullable<double> Cocaine { get; set; }

        //does conversion from the other object to this object.
        public static implicit operator AlcoholEnDrugs(ADDataSet v)
        {
            DataProcessingEntities db = new DataProcessingEntities();
            AlcoholEnDrugs item = new AlcoholEnDrugs
            {
                Perioden = db.ADPeriodens.FirstOrDefault(n => n.Key == v.Perioden)?.Title,
                Alcoholgebruik = v.Alcoholgebruik,
                BingeDrinken = v.BingeDrinken,
                CannabisActiefGebruik = v.CannabisActiefGebruik,
                CannabisOoitGebruikt = v.CannabisOoitGebruikt,
                Cocaine = v.Cocaine,
                Geslacht = db.ADGeslachts.FirstOrDefault(n => n.Key == v.Geslacht)?.Title,
                Herkomst = db.ADHerkomsts.FirstOrDefault(n => n.Key == v.Herkomst)?.Title,
                Id = v.Id,
                TotaalGebruik = v.TotaalGebruik,
                XTC = v.XTC
            };
            return item;
        }
    }
}