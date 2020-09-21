using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JShareSheet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GatDate();
        }

        private void GatDate()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;

            //Finance.JAsset jAsset = new Finance.JAsset();
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.SQL =
                @"select ss.code,sp.SharePCode,ss.ShareCount,ss.Az,ss.Ela,case when ss.NumPrint > 0 then N'چاپ شده' else N'چاپ نشده' end isPrint,
                    isnull((select (select Name from clsAllPerson where code=sa.PCode) from ShareAgent sa where code=ss.ACode), N'وکیل ندارد') Vakil
                    from ShareSheet ss 
                    inner join clsPerson cp on ss.PCode=cp.Code 
                    inner join SharePCodeSheet sp on sp.PersonCode=cp.Code
                    where Status=1  and ss.PCode = " + person.Code;

//                    @"Select top 100 percent * from (Select  finAsset.Code,finAsset.ClassName AClassName, (Select ClassNameFa From ClassNames where ClassName = finAsset.ClassName ) AssetType
//	                , finAsset.Comment FinanceComment, finAsset.Value  AssetCost
//	                ,finAssetTransfer.ClassName TClassName ,  (Select ClassNameFa From ClassNames where ClassName = finAssetTransfer.ClassName ) TransferType ,
//	                Case  OwnershipType 
//	                when 1 then N'قطعی'
//	                when 2 then N'سرقفلی'
//	                else '' end OwnershipType
//	                , finAssetTransfer.Comment  TransferComment
//	                , finAssetShare.Share Share , finAssetShare.PersonCode PersonCode
//                    , finAssetTransfer.ObjectCode TransferObjectCode, finAsset.ObjectCode FinanceObjectCode, GroupCode
//	                 from dbo.finAsset 
//	                inner Join  dbo.finAssetTransfer on finAsset.Code = finAssetTransfer.ACode
//	                inner Join  dbo.finAssetShare on finAssetTransfer.Code = finAssetShare.TCode
//                    and finAssetShare.Status = 1	
//	             )A  WHERE 1=1 and PersonCode = " + person.Code;//jAsset.GetSQLAssetPerson(person.Code, false);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "Asset";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).LoadGrid(true);
			
        }
    }
}