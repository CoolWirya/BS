using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Finance;


namespace Legal
{
    public partial class FrmGetContract : JBaseForm
    {
        /// <summary>
        ///شخص انتخاب شده را باز مي گرداند
        /// </summary>
        public JAllPerson Person;


        /// <summary>
        ///اطلاعات اموال را باز مي گرداند
        /// </summary>
        public JAsset Asset;

        /// <summary>
        ///قرارداد انتخاب شده را بر مي گرداند
        /// </summary>
        public JSubjectContract Contract;
        /// <summary>
        ///اطلاعات انتخاب شده را به صورت جدول باز مي گرداند
        /// </summary>
        public DataTable DtSelect;
        /// <summary>
        ///ركورد انتخاب شده را برمي گرداند
        /// </summary>
        public DataRow DrSelect;
        /// <summary>
        ///اگر كاربر دكمه انتخاب را زده باشد فرم بايد مقدار باز گرداند
        /// </summary>
        public Boolean UserSelect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContract = new ContextMenuStrip();
        private JPopupMenu Popup = new JPopupMenu();
        private DataTable DtResult;


        public FrmGetContract()
        {
            SetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string svalue = "RealEstate.JUnitBuild";
                if (rdaestate.Checked == true) svalue = "RealEstate.JUnitBuild";
                if (rdamosh.Checked == true) svalue = "RealEstate.JEnviroment";

                switch (svalue)
                {
                    case "RealEstate.JUnitBuild":
                        RealEstate.JSearchUnitForm frmSearchUnitBuild = new RealEstate.JSearchUnitForm();
                        label1.Text = "شماره جديد :";
                        if (frmSearchUnitBuild.ShowDialog() == DialogResult.OK)
                        {
                            Asset = new Finance.JAsset("RealEstate.JUnitBuild", frmSearchUnitBuild.SelectedCode);
                            txtBuild.Text = Asset.Comment;
                        }
                        else
                        {
                            Asset = null;
                            txtBuild.Text = "";
                        }
                        break;
                    case "RealEstate.JEnviroment":
                        RealEstate.JEnviroment Enviroment = new RealEstate.JEnviroment();
                        label1.Text = "نام مشاع :";
                        RealEstate.bndEnv EnvSer = new RealEstate.bndEnv();
                        if (EnvSer.ShowDialog() == DialogResult.OK)
                        {
                            Asset = new Finance.JAsset();
                            Asset.GetData("RealEstate.JEnviroment", EnvSer.SelectedCode);
                            txtBuild.Text = Asset.Comment;
                        }
                        else
                        {
                            Asset = null;
                            txtBuild.Text = "";
                        }
                        break;

                }
            }
            catch
            {
                JMessages.Information("نوع قرارداد نا مشخص است", "هشدار");

            }

        }

        private void PersonSearch_Click(object sender, EventArgs e)
        {
            //Financ
            ClassLibrary.JFindPersonForm searchPerson = new JFindPersonForm(JPersonTypes.None);
            if (searchPerson.ShowDialog() == DialogResult.OK)
            {
                /// انتخاب یکی
                Person = searchPerson.SelectedPerson;
                txtPerson.Text = Person.Name;
            }
            else
            {
                Person = null;
                txtPerson.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = 0;
            string Query = CreateQuery();
            if (RetriveData(Query))
            {
                //ShowData(DtSelect.Rows[0]);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.UserSelect = true;
            this.Close();
        }

        private void grdContracts_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                btnSelect.Enabled = true;
                Popup.ClearItems();

                JAction viewLetter;

                if (e.Row.DataRow != null)
                {
                    DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
                    FillData(_DR);
                }

                contextMenuStripContract = Popup.GetPopup();
                contextMenuStripContract.Show(MousePosition);
            }
            catch
            {
            }
        }

        private void FillData(DataRow _DR)
        {
            ShowData(_DR);
            JAction personAction = new JAction();
            Person = new JAllPerson(Convert.ToInt32(_DR["PersonCode"]));
            if (Person.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { Person.Code });
            else if (Person.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", null, new object[] { Person.Code });

            Popup.Insert(personAction);

            this.Contract = new JSubjectContract(Convert.ToInt32(_DR["Code"]));
            Legal.JContractdefine contractDefine = new Legal.JContractdefine(Contract.Type);
            JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, Convert.ToInt32(_DR["Code"]), false });
            Popup.Insert(viewContract);

