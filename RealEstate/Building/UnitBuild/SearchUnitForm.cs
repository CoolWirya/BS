using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Estates;

namespace RealEstate
{
    public partial class JSearchUnitForm : Globals.JBaseForm
    {
        public int SelectedCode = 0;
        public bool MultiSelect;

        public int[] SelectedCodes = new int[0];

        public JSearchUnitForm()
        {
            InitializeComponent();
            _fillComboBox();
        }
    
        private void _fillComboBox()
        {
            try
            {
                JUnitTypes UnitType = new JUnitTypes();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                cmbType.Items.Clear();
                cmbType.Items.Add(nullDeff);
                cmbType.SelectedItem = nullDeff;
                UnitType.SetComboBox(cmbType);
                //foreach (JSubBaseDefine city in UnitType.Items)
                //{
                //    cmbType.Items.Add(city);
                //}
                DataTable Markets = jMarkets.GetDataTable(0);
                cmbConstructionName.DisplayMember = estMarket.Title.ToString();
                cmbConstructionName.ValueMember = estMarket.Code.ToString();
                cmbConstructionName.DataSource = Markets;
                cmbConstructionName.SelectedItem = null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void cmbConstructionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //نمایش طبقات مجتمع بر اساس مجتمع انتخاب شده
            int CodeMarket = Convert.ToInt32(cmbConstructionName.SelectedValue);
            jMarketFloors Floor = new jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

            cmbFloor.DataSource = TableFloor;
            cmbFloor.DisplayMember = estMarketFloors.Name.ToString();
            cmbFloor.ValueMember = estMarketFloors.Code.ToString();
            cmbFloor.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int unitType = 0;
            if (cmbType.SelectedItem != null)
                unitType = Convert.ToInt32(cmbType.SelectedValue);
            int MarketCode = 0;
            if (cmbConstructionName.SelectedValue != null)
                MarketCode = Convert.ToInt32(cmbConstructionName.SelectedValue);
            int FloorCode = 0;
            if (cmbFloor.SelectedValue != null)
                FloorCode = Convert.ToInt32(cmbFloor.SelectedValue);
            grdUnits.DataSource = JUnitBuilds.Search(0, unitType, MarketCode, txtPlaque.Text,txtNumber.Text, FloorCode );
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (grdUnits.SelectedRows.Count == 0)
                return;
            if (MultiSelect)
            {
                int i = 0;
                foreach (DataGridViewRow row in grdUnits.SelectedRows)
                {
                    Array.Resize(ref SelectedCodes, i + 1);
                    SelectedCodes[i] = (int)row.Cells["Code"].Value;
                    i++;
                }
            }
            else
                SelectedCode = (int)grdUnits.CurrentRow.Cells["Code"].Value;
            DialogResult = DialogResult.OK;
        }

        private void grdUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdUnits.CurrentRow != null)
            {
                int selected = Convert.ToInt32(grdUnits.CurrentRow.Cells["Code"].Value);
                JUnitBuild build = new JUnitBuild(selected);
                build.ShowDialog(selected);
                btnSearch.PerformClick();
            }
        }

        private void JSearchUnitForm_Load(object sender, EventArgs e)
        {

        }

    }
}
