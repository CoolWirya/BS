using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCard
{
    public partial class JCardsTypeForm : JBaseForm
    {

        private int _Code;

        public JCardsTypeForm(int pCode)
        {
            InitializeComponent();
            cardProperties.ClassName = "SmartCard.JCardsType";
            _Code = pCode;
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            cmbCardType.Items.AddRange(JMainFrame.EnumToListBox(Type.GetType("SmartCard.JCardTypeEnum")));
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            JCardsType CT = new JCardsType();
            if (cmbCardType.SelectedItem != null)
            {
                CT.TypeCode = (int)((JKeyValue)cmbCardType.SelectedItem).Value;
                CT.Code = _Code;
                if (_Code > 0)
                {
                    CT.Update();
                }
                else
                {
                    _Code = CT.Insert();
                }
                cardProperties.AcceptChanges();
                Close();
            }
        }

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _CardType =(int)((JKeyValue)cmbCardType.SelectedItem).Value;
            JCardsType CT = new JCardsType();
            CT.GetDataType(_CardType);

            cardProperties.ObjectCode = _CardType.GetHashCode();

        }

        private void jDefinePropertyUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
