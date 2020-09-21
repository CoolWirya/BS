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

    public partial class LegalForm : JBaseContractForm
    {
        DataTable _dtPetition = new DataTable();
        public int _Code;

        public LegalForm()
        {
            InitializeComponent();
        }

        public LegalForm MakeForm()
        {
            LegalForm form = new LegalForm();
            return form;
        } 

        #region Methods

        public void setForm()
        {
        }

        public bool CheckData()
        {
            if (_dtPetition.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool ApplyData()
        {
            //JBaseContractForm.
            return true;
        }


        public bool Save(JDataBase tempdb, int pCode)
        {
            if (State != JStateContractForm.Update)
            {
                //if (tmp.Insert(tempdb,_dtPetition) > 0)
                //    return true;
                //else
                //    return false;
            }
            else
            {
                //tmp.Code = _Code;
                //if (tmp.Update(DB,_dtPetition) > 0)
                    return true;
                //else
                //    return false;
            }
            return true;
        }

        #endregion

        #region Events
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            ContractForms.NextForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //JPetitionSearchForm tmpfrm = new JPetitionSearchForm();
            //tmpfrm.ShowDialog();
            //_PetitionCode = tmpfrm._Code;
            //if (tmpfrm._Code != null)
            //{
            //    if (((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0))
            //    {
            //        DataRow dr = _dtPetition.NewRow();
            //        dr["PersonCode"] = p.SelectedPerson.Code;
            //        dr["Name"] = p.SelectedPerson.Name;
            //        dr["PersonType"] = p.SelectedPerson.PersonType;
            //        _dtPetition.Rows.Add(dr);
            //        jdgvPetition.DataSource = _dtSeller;
            //        //btnSave.Enabled = true;
            //    }
            //}
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvPetition.CurrentRow != null)
                    jdgvPetition.Rows.Remove(jdgvPetition.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion



    }
}
