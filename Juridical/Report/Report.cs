using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace Legal
{
    public partial class JReportForm : ClassLibrary.JBaseForm
    {
        public JReportForm()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Contract();
            Promisory();
            //jReport1.ReadControls();
            //string str = jReport1._Where;
            //str = jReport1.getSQL();
            //jReport1._AddToTablesList("asdsa");
        }
        private void Contract()
        {
            jReport1.Fields = @"LegSubjectContract.Type,
                                LegSubjectContract.Number,
                                LegSubjectContract.Date,
                                LegSubjectContract.DateDeliver,
                                LegSubjectContract.StartDate,
                                LegSubjectContract.EndDate,
                                LegSubjectContract.Location,
                                LegSubjectContract.FinanceCode";
            jReport1.ReadControls();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(jReport1.getSQL());
            jdgvContract.DataSource = DB.Query_DataTable();
        }

        private void Promisory()
        {
            jReport1.Fields = @"FinPromissoryNote.Code,
                                FinPromissoryNote.Serial_No,
                                FinPromissoryNote.Create_Date,
                                FinPromissoryNote.Price,
                                FinPromissoryNote.Concern,
                                FinPromissoryNote.ReceiverCode,
                                FinPromissoryNote.ExporterCode";
            jReport1.ReadControls();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(jReport1.getSQL());
            jdgvProm.DataSource = DB.Query_DataTable();
        }
    }
}
