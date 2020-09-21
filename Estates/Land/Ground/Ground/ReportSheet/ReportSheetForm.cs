using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public partial class ReportSheetForm : JBaseForm
    {
        public ReportSheetForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            jdgvSearch.DataSource = Report();
        }

        public DataTable Report()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " where 1=1 ";
            if (txtSDate.Date != DateTime.MinValue)
            {
                Where = Where + @" And ContractCodeBuy in (select Code from LegSubjectContract 
where [Date] >= '" + txtSDate.Date.ToString("yyyy/MM/dd").ToString() + "')";

//                Where = Where + @" And ContractCodeBuy in (select Code from LegSubjectContract 
//where (select FA_date from StaticDates where En_Date=StartDate) >= '" + txtSDate.Date.ToString("yyyy/MM/dd").ToString() + @"')
//or 
//ContractCodeSell in (select Code from LegSubjectContract 
//where (select FA_date from StaticDates where En_Date=StartDate) >= '" + txtSDate.Date.ToString("yyyy/MM/dd").ToString() + "')";
            }
            if (txtEDate.Date != DateTime.MinValue)
            {
                Where = Where + @"And 
ContractCodeBuy in (select Code from LegSubjectContract where [Date] <= '" + txtEDate.Date.ToString("yyyy/MM/dd").ToString() + "')";

//                Where = Where + @" And ContractCodeBuy in (select Code from LegSubjectContract 
//where (select FA_date from StaticDates where En_Date=EndDate) <= '" + txtEDate.Date.ToString("yyyy/MM/dd").ToString() + @"')
//or 
//ContractCodeSell in (select Code from LegSubjectContract 
//where (select FA_date from StaticDates where En_Date=EndDate) <= '" + txtEDate.Date.ToString("yyyy/MM/dd").ToString() + "')";
            }

            string Qouery = @"select 
Code ,
(Select BlockNum from estGround where Code=GCode) BlockNum,
(Select PartNum from estGround where Code=GCode) PartNum,
(Select Area from estGround where Code=GCode)AreaKol,
(Select (select Name from estUsageGround where Code=Usage) from estGround where Code=GCode) Usage,
PCode,
Area,
(select Name from clsAllPerson where Code=
(Select top 1 PersonCode from LegPersonContract where ContractSubjectCode=ContractCodeBuy And [TYPE]=7)) seller,
(select Name from clsAllPerson where Code=
(Select top 1 PersonCode from LegPersonContract where ContractSubjectCode=ContractCodeBuy And [TYPE]=9)) Buyer,
(select FA_date from StaticDates where En_Date=CreateDate) CreateDate

from estSheet ";
            try
            {
                Db.setQuery(Qouery + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
