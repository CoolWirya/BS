using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JHamkaran
    {
        public bool TransferData(DataTable pDTData)
        {
            if (pDTData == null)
                return false;
            if (pDTData.Rows.Count < 0)
                return false;

            System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
            JConnection conn = new JConnection();
            SqlBuilder = conn.GetSQlServerConnection("ClassLibrary.JHamkaranForm.Accounting", 0);
            JDataBase MyDB = new JDataBase(SqlBuilder);
            try
            {
                int MUnitRef = 0;
                int RqstHdrID = 0;
                int CCCode = 0;
                int ConsumerDLRef = 0;
                int RqstItmID = 0;
                int O;
                if (int.TryParse(pDTData.Rows[0]["محل__مصرف"].ToString(), out O))
                {
                    MyDB.setQuery(@"select CCCode from cac.CostCenter where CostCenterID=" + pDTData.Rows[0]["محل__مصرف"].ToString());
                    CCCode = Convert.ToInt32(MyDB.Query_ExecutSacler());
                    ConsumerDLRef = Convert.ToInt32(pDTData.Rows[0]["محل__مصرف"]);
                }

                MyDB.setQuery(@"select MAX(RqstHdrID)+1 from INV.InvRqstHdr");
                RqstHdrID = Convert.ToInt32(MyDB.Query_ExecutSacler());
                MyDB.setQuery(@"insert into INV.InvRqstHdr values(" + RqstHdrID + ",176,176," + ConsumerDLRef + "," + ConsumerDLRef + "," + pDTData.Rows[0]["FormObject.Date"].ToString().Substring(2, 2) + ",'C'," + pDTData.Rows[0]["Code"].ToString() + ",'" + JDateTime.GregorianDate(pDTData.Rows[0]["FormObject.Date"].ToString()).ToShortDateString() + "',0," + CCCode + ",NULL,NULL,NULL,NULL,NULL)");
                if (MyDB.Query_Execute() < 0)
                    return false;
                int i = 1;
                int Serial = 0;
                foreach (DataRow dr in pDTData.Rows)
                {
                    MyDB.setQuery(@"select MAX(RqstItmID)+1 from INV.InvRqstItm");
                    RqstItmID = Convert.ToInt32(MyDB.Query_ExecutSacler());
                    MyDB.setQuery(@"select MUnitRef from INV.Part where PartCode=" + dr["کالا"].ToString());
                    MUnitRef = Convert.ToInt32(MyDB.Query_ExecutSacler());
                    MyDB.setQuery(@"select Serial from INV.Part where PartCode=" + dr["کالا"].ToString());
                    Serial = Convert.ToInt32(MyDB.Query_ExecutSacler());
                    MyDB.setQuery(@"insert into INV.InvRqstItm values(" + RqstItmID + "," + i + ",NULL," + RqstHdrID + "," + Serial + "," + dr["مقدار"] + ",'CR',NULL," + MUnitRef + ",1,'" + dr["توضیحات"]+ "',NULL,NULL,NULL,NULL)");
                    if (MyDB.Query_Execute() < 0)
                        return false;
                    i++;
                }
                JMessages.Information(" با موفقیت به سیستم همکاران ارسال گردید ", "");
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا در ارسال به سیستم همکاران  ", "");
                return false;
            }
            finally
            {
                MyDB.Dispose();
            }
        }
    }
}
