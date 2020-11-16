using LiveCharts;
using LiveCharts.Wpf;
using Market.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market3
{
    public partial class Form1 : Form
    {
        public  Form1()
        {
            InitializeComponent();
            var lst = DataHandler.GetAllData();
            ChartValues<int> tmp = new ChartValues<int>();
            List<string> stmp = new List<string>();


            foreach (var el in lst)
            {
                tmp.Add(el.prise);
                stmp.Add(el.date);
            }

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Price",
                    Values = tmp
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Day",
                Labels = stmp
            });
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
