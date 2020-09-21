using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class bndEnv : JBaseForm
    {
        public DataRow _DR;
        public int SelectedCode { get; set; }
        public void FillCombo()
        {
            // پر كردن نام مجتمع / بازارها
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = jMarkets.GetDataTable(0);
            int CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
            jMarketFloors Floor = new jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);
            cmbFloor.DataSource = TableFloor;
            cmbFloor.DisplayMember = estMarketFloors.Name.ToString();
            cmbFloor.ValueMember = estMarketFloors.Code.ToString();
            cmbFloor.Text = "";
            // پر كردن عنوان محيط
            

            JDoorBuildings Door = new JDoorBuildings();
            Door.SetComboBox(cmbdoor);
            // پر كردن عنوان محيط
            cmbTypeEnviroment.Items.Clear();
            cmbTypeEnviroment.DataSource = JJoints.GetDataTable(0);
            cmbTypeEnviroment.ValueMember = "Code";
            cmbTypeEnviroment.DisplayMember = "Type";
          
            


           
           
        }
        public bndEnv()
        {
            InitializeComponent();
            FillCombo();
            SelectedCode = 0;
            this.DialogResult = System.Windows.Forms.DialogResult.None;

            
            

        }
        private DataTable  SetData(string Where)
        {
            JDataBase jdb=new JDataBase();
            try
            {
                jdb.setQuery("SELECT     dbo.ReEnviromentTable.Code, dbo.ReEnviromentTable.NameEnviroment, dbo.ReEnviromentTable.Area, dbo.ReEnviromentTable.moneyBase, " +
                        " CASE dbo.ReEnviromentTable.[state] WHEN 0 THEN N'معلق' WHEN 1 THEN N'آماده براي اجاره' WHEN 2 THEN N'در حال اجاره' WHEN 3 THEN N'رزو تا رسيدن زمان مناسب' WHEN 4 THEN N'در دست تعمير'  WHEN 5 THEN  N'در دست تعمير' ELSE '...' END State, dbo.ReJointTable.Type, dbo.estMarketFloors.Name,dbo.subdefine.Name, dbo.subdefine.name AS Door, " +
                         "dbo.ReEnviromentTable.moneyBaseCharge, dbo.ReEnviromentTable.Address " +
   "FROM         dbo.ReEnviromentTable LEFT OUTER JOIN " +
                         "dbo.estMarketFloors ON dbo.ReEnviromentTable.CodeFloor = dbo.estMarketFloors.Code LEFT OUTER JOIN  " +
                         "dbo.ReJointTable ON dbo.ReEnviromentTable.TypeEnviroment = dbo.ReJointTable.Code LEFT OUTER JOIN " +
                         "dbo.subdefine ON dbo.ReEnviromentTable.Door = dbo.subdefine.Code Where dbo.ReEnviromentTable.ISArchive='False' " + Where);
                return jdb.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                jdb.Dispose();
            }
           
        }
        private string BuilQuery()
        {
            try
            {
                string Query = "";
                if (cmbComplex.Text != string.Empty)
                {
                    Query = Query + " And dbo.ReEnviromentTable.Complex=" + cmbComplex.SelectedValue.ToString();
                }
                if (cmbFloor.Text != string.Empty)
                {
                    Query = Query + " And dbo.estMarketFloors.Code=" + cmbFloor.SelectedValue.ToString();
                }
                if (cmbdoor.Text != string.Empty)
                {
                    Query = Query + " And dbo.ReEnviromentTable.Door=" + cmbdoor.SelectedValue.ToString();
                }
                if (cmbTypeEnviroment.Text != string.Empty)
                {
                    Query = Query + " And dbo.ReEnviromentTable.TypeEnviroment=" + cmbTypeEnviroment.SelectedValue.ToString();
                }
                if (cmbState.Text != string.Empty)
                {
                    Query = Query + " And dbo.ReEnviromentTable.[state]=" + cmbState.SelectedIndex.ToString();
                }
                return Query;
            }
            catch
            {
                return "";
            }
        }
        private void JenviromentSerchForm_Load(object sender, EventArgs e)
        {

        }

        private void CmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {

            int CodeMarket = Convert.ToInt32(cmbComplex.SelectedValue);
            jMarketFloors Floor = new jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

            cmbFloor.DataSource = TableFloor;
            cmbFloor.DisplayMember = estMarketFloors.Name.ToString();
            cmbFloor.ValueMember = estMarketFloors.Code.ToString();
            cmbFloor.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComplex.Text!="")
                {
                    DataTable Dt = SetData(BuilQuery());
                    grdContracts.bind(Dt, "sss");
                }
                else
                {
                    JMessages.Error("Select Complex Please", "error");
                    cmbComplex.Focus();
                }
            }
            catch
            {
                
            }
        }
        public void Show(int code)
        {
             JEnviroment Env = new JEnviroment();
             Env.GetData(code);
             Env.ShowForm(code);
        }
       
        private void grdContracts_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            System.Windows.Forms.ContextMenuStrip contextMenuStripContract = new ContextMenuStrip();
            JPopupMenu Popup = new JPopupMenu();
            _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
            BtnSelect.Enabled = true;
             int Code= Convert.ToInt32(_DR["Code"]);
             SelectedCode = Code;
            JAction ac = new JAction("Showform", "RealEstate.bndEnv.Show",new object[] {Code},null);
            Popup.Insert(ac);
            JAction Select = new JAction("Select", "RealEstate.bndEnv.Select");
            Popup.Insert(Select);
            _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
              SelectedCode= Convert.ToInt32(_DR["Code"]);
           
              contextMenuStripContract = Popup.GetPopup();
            contextMenuStripContract.Show(MousePosition);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (SelectedCode != 0)
            {
                this.Close();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
           
        }
    }
}
