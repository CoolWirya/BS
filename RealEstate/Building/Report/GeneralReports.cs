using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ClassLibrary;

namespace RealEstate
{
    public partial class JContractAndUnitBuildReports : Globals.JBaseForm
    {
        public JContractAndUnitBuildReports()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// واحدهای تجاری
        /// </summary>
        private void GetUnits()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vUnitBiulds WHERE " +
                    JPermission.getObjectSql("RealEstate.JUnitBuilds.GetDataTable", "MarketCode"));
                grdUnits.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// واحدهای تجاری با مالکین
        /// </summary>
        private void GetUnitOwners()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vUnitBuildOwners WHERE " +
                    JPermission.getObjectSql("RealEstate.JUnitBuilds.GetDataTable", "MarketCode"));
                grdUnitOwners.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// واحدهای تجاری با اطلاعات قرارداد
        /// </summary>
        private void GetUnitContracts()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vUnitBuildContracts WHERE " +
                    JPermission.getObjectSql("RealEstate.JUnitBuilds.GetDataTable", "MarketCode"));
                grdUnitContract.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// قراردادها
        /// </summary>
        private void GetContracts()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vContracts WHERE " +
                   JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "DTCode"));
                grdContract.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// قراردادها با طرفین
        /// </summary>
        private void GetContractsParties()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vContractPerson WHERE " +
                   JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "DTCode"));
                grdContractParties.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// قراردادها و  واحدهای تجاری
        /// </summary>
        private void GetContractsUnitBuilds()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM vContractUnitBuilds WHERE " +
                   JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "DTCode"));
                grdContractUnit.DataSource = db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        private void tabControlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlUnits.SelectedTab == tabUnits && grdUnits.DataSource == null)
            {
                GetUnits();
            }
            if (tabControlUnits.SelectedTab == tabUnitOwners && grdUnitOwners.DataSource == null)
            {
                GetUnitOwners();
            }
            if (tabControlUnits.SelectedTab == tabUnitContract && grdUnitContract.DataSource == null)
            {
                GetUnitContracts();
            }
        }

        private void tabControlContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlContract.SelectedTab == tabContract && grdContract.DataSource == null)
            {
                GetContracts();
            }
            if (tabControlContract.SelectedTab == tabContractParties && grdContractParties.DataSource == null)
            {
                GetContractsParties();
            }
            if (tabControlContract.SelectedTab == tabContracUnit && grdContractUnit.DataSource == null)
            {
                GetContractsUnitBuilds();
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabUnitBuild)
                tabControlUnits_SelectedIndexChanged(sender, e);
            if (tabControl1.SelectedTab == tabContracts)
                tabControlContract_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdUnits.DataSource = null;
            grdContract.DataSource = null;
            grdContractParties.DataSource = null;
            grdContractUnit.DataSource = null;
            grdUnitContract.DataSource = null;
            grdUnitOwners.DataSource = null;
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void JContractAndUnitBuildReports_Shown(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(sender, e);
        }
    }
}
