using ClassLibrary;
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

namespace Dashboard
{
    public partial class MainForm : Form
    {
        private JDataBase database;
        public MainForm()
        {
            InitializeComponent();
            //database = new JDataBase();
        }
        const string transactionCountSumQuery = @"select datepart(hour,eventdate)HourN,count(*)TransactionCount,sum(cast(TicketPrice as float))*10 InCome from AUTTicketTransaction
                                                where 1=1  and EventDate between getdate() - 30 and getdate()
                                                and TicketPrice > 0 and CardType = 0 
                                                group by datepart(hour,eventdate)
                                                order by HourN";
        private void MainForm_Load(object sender, EventArgs e)
        {
            Chart lineChart = new Chart();
            //lineChart.Series.Add("line");
            //lineChart.Series["line"].XValueMember = "HourN";
            //lineChart.Series["line"].YValueMembers = "TransactionCount";
            //database.setQuery(transactionCountSumQuery);
            //lineChart.DataSource = database.Query_DataTable();
            //lineChart.DataBind();
            //lineChart.Series["line"].ChartType = SeriesChartType.Line;
            lineChart.BackColor = Color.Red;
            lineChart.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(lineChart);

            Chart barChart = new Chart();
            //barChart.Series[0].ChartType = SeriesChartType.Bar;
            barChart.BackColor = Color.Green;
            barChart.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(barChart);

            Chart pieChart = new Chart();
            //pieChart.Series[0].ChartType = SeriesChartType.Pie;
            pieChart.BackColor = Color.Blue;
            pieChart.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(pieChart);

            Chart pointChart = new Chart();
            //pointChart.Series[0].ChartType = SeriesChartType.Point;
            pointChart.BackColor = Color.Yellow;
            pointChart.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(pointChart);
        }
    }
}
