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
    public partial class JDocumentsForm : JBaseContractForm
    {
        public DataTable Documents = new DataTable();
        public JDocumentsForm()
        {
            InitializeComponent();
            FillComboBox();
            SaveOrder = 19;
           // LoadData();
        }
        public JDocumentsForm MakeForm()
        {
            JDocumentsForm form = new JDocumentsForm();
            return form;
        } 
        public void FillComboBox()
        {
            JDocumentTypes types = new JDocumentTypes();
            foreach (JDocumentType type in types.Items)
            {
                cmbTypeDoc.Items.Add(type);
            }
            if (cmbTypeDoc.Items.Count > 0)
                cmbTypeDoc.SelectedIndex = 0;

            SetCombo(cmbConcern, "select Code,Name,ClassCode1,ClassCode2,ClassCode3 from dbo.Trs_View_Concern", "Name", "Code");
            SetCombo(cmbForm, "select * from dbo.Trs_View_FormConcern", "Name", "Code");
        }

        public void LoadData()
        {
            
            if (ContractForms == null)
                grdDocuments.DataSource = JDocumentsContract.GetAllData(0);
            else
            {
                ConcernCode = ContractForms.Contract.ConncernCode;
                cmbForm.SelectedValue = ContractForms.Contract.FormId;
                txtSerial.Text = ContractForms.Contract.Serial.ToString();
                txtAcc1.Text = ContractForms.Contract.DtlClassCode1.ToString();
                txtAcc2.Text = ContractForms.Contract.DtlClassCode2.ToString();
                txtAcc3.Text = ContractForms.Contract.DtlClassCode3.ToString();
                try
                {
                    if (grdDocuments.DataSource == null)
                        grdDocuments.DataSource = JDocumentsContract.GetAllData(0);
                    DataTable docs = JDocumentsContract.GetAllData(ContractForms.Contract.Code);
                    grdDocuments.DataSource = docs;
                    foreach (DataRow doc in docs.Rows)
                    {
                        JAction action = new JAction("GetDocumentContract", doc["ClassName"].ToString() + ".GetDocumentContract", new object[] { Convert.ToInt32(doc["ObjectCode"]) }, null);
                        JDocumentContract docContract = (JDocumentContract)action.run();
                        doc["ContractText"] = docContract.ContractText;
                        //InsertInList(docContract);
                    }
                }
                catch(Exception ex)
                {

                }
            }
            grdDocuments.Columns["ContractSubjectCode"].Visible = false;
            grdDocuments.Columns["ClassName"].Visible = false;
            grdDocuments.Columns["ObjectCode"].Visible = false;
//            grdDocuments.Columns["Concern"].Visible = false;
            //grdDocuments.Columns["No/Price"].Visible = false;

            if (State == JStateContractForm.View)
            {
                btnDel.Enabled = false;
                btnReg.Enabled = false;
            }
        }

        public void InsertInList(JDocumentContract pDocument)
        {
            if (pDocument == null)
                return;
            DataRow row = ((DataTable)(grdDocuments.DataSource)).NewRow();
            row["Code"] = pDocument.Code;
            row["ClassName"] = pDocument.ClassName;
            row["DocumentType"] = JLanguages._Text(pDocument.ClassName);
            row["ObjectCode"] = pDocument.ObjectCode;
            row["Concern"] = pDocument.Concern;
            //row["No/Price"] = JLanguages._Text("No") + ": " + pDocument.Number + "       " + JLanguages._Text("Cost:") + pDocument.Price.ToString();
            row["No/Price"] = pDocument.Price.ToString();
            row["ContractText"] = pDocument.ContractText;
            ((DataTable)(grdDocuments.DataSource)).Rows.Add(row);
        }


        public void SetCombo(JComboBox pBox, String pSql, String pDisplayMember, string pValueMember)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(pSql);
                DataTable DT = DB.Query_DataTable();
                pBox.DataSource = DT;
                pBox.DisplayMember = pDisplayMember;
                pBox.ValueMember = pValueMember;
            }
            finally
            {
                DB.Dispose();
            }

        }

        public void InsertInLists(List<JDocumentContract> pDocument)
        {
            if (pDocument == null)
                return;
            for (int i = 0; i < pDocument.Count; i++)
            {
                DataRow row = ((DataTable)(grdDocuments.DataSource)).NewRow();
                row["Code"] = pDocument[i].Code;
                row["ClassName"] = pDocument[i].ClassName;
                row["DocumentType"] = JLanguages._Text(pDocument[i].ClassName);
                row["ObjectCode"] = pDocument[i].ObjectCode;
                row["Concern"] = pDocument[i].Concern;
                //row["No/Price"] = JLanguages._Text("No") + ": " + pDocument[i].Number + "       " +  JLanguages._Text("Cost:") + pDocument[i].Price.ToString();
                row["ContractText"] = pDocument[i].ContractText;
                row["No/Price"] = pDocument[i].Price.ToString();
                ((DataTable)(grdDocuments.DataSource)).Rows.Add(row);
            }
        }

        //public override bool SaveBack()
        //{
        //    if (isSave)
        //    {
        //        isSave = false;
        //        State = tempState;
        //    }
        //    return true;
        //}

        public override bool SaveBack()
        {
            if (!ContractForms.isSave)
            {
                foreach (DataRow dr in Documents.Rows)
                {
                    if ((State == JStateContractForm.Insert) || ((State == JStateContractForm.Update) && (dr.RowState == DataRowState.Added)))
                    {
                        if (String.Compare(dr["ClassName"].ToString(), "Finance.JCheque") == 0)
                        {
                            Finance.JCheque tmpCheque = new Finance.JCheque();
                            tmpCheque.Code = Convert.ToInt32(dr["ObjectCode"]);
                            tmpCheque.delete(Convert.ToInt32(dr["ObjectCode"]));
                        }
                        else if (String.Compare(dr["ClassName"].ToString(), "Finance.JFish") == 0)
                        {
                            Finance.JFish tmpFish = new Finance.JFish();
                            tmpFish.Code = Convert.ToInt32(dr["ObjectCode"]);
                            tmpFish.delete(Convert.ToInt32(dr["ObjectCode"]));
                        }
                        else if (String.Compare(dr["ClassName"].ToString(), "Finance.JPromissoryNote") == 0)
                        {
                            Finance.JPromissoryNote tmpPromissoryNote = new Finance.JPromissoryNote();
                            tmpPromissoryNote.Code = Convert.ToInt32(dr["ObjectCode"]);
                            tmpPromissoryNote.delete(Convert.ToInt32(dr["ObjectCode"]));
                        }
                        else if (String.Compare(dr["ClassName"].ToString(), "Finance.JRealPrice") == 0)
                        {
                            Finance.JRealPrice tmpRealPrice = new Finance.JRealPrice();
                            tmpRealPrice.Code = Convert.ToInt32(dr["ObjectCode"]);
                            tmpRealPrice.delete(Convert.ToInt32(dr["ObjectCode"]));
                        }
                    }
                }
            }
            return true;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            JContractDynamicType D = new JContractDynamicType(ContractForms.Contract.Type);
            int Exporter = 0;
            int Reciver = 0;
            if (ContractForms.Contract.T1Person != null && ContractForms.Contract.T1Person.Rows.Count > 0)
            {
                if (ContractForms.Contract.T1Person.Rows[0].RowState != DataRowState.Deleted)
                    Reciver = ContractForms.Contract.T1Person.Rows[0].Field<int>(ContractForms.Contract.T1Person.Columns["PersonCode"]);
            }
            if (ContractForms.Contract.T2Person != null && ContractForms.Contract.T2Person.Rows.Count > 0)
            {
                if (ContractForms.Contract.T2Person.Rows[0].RowState != DataRowState.Deleted)
                    Exporter = ContractForms.Contract.T2Person.Rows[0].Field<int>(ContractForms.Contract.T2Person.Columns["PersonCode"]);
            }
            int d1 = 0;
            int d2 = 0;
            int d3 = 0;
            int.TryParse(txtAcc1.Text, out d1);
            int.TryParse(txtAcc2.Text, out d2);
            int.TryParse(txtAcc3.Text, out d3);
            int Serial = 0;
            int.TryParse(txtSerial.Text, out Serial);

            if (((Legal.JDocumentType)(cmbTypeDoc.SelectedItem)).ClassName != "Finance.JCheques")
                InsertInList(((JDocumentType)cmbTypeDoc.SelectedItem).NewItem(Exporter, Reciver, "JDocumentContract" + ContractTypeCode, GroupCode, (int)cmbForm.SelectedValue
                    , (int)cmbConcern.SelectedValue, txtDateRecieve.Date, Serial, d1, d2, d3));
            else
                InsertInLists(((JDocumentType)cmbTypeDoc.SelectedItem).NewItems(Exporter, Reciver, "JDocumentContract" + ContractTypeCode, GroupCode, (int)cmbForm.SelectedValue
                    , (int)cmbConcern.SelectedValue, txtDateRecieve.Date, Serial, d1, d2, d3));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.ContractForms.Contract.ConncernCode = (int)cmbConcern.SelectedValue;
                if(txtAcc1.Text.Length>0)
                    this.ContractForms.Contract.DtlClassCode1 = int.Parse(txtAcc1.Text);
                if (txtAcc2.Text.Length > 0)
                    this.ContractForms.Contract.DtlClassCode2 = int.Parse(txtAcc2.Text);
                if (txtAcc3.Text.Length > 0)
                    this.ContractForms.Contract.DtlClassCode3 = int.Parse(txtAcc3.Text);
                Documents = ((DataTable)(grdDocuments.DataSource));
                Int64 Price = 0;
                foreach (DataRow dr in Documents.Rows)
                {
                    try
                    {
                        Price += Int64.Parse(dr["No/Price"].ToString());
                    }
                    catch
                    {

                    }
                }
                if(Price != TotalPrice)
                {
                    JMessages.Information("مبلغ اسناد مالی باید با مبلغ قرارداد برابر باشد", "خطا");
                    return;
                }
                ContractForms.NextForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdDocuments.CurrentRow != null)
                    grdDocuments.Rows.Remove(grdDocuments.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RollBackManual()
        {
            foreach (DataRow row in Documents.Rows)
            {
                JAction action = new JAction("DeleteDocument", row["ClassName"].ToString() + ".Delete", null, new object[] { row["ObjectCode"] });
                action.run();
            }
            return true;
        }

        public bool ApplyData()
        {

            return true;
        }
        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true, false);
        }
        public override bool SavePreview(DataTable pDt, bool pSetValue)
        {
            return SavePreview(pDt, pSetValue, false);
        }
        public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
        {
            try
            {
                List<string> Temp = new List<string>();
                //Finance.JConcernTypes Concerns = new Finance.JConcernTypes();
                JDataBase DB = new JDataBase();
                DB.setQuery("select * from Trs_View_FormConcern");
                DataTable DT = DB.Query_DataTable();
                //DataTable DT = Concerns.GetList();
                foreach (DataRow Concern in DT.Rows)
                {
                    // create culmun of babat
                    if (pDt.Columns.IndexOf(Concern["Name"].ToString()) < 0)
                        pDt.Columns.Add(Concern["Name"].ToString());
                }// +بابت
                //----------------------------
                if (pSetValue)
                {
                    if (pOffline)
                        LoadData();
                   // DataTable tempDT = Concerns.GetList();
                    foreach (DataRow Concern in DT.Rows)
                    {
                        // for babat
                        Temp.Clear();
                        foreach (DataRow DR in Documents.Rows)
                        {
                            if (DR.RowState == DataRowState.Deleted)
                                continue;
                            int tempCode = (int)DR["ObjectCode"];
                            if (DR["ContractText"] is DBNull && tempCode > 0)
                            {
                                if (DR["Concern"].ToString() == Concern["Name"].ToString()) //+بابت
                                {
                                    JDocumentType document = new JDocumentType();
                                    Temp.Add(document.GetContractText(tempCode));
                                }
                            }
                            else
                                if (DR["Concern"].ToString() == Concern["Name"].ToString())
                                //{
                                //    JDocumentType document = new JDocumentType();
                                //    Temp.Add(document.GetContractText(tempCode));
                                //}
                                    Temp.Add(DR["ContractText"].ToString());

                        }
                        pDt.Rows[0][Concern["Name"].ToString()] = String.Join("\r\n", Temp.ToArray());
                    }
                //--------------------------------
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public override bool Save(JDataBase tempdb)
        {
            tempState = State;
            try
            {
                JDocumentsContract tmp = new JDocumentsContract();
                if (State == JStateContractForm.Insert)
                {
                    if (tmp.InsertUpdate(tempdb, ContractForms.Contract.Code, Documents))
                    {
                        isSave = true;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (tmp.InsertUpdate(tempdb, ContractForms.Contract.Code, Documents))
                    {
                        isSave = true;
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void grdDocuments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            JDocumentType document = new JDocumentType();
            document.ClassName = grdDocuments.SelectedRows[0].Cells["ClassName"].Value.ToString();
            JDocumentContract doc = new JDocumentContract();
            doc.ObjectCode = (int)grdDocuments.SelectedRows[0].Cells["ObjectCode"].Value;
            doc.ClassName = grdDocuments.SelectedRows[0].Cells["ClassName"].Value.ToString();
            doc = document.EditItem(doc, "JDocumentContract"+ContractTypeCode);
            if (doc != null)
            {
                InsertInList(doc);
                grdDocuments.Rows.RemoveAt(grdDocuments.CurrentRow.Index);
            }
        }

        private void JDocumentsForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void JDocumentsForm_Load(object sender, EventArgs e)
        {
            LoadData();

            if (ConcernCode > 0)
            {
                cmbConcern.Enabled = false;
                cmbConcern.SelectedValue = ConcernCode;
            }

        }

        private void JDocumentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        public static bool SaveFinDocument(JDataBase pDB, int pContractCode)
        {
            //pDB.setQuery("select * from LegDocumentContract");
            //DataTable DT = pDB.Query_DataTable();

            //object[] O = new object[2] { DT,"dbo.tabletype" };
            //JDataBase _DB = new JDataBase();
            //_DB.setQuery("EXEC InsertDocumentToAccountingServer");
            //_DB.Params.Add("",O);
            return true;

        }

        private void txtAcc3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender == txtAcc1)
                {
                    Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new Finance.FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode1"]);
                    if (SAF.ShowDialog() == DialogResult.OK)
                    {
                        txtAcc1.Text = SAF.ReturnValue.ToString();
                    }
                }
                if (sender == txtAcc2)
                {
                    Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new Finance.FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode2"]);
                    if (SAF.ShowDialog() == DialogResult.OK)
                    {
                        txtAcc2.Text = SAF.ReturnValue.ToString();
                    }
                }
                if (sender == txtAcc3)
                {
                    Finance.FinanceDocuments.Cheques.JSelectAccForm SAF = new Finance.FinanceDocuments.Cheques.JSelectAccForm(int.Parse(txtDateRecieve.Text.Substring(0, 4)), (int)(cmbConcern.SelectedItem as DataRowView)["ClassCode3"]);
                    if (SAF.ShowDialog() == DialogResult.OK)
                    {
                        txtAcc3.Text = SAF.ReturnValue.ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerial.Text = (cmbForm.SelectedItem as DataRowView)["Text2"].ToString();
        }
    }
}
