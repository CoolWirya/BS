using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace BusManagment.Fleet
{
    public partial class FleetSearch : Form
    {
        public FleetSearch()
        {
            InitializeComponent();
        }

        private void btnSearchStartDate_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
               string str=txtName.Text;
               DateTime StartDate=DateTime.Parse(DateStart.Text);
               DateTime EndDate = DateTime.Parse(DateEnd.Text);
               DB.setQuery("SELECT * FROM AUTFleet WHERE Name LIKE '%" 
                             + str + "%' OR StartDate LIKE '%" 
                             + StartDate + "%' OR EndDate LIKE '%"
                             + EndDate + "%'");
                jJanusGridResault.DataSource = DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
