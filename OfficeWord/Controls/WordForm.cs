using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace OfficeWord
{
    public partial class JWordForm : JBaseForm
    {

        private string ClassName;
        private int ObjectCode;
        private bool ReadOnly;

        public JWordForm(string pClassName, int pObjectCode, bool pReadOnly)
        {
            InitializeComponent();

            ClassName = pClassName;
            ObjectCode = pObjectCode;
            ReadOnly = pReadOnly;

            winWordControl1.GetData(pClassName, pObjectCode);
            winWordControl1.ReadOnly = pReadOnly;
            winWordControl1.LoadDocument();

            JOfficeWord Of = new JOfficeWord();
            DataTable _DT = Of.GetAllChange(ClassName,pObjectCode);

            chkChangeList.Items.Clear();
            foreach(DataRow _DR in _DT.Rows)
            {
                JKeyValue KV = new JKeyValue();
                KV.Value = _DR;
                KV.Key = _DR["LastModify"].ToString();
                chkChangeList.Items.Add(KV);
            }
        }
        public void Load(int pCode)
        {
            winWordControl1.CloseWord();
            winWordControl1.GetData(pCode);
            winWordControl1.ReadOnly = true;
            winWordControl1.LoadDocument();
        }

        public static ClassLibrary.JAction getAction(string pClassName, int pCode, bool pReadOnly)
        {
            return new JAction("WordContract", "OfficeWord.JWordForm.ShowDialog", null, new object[] { pClassName, pCode, pReadOnly });
        }

        private void chkChangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void JWordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            winWordControl1.CloseControl();
        }

        private void chkChangeList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkChangeList.CheckedItems.Count == 1 && e.NewValue == CheckState.Checked)
            {
                int _Code = (int)((chkChangeList.CheckedItems[0] as JKeyValue).Value as DataRow)["Code"];
                Load(_Code);
                winWordControl1.Compare((int)((chkChangeList.Items[e.Index] as JKeyValue).Value as DataRow)["Code"]);

            }
        }

        private void chkChangeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int _Code = (int)((chkChangeList.SelectedItem as JKeyValue).Value as DataRow)["Code"];
            Load(_Code);
        }
    }

}
