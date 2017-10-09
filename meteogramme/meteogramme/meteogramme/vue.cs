using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using System.Windows.Forms;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

namespace meteogramme
{
    public partial class Vue : Form
    {
        //Meteo meteo = new Meteo();
        DownloadDATA DL; //= new DownloadDATA(txtLat.Text, txtLon.Text);

        public Vue()
        {
            InitializeComponent();
            //label1.Text = meteo.showMeteo();
        }

        private void Vue_Load(object sender, EventArgs e)
        {
            int PreviousDay = DateTime.Today.Day - 1;
            this.dtpWeather.MaxDate = DateTime.Today.AddDays(9);
            this.dtpWeather.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, PreviousDay);

            cc1.Width = 600;
            cc1.MaximumSize = new Size(650, 200);
            cc1.Height = 200;

            cc1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Précipitation",
                    Values = new ChartValues<decimal> {5, 6, 2, 7, 3},
                },
                new LineSeries
                {
                    Title = "Température",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7},
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 1
                }
            };
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DL = new DownloadDATA(txtLat.Text, txtLon.Text);
        }

        private void dtpWeather_ValueChanged(object sender, EventArgs e)
        {
            cc1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 2, 1, 6, 10, 2 }
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal> { 10, 1, 5, 6 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {3, 5, 1, 8},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };
        }
    }
}
