using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JDefineField : JLegal
    {

      #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام فیلد
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// متن 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// جداکننده 
        /// </summary>
        public string Separate { get; set; }

        #endregion

        #region سازنده

        public JDefineField()
        {
        }
        public JDefineField(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDefineFieldTable PDT = new JDefineFieldTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert();
                if (Code > 0)
                {
                    Histroy.Save(PDT, PDT.Code, "Insert");
                    Nodes.DataTable.Merge(JDefineFields.GetDataTable(Code));
                }
                return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDefineFieldTable PDT = new JDefineFieldTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update())
                {
                    Histroy.Save(PDT, PDT.Code, "Update");
                    Nodes.CurrentNode.Name = Name;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
         /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.beginTransaction("DELETE WORD");
                if (delete(DB, pCode))
                {
                    DB.Commit();
                    return true;
                }
                DB.Rollback("DELETE WORD");
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool delete(JDataBase pDB, int pCode)
        {

            if (pCode > 0)
            {
                GetData(pCode);
            }
            JDefineFieldTable PDT = new JDefineFieldTable();
            try
            {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        Histroy.Save(PDT, PDT.Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
            return false;
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JDefineFieldTable PDT = new JDefineFieldTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.DefineField + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
         #endregion

        #region ShowData

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JDefineFieldForm JNF = new JDefineFieldForm();
                JNF.State = JFormState.Insert;
                JNF.ShowDialog();
            }
            else
            {
                JDefineFieldForm JNF = new JDefineFieldForm(this.Code);
                JNF.State = JFormState.Update;
                JNF.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Legal.JDefineField");
            Node.Icone = JImageIndex.testimonial.GetHashCode();
            Node.Name = pRow["Name"].ToString();
            Node.Hint = pRow["Text"].ToString();

            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JDefineField.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Legal.JDefineField.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Legal.JDefineField.delete", new object[] { Node.Code }, null);
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);

            return Node;
        }

        public static DataTable GetColumnsByClassName(string pClassName)
        {  
            DataTable dt = new DataTable();
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery("select name from " + JTableNamesContracts.DefineField + " Where ClassName=@pClassName");
                Db.Params.Add("pClassName", pClassName);
                foreach (DataRow dr in Db.Query_DataTable().Rows)
                    dt.Columns.Add(dr["name"].ToString());
                return dt;
            }                
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DataTable GetColumns()
        {
            DataTable dt = new DataTable();
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery("select name from " + JTableNamesContracts.DefineField);
                foreach (DataRow dr in Db.Query_DataTable().Rows)
                    dt.Columns.Add(dr["name"].ToString());
                return dt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// گرفتن کلیه فیلدهای تعریف شده بصورت استاندارد name,text
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetDataName(int pCode)
        {
            string Where = "select name,name As 'text' from " + JTableNamesContracts.DefineField;
            if (pCode > 0)
            {
                Where += " where Code=" + pCode;
            }

            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetDataByName(string pFieldName)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.DefineField + " WHERE Name=N'" + pFieldName.ToString() + "'");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// لیست کلیه فیلدهای تعریف شده را بر می گرداند
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable DataTableField(DataTable dt)
        {
            try
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                    dr[i] = DataField(dt.Columns[i].Caption.ToString());
                dt.Rows.Add(dr);
                return dt;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
        }
        /// <summary>
        /// نام فیلد(تعریف شده) را از ورودی می گیرد 
        /// با توجه به نام کلاس متد آن کلاس را اجرا کرده و اطلاعات آنها را بصورت یک رشته بر می گرداند
        /// </summary>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public string DataField(string pFieldName)
        {
            try
            {
                string Str = "";
                bool FlagEmpty = false;
                if (GetDataByName(pFieldName))
                {
                    DataTable dt = new DataTable();
                    if (ClassName == "Legal.JSellerContract" || ClassName == "Legal.JSellerContractLegal") dt = JPartiesForm.DtSeller;
                    else
                        if (ClassName == "Legal.JSellerAdvocateContract" || ClassName == "Legal.JSellerAdvocateContractLegal") dt = JPartiesForm.DtAdSeller;
                        else
                            if (ClassName == "Legal.JBuyerContract" || ClassName == "Legal.JBuyerContractLegal") dt = JPartiesForm.DtBuyer;
                            else
                                if (ClassName == "Legal.JBuyerAdvocateContract" || ClassName == "Legal.JBuyerAdvocateContractLegal") dt = JPartiesForm.DtAdBuyer;
                                else
                                    if (ClassName == "Legal.JIntuitionContract") dt = JPartiesForm.Dtintuition;
                                    //else dt = JDocumentsForm.dtForm;

                    int[] Objectcode = new int[dt.Select("ClassNameEn = '" + ClassName + "'").Length];
                    int C = 0;
                    string tmpStr = "";
                    if (dt != null && Objectcode.Length>0)
                    {
                        foreach (DataRow dr in dt.Select("ClassNameEn = '" + ClassName + "'"))
                        {
                            if ((ClassName == "Finance.JCheque") || (ClassName == "Finance.JFish") || (ClassName == "Finance.JPromissoryNote"))
                                Objectcode[C] = Convert.ToInt32(dr["ObjectCode"]);
                            else
                                Objectcode[C] = Convert.ToInt32(dr["PersonCode"]);
                            C++;
                        }
                        JAction SaveAction = new JAction("FieldList", ClassName + ".FieldList", new object[] { Objectcode }, null);
                        dt = (DataTable)SaveAction.run();
                        FlagEmpty = false;
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            tmpStr = Str;
                            Str = Str + Text;
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                Str = Str.Replace("<" + JLanguages._Text(dt.Columns[j].Caption) + ">", " " + dt.Rows[i][dt.Columns[j]].ToString() + " ");
                                if (Text.Contains("<" + JLanguages._Text(dt.Columns[j].Caption) + ">") && (dt.Rows[i][dt.Columns[j]].ToString() != ""))
                                    FlagEmpty = true;
                            }
                            if (i < dt.Rows.Count-1)
                                Str = Str + " " + Separate;
                            if (FlagEmpty == false)
                                Str = tmpStr;
                            FlagEmpty = false;
                        }
                    }
                }
                Str = Str.Replace("\n", "\r");
                if ((FlagEmpty == false) && (Str == ""))
                    return "";
                else
                    return Str;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
        }
    }

    class JDefineFields : JSystem
    {
        public JDefineFields[] Items = new JDefineFields[0];
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = "select * from " + JTableNamesContracts.DefineField;
            if (pCode > 0)
            {
                Where += " where Code=" + pCode;
            }

            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "Legal.JDefineField.GetNode");
            Nodes.DataTable = GetDataTable();
            //اکشن جدید
            JAction newaction = new JAction("new...", "Legal.JDefineField.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
    }

