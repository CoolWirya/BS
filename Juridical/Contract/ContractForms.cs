using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Finance;
using System.Data;

namespace Legal
{
    public class JContractForms : JLegal
    {
        //public struct ArgParameter
        //{
        //    public string FormName;
        //    public string PrpertyName;
        //    public object Value;
        //}
        public ArgParameter[] B; 

        public JBaseContractForm[] Forms = new JBaseContractForm[0];
        public int FormIndex = 0;
        public int Count;
        public JSubjectContract Contract;
        public Boolean isSave = false;
        public int GroupCode;
        public int ConcernCode;

        public JPopupMenu FormsItems
        {
            get;
            set;
        }

        /// <summary>
        /// نوع قرارداد پایه
        /// </summary>
        //public int CotractType;
        public JContractTypeSettings Settings;//= new JContractTypeSettings();
        //        public JContractSettings Settings;
        /// <summary>
        /// کلاس قرارداد صدا زننده این فرمها (اجاره-سرقفلی ، انتقال ، ...)ر
        /// </summary>
        public object RelatedContract;

        public JContractForms()
            : this(0)
        {

        }

        public JContractForms(int pCCode)
        {
            Contract = new JSubjectContract(pCCode);
            Settings = new JContractTypeSettings();
        }


        public int Add(JBaseContractForm pForm, JContractFormsOrder pFormOrder)
        {
            if (pForm != null)
            {
                Array.Resize(ref Forms, Forms.Length + 1);
                Forms[Forms.Length - 1] = pForm;
                /// افزودن گزینه های منو
                if (FormsItems == null)
                    FormsItems = new JPopupMenu();
                JAction formItem = (new JAction(pFormOrder.FormName, "Legal.JContractForms.ShowForm", new object[] { this, pForm }, null));
                formItem.SenderObject = pForm;
                formItem.BeforRun += new JAction.BeforRunEventHandler(formItem_BeforRun);
                FormsItems.Insert(formItem);

                pForm.ContractForms = this;
            }
            return Forms.Length - 1;
        }


        void formItem_BeforRun(object Sender)
        {
            //(((Sender as JAction).SenderObject) as JBaseContractForm).ApplyData();

            //(Sender as JBaseContractForm).ApplyData();
        }

        public void ShowForm()
        {
            Forms[FormIndex].Show();
        }

        public void ShowForm(JContractForms pForms, JBaseContractForm pForm)
        {
            pForms.Forms[pForms.FormIndex].Visible = false;
            pForms.FormIndex = pForm.Index;
            pForm.Show();

            //for (int i = 0; i < pForms.Count(); i++)
            //{
            //    if (pForms[i].Name == pFormName)
            //    {
            //        pForms[
            //        pForms[i].Show();
            //}
        }

