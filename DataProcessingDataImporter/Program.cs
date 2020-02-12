using DataProcessingDataImporter.Models;
using DataProcessingDataImporter.Models.AD;
using DataProcessingDataImporter.Models.DS;
using DataProcessingDataImporter.Models.WB;
using RestSharp;
using System;
using System.Collections.Generic;
using ADTypedDataSetModel = DataProcessingDataImporter.Models.AD.TypedDataSetModel;
using DSTypedDataSetModel = DataProcessingDataImporter.Models.DS.TypedDataSetModel;
using WBTypedDataSetModel = DataProcessingDataImporter.Models.WB.TypedDataSetModel;

namespace DataProcessingDataImporter
{
    internal class Program
    {
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
        }

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

            //TODO: create the tables for DS in the database.
        }
    }
}
