using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
namespace ShareProfit
{

    public class JSDocument : JSystem
    {
        public int Code { get; set; }
        public int CourseCode { get; set; }
        public string DocDate { get; set; }
        public string DocNo { get; set; }
        public int PayLoc { get; set; }
        public bool ShowDeactiveSheet { get; set; }
        /// <summary>
        /// تاریخ پرداخت پیشفرض
        /// </summary>
        public int DefaultPayDate { get; set; }
        /// <summary>
        /// مبلغ کل پرداختی سند
        /// </summary>
        public decimal DocCost
        {
            get;
            set;
        }
        /// <summary>
        /// مبلغ پرداختی سند تا کنون
        /// </summary>
        public decimal SumAllCost 
        {
            get
            {
                return GetSumPayments();
            }
        }
        /// <summary>
        /// مبلغ مانده سند
        /// </summary>
        public decimal RemainCost
        {
            get
            {
                return DocCost - SumAllCost;
            }
        }
        public string DocDesc { get; set; }
        public string LocName
        {
            get
            {
                JDataBase db = JGlobal.MainFrame.GetDBO();
                try
                {
                    if (PayLoc == 0)
                        return "";
                    JSubBaseDefine define = new JSubBaseDefine(JBaseDefine.PaymentSource, PayLoc);
                    return define.Name;
                    
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        public JSDocument(int pCode)
        {
            GetData(pCode);
        }

        public JSDocument()
        {
        }

        //public static string Query = " SELECT * FROM  " + JTableNamesShareProfit.Documents;

        public Boolean GetData(int Code)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(Query + " WHERE " + JTableNamesShareProfit.Documents + ".[code] = " + Code.ToString());
                if (db.Query_DataReader())
                {
                    if (db.DataReader.Read())
                    {
                        JTable.SetToClassProperty(this, db.DataReader);
                    }
                    return db.DataReader.HasRows;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public override string ToString()
        {
            return this.DocDesc+" - "+ DocDesc + "( محل پرداخت : " + LocName + ")";
        }

        /// <summary>
        /// جستجو بر اساس دوره و شماره سند و محل پرداخت
        /// </summary>
        /// <param name="pDocNo"></param>
        /// <param name="pCourseCode"></param>
        /// <param name="pPayLoc"></param>
        /// <returns></returns>
        public Boolean find( int pCourseCode ,string pDocNo , int pPayLoc)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(Query + @" WHERE  [coursecode]=" + pCourseCode +
                "  AND [docno] = " + JDataBase.Quote(pDocNo) + " AND [payloc]=" + pPayLoc.ToString());
                if (db.Query_DataReader())
                {
                    return db.DataReader.HasRows;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

  

        public int insert()
        {
            int mCode = 0;
            //if (Code == 0)
            {
                if (find(this.CourseCode, this.DocNo, this.PayLoc))
                {
                    JMessages.Error("DocumentRepeated", "error");
                    return 0;
                }

                try
                {
                    JSDocumentTable table = new JSDocumentTable();
                    table.SetValueProperty(this);
                    mCode = table.Insert();
                    if (mCode > 0)
                    {
                        //Histroy.Save(this, table, mCode, "Insert");
                        Nodes.DataTable.Merge(JSDocuments.GetDataTable(0, mCode));
                        this.Code = mCode;
                    }
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }

            }
            return mCode;
        }

        public Boolean Update()
        {
            try
            {
                JSDocumentTable table = new JSDocumentTable();
                table.SetValueProperty(this);
                if (table.Update())
                {
                    //Histroy.Save(this, table, this.Code, "Update");
                    Nodes.Refreshdata(Nodes.CurrentNode, JSDocuments.GetDataTable(0, Code).Rows[0]);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete()
        {
            return Delete(Code);
        }
        public bool Delete(int pCode)
        {
            string[] parameters = { "@Item" };
            string[] values = { "Document" };
            string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
            if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }

            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                /// چک کردن وجود سند در پرداختها
                db.setQuery(@" Select * from sahampayment WHERE doccode=" + pCode.ToString());
                //Select  -1 AS Exs else Select 1 AS Exs ");
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JMessages.Error("DocumentHasSomeRecords", "Error");
                    return false;
                }
                this.GetData(pCode);
                JSDocumentTable table = new JSDocumentTable();
                table.SetValueProperty(this);
                if (table.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                return false;
               
            }
            finally
            {
                db.Dispose();
            }
        }

     

        public DataTable SelectAllDocs()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            DataTable table = new DataTable();
            db.setQuery(@"SELECT  sahamcourse.title CourseTitle , sahamcourse.finyear, docdate, docno, subdefine.name, docdesc, sahamcourse.Code as coursecode, sahamdocument.code as doccode,  sahamdocument.doccost
                    from sahamdocument inner join sahamcourse on sahamdocument.coursecode=sahamcourse.Code
	                left outer join subdefine on sahamdocument.payloc = subdefine.code");
            //sahamcourse.startdate, sahamcourse.enddate, sahamdocument.code,
            try
            {
                return db.Query_DataTable();
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// مجموع پرداختی برای سند 
        /// </summary>
        /// <returns></returns>
        public decimal GetSumPayments()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            db.setQuery(@"Select isNull(Sum(paycost), 0) as SumDoc from sahampayment where doccode =" + this.Code.ToString());
            try
            {
                object result = db.Query_ExecutSacler();
                if (result != null)
                    return Convert.ToDecimal(result);
                else
                    return -1;                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
                db.Dispose();
            }

        }
        /// <summary>
        /// نمایش فرم پرداخت 
        /// </summary>
        /// <param name="pCourseCode"></param>
        /// <param name="pDocCode"></param>
        public void PaymentDialog(int pCourseCode, int pDocCode)
        {
            if (JPermission.CheckPermission("ShareProfit.JSDocument.PaymentDialog"))
            {
            JPaymentForm form = new JPaymentForm(pCourseCode, pDocCode);
            form.formState = JFormState.Insert;
            form.Show();
            }
        }

        public static string Query = @" SELECT sahamdocument.*, subdefine.name  FROM [sahamdocument]  LEFT OUTER JOIN dbo.subdefine   
                    on sahamdocument.payloc = subdefine.code ";

        public JNode GetNode(DataRow pRow)
        {
             JNode node = new JNode((int)pRow["Code"], "ShareProfit.JSDocument");
            node.Name = pRow[JSDocumentEnum.docdesc.ToString()].ToString();
            node.Hint = JLanguages._Text("DocCost") + ": " + JGeneral.MoneyStr(pRow[JSDocumentEnum.doccost.ToString()].ToString());
            node.Icone = JImageIndex.MoneyDocuments.GetHashCode();

            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ShareProfit.JSDocument.ShowDialog", new object[] { node.Code }, null);

            JAction paymentAction = new JAction("PayProfit...", "ShareProfit.JSDocument.PaymentDialog", new object[] {(int)pRow[JSDocumentEnum.coursecode.ToString()], node.Code }, null);
            node.MouseDBClickAction = paymentAction;
            node.EnterClickAction = paymentAction;

            /// اکشن جدید
            JAction newAction = new JAction("New...", "ShareProfit.JSDocument.ShowDialog", new object[] { 0 }, null);

            /// اکشن حذف
            JAction delAction = new JAction("Delete...", "ShareProfit.JSDocument.Delete", new object[] { node.Code }, null);
            node.DeleteClickAction = editAction;

            node.Popup.Insert("-");
            node.Popup.Insert(newAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(delAction);
            node.Popup.Insert("-");
            node.Popup.Insert(paymentAction);

            return node;
        }


        public void ShowDialog(int pCode)
        {
            if (pCode == 0)
            {
                JDocumentForm form = new JDocumentForm();
                form.State = JFormState.Insert;
                form.ShowDialog();
            }
            else
            {
                JDocumentForm form = new JDocumentForm(pCode);
                form.State = JFormState.Update;
                form.ShowDialog();
            }
        }
    }

     public class JSDocuments : JSystem
    {
         public string OrderName = JTableNamesShareProfit.Documents + ".code";
        public JSDocument[] Items = new JSDocument[0];

        public void GetLists(string Where)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(JSDocument.Query + Where + "ORDER BY " + OrderName);
                DB.Query_DataReader();
                Array.Resize(ref Items, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Items[Count] = new JSDocument(Convert.ToInt32(DB.DataReader["code"]));
                    Count++;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public DataTable GetDataTable()
        {
            return GetDataTable(0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCourseCode, int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "WHERE 1=1 ";
                if (pCourseCode != 0)
                    WHERE = WHERE + " AND " + JTableNamesShareProfit.Documents + "." + JSDocumentEnum.coursecode.ToString() + " = " + pCourseCode.ToString();
                if (pCode != 0)
                    WHERE = WHERE + " AND " + JTableNamesShareProfit.Documents + ".Code = " + pCode;
                DB.setQuery(JSDocument.Query + WHERE + " ORDER BY docdate");
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ListView(int pCourseCode)
        {
            Nodes.clear();
            Nodes.ObjectBase = new JAction("GetCourses", "ShareProfit.JSDocument.GetNode");
            Nodes.DataTable = GetDataTable(pCourseCode, 0);

            JAction newAction = new JAction("New...", "ShareProfit.JSDocument.ShowDialog", new object[] { 0 }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }

    }
}
