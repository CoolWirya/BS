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
    public partial class JAssemblyPresenceForm : Globals.JBaseForm
    {
        int _AssemblyCode;
        public JAssemblyPresenceForm(int AssemblyCode)
        {
            InitializeComponent();
            _AssemblyCode = AssemblyCode;
            LoadAgents();
        }
        private void LoadAgents()
        {
            JAssemblyPresences presences = new JAssemblyPresences(_AssemblyCode);
            jJanusGrid1.DataSource = presences.GetData(0);
        }
        private void AssemblyPresenceForm_Load(object sender, EventArgs e)
        {
            /// جستجو بر اساس کد سهامداری انجام میشود
            personAgent.SearchOnCode = ClassLibrary.SearchOnCode.SharePCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

			JDataBase db = new JDataBase();
			JShareSheet jss = new JShareSheet();
			jss.GetDataByPerson(personAgent.SelectedCode);
			db.setQuery("update ShareSheet set ACode=null where pCode=" + jss.PCode);
			db.Query_Execute();
			
			if (personAgent.SelectedCode > 0)
            {
                JAssemblyPresence presence = new JAssemblyPresence();
                presence.ACode = _AssemblyCode;
                presence.AgentPCode = Convert.ToInt32(personAgent.SelectedCode);
                presence.PresenceTime = DateTime.Now;
                if (!presence.Exists())
                {
                    presence.Insert();
                    LoadAgents();
                }
                else
                {
                    JMessages.Error("این کد قبلا وارد شده است.", "");
                }
            }
            else
            {
                JMessages.Error("لطفاً کد وکیل را وارد کتید.", "");
            }
        }
    }
}
