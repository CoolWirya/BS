using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Persons
{
    public partial class JclsPersonAddress : System.Web.UI.UserControl
    {
        #region Properties & Fields
        ////______________________________________________________________________________________________________

        public string ClassName
        {
            get
            {
                return hfClassName.Value;
            }
            set
            {
                hfClassName.Value = value;
            }
        }

        public string ObjectCode
        {
            get
            {
                return hfObjectCode.Value;
            }
            set
            {
                hfObjectCode.Value = value;
            }
        }

        public ClassLibrary.JAddressTypes AddressType
        {
            get
            {
                if (hfAddressType.Value != string.Empty)
                {
                    if (hfAddressType.Value == ClassLibrary.JAddressTypes.GasStation.ToString())
                        return ClassLibrary.JAddressTypes.GasStation;
                    if (hfAddressType.Value == ClassLibrary.JAddressTypes.Home.ToString())
                        return ClassLibrary.JAddressTypes.Home;
                    if (hfAddressType.Value == ClassLibrary.JAddressTypes.Work.ToString())
                        return ClassLibrary.JAddressTypes.Work;
                    if (hfAddressType.Value == ClassLibrary.JAddressTypes.None.ToString())
                        return ClassLibrary.JAddressTypes.None;
                }
                return 0;
            }
            set
            {
                hfAddressType.Value = ((ClassLibrary.JAddressTypes)value).ToString();
            }
        }
        ////______________________________________________________________________________________________________
        #endregion Properties & Fields

        #region Global
        ////______________________________________________________________________________________________________
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                    GetData(true);
                //ViewState["FirstVisit"] = false;
            }
        }
        ////______________________________________________________________________________________________________
        #endregion Global

        #region Methods
        ////______________________________________________________________________________________________________
        public string FieldBinding(string FieldName, Object FieldValue)
        {
            switch (FieldName)
            {

            }
            return string.Empty;
        }
        ////______________________________________________________________________________________________________
        private void GetData(bool rebind )
        {
            if (ObjectCode != string.Empty && ClassName != string.Empty)
            {
                ClassLibrary.JProvinces Jpr = new ClassLibrary.JProvinces();
                cmbState.DataSource = Jpr.GetList(ClassLibrary.JBaseDefine.ProvinceCode);
                cmbState.DataBind();

                ClassLibrary.JPersonAddress PersonAddress = new ClassLibrary.JPersonAddress();
                DataTable dt = new DataTable();
                PersonAddress.ObjectCode = int.Parse(ObjectCode);
                PersonAddress.ClassName = ClassName;
                dt = PersonAddress.RetrieveForWeb(int.Parse(ObjectCode), ClassName, AddressType);
                if (dt != null)
                {
                    grvAddrress.DataSource = dt;
                    if (rebind)
                        grvAddrress.DataBind();
                }
            }
            //  JPersonAddress.Dispose();
        }
        ////______________________________________________________________________________________________________
        public void SaveToAddress()
        {
            ClassLibrary.JPersonAddress JPersonAddress = new ClassLibrary.JPersonAddress();
            JPersonAddress.ClassName = ClassName;
            JPersonAddress.ObjectCode = int.Parse(ObjectCode);
            JPersonAddress.Address = txtAddress.Text;
            JPersonAddress.AddressType = AddressType;
            if (!string.IsNullOrEmpty(cmbCity.SelectedValue))
                JPersonAddress.City = int.Parse(cmbCity.SelectedValue);
            if (!string.IsNullOrEmpty(cmbState.SelectedValue))
                JPersonAddress.State = int.Parse(cmbState.SelectedValue);
            JPersonAddress.Email = txtEmail.Text;
            JPersonAddress.Fax = txtFax.Text;
            JPersonAddress.Mobile = txtMobile.Text;
            JPersonAddress.PCode = 0;
            JPersonAddress.PostalCode = txtPostalCode.Text;
            JPersonAddress.Tel = txtTel.Text;
            JPersonAddress.WebSite = txtWebSite.Text;
            hfCode.Value = JPersonAddress.Insert().ToString();
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
            if (hfCode.Value != string.Empty)
            {
                txtAddress.Text = string.Empty;
                cmbCity.SelectedIndex = -1;
                cmbState.SelectedIndex = -1;
                txtEmail.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtPostalCode.Text = string.Empty;
                txtTel.Text = string.Empty;
                txtWebSite.Text = string.Empty;
            }
        }
        ////______________________________________________________________________________________________________
        public void Binding()
        {
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
        }
        ////______________________________________________________________________________________________________
        #endregion Methods

        #region Events
        ////______________________________________________________________________________________________________
        protected void cmbState_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ClassLibrary.JCities Jct = new ClassLibrary.JCities();
            cmbCity.DataSource = Jct.GetList(ClassLibrary.JBaseDefine.CityCode, int.Parse(cmbState.SelectedValue));
            cmbCity.DataBind();
        }
        ////______________________________________________________________________________________________________
        #endregion Events

        #region GridView Events
        ////______________________________________________________________________________________________________
        protected void grvAddrress_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
        }
        ////______________________________________________________________________________________________________
        protected void grvAddrress_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(false);
        }
        ////_______________________________________________________________________________________________________
        protected void grvAddrress_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
        }
        //////______________________________________________________________________________________________________
        //protected void grvAddrress_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)grvAddrress.DataSource;
        //    string TempRowFilter = dt.DefaultView.RowFilter;
        //    dt.DefaultView.RowFilter = " Code =" + grvAddrress.SelectedValues["Code"].ToString();
        //    SelectedRow = new Dictionary<string, object>();
        //    if (dt.DefaultView.Count != 0)
        //        foreach (DataColumn col in (grvAddrress.DataSource as DataTable).Columns)
        //        {
        //            SelectedRow.Add(col.ColumnName, dt.DefaultView[0][col.ColumnName]);
        //        }
        //    dt.DefaultView.RowFilter = TempRowFilter;
        //}
        ////______________________________________________________________________________________________________
        //protected void grvAddrress_PreRender(object sender, EventArgs e)
        //{

        //    if (grvAddrress.DataSource == null) return;
        //    foreach (DataColumn col in (grvAddrress.DataSource as DataTable).Columns)
        //        grvAddrress.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
        //    grvAddrress.MasterTableView.Rebind();

        //}
        ////______________________________________________________________________________________________________

        ////______________________________________________________________________________________________________
        protected void RadComboBox_Page_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        ////______________________________________________________________________________________________________
        protected void grvAddrress_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {

            grvAddrress.CurrentPageIndex = 1;
            ViewState["currentPage"] = 1;
            ViewState["pageSize"] = e.NewPageSize;
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
        }
        ////______________________________________________________________________________________________________
        protected void grvAddrress_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            grvAddrress.SelectedIndexes.Add(e.Item.ItemIndex);
            ClassLibrary.JPersonAddress JPersonAddress = new ClassLibrary.JPersonAddress();
            JPersonAddress.Delete((int)(grvAddrress.SelectedValue));
            grvAddrress.SelectedIndexes.Clear();
            if (!String.IsNullOrEmpty(ObjectCode) && !String.IsNullOrEmpty(ClassName))
                GetData(true);
        }

        protected void grvAddrress_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClassLibrary.JPersonAddress JPersonAddress = new ClassLibrary.JPersonAddress((int)(grvAddrress.SelectedValue));
            txtAddress.Text = JPersonAddress.Address;
            if (JPersonAddress.City.ToString() != "0")
                cmbCity.FindItemByValue(JPersonAddress.City.ToString()).Selected = true;
            if (JPersonAddress.State.ToString() != "0")
                cmbState.FindItemByValue(JPersonAddress.State.ToString()).Selected = true;
            txtEmail.Text = JPersonAddress.Email;
            txtFax.Text = JPersonAddress.Fax;
            //JPersonAddress.FullAddress = txtAddress.Text;
            txtMobile.Text = JPersonAddress.Mobile;
            txtPostalCode.Text = JPersonAddress.PostalCode;
            txtTel.Text = JPersonAddress.Tel;
            txtWebSite.Text = JPersonAddress.WebSite;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveToAddress();
        }

        protected void grvAddrress_SelectedCellChanged(object sender, EventArgs e)
        {

        }



        protected void grvAddrress_PreRender(object sender, EventArgs e)
        {
            foreach (Telerik.Web.UI.GridColumn colum in grvAddrress.Columns)
            {
                colum.HeaderText = ClassLibrary.JLanguages._Text(colum.UniqueName);
            }
        }


        ////______________________________________________________________________________________________________
        #endregion GridView Events
    }
}