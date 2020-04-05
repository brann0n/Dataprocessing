using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataProcessingClient.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models", IsNullable = false)]
    public class ArrayOfAlcoholEnDrugs : XMLConvertable<ArrayOfAlcoholEnDrugsAlcoholEnDrugs>
    {

        private ArrayOfAlcoholEnDrugsAlcoholEnDrugs[] alcoholEnDrugsField;

        /// <remarks/>
        [XmlElement("AlcoholEnDrugs")]
        public ArrayOfAlcoholEnDrugsAlcoholEnDrugs[] AlcoholEnDrugs
        {
            get
            {
                return this.alcoholEnDrugsField;
            }
            set
            {
                this.alcoholEnDrugsField = value;
            }
        }

        public ArrayOfAlcoholEnDrugsAlcoholEnDrugs[] GetArray()
        {
            return AlcoholEnDrugs;
        }      
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    public class ArrayOfAlcoholEnDrugsAlcoholEnDrugs
    {

        private Nullable<double> alcoholgebruikField;

        private Nullable<double> bingeDrinkenField;

        private Nullable<double> cannabisActiefGebruikField;

        private Nullable<double> cannabisOoitGebruiktField;

        private Nullable<double> cocaineField;

        private string geslachtField;

        private string herkomstField;

        private int idField;

        private string periodenField;

        private Nullable<double> totaalGebruikField;

        private Nullable<double> xTCField;

        /// <remarks/>
        public Nullable<double> Alcoholgebruik
        {
            get
            {
                return this.alcoholgebruikField;
            }
            set
            {
                this.alcoholgebruikField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> BingeDrinken
        {
            get
            {
                return this.bingeDrinkenField;
            }
            set
            {
                this.bingeDrinkenField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> CannabisActiefGebruik
        {
            get
            {
                return this.cannabisActiefGebruikField;
            }
            set
            {
                this.cannabisActiefGebruikField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> CannabisOoitGebruikt
        {
            get
            {
                return this.cannabisOoitGebruiktField;
            }
            set
            {
                this.cannabisOoitGebruiktField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> Cocaine
        {
            get
            {
                return this.cocaineField;
            }
            set
            {
                this.cocaineField = value;
            }
        }

        /// <remarks/>
        public string Geslacht
        {
            get
            {
                return this.geslachtField;
            }
            set
            {
                this.geslachtField = value;
            }
        }

        /// <remarks/>
        public string Herkomst
        {
            get
            {
                return this.herkomstField;
            }
            set
            {
                this.herkomstField = value;
            }
        }

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Perioden
        {
            get
            {
                return this.periodenField;
            }
            set
            {
                this.periodenField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> TotaalGebruik
        {
            get
            {
                return this.totaalGebruikField;
            }
            set
            {
                this.totaalGebruikField = value;
            }
        }

        /// <remarks/>
        public Nullable<double> XTC
        {
            get
            {
                return this.xTCField;
            }
            set
            {
                this.xTCField = value;
            }
        }
    }

}
