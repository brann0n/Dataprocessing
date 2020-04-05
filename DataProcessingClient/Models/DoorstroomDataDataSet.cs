using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataProcessingClient.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models", IsNullable = false)]
    public class DoorstroomDataDataSet : XMLConvertable<ArrayOfDoorstroomDataDoorstroomData>
    {
        private ArrayOfDoorstroomDataDoorstroomData[] doorstroomDataField;
        private string schemaName;
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get { return schemaName; } set { schemaName = value; } }
        
        [XmlArrayItem("DoorstroomData", IsNullable = false)]
        public ArrayOfDoorstroomDataDoorstroomData[] DoorstroomDataArray
        {
            get
            {
                return this.doorstroomDataField;
            }
            set
            {
                this.doorstroomDataField = value;
            }
        }

        public ArrayOfDoorstroomDataDoorstroomData[] GetArray()
        {
            return DoorstroomDataArray;
        }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models")]
    public class ArrayOfDoorstroomDataDoorstroomData
    {

        private Nullable<int> basisberoepsgerichteLeerweg_27Field;

        private Nullable<int> basisberoepsgerichteLeerweg_34Field;

        private Nullable<int> combinatieBKG_16Field;

        private Nullable<int> combinatieBKG_23Field;

        private Nullable<int> combinatieBKG_9Field;

        private Nullable<int> combinatie_44Field;

        private Nullable<int> combinatie_50Field;

        private Nullable<int> combinatie_56Field;

        private Nullable<int> combinatie_63Field;

        private Nullable<int> economieBKG_14Field;

        private Nullable<int> economieBKG_21Field;

        private Nullable<int> economieBKG_7Field;

        private Nullable<int> economie_42Field;

        private Nullable<int> economie_48Field;

        private Nullable<int> economie_54Field;

        private Nullable<int> economie_61Field;

        private Nullable<int> geenSectorT_10Field;

        private Nullable<int> geenSectorT_17Field;

        private Nullable<int> geenSectorT_24Field;

        private Nullable<int> gemengdeLeerweg_30Field;

        private Nullable<int> gemengdeLeerweg_37Field;

        private string geslachtField;

        private Nullable<int> havo4Totaal_66Field;

        private Nullable<int> havo5MetDiploma_68Field;

        private Nullable<int> havo5Totaal_67Field;

        private Nullable<int> havo5ZonderDiploma_69Field;

        private Nullable<int> havoVwoInclAlgLeerjr_65Field;

        private int idField;

        private Nullable<int> kaderberoepsgerichteLeerweg_28Field;

        private Nullable<int> kaderberoepsgerichteLeerweg_35Field;

        private Nullable<int> landbouwBKG_12Field;

        private Nullable<int> landbouwBKG_19Field;

        private Nullable<int> landbouwBKG_5Field;

        private Nullable<int> landbouw_40Field;

        private Nullable<int> landbouw_46Field;

        private Nullable<int> landbouw_52Field;

        private Nullable<int> landbouw_59Field;

        private Nullable<int> leerjaar12_2Field;

        private string mboLeerwegEnNiveauField;

        private string mboRichtingEnSectorField;

        private string periodenField;

        private string persoonskenmerkenField;

        private Nullable<int> praktijkonderwijs_73Field;

        private Nullable<int> techniekBKG_15Field;

        private Nullable<int> techniekBKG_22Field;

        private Nullable<int> techniekBKG_8Field;

        private Nullable<int> techniek_43Field;

        private Nullable<int> techniek_49Field;

        private Nullable<int> techniek_55Field;

        private Nullable<int> techniek_62Field;

        private Nullable<int> theoretischeLeerweg_31Field;

        private Nullable<int> theoretischeLeerweg_38Field;

        private Nullable<int> theoretischeLeerweg_64Field;

        private Nullable<int> totaalDoorstroomLeerling_1Field;

        private Nullable<int> totaal_11Field;

        private Nullable<int> totaal_18Field;

        private Nullable<int> totaal_25Field;

        private Nullable<int> totaal_26Field;

        private Nullable<int> totaal_29Field;

        private Nullable<int> totaal_32Field;

        private Nullable<int> totaal_33Field;

        private Nullable<int> totaal_36Field;

        private Nullable<int> totaal_39Field;

        private Nullable<int> totaal_4Field;

        private Nullable<int> totaal_45Field;

        private Nullable<int> totaal_51Field;

        private Nullable<int> totaal_57Field;

        private Nullable<int> totaal_58Field;

        private Nullable<int> vmbo3Totaal_3Field;

        private Nullable<int> vwo46Totaal_70Field;

        private Nullable<int> vwo46ZonderDiploma_72Field;

        private Nullable<int> vwo6MetDiploma_71Field;

        private Nullable<int> zorgEnWelzijnBKG_13Field;

        private Nullable<int> zorgEnWelzijnBKG_20Field;

        private Nullable<int> zorgEnWelzijnBKG_6Field;

        private Nullable<int> zorgEnWelzijn_40Field;

        private Nullable<int> zorgEnWelzijn_47Field;

        private Nullable<int> zorgEnWelzijn_53Field;

        private Nullable<int> zorgEnWelzijn_60Field;

        /// <remarks/>
        public Nullable<int> BasisberoepsgerichteLeerweg_27
        {
            get
            {
                return this.basisberoepsgerichteLeerweg_27Field;
            }
            set
            {
                this.basisberoepsgerichteLeerweg_27Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> BasisberoepsgerichteLeerweg_34
        {
            get
            {
                return this.basisberoepsgerichteLeerweg_34Field;
            }
            set
            {
                this.basisberoepsgerichteLeerweg_34Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> CombinatieBKG_16
        {
            get
            {
                return this.combinatieBKG_16Field;
            }
            set
            {
                this.combinatieBKG_16Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> CombinatieBKG_23
        {
            get
            {
                return this.combinatieBKG_23Field;
            }
            set
            {
                this.combinatieBKG_23Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> CombinatieBKG_9
        {
            get
            {
                return this.combinatieBKG_9Field;
            }
            set
            {
                this.combinatieBKG_9Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Combinatie_44
        {
            get
            {
                return this.combinatie_44Field;
            }
            set
            {
                this.combinatie_44Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Combinatie_50
        {
            get
            {
                return this.combinatie_50Field;
            }
            set
            {
                this.combinatie_50Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Combinatie_56
        {
            get
            {
                return this.combinatie_56Field;
            }
            set
            {
                this.combinatie_56Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Combinatie_63
        {
            get
            {
                return this.combinatie_63Field;
            }
            set
            {
                this.combinatie_63Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> EconomieBKG_14
        {
            get
            {
                return this.economieBKG_14Field;
            }
            set
            {
                this.economieBKG_14Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> EconomieBKG_21
        {
            get
            {
                return this.economieBKG_21Field;
            }
            set
            {
                this.economieBKG_21Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> EconomieBKG_7
        {
            get
            {
                return this.economieBKG_7Field;
            }
            set
            {
                this.economieBKG_7Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Economie_42
        {
            get
            {
                return this.economie_42Field;
            }
            set
            {
                this.economie_42Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Economie_48
        {
            get
            {
                return this.economie_48Field;
            }
            set
            {
                this.economie_48Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Economie_54
        {
            get
            {
                return this.economie_54Field;
            }
            set
            {
                this.economie_54Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Economie_61
        {
            get
            {
                return this.economie_61Field;
            }
            set
            {
                this.economie_61Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> GeenSectorT_10
        {
            get
            {
                return this.geenSectorT_10Field;
            }
            set
            {
                this.geenSectorT_10Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> GeenSectorT_17
        {
            get
            {
                return this.geenSectorT_17Field;
            }
            set
            {
                this.geenSectorT_17Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> GeenSectorT_24
        {
            get
            {
                return this.geenSectorT_24Field;
            }
            set
            {
                this.geenSectorT_24Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> GemengdeLeerweg_30
        {
            get
            {
                return this.gemengdeLeerweg_30Field;
            }
            set
            {
                this.gemengdeLeerweg_30Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> GemengdeLeerweg_37
        {
            get
            {
                return this.gemengdeLeerweg_37Field;
            }
            set
            {
                this.gemengdeLeerweg_37Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
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
        public Nullable<int> Havo4Totaal_66
        {
            get
            {
                return this.havo4Totaal_66Field;
            }
            set
            {
                this.havo4Totaal_66Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Havo5MetDiploma_68
        {
            get
            {
                return this.havo5MetDiploma_68Field;
            }
            set
            {
                this.havo5MetDiploma_68Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Havo5Totaal_67
        {
            get
            {
                return this.havo5Totaal_67Field;
            }
            set
            {
                this.havo5Totaal_67Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Havo5ZonderDiploma_69
        {
            get
            {
                return this.havo5ZonderDiploma_69Field;
            }
            set
            {
                this.havo5ZonderDiploma_69Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> HavoVwoInclAlgLeerjr_65
        {
            get
            {
                return this.havoVwoInclAlgLeerjr_65Field;
            }
            set
            {
                this.havoVwoInclAlgLeerjr_65Field = value;
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
        public Nullable<int> KaderberoepsgerichteLeerweg_28
        {
            get
            {
                return this.kaderberoepsgerichteLeerweg_28Field;
            }
            set
            {
                this.kaderberoepsgerichteLeerweg_28Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> KaderberoepsgerichteLeerweg_35
        {
            get
            {
                return this.kaderberoepsgerichteLeerweg_35Field;
            }
            set
            {
                this.kaderberoepsgerichteLeerweg_35Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> LandbouwBKG_12
        {
            get
            {
                return this.landbouwBKG_12Field;
            }
            set
            {
                this.landbouwBKG_12Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> LandbouwBKG_19
        {
            get
            {
                return this.landbouwBKG_19Field;
            }
            set
            {
                this.landbouwBKG_19Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> LandbouwBKG_5
        {
            get
            {
                return this.landbouwBKG_5Field;
            }
            set
            {
                this.landbouwBKG_5Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Landbouw_40
        {
            get
            {
                return this.landbouw_40Field;
            }
            set
            {
                this.landbouw_40Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Landbouw_46
        {
            get
            {
                return this.landbouw_46Field;
            }
            set
            {
                this.landbouw_46Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Landbouw_52
        {
            get
            {
                return this.landbouw_52Field;
            }
            set
            {
                this.landbouw_52Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Landbouw_59
        {
            get
            {
                return this.landbouw_59Field;
            }
            set
            {
                this.landbouw_59Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Leerjaar12_2
        {
            get
            {
                return this.leerjaar12_2Field;
            }
            set
            {
                this.leerjaar12_2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MboLeerwegEnNiveau
        {
            get
            {
                return this.mboLeerwegEnNiveauField;
            }
            set
            {
                this.mboLeerwegEnNiveauField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string MboRichtingEnSector
        {
            get
            {
                return this.mboRichtingEnSectorField;
            }
            set
            {
                this.mboRichtingEnSectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string Persoonskenmerken
        {
            get
            {
                return this.persoonskenmerkenField;
            }
            set
            {
                this.persoonskenmerkenField = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Praktijkonderwijs_73
        {
            get
            {
                return this.praktijkonderwijs_73Field;
            }
            set
            {
                this.praktijkonderwijs_73Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TechniekBKG_15
        {
            get
            {
                return this.techniekBKG_15Field;
            }
            set
            {
                this.techniekBKG_15Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TechniekBKG_22
        {
            get
            {
                return this.techniekBKG_22Field;
            }
            set
            {
                this.techniekBKG_22Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TechniekBKG_8
        {
            get
            {
                return this.techniekBKG_8Field;
            }
            set
            {
                this.techniekBKG_8Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Techniek_43
        {
            get
            {
                return this.techniek_43Field;
            }
            set
            {
                this.techniek_43Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Techniek_49
        {
            get
            {
                return this.techniek_49Field;
            }
            set
            {
                this.techniek_49Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Techniek_55
        {
            get
            {
                return this.techniek_55Field;
            }
            set
            {
                this.techniek_55Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Techniek_62
        {
            get
            {
                return this.techniek_62Field;
            }
            set
            {
                this.techniek_62Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TheoretischeLeerweg_31
        {
            get
            {
                return this.theoretischeLeerweg_31Field;
            }
            set
            {
                this.theoretischeLeerweg_31Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TheoretischeLeerweg_38
        {
            get
            {
                return this.theoretischeLeerweg_38Field;
            }
            set
            {
                this.theoretischeLeerweg_38Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TheoretischeLeerweg_64
        {
            get
            {
                return this.theoretischeLeerweg_64Field;
            }
            set
            {
                this.theoretischeLeerweg_64Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> TotaalDoorstroomLeerling_1
        {
            get
            {
                return this.totaalDoorstroomLeerling_1Field;
            }
            set
            {
                this.totaalDoorstroomLeerling_1Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_11
        {
            get
            {
                return this.totaal_11Field;
            }
            set
            {
                this.totaal_11Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_18
        {
            get
            {
                return this.totaal_18Field;
            }
            set
            {
                this.totaal_18Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_25
        {
            get
            {
                return this.totaal_25Field;
            }
            set
            {
                this.totaal_25Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_26
        {
            get
            {
                return this.totaal_26Field;
            }
            set
            {
                this.totaal_26Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_29
        {
            get
            {
                return this.totaal_29Field;
            }
            set
            {
                this.totaal_29Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_32
        {
            get
            {
                return this.totaal_32Field;
            }
            set
            {
                this.totaal_32Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_33
        {
            get
            {
                return this.totaal_33Field;
            }
            set
            {
                this.totaal_33Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_36
        {
            get
            {
                return this.totaal_36Field;
            }
            set
            {
                this.totaal_36Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_39
        {
            get
            {
                return this.totaal_39Field;
            }
            set
            {
                this.totaal_39Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_4
        {
            get
            {
                return this.totaal_4Field;
            }
            set
            {
                this.totaal_4Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_45
        {
            get
            {
                return this.totaal_45Field;
            }
            set
            {
                this.totaal_45Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_51
        {
            get
            {
                return this.totaal_51Field;
            }
            set
            {
                this.totaal_51Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_57
        {
            get
            {
                return this.totaal_57Field;
            }
            set
            {
                this.totaal_57Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Totaal_58
        {
            get
            {
                return this.totaal_58Field;
            }
            set
            {
                this.totaal_58Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Vmbo3Totaal_3
        {
            get
            {
                return this.vmbo3Totaal_3Field;
            }
            set
            {
                this.vmbo3Totaal_3Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Vwo46Totaal_70
        {
            get
            {
                return this.vwo46Totaal_70Field;
            }
            set
            {
                this.vwo46Totaal_70Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Vwo46ZonderDiploma_72
        {
            get
            {
                return this.vwo46ZonderDiploma_72Field;
            }
            set
            {
                this.vwo46ZonderDiploma_72Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> Vwo6MetDiploma_71
        {
            get
            {
                return this.vwo6MetDiploma_71Field;
            }
            set
            {
                this.vwo6MetDiploma_71Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijnBKG_13
        {
            get
            {
                return this.zorgEnWelzijnBKG_13Field;
            }
            set
            {
                this.zorgEnWelzijnBKG_13Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijnBKG_20
        {
            get
            {
                return this.zorgEnWelzijnBKG_20Field;
            }
            set
            {
                this.zorgEnWelzijnBKG_20Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijnBKG_6
        {
            get
            {
                return this.zorgEnWelzijnBKG_6Field;
            }
            set
            {
                this.zorgEnWelzijnBKG_6Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijn_40
        {
            get
            {
                return this.zorgEnWelzijn_40Field;
            }
            set
            {
                this.zorgEnWelzijn_40Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijn_47
        {
            get
            {
                return this.zorgEnWelzijn_47Field;
            }
            set
            {
                this.zorgEnWelzijn_47Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijn_53
        {
            get
            {
                return this.zorgEnWelzijn_53Field;
            }
            set
            {
                this.zorgEnWelzijn_53Field = value;
            }
        }

        /// <remarks/>
        public Nullable<int> ZorgEnWelzijn_60
        {
            get
            {
                return this.zorgEnWelzijn_60Field;
            }
            set
            {
                this.zorgEnWelzijn_60Field = value;
            }
        }
    }


}
