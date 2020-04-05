using DataProcessingClient.DataHandler;
using DataProcessingClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataProcessingClient
{
    public delegate void ReportErrorEventHandler(Exception exception);

    public partial class DataForm : Form
    {
        private AlcoholEnDrugsHandler alcoholEnDrugs;
        private DoorstroomHandler doorstroom;
        private WerkzameBeroepsBevolkingHandler werkzameBeroeps;

        /// <summary>
        /// The static event that each thread subscribes to
        /// </summary>
        private static event ReportErrorEventHandler errorHandler;

        /// <summary>
        /// DataFormat enum with either Json or XML
        /// </summary>
        public DataFormat Format { get => (rbXML.Checked) ? DataFormat.XML : DataFormat.JSON; }

        /// <summary>
        /// The max amount of records this Form may retrieve from the API
        /// </summary>
        public int MaxRecords { get => trbMaxRecords.Value * 100; }

        public DataForm()
        {
            InitializeComponent();
            RefreshAsync();
            errorHandler += OnErrorReported;
        }

        /// <summary>
        /// Method that is called on the UI thread that shows the error
        /// </summary>
        /// <param name="exception"></param>
        private void OnErrorReported(Exception exception)
        {
            MessageBox.Show(exception.Message, "Error occured during the data retrieval", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Static void to report errors to the UI from anywhere in the code
        /// </summary>
        /// <param name="exception">The exception you wanna show</param>
        public static void ReportError(Exception exception)
        {
            errorHandler(exception);
        }

        /// <summary>
        /// Does a refresh of data and then draws that data, async so it doesnt freeze the UI thread
        /// </summary>
        public async void RefreshAsync()
        {
            alcoholEnDrugs = new AlcoholEnDrugsHandler(tbHostUrl.Text, Format, MaxRecords);
            doorstroom = new DoorstroomHandler(tbHostUrl.Text, Format, MaxRecords);
            werkzameBeroeps = new WerkzameBeroepsBevolkingHandler(tbHostUrl.Text, Format, MaxRecords);
            WriteStats();
            alcoholEnDrugs.SetData(await alcoholEnDrugs.DownloadDataAsync());
            doorstroom.SetData(await doorstroom.DownloadDataAsync());
            werkzameBeroeps.SetData(await werkzameBeroeps.DownloadDataAsync());

            DrawData();
            WriteStats();
        }

        /// <summary>
        /// Writes a label to the UI
        /// </summary>
        public void WriteStats()
        {
            int ADcount = alcoholEnDrugs.Count;
            int DScount = doorstroom.Count;
            int WBcount = werkzameBeroeps.Count;

            StringBuilder builder = new StringBuilder();
            builder.Append("Current record count: \r\n");
            builder.Append($"   Alcohol En Drugs: {ADcount}\r\n");
            builder.Append($"   Doorstroom: {DScount}\r\n");
            builder.Append($"   WerkzameBeroepsBevolking: {WBcount}\r\n");
            builder.Append($"With dataformat: {(rbXML.Checked ? "XML" : "JSON")}");

            tbStats.Text = builder.ToString();
        }

        /// <summary>
        /// Checks if there is data and then calls the individual draw functions for each graph
        /// </summary>
        private void DrawData()
        {
            List<ArrayOfAlcoholEnDrugsAlcoholEnDrugs> AD = alcoholEnDrugs.GetData()?.AlcoholEnDrugsArray?.ToList();
            List<ArrayOfDoorstroomDataDoorstroomData> DS = doorstroom.GetData()?.DoorstroomDataArray?.ToList();
            List<ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking> WB = werkzameBeroeps.GetData()?.WerkzameBeroepsbevolkingArray?.ToList();


            if (AD != null && DS != null && WB != null)
            {
                if (AD.Count != 0 && DS.Count != 0 && WB.Count != 0)
                {
                    DrawChartAD1(AD, DS, WB);
                    DrawChart2(AD, DS, WB);
                    DrawChart3(AD, DS, WB);
                }
                else
                {
                    //display a nice error or something :)
                    ReportError(new Exception("Data was downloaded but some datasets have no items"));
                }
            }
            else
            {
                //display a nice error or something :)
                ReportError(new Exception("Some Data could not be downloaded"));
            }


        }

        /// <summary>
        /// Render Graph 1
        /// </summary>
        /// <param name="AD">List of ArrayOfAlcoholEnDrugsAlcoholEnDrugs</param>
        /// <param name="DS">List of ArrayOfDoorstroomDataDoorstroomData</param>
        /// <param name="WB">List of ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking</param>
        public void DrawChartAD1(List<ArrayOfAlcoholEnDrugsAlcoholEnDrugs> AD, List<ArrayOfDoorstroomDataDoorstroomData> DS, List<ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking> WB)
        {
            Dictionary<string, double> ADAvarageBinge = new Dictionary<string, double>();
            Dictionary<string, double> ADAvarageDrugUse = new Dictionary<string, double>();
            foreach (string year in AD.Select(n => n.Perioden).Distinct())
            {
                double avarage = AD.Where(n => n.Perioden == year).Average(n => n.BingeDrinken).GetValueOrDefault();
                ADAvarageBinge.Add(year, avarage);
            }

            foreach (string year in AD.Select(n => n.Perioden).Distinct())
            {
                double avarage = AD.Where(n => n.Perioden == year).Average(n => n.CannabisActiefGebruik).GetValueOrDefault();
                ADAvarageDrugUse.Add(year, avarage);
            }

            chartAD1.Series.Clear();
            chartAD1.Titles.Clear();

            chartAD1.Titles.Add("Onderzoek naar scholieren tussen 12 en 19 jaar");
            var series1 = new Series("Gemiddeld % Alcohol drinkers onder scholieren");
            series1.ChartType = SeriesChartType.Spline;
            series1.Points.DataBindXY(ADAvarageBinge.Keys, ADAvarageBinge.Values);

            var series2 = new Series("Gemiddeld % Wiet Rokers onder scholieren");
            series2.ChartType = SeriesChartType.Spline;
            series2.Points.DataBindXY(ADAvarageBinge.Keys, ADAvarageDrugUse.Values);

            chartAD1.ChartAreas[0].AxisY.LabelStyle.Format = "{#,#}%";

            chartAD1.Series.Add(series1);
            chartAD1.Series.Add(series2);
            chartAD1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chartAD1.ChartAreas[0].RecalculateAxesScale();
        }

        /// <summary>
        /// Render Graph 2
        /// </summary>
        /// <param name="AD">List of ArrayOfAlcoholEnDrugsAlcoholEnDrugs</param>
        /// <param name="DS">List of ArrayOfDoorstroomDataDoorstroomData</param>
        /// <param name="WB">List of ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking</param>
        public void DrawChart2(List<ArrayOfAlcoholEnDrugsAlcoholEnDrugs> AD, List<ArrayOfDoorstroomDataDoorstroomData> DS, List<ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking> WB)
        {
            Dictionary<string, double> DSGemiddeldeHavo = new Dictionary<string, double>();
            Dictionary<string, double> DSGemiddeldeVwo = new Dictionary<string, double>();
            foreach (string year in DS.Select(n => n.Perioden).Distinct())
            {
                double avarage1 = DS.Where(n => n.Perioden == year).Average(n=>n.Havo5Totaal_67).GetValueOrDefault();
                double avarage2 = DS.Where(n => n.Perioden == year).Average(n => n.Vwo46Totaal_70).GetValueOrDefault();
                DSGemiddeldeHavo.Add(year.Substring(0, 4), avarage1);
                DSGemiddeldeVwo.Add(year.Substring(0, 4), avarage2);
            }
            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Titles.Add("Gemiddelde doorstroom van mannen en vrouwen van HAVO en VWO naar MBO over alle MBO richtingen");

            var series1 = new Series("HAVO");
            series1.ChartType = SeriesChartType.SplineRange;
            series1.Points.DataBindXY(DSGemiddeldeHavo.Keys, DSGemiddeldeHavo.Values);

            var series2 = new Series("VWO");
            series2.ChartType = SeriesChartType.SplineRange;
            series2.Points.DataBindXY(DSGemiddeldeVwo.Keys, DSGemiddeldeVwo.Values);
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "{#,##}";
            chart2.Series.Add(series1);
            chart2.Series.Add(series2);
            chart2.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart2.ChartAreas[0].RecalculateAxesScale();
        }

        /// <summary>
        /// Render Graph 3
        /// </summary>
        /// <param name="AD">List of ArrayOfAlcoholEnDrugsAlcoholEnDrugs</param>
        /// <param name="DS">List of ArrayOfDoorstroomDataDoorstroomData</param>
        /// <param name="WB">List of ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking</param>
        public void DrawChart3(List<ArrayOfAlcoholEnDrugsAlcoholEnDrugs> AD, List<ArrayOfDoorstroomDataDoorstroomData> DS, List<ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking> WB)
        {
            Dictionary<string, double> DW15jaar = new Dictionary<string, double>();
            Dictionary<string, double> DW16jaar = new Dictionary<string, double>();
            Dictionary<string, double> DW19jaar = new Dictionary<string, double>();

            foreach (string year in WB.Select(n => n.Perioden).Distinct())
            {
                double avarage1 = WB.Where(n => n.Perioden == year && n.Kenmerken == "Leeftijd: 15 tot 25 jaar").Sum(n => n.TotaalCreatieveBeroepen).GetValueOrDefault();
                double avarage2 = WB.Where(n => n.Perioden == year && n.Kenmerken == "Leeftijd: 25 tot 35 jaar").Sum(n => n.TotaalCreatieveBeroepen).GetValueOrDefault();
                double avarage3 = WB.Where(n => n.Perioden == year && n.Kenmerken == "Leeftijd: 35 tot 45 jaar").Sum(n => n.TotaalCreatieveBeroepen).GetValueOrDefault();

                DW15jaar.Add(year.Substring(0, 4), avarage1);
                DW16jaar.Add(year.Substring(0, 4), avarage2);
                DW19jaar.Add(year.Substring(0, 4), avarage3);

            }

            chart3.Series.Clear();
            chart3.Titles.Clear();
            chart3.Titles.Add("Totale creatieve beroepen per leeftijds categorie");

            var series1 = new Series("15 tot 25 jaar");
            series1.ChartType = SeriesChartType.Column;
            series1.Points.DataBindXY(DW15jaar.Keys, DW15jaar.Values);

            var series2 = new Series("25 tot 35 jaar");
            series2.ChartType = SeriesChartType.Column;
            series2.Points.DataBindXY(DW16jaar.Keys, DW16jaar.Values);

            var series3 = new Series("35 tot 45 jaar");
            series3.ChartType = SeriesChartType.Column;
            series3.Points.DataBindXY(DW19jaar.Keys, DW19jaar.Values);

            chart3.ChartAreas[0].AxisY.LabelStyle.Format = "{#}";
            chart3.Series.Add(series1);
            chart3.Series.Add(series2);
            chart3.Series.Add(series3);
            chart3.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart3.ChartAreas[0].RecalculateAxesScale();
        }

        /// <summary>
        /// When a different data format is selected refresh all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbXML_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAsync();
        }

        /// <summary>
        /// Upon an record size change refresh all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbMaxRecords_Scroll(object sender, EventArgs e)
        {
            RefreshAsync();
        }
    }
}
