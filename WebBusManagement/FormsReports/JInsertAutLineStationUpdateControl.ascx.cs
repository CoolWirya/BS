using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JInsertAutLineStationUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            DataTable dts = WebClassLibrary.JWebDataBase.GetDataTable(@"select distinct ats.Code as TCode,ei.f10,ei.f11,ei.f12 from Erp_TabrizBus9205.dbo.AUTStation ats
                left join [ERP_Temp].[dbo].[eistgah] ei
                on ats.lat = ei.f9
                and ats.lng = ei.f8
                --collate SQL_Latin1_General_CP1_CI_AS;
                where ei.f10 is not null or ei.f11 is not null or ei.f12 is not null");
            int Code, LineCode1, LineCode2, LineCode3, StationCode, IsBack1 = 0, IsBack2 = 0, IsBack3 = 0;
            Code = 1;
            DataTable dtl1 = null, dtl2 = null, dtl3 = null;
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                StationCode = Convert.ToInt32(dts.Rows[i]["TCode"].ToString());
                if (dts.Rows[i]["f10"].ToString().Length > 0)
                    dtl1 = WebClassLibrary.JWebDataBase.GetDataTable(@"select code from autline where linenumber = " + dts.Rows[i]["f10"].ToString().Substring(0, 3));
                if (dts.Rows[i]["f11"].ToString().Length > 0)
                    dtl2 = WebClassLibrary.JWebDataBase.GetDataTable(@"select code from autline where linenumber = " + dts.Rows[i]["f11"].ToString().Substring(0, 3));
                if (dts.Rows[i]["f12"].ToString().Length > 0)
                    dtl3 = WebClassLibrary.JWebDataBase.GetDataTable(@"select code from autline where linenumber = " + dts.Rows[i]["f12"].ToString().Substring(0, 3));
                if (dtl1 != null && dtl1.Rows.Count > 0)
                {
                    LineCode1 = Convert.ToInt32(dtl1.Rows[0][0].ToString());
                    if (dts.Rows[i]["f10"].ToString().EndsWith("1"))
                        IsBack1 = 0;
                    else
                        IsBack1 = 1;
                    //db = null;
                    db.setQuery(@"INSERT INTO [dbo].[AUTLineStation]
                                   ([Code]
                                   ,[LineCode]
                                   ,[StationCode]
                                   ,[IsBack]
                                   ,[Priority])
                             VALUES
                                   (isnull((select max(code)+1 from AUTLineStation),1)
                                   ," + LineCode1 + @"
                                   ," + StationCode + @"
                                   ," + IsBack1 + @"
                                   ,1)");
                    db.Query_ExecutSacler();
                }
                if (dtl2 != null && dtl2.Rows.Count > 0)
                {
                    LineCode2 = Convert.ToInt32(dtl2.Rows[0][0].ToString());
                    if (dts.Rows[i]["f11"].ToString().EndsWith("1"))
                        IsBack2 = 0;
                    else
                        IsBack2 = 1;
                    //db = null;
                    db.setQuery(@"INSERT INTO [dbo].[AUTLineStation]
                                   ([Code]
                                   ,[LineCode]
                                   ,[StationCode]
                                   ,[IsBack]
                                   ,[Priority])
                             VALUES
                                   (isnull((select max(code)+1 from AUTLineStation),1)
                                   ," + LineCode2 + @"
                                   ," + StationCode + @"
                                   ," + IsBack2 + @"
                                   ,1)");
                    db.Query_ExecutSacler();
                }
                if (dtl3 != null && dtl3.Rows.Count > 0)
                {
                    LineCode3 = Convert.ToInt32(dtl3.Rows[0][0].ToString());
                    if (dts.Rows[i]["f12"].ToString().EndsWith("1"))
                        IsBack3 = 0;
                    else
                        IsBack3 = 1;
                    //db = null;
                    db.setQuery(@"INSERT INTO [dbo].[AUTLineStation]
                                   ([Code]
                                   ,[LineCode]
                                   ,[StationCode]
                                   ,[IsBack]
                                   ,[Priority])
                             VALUES
                                   (isnull((select max(code)+1 from AUTLineStation),1)
                                   ," + LineCode3 + @"
                                   ," + StationCode + @"
                                   ," + IsBack3 + @"
                                   ,1)");
                    db.Query_ExecutSacler();
                }

                Code++;
            }
        }
    }
}