            Asset = new Finance.JAsset(Convert.ToInt32(_DR["FinanceCode"]));
            switch (Asset.ClassName)
            {
                case "RealEstate.JUnitBuild":
                    JAction AssetShow = new JAction("Asset", "RealEstate.JUnitBuild.ShowDialog", new object[] { Asset.ObjectCode }, null);
                    Popup.Insert(AssetShow);
                    break;
                case "RealEstate.JEnviroment":
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            try
            {
                DtSelect = new DataTable();
                DrSelect = null;
                Contract = new Legal.JSubjectContract();
                grdContracts.bind(DtSelect, "ContractShow");
                Person = null;
                Asset = null;
                txtBuild.Text = "";

                txtPerson.Text = "";

                txtDatein.Text = "";
                TxtDateout.Text = "";
                btnSelect.Enabled = false;
            }
            catch
            {

            }
        }


        private string CreateQuery()
        {
            string Str = " Where (0=0) ";


            if (Asset != null)
            {
                Str = Str + " And " + "SC.FinanceCode=" + Asset.Code.ToString();

            }
            if (Person != null)
            {
                Str = Str + " And PersonCode=" + Person.Code.ToString();
            }

            if (txtDatein.Date.Year != 1 && txtDatein1.Date.Year != 1)
            {
                Str = Str + " And " + "(SC.StartDate>='" + txtDatein.Date.ToString("yyyy/MM/dd") + "'" + " And " + "SC.StartDate<='" + txtDatein1.Date.ToString("yyyy/MM/dd") + "')";
            }
            else
            {
                if (txtDatein.Date.Year != 1)
                {
                    Str = Str + " And " + "SC.StartDate>='" + txtDatein.Date.ToString("yyyy/MM/dd") + "'";
                }
                if (txtDatein1.Date.Year != 1)
                {
                    Str = Str + " And " + "SC.StartDate>='" + txtDatein1.Date.ToString("yyyy/MM/dd") + "'";
                }
            }
            if (TxtDateout.Date.Year != 1 && TxtDateout1.Date.Year != 1)
            {
                Str = Str + " And " + "(SC.EndDate>='" + TxtDateout.Date.ToString("yyyy/MM/dd") + "'" + " And " + "SC.EndDate<='" + TxtDateout1.Date.ToString("yyyy/MM/dd") + "')";
            }

            else
            {
                if (TxtDateout.Date.Year != 1)
                {
                    Str = Str + " And " + "SC.EndDate<='" + TxtDateout.Date.ToString("yyyy/MM/dd") + "'";
                }
                if (TxtDateout1.Date.Year != 1)
                {
                    Str = Str + " And " + "SC.EndDate<='" + TxtDateout1.Date.ToString("yyyy/MM/dd") + "'";
                }
            }

            if (txtDateDS.Date.Year != 1)
            {
                Str = Str + " And " + "SC.Date>='" + txtDateDS.Date.ToString("yyyy/MM/dd") + "'";
            }
            if (txtDateDE.Date.Year != 1)
            {
                Str = Str + " And " + "SC.Date<='" + txtDateDE.Date.ToString("yyyy/MM/dd") + "'";
            }

            //if (CmbTypeGh.Text != "")
            //{
            //    Str = Str + " And Dt.Code='" + CmbTypeGh.SelectedValue.ToString() + "'";
            //}

            if (chklistContracts.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistContracts.Items.Count; i++)
                    if (chklistContracts.GetItemChecked(i))
                        CodeGH = CodeGH + "'" + ((ClassLibrary.JKeyValue)(chklistContracts.Items[i])).Value.ToString() + "',";
                if (CodeGH != "")
                    Str = Str + " And DT.AssetTransferType in (" + CodeGH + "'0')";
                //Str = Str + " And Dt.Code in (" + CodeGH  + "'0')";                
            }

            if (chklistMarkets.CheckedItems.Count > 0)
            {
                string CodeM = "";
                for (int i = 0; i < chklistMarkets.Items.Count; i++)
                    if (chklistMarkets.GetItemChecked(i))
                        CodeM = CodeM + ((ClassLibrary.JKeyValue)(chklistMarkets.Items[i])).Value.ToString() + ",";
                if (CodeM != "")
                    Str = Str + " And dbo.estUnitBuild.MarketCode in (" + CodeM + "0)";
            }

            if (chklistContractType.CheckedItems.Count > 0)
            {
                string CodeM = "";
                for (int i = 0; i < chklistContractType.Items.Count; i++)
                    if (chklistContractType.GetItemChecked(i))
                        CodeM = CodeM + ((ClassLibrary.JKeyValue)(chklistContractType.Items[i])).Value.ToString() + ",";
                if (CodeM != "")
                    Str = Str + " And DT.Code in (" + CodeM + "0)";
            }

            if (ChkActive.Checked == true)
            {
                Str = Str + " And  SC.Status=1";
            }



