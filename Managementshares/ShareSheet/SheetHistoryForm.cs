using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JSheetHistoryForm : ClassLibrary.JBaseForm
    {
        public JSheetHistoryForm(DataTable historyTable)
        {
            InitializeComponent();            
            grdHistory.DataSource = historyTable;
            grdHistory.gridEX1.Tables[0].Columns["Operationcode"].Visible = false;
            grdHistory.gridEX1.Tables[0].Columns["SheetType"].Visible = false;
            grdHistory.gridEX1.Tables[0].Columns["InSum"].Visible = false;
            grdHistory.gridEX1.Tables[0].Columns["OutSum"].Visible = false;
            grdHistory.gridEX1.Tables[0].Columns["SumA"].Visible = false;
        }
    }
}
