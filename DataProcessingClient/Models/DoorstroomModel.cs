using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.Models
{
    public class DoorstroomModel
    {
        public int Id { get; set; }
        public string Geslacht { get; set; }
        public string MboLeerwegEnNiveau { get; set; }
        public string MboRichtingEnSector { get; set; }
        public string Persoonskenmerken { get; set; }
        public string Perioden { get; set; }
        public Nullable<int> TotaalDoorstroomLeerling_1 { get; set; }
        public Nullable<int> Leerjaar12_2 { get; set; }
        public Nullable<int> Vmbo3Totaal_3 { get; set; }
        public Nullable<int> Totaal_4 { get; set; }
        public Nullable<int> LandbouwBKG_5 { get; set; }
        public Nullable<int> ZorgEnWelzijnBKG_6 { get; set; }
        public Nullable<int> EconomieBKG_7 { get; set; }
        public Nullable<int> TechniekBKG_8 { get; set; }
        public Nullable<int> CombinatieBKG_9 { get; set; }
        public Nullable<int> GeenSectorT_10 { get; set; }
        public Nullable<int> Totaal_11 { get; set; }
        public Nullable<int> LandbouwBKG_12 { get; set; }
        public Nullable<int> ZorgEnWelzijnBKG_13 { get; set; }
        public Nullable<int> EconomieBKG_14 { get; set; }
        public Nullable<int> TechniekBKG_15 { get; set; }
        public Nullable<int> CombinatieBKG_16 { get; set; }
        public Nullable<int> GeenSectorT_17 { get; set; }
        public Nullable<int> Totaal_18 { get; set; }
        public Nullable<int> LandbouwBKG_19 { get; set; }
        public Nullable<int> ZorgEnWelzijnBKG_20 { get; set; }
        public Nullable<int> EconomieBKG_21 { get; set; }
        public Nullable<int> TechniekBKG_22 { get; set; }
        public Nullable<int> CombinatieBKG_23 { get; set; }
        public Nullable<int> GeenSectorT_24 { get; set; }
        public Nullable<int> Totaal_25 { get; set; }
        public Nullable<int> Totaal_26 { get; set; }
        public Nullable<int> BasisberoepsgerichteLeerweg_27 { get; set; }
        public Nullable<int> KaderberoepsgerichteLeerweg_28 { get; set; }
        public Nullable<int> Totaal_29 { get; set; }
        public Nullable<int> GemengdeLeerweg_30 { get; set; }
        public Nullable<int> TheoretischeLeerweg_31 { get; set; }
        public Nullable<int> Totaal_32 { get; set; }
        public Nullable<int> Totaal_33 { get; set; }
        public Nullable<int> BasisberoepsgerichteLeerweg_34 { get; set; }
        public Nullable<int> KaderberoepsgerichteLeerweg_35 { get; set; }
        public Nullable<int> Totaal_36 { get; set; }
        public Nullable<int> GemengdeLeerweg_37 { get; set; }
        public Nullable<int> TheoretischeLeerweg_38 { get; set; }
        public Nullable<int> Totaal_39 { get; set; }
        public Nullable<int> Landbouw_40 { get; set; }
        public Nullable<int> ZorgEnWelzijn_40 { get; set; }
        public Nullable<int> Economie_42 { get; set; }
        public Nullable<int> Techniek_43 { get; set; }
        public Nullable<int> Combinatie_44 { get; set; }
        public Nullable<int> Totaal_45 { get; set; }
        public Nullable<int> Landbouw_46 { get; set; }
        public Nullable<int> ZorgEnWelzijn_47 { get; set; }
        public Nullable<int> Economie_48 { get; set; }
        public Nullable<int> Techniek_49 { get; set; }
        public Nullable<int> Combinatie_50 { get; set; }
        public Nullable<int> Totaal_51 { get; set; }
        public Nullable<int> Landbouw_52 { get; set; }
        public Nullable<int> ZorgEnWelzijn_53 { get; set; }
        public Nullable<int> Economie_54 { get; set; }
        public Nullable<int> Techniek_55 { get; set; }
        public Nullable<int> Combinatie_56 { get; set; }
        public Nullable<int> Totaal_57 { get; set; }
        public Nullable<int> Totaal_58 { get; set; }
        public Nullable<int> Landbouw_59 { get; set; }
        public Nullable<int> ZorgEnWelzijn_60 { get; set; }
        public Nullable<int> Economie_61 { get; set; }
        public Nullable<int> Techniek_62 { get; set; }
        public Nullable<int> Combinatie_63 { get; set; }
        public Nullable<int> TheoretischeLeerweg_64 { get; set; }
        public Nullable<int> HavoVwoInclAlgLeerjr_65 { get; set; }
        public Nullable<int> Havo4Totaal_66 { get; set; }
        public Nullable<int> Havo5Totaal_67 { get; set; }
        public Nullable<int> Havo5MetDiploma_68 { get; set; }
        public Nullable<int> Havo5ZonderDiploma_69 { get; set; }
        public Nullable<int> Vwo46Totaal_70 { get; set; }
        public Nullable<int> Vwo6MetDiploma_71 { get; set; }
        public Nullable<int> Vwo46ZonderDiploma_72 { get; set; }
        public Nullable<int> Praktijkonderwijs_73 { get; set; }

        /// <summary>
        /// Converts the database item into a api friendly item
        /// </summary>
        /// <param name="d">item to convert</param>
        public static implicit operator DoorstroomModel(ArrayOfDoorstroomDataDoorstroomData d)
        {
            DoorstroomModel item = new DoorstroomModel
            {
                Id = d.Id,
                Geslacht =  d.Geslacht,
                MboLeerwegEnNiveau =  d.MboLeerwegEnNiveau,
                MboRichtingEnSector = d.MboRichtingEnSector,
                Persoonskenmerken = d.Persoonskenmerken,
                Perioden =  d.Perioden,
                TotaalDoorstroomLeerling_1 = d.TotaalDoorstroomLeerling_1,
                Leerjaar12_2 = d.Leerjaar12_2,
                Vmbo3Totaal_3 = d.Vmbo3Totaal_3,
                Totaal_4 = d.Totaal_4,
                LandbouwBKG_5 = d.LandbouwBKG_5,
                ZorgEnWelzijnBKG_6 = d.ZorgEnWelzijnBKG_6,
                EconomieBKG_7 = d.EconomieBKG_7,
                TechniekBKG_8 = d.TechniekBKG_8,
                CombinatieBKG_9 = d.CombinatieBKG_9,
                GeenSectorT_10 = d.GeenSectorT_10,
                Totaal_11 = d.Totaal_11,
                LandbouwBKG_12 = d.LandbouwBKG_12,
                ZorgEnWelzijnBKG_13 = d.ZorgEnWelzijnBKG_13,
                EconomieBKG_14 = d.EconomieBKG_14,
                TechniekBKG_15 = d.TechniekBKG_15,
                CombinatieBKG_16 = d.CombinatieBKG_16,
                GeenSectorT_17 = d.GeenSectorT_17,
                Totaal_18 = d.Totaal_18,
                LandbouwBKG_19 = d.LandbouwBKG_19,
                ZorgEnWelzijnBKG_20 = d.ZorgEnWelzijnBKG_20,
                EconomieBKG_21 = d.EconomieBKG_21,
                TechniekBKG_22 = d.TechniekBKG_22,
                CombinatieBKG_23 = d.CombinatieBKG_23,
                GeenSectorT_24 = d.GeenSectorT_24,
                Totaal_25 = d.Totaal_25,
                Totaal_26 = d.Totaal_26,
                BasisberoepsgerichteLeerweg_27 = d.BasisberoepsgerichteLeerweg_27,
                KaderberoepsgerichteLeerweg_28 = d.KaderberoepsgerichteLeerweg_28,
                Totaal_29 = d.Totaal_29,
                GemengdeLeerweg_30 = d.GemengdeLeerweg_30,
                TheoretischeLeerweg_31 = d.TheoretischeLeerweg_31,
                Totaal_32 = d.Totaal_32,
                Totaal_33 = d.Totaal_33,
                BasisberoepsgerichteLeerweg_34 = d.BasisberoepsgerichteLeerweg_34,
                KaderberoepsgerichteLeerweg_35 = d.KaderberoepsgerichteLeerweg_35,
                Totaal_36 = d.Totaal_36,
                GemengdeLeerweg_37 = d.GemengdeLeerweg_37,
                TheoretischeLeerweg_38 = d.TheoretischeLeerweg_38,
                Totaal_39 = d.Totaal_39,
                Landbouw_40 = d.Landbouw_40,
                ZorgEnWelzijn_40 = d.ZorgEnWelzijn_40,
                Economie_42 = d.Economie_42,
                Techniek_43 = d.Techniek_43,
                Combinatie_44 = d.Combinatie_44,
                Totaal_45 = d.Totaal_45,
                Landbouw_46 = d.Landbouw_46,
                ZorgEnWelzijn_47 = d.ZorgEnWelzijn_47,
                Economie_48 = d.Economie_48,
                Techniek_49 = d.Techniek_49,
                Combinatie_50 = d.Combinatie_50,
                Totaal_51 = d.Totaal_51,
                Landbouw_52 = d.Landbouw_52,
                ZorgEnWelzijn_53 = d.ZorgEnWelzijn_53,
                Economie_54 = d.Economie_54,
                Techniek_55 = d.Techniek_55,
                Combinatie_56 = d.Combinatie_56,
                Totaal_57 = d.Totaal_57,
                Totaal_58 = d.Totaal_58,
                Landbouw_59 = d.Landbouw_59,
                ZorgEnWelzijn_60 = d.ZorgEnWelzijn_60,
                Economie_61 = d.Economie_61,
                Techniek_62 = d.Techniek_62,
                Combinatie_63 = d.Combinatie_63,
                TheoretischeLeerweg_64 = d.TheoretischeLeerweg_64,
                HavoVwoInclAlgLeerjr_65 = d.HavoVwoInclAlgLeerjr_65,
                Havo4Totaal_66 = d.Havo4Totaal_66,
                Havo5Totaal_67 = d.Havo5Totaal_67,
                Havo5MetDiploma_68 = d.Havo5MetDiploma_68,
                Havo5ZonderDiploma_69 = d.Havo5ZonderDiploma_69,
                Vwo46Totaal_70 = d.Vwo46Totaal_70,
                Vwo6MetDiploma_71 = d.Vwo6MetDiploma_71,
                Vwo46ZonderDiploma_72 = d.Vwo46ZonderDiploma_72,
                Praktijkonderwijs_73 = d.Praktijkonderwijs_73
            };
            return item;
        }
    }
}
