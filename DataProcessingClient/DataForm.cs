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
    public partial class DataForm : Form
    {
        private AlcoholEnDrugsHandler alcoholEnDrugs;
        private DoorstroomHandler doorstroom;
        private WerkzameBeroepsBevolkingHandler werkzameBeroeps;

        public DataFormat Format { get => (rbXML.Checked) ? DataFormat.XML : DataFormat.JSON; }
        public int MaxRecords { get => trbMaxRecords.Value * 100; }


        public DataForm()
        {
            InitializeComponent();
            RefreshAsync();
        }

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

        private void ResetData()
        {
            alcoholEnDrugs = new AlcoholEnDrugsHandler(tbHostUrl.Text, Format, MaxRecords);
            doorstroom = new DoorstroomHandler(tbHostUrl.Text, Format, MaxRecords);
            werkzameBeroeps = new WerkzameBeroepsBevolkingHandler(tbHostUrl.Text, Format, MaxRecords);
        }

        private void DrawData()
        {
            List<AlcoholEnDrugs> AD = alcoholEnDrugs.GetData();
            List<DoorstroomModel> DS = doorstroom.GetData();
            List<WerkzameBeroepsBevolkingModel> WB = werkzameBeroeps.GetData();

            if(AD.Count != 0 && DS.Count != 0 && WB.Count != 0)
            {
                DrawChartAD1(AD, DS, WB);
                DrawChart2(AD, DS, WB);
            }
            else
            {
                //display a nice error or something :)
            }
            
        }

        public void DrawChartAD1(List<AlcoholEnDrugs> AD, List<DoorstroomModel> DS, List<WerkzameBeroepsBevolkingModel> WB)
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
        public void DrawChart2(List<AlcoholEnDrugs> AD, List<DoorstroomModel> DS, List<WerkzameBeroepsBevolkingModel> WB)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save the current settings
        }

        private void rbXML_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAsync();
        }

        private void trbMaxRecords_Scroll(object sender, EventArgs e)
        {
            RefreshAsync();
        }
    }
}
