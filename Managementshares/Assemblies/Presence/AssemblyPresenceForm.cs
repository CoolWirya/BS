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
    public partial class JAssemblyPresenceForm : ClassLibrary.JBaseForm
    {
        int _AssemblyCode;
		int _CompanyCode;
        public JAssemblyPresenceForm(int AssemblyCode, int PCompanyCode)
        {

            InitializeComponent();
			_CompanyCode = PCompanyCode;
            _AssemblyCode = AssemblyCode;
            personAgent.CompanyCode = _CompanyCode;
            LoadAgents();
        }
        private void LoadAgents()
        {
			JAssemblyPresences presences = new JAssemblyPresences(_AssemblyCode, _CompanyCode);
            jJanusGrid1.DataSource = presences.GetData(0, false);
			jJanusGrid1.ShowNavigator = false;
			jJanusGrid1.ShowToolbar = false;
			jJanusGrid1.Columns["ACode"].Visible = false;
			jJanusGrid1.Columns["AgentPCode"].Visible = false;
			jJanusGrid1.Columns["Name"].Width = 300;
		}
        private void AssemblyPresenceForm_Load(object sender, EventArgs e)
        {
            /// جستجو بر اساس کد سهامداری انجام میشود
            personAgent.SearchOnCode = ClassLibrary.SearchOnCode.SharePCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
			JDataBase db = new JDataBase();

			if (personAgent.SelectedCode > 0)
            {
				JAssemblyPresence presence = new JAssemblyPresence(_CompanyCode,"");
                presence.ACode = _AssemblyCode;
                presence.AgentPCode = personAgent.SelectedCode;
                presence.PresenceTime = DateTime.Now;

                ClassLibrary.JAllPerson P = new JAllPerson(presence.AgentPCode);


                //presence.VoteRight = JAssemblyPresences.GetVoteRight(P.SharePCode);

                if (!presence.Exists())
                {
                    presence.Insert();
                    LoadAgents();
                    personAgent.txtExportCode.Text = "";
                    personAgent.txtExportCode.Focus();
                    {
                        try
                        {
                            JShareSheet jss = new JShareSheet();
                            jss.GetDataByPerson(P.Code);
                            db.setQuery("update ShareSheet set ACode=null where pCode=" + jss.PCode+ " and companyCode="+_CompanyCode);
                            db.Query_Execute();
                        }
                        finally
                        {
                            db.Dispose();
                        }
                    }
                    //personAgent.txtExportCode.Focus();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                if (JMessages.Question("آیا میخواهید نماینده مورد نظر از لیست حاضرین حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                {
					int code = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
					JAssemblyPresence presence = new JAssemblyPresence(_CompanyCode,code);
                    if (presence.Delete())
                        LoadAgents();
                }
            }
        }

		private void personAgent_Load(object sender, EventArgs e)
		{

		}
    }
}