        public void ShowForm(int pFormIndex)
        {
            try
            {
                Forms[FormIndex].Visible = false;
                FormIndex = pFormIndex;
                ShowForm();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
        }

        public void NextForm()
        {
            try
            {
                if (FormIndex < Forms.Length)
                {
                    Forms[FormIndex].Visible = false;
                    FormIndex++;
                    ShowForm();
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
        }

        public void BackForm()
        {
            try
            {
                if (FormIndex > 0)
                {
                    Forms[FormIndex].Visible = false;
                    FormIndex--;
                    ShowForm();
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
        }

        public void Cancel(bool pClose)
        {
            foreach (JBaseContractForm BCF in Forms)
            {
                if (pClose == true)
                    BCF.Close();
                BCF.SaveBack();
                BCF.Dispose();
            }
        }
        public void Cancel()
        {
            Cancel(true);
        }

        public void CloseAll()
        {
            Cancel();
        }

        /// <summary>
        /// فراخوانی متد ذخیره هر کدام از فرمها
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.beginTransaction("Save Contract");

            for (int count = 0; count <= JBaseContractForm.MaxFormNumber; count++)
            {
                foreach (JBaseContractForm BCF in Forms)
                {
                    if (BCF.SaveOrder == count)
                    {
                        JBaseContractForm.JStateContractForm SCFtemp = BCF.State;
                        if (!BCF.Save(DB))
                        {
                            //Contract.Code = 0;
                            foreach (JBaseContractForm tempBCF in Forms)
                                tempBCF.SaveBack();
                            DB.Rollback("Save Contract");
                            return false;
                        }
                    }
                }
            }
            DB.Commit();
            isSave = true;
            return true;
        }

        /// <summary>
        /// فراخوانی متد حذف هر کدام از فرمها
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.beginTransaction("Delete Contract");

            for (int count = 0; count <= JBaseContractForm.MaxFormNumber; count++)
            {
                foreach (JBaseContractForm BCF in Forms)
                {
                    if (BCF.SaveOrder == count)
                    {
                        JBaseContractForm.JStateContractForm SCFtemp = BCF.State;
                        if (!BCF.DeleteContract(DB))
                        {
                            DB.Rollback("Delete Contract");
                            return false;
                        }
                    }
                }
            }
            DB.Commit();
            isSave = true;
            return true;
        }

        private void RollbackForms()
        {
            foreach (JBaseContractForm BCF in Forms)
            {
                //BCF.State = JBaseContractForm.JStateContractForm.Insert;
            }
            //Contract.Code = 0;
        }

        public DataTable SavePrviewColumn()
        {
            DataTable tempdt = SavePreview(false,false);
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("text");
            foreach (DataColumn DC in tempdt.Columns)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = DC.ColumnName;
                dr["text"] = JLanguages._Text(DC.ColumnName);
                dt.Rows.Add(dr);
            }
            return dt;

        }
        /// <summary>
        /// فراخوانی متد نمایش هر کدام از فرمها
        /// </summary>
        /// <returns></returns>
        public DataTable SavePreview()
        {
            return SavePreview(true,false);
        }

        public DataTable SavePreview(bool pSetValue,bool pOffLine)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                foreach (JBaseContractForm BCF in Forms)
                {
                    if (BCF.SavePreview(dt, pSetValue, pOffLine))
                    {
                    }
                    else
                    {
                        if (pSetValue)
                            return null;
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// فراخوانی تابع ذخیره هر کلاس قرارداد که بصورت آبجکت به فرم داده شده است
        /// </summary>
        /// <returns></returns>
        public int SaveContract(JDataBase pDB)
        {
            JAction SaveAction = new JAction("SaveContract", RelatedContract.GetType().ToString() + ".SaveAssests", new object[] { pDB }, null);
            return (int)SaveAction.run();
        }

        public DataTable GetContractData(int pCode)
        {
            return null;
        }

        public DataTable GetContractColumn()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery(@"SELECT syscolumns.name,(select dic.text from dic where dic.name=syscolumns.name) as text
                FROM sysobjects 
                INNER JOIN 	syscolumns ON sysobjects.id = syscolumns.id INNER JOIN	
                systypes ON syscolumns.xtype = systypes.xtype WHERE (sysobjects.xtype = 'U') and
                sysobjects.name = 'LegSubjectContract'");
            return DB.Query_DataTable();
        }
        /// <summary>
        /// ???
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return "Select * from ";
        }

        public void CreateWordContract()
        {
            JContractdefine tmp = new JContractdefine(Contract.Type);
            JContractDynamicType dynamicType = new JContractDynamicType(tmp.ContractType);
            DataTable dt = new DataTable();
            int FileCode=0;
            JDataBase _DB = new JDataBase();
            try
            {
                DataTable DataTableC = SavePreview(true, true);
                if (DataTableC != null)
                {

                    //---------------------------
                    try
                    {
                        OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
                        Office.GetData("Legal.JContractdefine", tmp.Code);
                        string tmpstr = Office.ReplaceXml(DataTableC, Office.DocumentContent, Office.Code);

                        Finance.JAsset tmpAsset = new Finance.JAsset(Convert.ToInt32(DataTableC.Rows[0]["FinanceCode"]));
                        JAction SaveAction = new JAction("FieldList", tmpAsset.ClassName + ".GetContractData", new object[] { tmpAsset.ObjectCode, dynamicType.PrtClassName, dynamicType.PrtObjectCode }, null);
                        dt = (DataTable)SaveAction.run();

                        if (dt == null)
                            dt = DataTableC.Copy();

                        _DB.beginTransaction("Contract");
                        ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
                        if (_DB.Transaction != null)
                            adb.beginTransaction("");
                        _DB.ADDRelation(adb);

                        FileCode = Office.Insert(adb, "Legal.JContractForms", Contract.Code,
                            Office.ReplaceXml(dt, tmpstr, Office.Code), "", true, true);
                        if (FileCode > 0)
                        {
                            Contract.FileCode = FileCode;
                            if (Contract.Update(_DB))
                                _DB.Commit();
                            else
                            {
                                _DB.Rollback("Contract");
                                JMessages.Error(" خطا در سیستم ", "");
                            }
                        }
                    }

                    //---------------------------
                    //pWinWordControl.GetData("Legal.JContractdefine", tmp.Code);
                    //pWinWordControl.LoadDocument();
                    //pWinWordControl.Reaplce(DataTableC);

                    //// اطلاعات ریز اموال
                    //Finance.JAsset tmpAsset = new Finance.JAsset(Convert.ToInt32(DataTableC.Rows[0]["FinanceCode"]));
                    //JAction SaveAction = new JAction("FieldList", tmpAsset.ClassName + ".GetContractData", new object[] { tmpAsset.ObjectCode, dynamicType.PrtClassName, dynamicType.PrtObjectCode }, null);
                    //dt = (DataTable)SaveAction.run();
                    //if (dt != null)
                    //    pWinWordControl.Reaplce(dt);
                    //try
                    //{
                    //    bool ret = pWinWordControl.SaveInOfficeWord(_DB, "Legal.JContractForms", Contract.Code, true);
                    //    if (ret)
                    //    {
                    //        if (pWinWordControl.FileCode > 0)
                    //        {
                    //            Contract.FileCode = pWinWordControl.FileCode;
                    //            Contract.Update();
                    //        }
                    //    }
                    //}
                    finally
                    {
                        //tmpAsset.Dispose();
                        //SaveAction.Dispose();
                        DataTableC.Clear();
                        DataTableC.Dispose();
                    }
                }
                else
                {
                    //JMessages.Error(Contract.Code.ToString(), "");
                    //                    JMessages.Error("Error in Contract Data", "Error");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                _DB.Rollback("Contract");
                JMessages.Error(" خطا در سیستم ", "");
                //JMessages.Error(Contract.Code.ToString(), "");
            }
            finally
            {
                _DB.Dispose();
                tmp.Dispose();
                dynamicType.Dispose();
                dt.Dispose();
            }
        }
    }
}
