using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace DataProcessingWebAPI.Models
{
    [XMLValidatorSchema("test.xsd")]
    public class AlcoholEnDrugs
    {
        /// <summary>
        /// Item id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Geslacht van persoon
        /// </summary>
        public string Geslacht { get; set; }
        /// <summary>
        /// Herkomst van persoon
        /// </summary>
        public string Herkomst { get; set; }
        /// <summary>
        /// Periode van ondervragen
        /// </summary>
        public string Perioden { get; set; }
        /// <summary>
        /// Gehalte van alcoholgebruik
        /// </summary>
        public Nullable<double> Alcoholgebruik { get; set; }
        /// <summary>
        /// Gehalte van Bingedrinken
        /// </summary>
        public Nullable<double> BingeDrinken { get; set; }
        /// <summary>
        /// Gehalte van Cannabis Ooit Gebruikt
        /// </summary>
        public Nullable<double> CannabisOoitGebruikt { get; set; }
        /// <summary>
        /// Gehalte van Cannabis Actief Gebruik
        /// </summary>
        public Nullable<double> CannabisActiefGebruik { get; set; }
        /// <summary>
        /// Gehalte Totaal gebruik
        /// </summary>
        public Nullable<double> TotaalGebruik { get; set; }
        /// <summary>
        /// Gehalte XTC
        /// </summary>
        public Nullable<double> XTC { get; set; }
        /// <summary>
        /// Gehalte Cocaine
        /// </summary>
        public Nullable<double> Cocaine { get; set; }

        /// <summary>
        /// does conversion from the other object to this object.
        /// </summary>
        /// <param name="v">the object to convert</param>
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

    public class AlcoholEnDrugsDataSet
    {
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation = "http://localhost:54164/Content/Schemas/AlcoholEnDrugs.xsd";

        public List<AlcoholEnDrugs> AlcoholEnDrugsArray { get; set; }

        public AlcoholEnDrugsDataSet()
        {
            AlcoholEnDrugsArray = new List<AlcoholEnDrugs>();
        }
    }
}