            return Str;
        }
        public void ShowData(DataRow _DrSelect)
        {
            try
            {
                DrSelect = _DrSelect;
                Contract = new Legal.JSubjectContract(Convert.ToInt32(_DrSelect["Code"]));

                txtBuild.Text = _DrSelect["Asset"].ToString();

                txtPerson.Text = _DrSelect["Tarfin"].ToString();


            }
            catch
            {
            }
        }

        private void SetForm()
        {
            InitializeComponent();
            FillCombo();
            //Contract = new JSubjectContract();
            //Asset = new JAsset();
            //Person = new JAllPerson();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        private Boolean RetriveData(string Where)
        {
            try
            {
                DtSelect = jcontractpersonsearch.QueryAssetPerson(Where, chkAsset.Checked, chkPerson.Checked, chkpersonliner.Checked);
                grdContracts.bind(DtSelect, "ContractShow");
                if (DtSelect != null && DtSelect.Rows.Count > 0)
                {
                    string[] strHide = new string[] { "CodePerson", "FinanceCode", "Code" };
                    grdContracts.HidColumns(strHide);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public FrmGetContract(int ContratcCode, int PersonCode)
        {
            SetForm();
            if (RetriveData("Where SC.Code=" + ContratcCode.ToString() + " And PersonCode=" + PersonCode.ToString()))
            {
                ShowData(DtSelect.Rows[0]);
                FillData(DtSelect.Rows[0]);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        public FrmGetContract(int ContratcCode)
        {
            SetForm();
            string Str = "Where SC.Code=" + ContratcCode.ToString();

            this.DialogResult = System.Windows.Forms.DialogResult.None;


            if (RetriveData(Str))
            {
                ShowData(DtSelect.Rows[0]);
                FillData(DtSelect.Rows[0]);
            }
        }

        private void FillCombo()
        {
            try
            {


                DataTable _dtContractType = new DataTable();
                _dtContractType.Columns.Add("Code");
                _dtContractType.Columns.Add("Title");
                _dtContractType.Rows.Add(1, "قطعی");
                _dtContractType.Rows.Add(2, "سرقفلی");
                _dtContractType.Rows.Add(4, "صلح سرقفلی");
                _dtContractType.Rows.Add(3, "اجاره");
                _dtContractType.Rows.Add(99, "سایر");

                JKeyValue[] L = new JKeyValue[_dtContractType.Rows.Count];
                int count = 0;
                foreach (DataRow dr in _dtContractType.Rows)//JContractDynamicTypes.GetDataTable(0).Rows
                {
                    L[count] = new JKeyValue();
                    L[count].Key = dr["Title"].ToString();
                    L[count].Value = dr["Code"];
                    count++;
                }
                chklistContracts.Items.AddRange(L);

                DataTable tmpdt = RealEstate.jMarkets.GetDataTable(0);
                JKeyValue[] M = new JKeyValue[tmpdt.Rows.Count];
                count = 0;
                foreach (DataRow dr in tmpdt.Rows)
                {
                    M[count] = new JKeyValue();
                    M[count].Key = dr["Title"].ToString();
                    M[count].Value = dr["Code"];
                    count++;
                }
                chklistMarkets.Items.AddRange(M);

                chklistContractType.Items.Clear();
                DataTable tmpdt1 = Legal.JContractDynamicTypes.GetDataTable();
                JKeyValue[] M1 = new JKeyValue[tmpdt1.Rows.Count];
                count = 0;
                foreach (DataRow dr in tmpdt1.Rows)
                {
                    M1[count] = new JKeyValue();
                    M1[count].Key = dr["Title"].ToString();
                    M1[count].Value = dr["Code"];
                    count++;
                }
                chklistContractType.Items.AddRange(M1);
            }
            catch
            {
            }
        }

        private void FrmContractPerson_Load(object sender, EventArgs e)
        {

        }

        private void chklistContracts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkpersonliner_CheckedChanged(object sender, EventArgs e)
        {
            chkPerson.Checked = !chkpersonliner.Checked;
            PersonSearch.Enabled = chkPerson.Checked;
        }

        private void chkAsset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i, j = 0;
                string UnitbuildList = "";
                string MarketList = "";
                for (i = 0; i < grdContracts.gridEX1.RowCount; i++)
                {
                    if (grdContracts.gridEX1.GetRow(i).Cells["plaque"].Value != null)
                        UnitbuildList = UnitbuildList + ",'" + grdContracts.gridEX1.GetRow(i).Cells["plaque"].Value.ToString() + "'";
                }
                string CodeM = "";
                for (j = 0; j < chklistMarkets.Items.Count; j++)
                    if (chklistMarkets.GetItemChecked(j))
                        MarketList = ",'" + MarketList + ((ClassLibrary.JKeyValue)(chklistMarkets.Items[j])).Value.ToString() + "'";
                grdContracts.bind(jcontractpersonsearch.GetActivePerson(UnitbuildList, MarketList));
            }
            catch
            {
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
