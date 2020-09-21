using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JEPersonPostForm : JBaseForm
    {

        JEPersonPosts JEPP;
        public JEPersonPostForm()
        {
            InitializeComponent();
            JEPP = new JEPersonPosts();
            FillCombo();

        }

        public JEPersonPostForm(int pPCode)
        {
            InitializeComponent();
            JEPP = new JEPersonPosts(pPCode);
            FillCombo();
            SetForm();

            #region OldCode
            //JSubBaseDefines states = new JSubBaseDefines(JBaseDefine.States);
            //cmbPostsFree.DisplayMember = "title";
            //cmbPostsFree.ValueMember = "Code";
            //cmbPostsFree.DataSource = JEPosts.GetFreePosts();
            //_pCode = pPCode;
            //_setPerson(pPCode);
            #endregion
        }

        public void SetForm()
        {
            JAllPerson Newp = new JAllPerson(JEPP.PersonCode);
            txtName.Text = Newp.Name;
            txtPCode.Text = Convert.ToString(JEPP.PersonCode);
            btnSelectPerson.Enabled = false;
            
        }
        private void FillCombo()
        {
            JEPosts JEPs = new JEPosts();
            JEPost NullDf = new JEPost();
            NullDf.Code = -1;
            NullDf.MetierName = "------";
            cmbPostsFree.Items.Add(NullDf);
            cmbPostsFree.SelectedItem = NullDf;
            foreach (JEPost Post in JEPs.Items)
            {
                cmbPostsFree.Items.Add(Post);
                
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (JEPP.SavePost(this.State))
            {
                JMessages.Information("Information Saved.", "");
                this.Close();

            }




        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            JFindPersonForm JFPF = new JFindPersonForm(JPersonTypes.RealPerson);
            JFPF.ShowDialog();
            if (JFPF.DialogResult == DialogResult.OK)
            {
                if(JEPersonPost.Find(JFPF.SelectedPersonCode)>0)
                {
                    JMessages.Error("برای این شخص سمت انتخاب شده است.", "error");
                    return ;

                }
                txtName.Text = JFPF.SelectedPerson.Name;
                txtPCode.Text =Convert.ToString(JFPF.SelectedPersonCode);
                JEPP.PersonCode = JFPF.SelectedPersonCode;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (jDGPosts.CurrentRow != null)
                jDGPosts.Rows.Remove(jDGPosts.CurrentRow);
            else
                JMessages.Error("یک سطر را انتخاب کنید", "error");

        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (JEPP.ListPost.Select(JEPersonPostEnum.PostCode.ToString() + "=" + ((JEPost)cmbPostsFree.SelectedItem).Code).Length >0)
                {
                    JMessages.Error("این سمت قبلا انتخاب شده است.", "error");
                    return;
                }
                DataRow Row = ((DataTable)jDGPosts.DataSource).NewRow();
                Row[JEPersonPostEnum.Active.ToString()] = JPostState.Active;
                if (txtContractCode.Text != "")
                {
                    Row[JEPersonPostEnum.ContractCode.ToString()] = txtContractCode.Text;
                }
                Row[JEPersonPostEnum.DateEnd.ToString()] = txtDateEnd.Date;
                Row[JEPersonPostEnum.DateStart.ToString()] = txtDateStart.Date;
                if (((JEPost)cmbPostsFree.SelectedItem).Code != -1)
                {
                    Row[JEPersonPostEnum.PostCode.ToString()] = ((JEPost)cmbPostsFree.SelectedItem).Code;
                    Row[JEPersonPostEnum.PostName.ToString()] = ((JEPost)cmbPostsFree.SelectedItem).ToString();
                }
                else
                {
                    JMessages.Error("پست سازمانی را انتخاب کنید.", "error");
                    cmbPostsFree.Focus();
                    return;
                }
                JEPP.ListPost.Rows.Add(Row);
                ClearPost();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
        private void ClearPost()
        {  
            JEPost NullDf = new JEPost();
            NullDf.Code = -1;
            NullDf.MetierName = "------";
            cmbPostsFree.Items.Add(NullDf);
            cmbPostsFree.SelectedItem = NullDf;
            cmbPostsFree.SelectedItem = NullDf;
            txtContractCode.Clear();
            txtDateEnd.Clear();
            txtDateStart.Clear();

        }

        private void JEPersonPostForm_Load(object sender, EventArgs e)
        {
            jDGPosts.DataSource = JEPP.ListPost;
            jDGPosts.Columns[JEPersonPostEnum.PCode.ToString()].Visible = false;
            jDGPosts.Columns[JEPersonPostEnum.Code.ToString()].Visible = false;
            jDGPosts.Columns[JEPersonPostEnum.PostCode.ToString()].Visible = false;
            jDGPosts.Columns[JEPersonPostEnum.PostName.ToString()].Width = 180;
            jDGPosts.Columns[JEPersonPostEnum.PostName.ToString()].ReadOnly = true;
        }

       

        #region OldCode

        //    private void btnSave_Click(object sender, EventArgs e)
        //    {
        //    }

        //    private void btnCancel_Click(object sender, EventArgs e)
        //    {
        //        DialogResult = DialogResult.Cancel;
        //    }

        //    private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnSelectPerson_Click(object sender, EventArgs e)
        //    {
        //        ClassLibrary.JFindPersonForm FP = new JFindPersonForm();
        //        FP.ShowDialog();
        //        if (FP.SelectedPerson != null)
        //        {
        //            _setPerson(FP.SelectedPerson);
        //        }
        //    }

        //    private void _setPerson(int pPcode)
        //    {
        //        JAllPerson Ap = new JAllPerson(pPcode);
        //        _setPerson(Ap);
        //    }

        //    private void _setPerson(JAllPerson pAllPerson)
        //    {
        //        txtPCode.Text = pAllPerson.Name;
        //        jDGPosts.DataSource = JEPersonPost.GetPersonPosts(pAllPerson.Code);
        //    }

        //    private void btnAdd_Click(object sender, EventArgs e)
        //    {
        //        if (txtContractCode.Text == "")
        //        {
        //            string[] parameters = { "@Value" };
        //            string[] values = { "کد قرارداد" };
        //            string msg = JLanguages._Text("PleaseEnter", parameters, values);
        //            JMessages.Message(msg, "", JMessageType.Error);
        //            txtContractCode.Focus();
        //            return;
        //        }
        //        JEPersonPost pPost = new JEPersonPost(Convert.ToInt32(txtPCode.Text));
        //        pPost.ContractCode = Convert.ToInt32(txtContractCode.Text);
        //        pPost.DateEnd = JDateTime.GregorianDate(txtDateEnd.Text);
        //        pPost.DateStart = JDateTime.GregorianDate(txtDateStart.Text);
        //        pPost.Active = Convert.ToInt16(chkActive.Checked);

        //    }

        //    private void btnDelete_Click(object sender, EventArgs e)
        //    {

        //    }
        #endregion
        
    }
}
