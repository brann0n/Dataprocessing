using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DataProcessingWebAPI.Models
{
    /// <summary>
    /// Data model
    /// </summary>
    public class WerkzameBeroepsbevolking
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Kenmerken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Perioden { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> WerkzameBeroepsbevolkingTotaal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> TotaalCreatieveBeroepen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> Kunsten { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> MediaEnEntertainment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> CreatieveZakelijkeDienstverlening { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> OverigeCreatieveBeroepen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> WerkzPersMetNietCreatieveBeroep { get; set; }
        /// <summary>
        /// 
        /// </summary>
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

    /// <summary>
    /// Sub data model
    /// </summary>
    public class WerkzameBeroepsbevolkingDataSet
    {
        /// <summary>
        /// Schema Location
        /// </summary>
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation = "http://localhost:54164/Content/Schemas/WerkzameBeroepsbevolking";

        /// <summary>
        /// sub array
        /// </summary>
        public List<WerkzameBeroepsbevolking> WerkzameBeroepsbevolkingArray { get; set; }

        /// <summary>
        /// public constructor
        /// </summary>
        public WerkzameBeroepsbevolkingDataSet()
        {
            WerkzameBeroepsbevolkingArray = new List<WerkzameBeroepsbevolking>();
        }
    }
}