using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals.Property.PropertyHistory
{
    public partial class JPropertyHistoryViewForm : JBaseForm
    {
        private string _ClassName;
        private int _ObjectCode, _TableObjectCode, _UserCode;
        private DateTime _Date;
        public JPropertyHistoryViewForm(string ClassName, int ObjectCode, int TableObjectCode, int UserCode, DateTime Date)
        {
            InitializeComponent();
            JUser jUser = new JUser(UserCode);
            JPerson jPerson = new JPerson(jUser.PCode);
            lblName.Text = jPerson.Fam + " " + jPerson.Name;
            lblDate.Text = JDateTime.FarsiDate(Date) + " " + Date.Hour.ToString("00") + ":" + Date.Minute.ToString("00") + ":" + Date.Second.ToString("00");
            _ClassName = ClassName;
            _ObjectCode = ObjectCode;
            _TableObjectCode = TableObjectCode;
            _UserCode = UserCode;
            _Date = Date;
            dgrChangeset.DataSource = (new JPropertyHistory()).GetChangesetDetails(_ClassName, _ObjectCode, _TableObjectCode, _UserCode, _Date);
            if (dgrChangeset.DataSource != null) dgrChangeset.Columns[0].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
