using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JAggregateSheetForm : JBaseForm
    {
        int _GCode;
        int _PCode;

        public JAggregateSheetForm()
        {
            InitializeComponent();
        }

        public JAggregateSheetForm(int GCode,int pCode)
        {
            InitializeComponent();
            _GCode = GCode;
            _PCode = pCode;
        }

        public bool CheckPer()
        {
            if (JPermission.CheckPermission("Estates.JAggregateSheetForm.CheckPer"))
                return true;
            else
                return false;
        }

        private void JAggregateSheetForm_Load(object sender, EventArgs e)
        {
            if (!(CheckPer()))
                Close();
            jdgvAggregateSheet.DataSource = JSheetLog.ListPCodeinGCode(_GCode, _PCode);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           JGroundSheet tmpSheet = new JGroundSheet();
            DataTable dt = (DataTable)jdgvAggregateSheet.DataSource;
            JDataBase db = JGlobal.MainFrame.GetDBO();

            decimal Share = 0;
            decimal Area = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Share = Share + Convert.ToDecimal(dr["Share"]);
                Area = Area + Convert.ToDecimal(dr["Area"]);
            }
            string msg = (" آیا از عملیات تجمیع مطمئن هستید ؟ "+ Area.ToString() + " جمع مساحت " ).ToString();
            if (JMessages.Message(msg, " تجمیع ", JMessageType.Question) != DialogResult.Yes)
                return;
            
            try
            {
                Share = 0;
                Area = 0;
                db.beginTransaction("ConfirmContract");
                foreach (DataRow dr in dt.Rows)
                {
                    tmpSheet.GetData(Convert.ToInt32(dr["Code"]));
                    tmpSheet.DeActive = 1;
                    if (!(tmpSheet.Update(db)))
                    {
                        db.Rollback("ConfirmContract");
                        JMessages.Error(" خطا در تجمیع ", "");
                        return;
                    }
                    Share = Share + Convert.ToDecimal(dr["Share"]);
                    Area = Area + Convert.ToDecimal(dr["Area"]);
                }
                tmpSheet.CreateDate = DateTime.Now;
                tmpSheet.GCode = _GCode;
                tmpSheet.PCode = _PCode;
                tmpSheet.Share = (float)(Share);
                tmpSheet.Area = (float)Area;
                tmpSheet.State = 1;
                tmpSheet.DeActive = 0;
                tmpSheet.Creator = JMainFrame.CurrentPersonCode;
                tmpSheet.Code = tmpSheet.Insert(db);
                if (tmpSheet.Code > 0)
                {
                    JSheetLog tmpJSheetLog = new JSheetLog();
                    tmpJSheetLog.Action = JَActionSheetType.Aggregate.GetHashCode();
                    tmpJSheetLog.CreateDate = DateTime.Now;
                    tmpJSheetLog.Creator = JMainFrame.CurrentPersonCode;
                    tmpJSheetLog.Desc = txtDesc.Text;
                    tmpJSheetLog.SheetCode = tmpSheet.Code;
                    tmpJSheetLog.SheetLogDetails = (DataTable)jdgvAggregateSheet.DataSource;
                    if (tmpJSheetLog.Insert(db) > 0)
                    {
                        if (db.Commit())
                            JMessages.Message(" با موفقیت ثبت شد ", "", JMessageType.Information);
                        else
                        {
                            db.Rollback("ConfirmContract");
                            JMessages.Error(" خطا در تجمیع ", "");
                            return;
                        }
                    }
                    else
                    {
                        db.Rollback("ConfirmContract");
                        JMessages.Error(" خطا در تجمیع ", "");
                        return;
                    }
                }
                else
                {
                    db.Rollback("ConfirmContract");
                    JMessages.Error(" خطا در تجمیع ", "");
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
                tmpSheet.Dispose();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvAggregateSheet.CurrentRow != null)
                {
                    jdgvAggregateSheet.Rows.Remove(jdgvAggregateSheet.CurrentRow);
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
