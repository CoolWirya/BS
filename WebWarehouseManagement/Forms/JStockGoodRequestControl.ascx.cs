using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebControllers.MainControls;

namespace WebWarehouseManagement.Forms
{
    public partial class JStockGoodRequestControl : System.Web.UI.UserControl
    {
     
        int Code=0;
        int ReferCode = 0;

        private const string _ConstClassName = "WebWarehouseManagement.JStockGoodRequestControl";
        public string ClassName {get;set;}
        public int ObjectCode { get; set; }

        // برای افزودن کالا توسط کاربر
        private DataTable GoodsData = new DataTable();

        // برای دریافت کالاهای دریافتی از ورودی
        private DataTable GoodsDataTable = new DataTable();

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            #region txtStockCode_Settings
            JJson.JsonResponse txtStockCode_res = new JJson.JsonResponse();
            txtStockCode_res.Type = JJson.JsonResponseType.Item;
            txtStockCode_res.Params = new List<JJson.JsonResponseParam>();
            txtStockCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtStockName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Name" });
            //txtStockCode_res.Params.Add(new JJson.JsonResponseParam() {  ControlToSet = txtStockName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Name" });
            txtStockCode.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtStockCode_res };
            
            JJson.JsonRequest txtStockCode_req = new JJson.JsonRequest();
            txtStockCode_req.URL = "JJsonService/JJsonService.asmx/Run";////GetTitleByCode";
            txtStockCode_req.Type = JJson.JsonRequestType.SQL;
            txtStockCode_req.data = "SELECT Name FROM WarWarehouse  WHERE Code = @code";
            txtStockCode_req.Params = new List<JJson.JsonRequestParam>();
            txtStockCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@code", Type = JJson.JsonAction.Value, ControlID = txtStockCode.ClientID });

            txtStockCode.Request = new List<JJson.JsonRequest>() { txtStockCode_req };
            JJson.JsonResponse txtStockCode_error = new JJson.JsonResponse();
            txtStockCode_error.Params = new List<JJson.JsonResponseParam>();
            txtStockCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            txtStockCode.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtStockCode_error };
            #endregion

            #region txtStockCode_Settings
            JJson.JsonResponse txtGoodCode_res = new JJson.JsonResponse();
            txtGoodCode_res.Type = JJson.JsonResponseType.Item;
            txtGoodCode_res.Params = new List<JJson.JsonResponseParam>();
            txtGoodCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtGoodName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            txtGoodCode.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtGoodCode_res };
            JJson.JsonRequest txtGoodCode_req = new JJson.JsonRequest();
            txtGoodCode_req.URL = "JJsonService/JJsonService.asmx/Run";////GetTitleByCode";
            txtGoodCode_req.Type = JJson.JsonRequestType.SQL;
            txtGoodCode_req.data = "select wg.Description from WarGoods wg inner join WarReceiptOfGoods inner join  WarWarehouse "
                                    + "on WarWarehouse.Code = WarReceiptOfGoods.WarehouseCode "
                                    + "on WarReceiptOfGoods.Code =  wg.Code "
                                    + "where wg.Code = @goodcode and WarWarehouse.Code = @warcode";
            txtGoodCode_req.Params = new List<JJson.JsonRequestParam>();
            txtGoodCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@goodcode", Type = JJson.JsonAction.Value, ControlID = txtGoodCode.ClientID });
            txtGoodCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@warcode", Type = JJson.JsonAction.Value, ControlID = txtStockCode.ClientID });
            txtGoodCode.Request = new List<JJson.JsonRequest>() { txtGoodCode_req };
            JJson.JsonResponse txtGoodCode_error = new JJson.JsonResponse();
            txtGoodCode_error.Params = new List<JJson.JsonResponseParam>();
            txtGoodCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            txtGoodCode.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtGoodCode_error };
            #endregion

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out this.Code);
            this.ClassName =_ConstClassName;
            this.ObjectCode = Convert.ToInt32(Request["ObjectCode"]);
            this.ReferCode =Convert.ToInt32(Request["ReferCode"]);

            if (Request["GoodsDataTable"]!=null)
                ViewState["GoodsDataTable"]= CreateDataTable(Request["GoodsDataTable"]);

            if(!setform() && !this.IsPostBack)
                RadTabStrip1.Tabs[1].Enabled = false;

            RadTabStrip1.SelectedIndex = 0;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }
 
        protected void btnBack_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnReferGood_Click(object sender, EventArgs e)
        {
            try
            {

                WarehouseManagement.Goods.JWarGoodRequest WGR = new WarehouseManagement.Goods.JWarGoodRequest();

                WGR.RequestDate = ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).GetDate();
                WGR.WarCode = Convert.ToInt32(txtStockCode.Text);
                WGR.ClassName = this.ClassName;
                WGR.ObjectCode = this.ObjectCode;
                WGR.UserCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                int result = WGR.Insert();

                if (result > 0)
                { 
                    RadTabStrip1.Tabs[1].Enabled = true;
                    RadTabStrip1.SelectedIndex = 1;
                    RadMultiPage1.SelectedIndex = 1;
                }
            }
            catch
            {
                WebClassLibrary.JWebManager.ShowMessage("لطفا اطلاعات وارد شده رو چک کنید و مجددا سعی نمایید.", WebClassLibrary.MessageType.Error);
            }
        }

        protected void btnAddGoodRequestDetails_Click(object sender, EventArgs e)
        {

            int result = 0;

            WarehouseManagement.Goods.JWarGoodRequestDetails WGRD = new WarehouseManagement.Goods.JWarGoodRequestDetails();

            WGRD.GRCode = Convert.ToInt32(txtStockCode.Text);
            //WGRD.GoodCode = Convert.ToInt32(txtGoodCode.Text);
            WGRD.Count = Convert.ToInt32(txtCount.Text);

            if (WGRD.Insert() > 0)
            {
                btnReferGoodRequestDetails.Enabled = true;
                result = AddToGrid(); // برای نمایش در گرید
               if( result > 0) 
               {
                   WGRD.Count = result;
                   WGRD.Update();
               }
            }
        }


