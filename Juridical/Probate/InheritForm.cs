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
    public partial class JInheritForm : Globals.JBaseForm
    {
        public int Share;
        public int AllShare;
        public int RelationFamilyCode;
        public string RelationFamilyName;
        public string InherDesc;
        public string InherText
        {
            get
            {
                return Share.ToString() + "/" + AllShare.ToString();
            }
        }
        public JInheritForm(string pHeirName)
        {
            InitializeComponent();
            groupBox1.Text = pHeirName;
            _Fillcombobox();
        }
        public JInheritForm(string pHeirName, int pShare, int pAllShare, int pRelationFamily, string pDesc)
        {
            InitializeComponent();
            groupBox1.Text = pHeirName;
            txtShare.Text = pShare.ToString();
            txtAllShare.Text = pAllShare.ToString();
            _Fillcombobox();
            cmbRelationFamily.SelectedValue = pRelationFamily;
            txtDesc.Text = pDesc;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtShare.IntValue == 0 || txtAllShare.IntValue == 0)
                //{
                //    JMessages.Error("PleaseEnterAllValues", "Error");
                //    txtShare.Focus();
                //    return;
                //}
                if (txtShare.IntValue > txtAllShare.IntValue)
                {
                    JMessages.Error("PleaseEnterValuesCorrectly", "Error");
                    txtShare.Focus();
                    return;
                }
                Share = txtShare.IntValue;
                AllShare = txtAllShare.IntValue;
                RelationFamilyCode = Convert.ToInt32(cmbRelationFamily.SelectedValue);
                RelationFamilyName = cmbRelationFamily.Text;
                InherDesc = txtDesc.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void _Fillcombobox()
        {
            try
            {
                JFamilyRelationTypes JFRT = new JFamilyRelationTypes();
                //JFRT.GetList();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";
                cmbRelationFamily.Items.Clear();
                cmbRelationFamily.Items.Add(nullDeff);
                cmbRelationFamily.SelectedItem = nullDeff;
                JFRT.SetComboBox(cmbRelationFamily);
                //foreach (JSubBaseDefine Relation in JFRT.Items)
                //{
                //    cmbRelationFamily.Items.Add(Relation);
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

            //JCities cities = new JCities();
            //cmbBirthPlace.Items.Clear();
            //cmbBirthPlace.Items.Add(nullDeff);
            //cmbBirthPlace.SelectedItem = nullDeff;
            //foreach (JSubBaseDefine city in cities.Items)
            //{
            //    cmbBirthPlace.Items.Add(city);
            //    if (_Person.BirthplaceCode != 0 && _Person.BirthplaceCode == city.Code)
            //        cmbBirthPlace.SelectedItem = city;
            //}
        }

      
       
    }
}
