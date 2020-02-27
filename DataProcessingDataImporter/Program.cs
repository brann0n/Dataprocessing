using DataProcessingDataImporter.Models;
using DataProcessingDataImporter.Models.AD;
using DataProcessingDataImporter.Models.DS;
using DataProcessingDataImporter.Models.WB;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using ADTypedDataSetModel = DataProcessingDataImporter.Models.AD.TypedDataSetModel;
using DSTypedDataSetModel = DataProcessingDataImporter.Models.DS.TypedDataSetModel;
using WBTypedDataSetModel = DataProcessingDataImporter.Models.WB.TypedDataSetModel;

namespace DataProcessingDataImporter
{
    internal class Program
    {

        public static DataProcessingEntities db = new DataProcessingEntities();
        private static void Main(string[] args)
        {
            Console.WriteLine("Dataprocessing dataset importer.");
            GetAlcoholEnDrugs();
            GetWerkzameBeroepsbevolking();
            GetDoorstroomData();
        }

        /// <summary>
        /// function that gets the content of the alchol and drugs dataset and then stores it in a local sql database.
        /// </summary>
        public static void GetAlcoholEnDrugs()
        {
            Console.WriteLine("Starting Alcohol en drugs import");
            //do the webrequests to get the property metadata
            IRestResponse requestGeslacht = RestHelper.Get("https://dataderden.cbs.nl/", "ODataApi/OData/71794ned/Geslacht");
            IRestResponse requestHerkomst = RestHelper.Get("https://dataderden.cbs.nl/", "ODataApi/OData/71794ned/Herkomst");
            IRestResponse requestperioden = RestHelper.Get("https://dataderden.cbs.nl/", "ODataApi/OData/71794ned/Perioden");

            //convert the requests to C# object lists
            OdataReceiver<GeslachtModel> dGeslacht = RestHelper.ConvertJsonToObject<OdataReceiver<GeslachtModel>>(requestGeslacht.Content);
            OdataReceiver<HerkomstModel> dHerkomst = RestHelper.ConvertJsonToObject<OdataReceiver<HerkomstModel>>(requestHerkomst.Content);
            OdataReceiver<PeriodenModel> dPerioden = RestHelper.ConvertJsonToObject<OdataReceiver<PeriodenModel>>(requestperioden.Content);

            //now get the actual data and convert it
            IRestResponse requestTypedSet = RestHelper.Get("https://dataderden.cbs.nl/", "ODataApi/OData/71794ned/TypedDataSet");
            OdataReceiver<ADTypedDataSetModel> dTypedSet = RestHelper.ConvertJsonToObject<OdataReceiver<ADTypedDataSetModel>>(requestTypedSet.Content);
            Console.WriteLine("Done with Alcohol en drugs import");

            foreach (GeslachtModel model in dGeslacht.value)
            {
                if (!db.ADGeslacht.Any(n => n.Key == model.Key))
                {
                    db.ADGeslacht.Add(new ADGeslacht
                    {
                        Key = model.Key,
                        Title = model.Title
                    });
                }
            }

            foreach (HerkomstModel model in dHerkomst.value)
            {
                if (!db.ADHerkomst.Any(n => n.Key == model.Key))
                {
                    db.ADHerkomst.Add(new ADHerkomst
                    {
                        Key = model.Key,
                        Title = model.Title,
                        CategoryGroupID = model.CategoryGroupID
                    });
                }
            }

            foreach (PeriodenModel model in dPerioden.value)
            {
                if (!db.ADPerioden.Any(n => n.Key == model.Key))
                {
                    db.ADPerioden.Add(new ADPerioden
                    {
                        Key = model.Key,
                        Status = model.Status,
                        Title = model.Title
                    });
                }
            }

            foreach (ADTypedDataSetModel model in dTypedSet.value)
            {
                if (!db.ADDataSet.Any(n => n.Id == model.ID))
                {
                    db.ADDataSet.Add(new ADDataSet
                    {
                        Alcoholgebruik = model.Alcoholgebruik_1,
                        BingeDrinken = model.BingeDrinken_2,
                        CannabisActiefGebruik = model.CannabisActiefGebruik_4,
                        CannabisOoitGebruikt = model.CannabisOoitGebruikt_3,
                        Cocaine = model.Cocaine_7,
                        Geslacht = model.Geslacht,
                        Herkomst = model.Herkomst,
                        Perioden = model.Perioden,
                        Id = model.ID,
                        TotaalGebruik = model.TotaalGebruik_5,
                        XTC = model.XTC_6
                    });
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
        }

        /// <summary>
        /// function that gets the content of the werkzame beroepsbevolking dataset and then stores it in a local sql database.
        /// </summary>
        public static void GetWerkzameBeroepsbevolking()
        {
            Console.WriteLine("Starting Werkzame Beroepsbevolking import");
            //do the webrequests to get the first datatypes
            IRestResponse requestKenmerken = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/80815ned/Kenmerken");
            IRestResponse requestperioden = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/80815ned/Perioden");

            //convert the requests to C# object lists
            OdataReceiver<KenmerkenModel> dKenmerken = RestHelper.ConvertJsonToObject<OdataReceiver<KenmerkenModel>>(requestKenmerken.Content);
            OdataReceiver<PeriodenModel> dPerioden = RestHelper.ConvertJsonToObject<OdataReceiver<PeriodenModel>>(requestperioden.Content);

            //now get the actual data and convert it
            IRestResponse requestTypedSet = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/80815ned/TypedDataSet");
            OdataReceiver<WBTypedDataSetModel> dTypedSet = RestHelper.ConvertJsonToObject<OdataReceiver<WBTypedDataSetModel>>(requestTypedSet.Content);

            Console.WriteLine("Done with werkzame beroepsbevolking import");

            foreach (KenmerkenModel model in dKenmerken.value)
            {
                if (!db.WBKenmerken.Any(n => n.Key == model.Key))
                {
                    db.WBKenmerken.Add(new WBKenmerken
                    {
                        Key = model.Key,
                        Description = model.Description,
                        Title = model.Title
                    });
                }
            }

            foreach (PeriodenModel model in dPerioden.value)
            {
                if (!db.WBPerioden.Any(n => n.Key == model.Key))
                {
                    db.WBPerioden.Add(new WBPerioden
                    {
                        Key = model.Key,
                        Status = model.Status,
                        Title = model.Title
                    });
                }
            }
            int saveCounter = 0;
            foreach (WBTypedDataSetModel model in dTypedSet.value)
            {
                if (saveCounter > 100)
                {
                    Console.WriteLine("Writing records, currently at record: " + model.ID);
                    db.SaveChanges();
                    saveCounter = 0;
                }
                saveCounter++;

                if (!db.WBDataSet.Any(n => n.Id == model.ID))
                {
                    db.WBDataSet.Add(new WBDataSet
                    {
                        CreatieveZakelijkeDienstverlening = model.CreatieveZakelijkeDienstverlening_5,
                        Id = model.ID,
                        Kenmerken = model.Kenmerken,
                        Kunsten = model.Kunsten_3,
                        MediaEnEntertainment = model.MediaEnEntertainment_4,
                        OverigeCreatieveBeroepen = model.OverigeCreatieveBeroepen_6,
                        Perioden = model.Perioden,
                        TotaalCreatieveBeroepen = model.TotaalCreatieveBeroepen_2,
                        WerkzameBeroepsbevolkingTotaal = model.WerkzameBeroepsbevolkingTotaal_1,
                        WerkzPersMetBeroepOnbekend = model.WerkzPersMetBeroepOnbekend_8,
                        WerkzPersMetNietCreatieveBeroep = model.WerkzPersMetNietCreatiefBeroep_7
                    });
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
        }

        /// <summary>
        /// function that gets teh content of the doorstroom data dataset and then stores it in a local sql database.
        /// </summary>
        public static void GetDoorstroomData()
        {
            Console.WriteLine("Starting doorstroom data import");
            List<DSTypedDataSetModel> fullDataSet = new List<DSTypedDataSetModel>();
            //since this dataset is huge! we need to loop through each 5000 records in order to not overload the remote :
            //1: get the total record count: /ODataApi/OData/71892ned/TypedDataSet/$count
            IRestResponse requestRecordCount = RestHelper.Get("https://opendata.cbs.nl/", "/ODataApi/OData/71892ned/TypedDataSet/$count");
            int rCount = int.Parse(requestRecordCount.Content);
            Console.WriteLine($"Importing {rCount} records!");
            int downloadedCount = 0;
            while (rCount - downloadedCount != 0)
            {
                int requestAmount = 5000;
                int skipAmount = downloadedCount;

                IRestResponse requestTypedSet = RestHelper.Get("https://opendata.cbs.nl/", $"ODataApi/OData/71892ned/TypedDataSet/?$top={requestAmount}&$skip={skipAmount}");
                OdataReceiver<DSTypedDataSetModel> dTypedSet = RestHelper.ConvertJsonToObject<OdataReceiver<DSTypedDataSetModel>>(requestTypedSet.Content);

                fullDataSet.AddRange(dTypedSet.value);
                downloadedCount += dTypedSet.value.Count;
                Console.WriteLine($"imported {downloadedCount} records!");
            }
            //the above while loop should have gotten the exact amount of records into a local storage

            IRestResponse requestMboLeerweg = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/71892ned/MboLeerwegEnNiveau");
            IRestResponse requestMboRichting = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/71892ned/MboRichtingEnSector");
            IRestResponse requestPersoonsKenmerken = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/71892ned/Persoonskenmerken");
            IRestResponse requestGeslacht = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/71892ned/Geslacht");
            IRestResponse requestperioden = RestHelper.Get("https://opendata.cbs.nl/", "ODataApi/OData/71892ned/Perioden");

            OdataReceiver<MboLeerwegEnNiveauModel> dMboLeerwegEnNiveauModel = RestHelper.ConvertJsonToObject<OdataReceiver<MboLeerwegEnNiveauModel>>(requestMboLeerweg.Content);
            OdataReceiver<MboRichtingEnSectorModel> dMboRichting = RestHelper.ConvertJsonToObject<OdataReceiver<MboRichtingEnSectorModel>>(requestMboLeerweg.Content);
            OdataReceiver<PersoonsKenmerkenModel> dPersoonsKenmerken = RestHelper.ConvertJsonToObject<OdataReceiver<PersoonsKenmerkenModel>>(requestMboLeerweg.Content);
            OdataReceiver<GeslachtModel> dGeslacht = RestHelper.ConvertJsonToObject<OdataReceiver<GeslachtModel>>(requestMboLeerweg.Content);
            OdataReceiver<PeriodenModel> dPerioden = RestHelper.ConvertJsonToObject<OdataReceiver<PeriodenModel>>(requestMboLeerweg.Content);

            //check for existing key/id and if its new then add
            foreach (MboLeerwegEnNiveauModel model in dMboLeerwegEnNiveauModel.value)
            {
                if (!db.DSMboLeerwegEnNiveau.Any(n => n.Key == model.Key))
                {
                    db.DSMboLeerwegEnNiveau.Add(new DSMboLeerwegEnNiveau
                    {
                        Description = model.Description,
                        Key = model.Key,
                        Title = model.Title
                    });
                }
            }

            foreach (MboRichtingEnSectorModel model in dMboRichting.value)
            {
                if (!db.DSMboRichtingEnSector.Any(n => n.Key == model.Key))
                {
                    db.DSMboRichtingEnSector.Add(new DSMboRichtingEnSector
                    {
                        Description = model.Description,
                        Key = model.Key,
                        Title = model.Title
                    });
                }
            }

            foreach (PersoonsKenmerkenModel model in dPersoonsKenmerken.value)
            {
                if (!db.DSPersoonsKenmerken.Any(n => n.Key == model.Key))
                {
                    db.DSPersoonsKenmerken.Add(new DSPersoonsKenmerken
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Key = model.Key
                    });
                }
            }

            foreach (GeslachtModel model in dGeslacht.value)
            {
                if (!db.DSGeslacht.Any(n => n.Key == model.Key))
                {
                    db.DSGeslacht.Add(new DSGeslacht
                    {
                        Key = model.Key,
                        Description = model.Description,
                        Title = model.Title
                    });
                }
            }

            foreach (PeriodenModel model in dPerioden.value)
            {
                if (!db.DSPerioden.Any(n => n.Key == model.Key))
                {
                    db.DSPerioden.Add(new DSPerioden
                    {
                        Description = model.Description,
                        Key = model.Key,
                        Status = model.Status,
                        Title = model.Title
                    });
                }
            }

            db.SaveChanges();

            int saveCounter = 0;
            foreach (DSTypedDataSetModel model in fullDataSet)
            {
                if (saveCounter > 100)
                {
                    Console.WriteLine("Writing records, currently at record: " + model.ID);
                    db.SaveChanges();
                    saveCounter = 0;
                }
                

                if (!db.DSDataSet.Any(n => n.Id == model.ID))
                {
                    saveCounter++;
                    db.DSDataSet.Add(new DSDataSet
                    {
                        Id = model.ID,
                        Geslacht = model.Geslacht,
                        MboLeerwegEnNiveau = model.MboLeerwegEnNiveau,
                        MboRichtingEnSector = model.MboRichtingEnSector,
                        Perioden = model.Perioden,
                        Persoonskenmerken = model.Persoonskenmerken,
                        TotaalDoorstroomLeerling_1 = model.TotaalDoorstroomLeerlingen_1,
                        Leerjaar12_2 = model.Leerjaar12_2,
                        Vmbo3Totaal_3 = model.Vmbo3Totaal_3,
                        Totaal_4 = model.Totaal_4,
                        LandbouwBKG_5 = model.LandbouwBKG_5,
                        ZorgEnWelzijnBKG_6 = model.ZorgEnWelzijnBKG_6,
                        EconomieBKG_7 = model.EconomieBKG_7,
                        TechniekBKG_8 = model.TechniekBKG_8,
                        CombinatieBKG_9 = model.CombinatieBKG_9,
                        GeenSectorT_10 = model.GeenSectorT_10,
                        Totaal_11 = model.Totaal_11,
                        LandbouwBKG_12 = model.LandbouwBKG_12,
                        ZorgEnWelzijnBKG_13 = model.ZorgEnWelzijnBKG_13,
                        EconomieBKG_14 = model.EconomieBKG_14,
                        TechniekBKG_15 = model.TechniekBKG_15,
                        CombinatieBKG_16 = model.CombinatieBKG_16,
                        GeenSectorT_17 = model.GeenSectorT_17,
                        Totaal_18 = model.Totaal_18,
                        LandbouwBKG_19 = model.LandbouwBKG_19,
                        ZorgEnWelzijnBKG_20 = model.ZorgEnWelzijnBKG_20,
                        EconomieBKG_21 = model.EconomieBKG_21,
                        TechniekBKG_22 = model.TechniekBKG_22,
                        CombinatieBKG_23 = model.CombinatieBKG_23,
                        GeenSectorT_24 = model.GeenSectorT_24,
                        Totaal_25 = model.Totaal_25,
                        Totaal_26 = model.Totaal_26,
                        BasisberoepsgerichteLeerweg_27 = model.BasisberoepsgerichteLeerweg_27,
                        KaderberoepsgerichteLeerweg_28 = model.KaderberoepsgerichteLeerweg_28,
                        Totaal_29 = model.Totaal_29,
                        GemengdeLeerweg_30 = model.GemengdeLeerweg_30,
                        TheoretischeLeerweg_31 = model.TheoretischeLeerweg_31,
                        Totaal_32 = model.Totaal_32,
                        Totaal_33 = model.Totaal_33,
                        BasisberoepsgerichteLeerweg_34 = model.BasisberoepsgerichteLeerweg_34,
                        KaderberoepsgerichteLeerweg_35 = model.KaderberoepsgerichteLeerweg_35,
                        Totaal_36 = model.Totaal_36,
                        GemengdeLeerweg_37 = model.GemengdeLeerweg_37,
                        TheoretischeLeerweg_38 = model.TheoretischeLeerweg_38,
                        Totaal_39 = model.Totaal_39,
                        Landbouw_40 = model.Landbouw_40,
                        ZorgEnWelzijn_40 = model.ZorgEnWelzijn_41,
                        Economie_42 = model.Economie_42,
                        Techniek_43 = model.Techniek_43,
                        Combinatie_44 = model.Combinatie_44,
                        Totaal_45 = model.Totaal_45,
                        Landbouw_46 = model.Landbouw_46,
                        ZorgEnWelzijn_47 = model.ZorgEnWelzijn_47,
                        Economie_48 = model.Economie_48,
                        Techniek_49 = model.Techniek_49,
                        Combinatie_50 = model.Combinatie_50,
                        Totaal_51 = model.Totaal_51,
                        Landbouw_52 = model.Landbouw_52,
                        ZorgEnWelzijn_53 = model.ZorgEnWelzijn_53,
                        Economie_54 = model.Economie_54,
                        Techniek_55 = model.Techniek_55,
                        Combinatie_56 = model.Combinatie_56,
                        Totaal_57 = model.Totaal_57,
                        Totaal_58 = model.Totaal_58,
                        Landbouw_59 = model.Landbouw_59,
                        ZorgEnWelzijn_60 = model.ZorgEnWelzijn_60,
                        Economie_61 = model.Economie_61,
                        Techniek_62 = model.Techniek_62,
                        Combinatie_63 = model.Combinatie_63,
                        TheoretischeLeerweg_64 = model.TheoretischeLeerweg_64,
                        HavoVwoInclAlgLeerjr_65 = model.HavoVwo3InclAlgLeerjr_65,
                        Havo4Totaal_66 = model.Havo4Totaal_66,
                        Havo5Totaal_67 = model.Havo5Totaal_67,
                        Havo5MetDiploma_68 = model.Havo5MetDiploma_68,
                        Havo5ZonderDiploma_69 = model.Havo5ZonderDiploma_69,
                        Vwo46Totaal_70 = model.Vwo46Totaal_70,
                        Vwo6MetDiploma_71 = model.Vwo6MetDiploma_71,
                        Vwo46ZonderDiploma_72 = model.Vwo46ZonderDiploma_72,
                        Praktijkonderwijs_73 = model.Praktijkonderwijs_73,
                    });
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
