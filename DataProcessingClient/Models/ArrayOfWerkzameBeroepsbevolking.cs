using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataProcessingClient.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models", IsNullable = false)]
    public partial class ArrayOfWerkzameBeroepsbevolking : XMLConvertable<ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking>
    {

        private ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking[] werkzameBeroepsbevolkingField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WerkzameBeroepsbevolking")]
        public ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking[] WerkzameBeroepsbevolking
        {
            get
            {
                return this.werkzameBeroepsbevolkingField;
            }
            set
            {
                this.werkzameBeroepsbevolkingField = value;
            }
        }

        public ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking[] GetArray()
        {
            return WerkzameBeroepsbevolking;
        }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    public partial class ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking
    {

        private Nullable<int> creatieveZakelijkeDienstverleningField;

        private int idField;

        private string kenmerkenField;

        private Nullable<int> kunstenField;

        private Nullable<int> mediaEnEntertainmentField;

        private Nullable<int> overigeCreatieveBeroepenField;

        private string periodenField;

        private Nullable<int> totaalCreatieveBeroepenField;

        private Nullable<int> werkzPersMetBeroepOnbekendField;

        private Nullable<int> werkzPersMetNietCreatieveBeroepField;

        private Nullable<int> werkzameBeroepsbevolkingTotaalField;

        /// <remarks/>
        public Nullable<int> CreatieveZakelijkeDienstverlening
        {
            get
            {
                return this.creatieveZakelijkeDienstverleningField;
            }
            set
            {
                this.creatieveZakelijkeDienstverleningField = value;
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
        public string Kenmerken
        {
            get
            {
                return this.kenmerkenField;
            }
            set
            {
                this.kenmerkenField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Kunsten
        {
            get
            {
                return this.kunstenField;
            }
            set
            {
                this.kunstenField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> MediaEnEntertainment
        {
            get
            {
                return this.mediaEnEntertainmentField;
            }
            set
            {
                this.mediaEnEntertainmentField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> OverigeCreatieveBeroepen
        {
            get
            {
                return this.overigeCreatieveBeroepenField;
            }
            set
            {
                this.overigeCreatieveBeroepenField = value;
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
        public Nullable<int> TotaalCreatieveBeroepen
        {
            get
            {
                return this.totaalCreatieveBeroepenField;
            }
            set
            {
                this.totaalCreatieveBeroepenField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> WerkzPersMetBeroepOnbekend
        {
            get
            {
                return this.werkzPersMetBeroepOnbekendField;
            }
            set
            {
                this.werkzPersMetBeroepOnbekendField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> WerkzPersMetNietCreatieveBeroep
        {
            get
            {
                return this.werkzPersMetNietCreatieveBeroepField;
            }
            set
            {
                this.werkzPersMetNietCreatieveBeroepField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> WerkzameBeroepsbevolkingTotaal
        {
            get
            {
                return this.werkzameBeroepsbevolkingTotaalField;
            }
            set
            {
                this.werkzameBeroepsbevolkingTotaalField = value;
            }
        }
    }


}
