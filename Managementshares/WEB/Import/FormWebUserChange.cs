using System;
using System.Data;
using System.Linq;
using ClassLibrary;

namespace ManagementShares
{
    public partial class FormWebUserChange : Globals.JBaseForm
    {

        int _pCode;
        DataTable _dtChange=new DataTable();
        //DataTable _DtWeb;
        //int _Index;
        public FormWebUserChange()
        {
            InitializeComponent();
        }
        private void LoadWebData()
        {
            string filter = " WHERE clsPerson.edited=1 OR FB.edited=1  ";//ORDER BY clsPerson.edited_On DESC
            //if (txtFrom.Text != string.Empty && txtTo.Text != string.Empty)
            //    filter += string.Format(" Limit {0}, {1} ", txtFrom.Text, txtTo.Text);
            jJanusGridWeb.DataSource = tablePersonWeb = JWebUserChanges.GetDataWeb(filter);
        }
        private void FormWebUserChange_Load(object sender, EventArgs e)
        {
            LoadWebData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (jJanusGridWeb.DataSource != null)
                {
                    (jJanusGridWeb.DataSource as DataTable).Clear();
                }
                LoadWebData();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        string[] changeFields = new string[0];
        private void btnApply_Click(object sender, EventArgs e)
        {
           JWebUserChanges.UpdateLocal(updateCommad, _pCode);

            //if (JWebUserChanges.UpdateLocal(tablePersonWeb, tableAddressHWeb, tableAddressWWeb, null, tableAccountWeb, changeFields))
            //    JMessages.Information("تغییرات، با موفقیت اعمال شد.", "");
            //else
            //    JMessages.Error(" انتقال اطلاعات با مشکل مواجه شد.", "خطا");
        }

      
        private void jJanusGridWeb_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.DataRow != null)
                {
                    _pCode = Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row["Code"]);
                    lbName.Text = ((System.Data.DataRowView)(e.Row.DataRow)).Row["Name"].ToString() + " " + ((System.Data.DataRowView)(e.Row.DataRow)).Row["Fam"].ToString();
                    int _Index = e.Row.RowIndex;
                    CreateTable(tablePersonWeb.Rows[_Index], _pCode);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private bool IsExceptField(string FieldName)
        {
            return exceptFields.Select("FieldName=" + JDataBase.Quote(FieldName, false )).Count() > 0;
        }
        private bool CompareValues(string ShareValue, string WebValue)
        {
            if (ShareValue.Trim() == WebValue.Trim())
                return true;
            if (ShareValue.ToLower().Trim() == "null" && WebValue.Trim() == "")
                return true;
            if (ShareValue.Trim() == "" && WebValue.ToLower().Trim() == "null")
                return true;
            if (ShareValue.Trim() == "" && WebValue.Trim() == "")
                return true;
            if (ShareValue.Trim() == "1" && WebValue.Trim() == "True")
                return true;
            if (ShareValue.Trim() == "True" && WebValue.Trim() == "1")
                return true;
            if (ShareValue.Trim() == "0" && WebValue.Trim() == "")
                return true;
            if (ShareValue.Trim() == "" && WebValue.Trim() == "0")
                return true;
            return false;
        }
        private bool CompareFields(DataRow LocalRow, DataRow WebRow, int PCode)
        {
            try
            {
                updateCommad = "";
                if (LocalRow != null && WebRow != null)
                    for (int i = 0; i < LocalRow.Table.Columns.Count; i++)
                        {
                            if (WebRow.Table.Columns.IndexOf(LocalRow.Table.Columns[i].ColumnName) >= 0)
                            {
                                string webValue = WebRow[LocalRow.Table.Columns[i].ColumnName].ToString();
                                string localValue = LocalRow[LocalRow.Table.Columns[i].ColumnName].ToString();
                                string fieldName = LocalRow.Table.Columns[i].ColumnName.ToString();
                                if (!CompareValues(webValue, localValue)) //&& !IsExceptField(fieldName)
                                {
                                    Array.Resize(ref changeFields, changeFields.Length + 1);
                                    changeFields[changeFields.Length - 1] = fieldName;
                                    DataRow dr = _dtChange.NewRow();
                                    dr["NameColumn"] = JLanguages._Text(fieldName);
                                    dr["Saham"] = localValue;
                                    dr["Web"] = webValue;
                                    _dtChange.Rows.Add(dr);
                                    updateCommad += JWebUserChanges.CreateUpdateCommand(fieldName, webValue, PCode);
                                }
                            }
                        }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool CompareFields(DataTable ShareTable, DataTable WebTable)
        {
            try
            {
                if (ShareTable != null && WebTable != null)
                    if (ShareTable.Rows.Count > 0 && WebTable.Rows.Count > 0)
                        for (int i = 0; i < ShareTable.Columns.Count; i++)
                        {
                            if (WebTable.Columns.IndexOf(ShareTable.Columns[i].ColumnName) >= 0)
                            {
                                string webValue = WebTable.Rows[0][ShareTable.Columns[i].ColumnName].ToString();
                                string localValue = ShareTable.Rows[0][ShareTable.Columns[i].ColumnName].ToString();
                                string fieldName = ShareTable.Columns[i].ColumnName.ToString();
                                if (!CompareValues(webValue, localValue) && !IsExceptField(fieldName))
                                {
                                    Array.Resize(ref changeFields, changeFields.Length + 1);
                                    changeFields[changeFields.Length-1] = fieldName;
                                    DataRow dr = _dtChange.NewRow();
                                    //dr["MainNameColumn"] = fieldName;
                                    dr["NameColumn"] = JLanguages._Text(fieldName);
                                    dr["Saham"] = localValue;
                                    dr["Web"] = webValue;
                                    _dtChange.Rows.Add(dr);
                                }
                            }
                        }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        DataTable tablePerson;
        DataTable tablePersonWeb;

        DataTable tableAddressH;
        DataTable tableAddressHWeb;

        DataTable tableAddressW;
        DataTable tableAddressWWeb;

        DataTable tableAccount;
        DataTable tableAccountWeb;

        DataTable exceptFields;
        string updateCommad = "";
        //========= ایجاد جدول تغییرات بین سهام و وب
        private void CreateTable(DataRow CurrenRow,int PCode)
        {
            try
            {
                _dtChange = null;
                _dtChange = new DataTable();
                _dtChange.Columns.Clear();
                //_dtChange.Columns.Add("MainNameColumn");
                _dtChange.Columns.Add("NameColumn");
                _dtChange.Columns.Add("Saham");
                _dtChange.Columns.Add("Web");

                exceptFields = JWebUserChanges.GetExceptField();
                #region Person
                tablePerson = JWebUserChanges.GetDataLocal(" WHERE clsPerson.Code = " + PCode);
                if (tablePerson.Rows.Count > 0)
                {
                    CompareFields(tablePerson.Rows[0], CurrenRow, PCode);
                }
                #endregion Person
                jJanusGridCompare.DataSource = _dtChange;
                jJanusGridCompare.bind(_dtChange, "JanusSearchResturant", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error("خطا در خواندن اطلاعات از وب سایت.", "");
            }
        }
        //private void CreateTable()
        //{
        //    try
        //    {
        //        _dtChange = null;
        //        _dtChange = new DataTable();
        //        _dtChange.Columns.Clear();
        //        //_dtChange.Columns.Add("MainNameColumn");
        //        _dtChange.Columns.Add("NameColumn");
        //        _dtChange.Columns.Add("Saham");
        //        _dtChange.Columns.Add("Web");

        //        exceptFields = JWebUserChanges.GetExceptField();
        //        //JSahamPerson Saham = new JSahamPerson();
        //        //DataTable DtSaham = Saham.GetDataTable(_pCode);
        //        //JWebUserChanges WebC = new JWebUserChanges();
        //        //DataTable DrWeb = _DtWeb;//.Select(" pCode=" + _pCode.ToString()).;
        //        #region Person
        //         tablePerson = JWebUserChanges.GetPerson(_pCode);
        //         tablePersonWeb = JWebUserChanges.GetPersonWeb(_pCode);
        //         CompareFields(tablePerson, tablePersonWeb);
        //        #endregion Person

        //        #region Address Home
        //         tableAddressH= JWebUserChanges.GetPersonAddressH(_pCode);
        //        tableAddressHWeb = JWebUserChanges.GetPersonAddressHWeb(_pCode);

        //        CompareFields(tableAddressH, tableAddressHWeb);
        //        #endregion Address Home

        //        #region Address Work
        //         tableAddressW = JWebUserChanges.GetPersonAddressW(_pCode);
        //        tableAddressWWeb = JWebUserChanges.GetPersonAddressWWeb(_pCode);
        //        CompareFields(tableAddressW, tableAddressWWeb);
 
        //        #endregion Address Work

        //        //#region Properties
        //        //DataTable tableProperties= JWebUserChanges.GetPersonProperties(_pCode);
        //        //DataTable tablePropertiesWeb = JWebUserChanges.GetPersonPropertiesWeb(_pCode);

                
        //        //#endregion Properties

        //        #region Accounts
        //         tableAccount= JWebUserChanges.GetAccounts(_pCode);
        //        tableAccountWeb = JWebUserChanges.GetAccountsWeb(_pCode);
        //        CompareFields(tableAccount, tableAccountWeb);

                 
        //        #endregion Accounts
        //        jJanusGridCompare.DataSource = _dtChange;
        //        jJanusGridCompare.bind(_dtChange, "JanusSearchResturant", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
        //        ////-----رنگی کردن سطرهای تغییر یافته
        //        //for (int i = 0; i < this.jJanusGridCompare.gridEX1.RowCount;i++ )
        //        //{
        //        //    if (((System.Data.DataRowView)(this.jJanusGridCompare.gridEX1.GetRow(i).DataRow)).Row.ItemArray[1].ToString() != ((System.Data.DataRowView)(this.jJanusGridCompare.gridEX1.GetRow(i).DataRow)).Row.ItemArray[2].ToString())
        //        //        this.jJanusGridCompare.gridEX1.GetRow(i).Table.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;// = System.Drawing.SystemColors.GrayText;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //        JMessages.Error("خطا در خواندن اطلاعات از وب سایت.", "");
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prePage_Click(object sender, EventArgs e)
        {
            if (txtFrom.IntValue >= 31)
            {
                txtFrom.Text = (txtFrom.IntValue - 30).ToString();
                txtTo.Text = (txtFrom.IntValue - 30).ToString();
                btnRefresh.PerformClick();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (jJanusGridWeb.DataSource.Rows.Count>=30)
            {
                txtFrom.Text = (txtFrom.IntValue + 30).ToString();
                txtTo.Text = (txtFrom.IntValue + 30).ToString();
                btnRefresh.PerformClick();
            }
        }
 
    }
}