#region "Methods"

        public Boolean setform()
        {
            int WarCode=0;
            int UserCode = 0;
            DateTime RequestDate;
            string[] GoodsCode;
            string[] GoodsCount;

            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select username from users where code=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            lblUser.Text = dt.Rows[0]["username"].ToString();


            if (ViewState["GoodsDataTable"] == null) return false;

            GoodsDataTable = (DataTable)ViewState["GoodsDataTable"];

            WarCode = Convert.ToInt32(GoodsDataTable.Rows[0]["WarCode"]);
            UserCode = Convert.ToInt32(GoodsDataTable.Rows[0]["UserCode"]);
            RequestDate = Convert.ToDateTime(GoodsDataTable.Rows[0]["RequestDate"]);

            dt = WebClassLibrary.JWebDataBase.GetDataTable("select wh.Name, u.username from WarWarehouse wh inner join WarGoodRequest wg inner join users u "
                                                                + " on u.code = wg.UserCode on wg.WarCode = wh.Code where " 
                                                                + " wh.Code=" + WarCode.ToString()
                                                                + "and u.code=" + UserCode.ToString());
            
            
            GoodsCode = GoodsDataTable.Rows[0]["GoodsCode"].ToString().Split(',');
            GoodsCount =  GoodsDataTable.Rows[0]["GoodsCount"].ToString().Split(',');

            //DataTable _dt = new DataTable();
            DataRow dr;
            DataTable gt;

            string columes = "GoodName,GoodCount";
            dt = this.CreateInstanceDataTable(columes.ToString());           

            for (int index = 0; index < GoodsCode.Length; index ++ )
            {
                gt = WebClassLibrary.JWebDataBase.GetDataTable("select * from WarGoods where code=" + GoodsCode[index]);
                dr = dt.NewRow();
                dr["GoodName"] = gt.Rows[0]["Description"];
                dr["GoodCount"] = GoodsCount[index];
                dt.Rows.Add(dr);
            }

            this.grdGoodsOfRequestDetails.DataSource = dt;
            this.grdGoodsOfRequestDetails.DataBind();

            WarehouseManagement.Warehouse.JWarehouse wh = new WarehouseManagement.Warehouse.JWarehouse();
            wh.GetData(WarCode);

            dt = WebClassLibrary.JWebDataBase.GetDataTable("select u.username from users u where u.code= " + UserCode.ToString() );

            this.txtStockCode.Text = WarCode.ToString();
            this.txtStockName.Text = wh.Name;
            this.lblUser.Text = dt.Rows[0]["username"].ToString();

            btnReferGood.Enabled = false;
            btnAddGoodRequestDetails.Enabled = false;
            txtGoodCode.Enabled = false;
            txtGoodName.Enabled = false;
            txtCount.Enabled = false;
            ((WebControllers.MainControls.Date.JDateControl)dteRegisterDate).SetDate(RequestDate);
            //ViewState["GoodsDataTable"] = dt;

            return true;
        }


        public DataTable CreateDataTable(string data)
        {
            string _ClassName;
            int _ObjectCode = 0;
            int WarCode=0;
            int UserCode = 0;
            DateTime RequestDate;
            string GoodsCode;
            string GoodsCount;

            string[] temp;

            temp = data.Split('|');

            _ClassName = temp[0].Split('=')[1];
            _ObjectCode = Convert.ToInt32(temp[1].Split('=')[1]);
            WarCode = Convert.ToInt32(temp[2].Split('=')[1]);
            UserCode =Convert.ToInt32( temp[3].Split('=')[1]);
            RequestDate =Convert.ToDateTime( temp[4].Split('=')[1]);
            GoodsCode =temp[5].Split('=')[1];
            GoodsCount = temp[6].Split('=')[1];

            string Columes = "ClassName,ObjectCode,WarCode,UserCode,RequestDate,GoodsCode,GoodsCount";
            DataTable dt = CreateInstanceDataTable(Columes.Trim());
            DataRow dr;

            dr = dt.NewRow();
            dr["ClassName"] = _ClassName;
            dr["ObjectCode"] = _ObjectCode;
            dr["WarCode"] = WarCode;
            dr["UserCode"] = UserCode;
            dr["RequestDate"] = RequestDate;
            dr["GoodsCode"] = GoodsCode;
            dr["GoodsCount"] = GoodsCount;

            dt.Rows.Add(dr);
            
            return dt;

        }

        private DataTable CreateInstanceDataTable(string Col)
        {
            string[] Columns = Col.Split(',');

            DataTable dt = new DataTable();

            foreach(string d in Columns)
            {
                dt.Columns.Add(d);
            }
            
            return dt;
        }

