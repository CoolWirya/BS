using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;

namespace Estates
{
    public partial class JChangeSahmForm : JBaseForm
    {
        int _SheetCode;
        int _GCode;
        int _PersonCode;

        public JChangeSahmForm()
        {
            InitializeComponent();
        }

        public JChangeSahmForm(int pSheetCode)
        {
            InitializeComponent();
            _SheetCode = pSheetCode;            
        }

        public JChangeSahmForm(int pSheetCode, int pGCode, int pPersonCode)
        {
            InitializeComponent();
            _SheetCode = pSheetCode;
            _GCode = pGCode;
            _PersonCode = pPersonCode;
        }

        public bool CheckPer()
        {
            if (JPermission.CheckPermission("Estates.JChangeSahmForm.CheckPer"))
                return true;
            else
                return false;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!(CheckPer()))
                return;
            if (Convert.ToDouble(lblM.Text) < Convert.ToDouble(txtM.Text))
            {
                JMessages.Error(" متراژ ورودی بزرگتر از متراژ کل است ", "");
                return;
            }
            DataTable dt = (DataTable)jDataGrid1.DataSource;
            DataRow dr = dt.NewRow();
            dr["Share"] = txtM.Text;
            dt.Rows.Add(dr);
            jDataGrid1.DataSource = dt;
            //Fill();
            lblM.Text = (Convert.ToDouble(lblM.Text) - Convert.ToDouble(txtM.Text)).ToString();
        }

        private void JChangeSahmForm_Load(object sender, EventArgs e)
        {
            JGroundSheet tmpSheet = new JGroundSheet(_SheetCode);
            lblM.Text = tmpSheet.Area.ToString();
            lblS.Text = tmpSheet.Share.ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("SheetCodeDetails");
            dt.Columns.Add("Share");
            jDataGrid1.DataSource = dt;
        }

        //private void Fill()
        //{
        //    JDataBase db = new JDataBase();
        //    try
        //    {
        //        db.setQuery("Select *,Code SheetCodeDetails From estSheet Where Code <> " + _SheetCode + " And GCode= " + _GCode + " And PCode=" + _PersonCode);
        //        jDataGrid1.DataSource = db.Query_DataTable();
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            JDataBase db = new JDataBase();
            //string Query = @"
//declare @Share float
//declare @Area float
//declare @SheetCodeNew int 
//declare @SheetCode int 

//Select @Share
//Select @Area=" + txtM.Text + @"
//Select @SheetCode=" + _SheetCode + @"

//Select @Share =((Select Share From estSheet Where Code=@SheetCode) *@Area) /(Select Area From estSheet Where Code=@SheetCode)

//Select @SheetCodeNew = (select MAX(Code) from estSheet)+1
//insert into estSheet
//select @SheetCodeNew,GCode,PCode,ContractCodeSell,ContractCodeBuy,@Area,CreateDate,DeliveryDate,Creator,NumPrint,State,DeActive,Parent,@Share
// from estSheet Where Code=@SheetCode
//update estSheet set Area=Area-@Area,Share=Share-@Share where Code=@SheetCode 
//Select @SheetCodeNew";
            try
            {
                //db.setQuery(Query);
                //int SheetCodeNew = (int)(db.Query_ExecutSacler());

                DataTable dt = (DataTable)jDataGrid1.DataSource;
                JGroundSheet tmpJGroundSheet = new JGroundSheet();
                float AreaTotal = 0;
                float ShareTotal = 0;
                tmpJGroundSheet.GetData(_SheetCode);
                db.beginTransaction("ConfirmContract");
                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    AreaTotal = tmpJGroundSheet.Area;
                    ShareTotal = tmpJGroundSheet.Share;
                    tmpJGroundSheet.Share = tmpJGroundSheet.Share * ((float)Convert.ToDouble(dt.Rows[i]["Share"])) / AreaTotal;
                    tmpJGroundSheet.Area = (float)Convert.ToDouble(dt.Rows[i]["Share"]);
                    tmpJGroundSheet.Code = tmpJGroundSheet.Insert(db);
                    if (tmpJGroundSheet.Code > 0)
                    {
                        dt.Rows[i]["SheetCodeDetails"] = tmpJGroundSheet.Code;
                        tmpJGroundSheet.Share = ShareTotal - tmpJGroundSheet.Share;
                        tmpJGroundSheet.Area = AreaTotal - (float)Convert.ToDouble(dt.Rows[i]["Share"]);
                        tmpJGroundSheet.Code = _SheetCode;
                        if (!(tmpJGroundSheet.Update(db)))
                        {
                            db.Rollback("ConfirmContract");
                            JMessages.Error(" خطا در تفکیک ", "");
                            return;
                        }
                    }
                    else
                    {
                        db.Rollback("ConfirmContract");
                        JMessages.Error(" خطا در تفکیک ", "");
                        return;
                    }                    
                }

                JSheetLog tmpJSheetLog = new JSheetLog();
                tmpJSheetLog.Action = JَActionSheetType.BreakDown.GetHashCode();
                tmpJSheetLog.CreateDate = DateTime.Now;
                tmpJSheetLog.Creator = JMainFrame.CurrentPersonCode;
                tmpJSheetLog.Desc = txtDesc.Text;
                tmpJSheetLog.SheetCode = _SheetCode;
                tmpJSheetLog.SheetLogDetails = dt;
                int SheetCodeNew = tmpJSheetLog.Insert(db);
                if (SheetCodeNew < 0)
                {
                    db.Rollback("ConfirmContract");
                    JMessages.Error(" خطا در تفکیک ", "");
                    return;
                }

                if (db.Commit())
                    JMessages.Message(" با موفقیت ثبت شد ", "", JMessageType.Information);
                else
                {
                    db.Rollback("ConfirmContract");
                    JMessages.Error(" خطا در تفکیک ", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("ConfirmContract");
                JMessages.Error(" خطا در تفکیک ", "");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jDataGrid1.CurrentRow != null)
                {
                    jDataGrid1.Rows.Remove(jDataGrid1.CurrentRow);
                    lblM.Text = (Convert.ToDouble(lblM.Text) - Convert.ToDouble(jDataGrid1.CurrentRow.Cells["Share"].Value)).ToString();
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
