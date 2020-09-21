using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estates.Land.Ground.Ground.HistoryOwner
{
    public partial class FormHistoryOwner : ClassLibrary.JBaseForm
    {
        public FormHistoryOwner(int pContractCode, int pPersonCode)
        {
            InitializeComponent();
            DataTable DT = JHistoryOwner.GetPersonHistory(pContractCode, pPersonCode);
            jJanusGrid1.DataSource = DT;
            jJanusGrid1.ActionClassName = "FormHistoryOwner";
        }
    }
}