#endregion


        /// <summary>
        /// جهت نمایش همه کالاهای دخواست شده توسط کاربر جاری، در گرید
        /// و چک می کند در صورت تکراری بودن یک کالا تنها به تعداد آن می افزاید
        /// و تعداد نهایی کالا را برگشت می دهد
        /// </summary>
        private int AddToGrid()
        {

            int Result = 0;

            this.GoodsData = WebClassLibrary.JWebDataBase.GetDataTable("DECLARE @Code INT SET @Code = (SELECT MAX(Code) FROM WarGoodRequestDetails) "
                                                                + "select WarGoods.Description GoodName, WarWarehouse.Name WarName, tb.Count GoodCount from WarGoods inner join (select * from WarGoodRequestDetails where Code = @Code) TB inner join WarWarehouse "
                                                                + "on WarWarehouse.Code = tb.GRCode "
                                                                + "on WarGoods.Code = tb.GoodCode");

            if (ViewState["GoodsData"] == null)
            {
                ViewState.Add("GoodsData", this.GoodsData);
            }
            else
            {
                DataTable tmp = new DataTable();

                tmp = ((DataTable)ViewState["GoodsData"]);
                Boolean flag = false;
                int count = 0;

                for (int row = 0; row < tmp.Rows.Count; row++)
                {
                    if (tmp.Rows[row]["GoodName"].ToString().Trim() == GoodsData.Rows[0]["GoodName"].ToString().Trim()
                        && tmp.Rows[row]["WarName"].ToString().Trim() == GoodsData.Rows[0]["WarName"].ToString().Trim())
                    {
                        count = Convert.ToInt32(tmp.Rows[row]["GoodCount"]);
                        count += (int)GoodsData.Rows[0]["GoodCount"];
                        tmp.Rows[row]["GoodCount"] = count;
                        ViewState["GoodsData"] = tmp;
                        flag = true;
                        // کالا قبلا اضافه شده است تنها تعداد آن بروز می شود
                        Result =count;
                        break;
                    }
                }

                if (!flag)
                    ((DataTable)ViewState["GoodsData"]).Merge(this.GoodsData);
            }

            this.grdGoodsOfRequestDetails.DataSource = (DataTable)ViewState["GoodsData"];
            this.grdGoodsOfRequestDetails.DataBind();

            return Result;
        }

        protected void btnReferGoodRequestDetails_Click(object sender, EventArgs e)
        {

            if(ViewState["GoodsDataTable"]!=null)
            {
                DataTable dt = (DataTable)ViewState["GoodsDataTable"];

                WarehouseManagement.Goods.JWarGoodRequest WGR = new WarehouseManagement.Goods.JWarGoodRequest();

                WGR.ClassName = dt.Rows[0]["ClassName"].ToString();
                WGR.ObjectCode = (int)dt.Rows[0]["ObjectCode"];
                WGR.UserCode = (int)dt.Rows[0]["UserCode"];
                WGR.RequestDate = (DateTime)dt.Rows[0]["RequestDate"];
                WGR.WarCode = (int)dt.Rows[0]["WarCode"];
                
                int result = WGR.Insert();
                if(result > 0)
                {
                    WarehouseManagement.Goods.JWarGoodRequestDetails WGRD = new WarehouseManagement.Goods.JWarGoodRequestDetails();

                    string[] GoodsCode = dt.Rows[0]["GoodsCode"].ToString().Split(',');
                    string[] GoodsCount = dt.Rows[0]["GoodsCount"].ToString().Split(',');

                    for (int index = 0; index < GoodsCode.Length ; index++)
                    {
                        WGRD.GRCode = (int)dt.Rows[0]["WarCode"];
                        //WGRD.GoodCode =Convert.ToInt32( GoodsCode[index]);
                        WGRD.Count = Convert.ToInt32(GoodsCount[index]);
                        WGRD.Insert();
                    }
                }
            }

            WarehouseManagement.Goods.JWarGoodRequestDetailsTable f = new WarehouseManagement.Goods.JWarGoodRequestDetailsTable();

            //DataTable _dt= f.GetDataTable(Convert.ToInt32(txtGoodCode.Text));
            
            WebControllers.Automation.JAutomationRefer.ShowRefer(_ConstClassName, 0, Convert.ToInt32(txtGoodCode.Text)
                , f.GetDataTable(Convert.ToInt32(txtGoodCode.Text)) , ReferCode, "ارجاع نامه درخواست");

        }

    }
}