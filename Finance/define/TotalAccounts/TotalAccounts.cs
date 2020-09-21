using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace Finance
{
    public enum TypeOfTotalAccounts
    {
        NoMatter=1,//مهم نیست
        Debtor=2,//بدهکار
        Creditor=3,//بستانکار


    }
    /// <summary>
    /// حساب کل
    /// </summary>
    public class JTotalAccount : JSystem
    {
        #region Constructor
        public JTotalAccount()
        {
        }
        public JTotalAccount(int pCode)
        {
            this.Getdata(pCode);
        }
        #endregion

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد حساب کل
        /// </summary>
        public int TotalAccountCode { get; set; }
        /// <summary>
        /// عنوان حساب کل
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ماهیت حساب
        /// </summary>
        public TypeOfTotalAccounts Type { get; set; }
        #endregion

        #region SearchMethod
        public bool Getdata(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qouery = "select * from " + JTableNamesFinance.TotalAccounts + " where Code=" + pCode.ToString();
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }

        }
        /// <summary>
        /// جستجو بر اساس کد حساب کل
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Find(int pCode, int pTotalAccountCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = "select * from " + JTableNamesFinance.TotalAccounts + " where TotalAccountCode= " + pTotalAccountCode.ToString() + " And Code <> " + pCode;
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }

        }
        /// <summary>
        /// جستجو بر اساس عنوان حساب کل
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public bool Find(string pName,int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = " select * from " + JTableNamesFinance.TotalAccounts + " where Name= " + pName.ToString()+" and code<>"+pCode;
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }

        }
        #endregion
        #region Method
        /// <summary>
        /// ثبت یک حساب کل
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (Find(this.Code ,this.TotalAccountCode))
            {
                JMessages.Error("کد حساب کل تکرار می باشد", "خطا در ثبت اطلاعات");
                return 0;

            }
            if (Find(this.Name,Code))
            {
                JMessages.Error("عنوان حساب کل تکراری می ابشد", "خطا در ثبت اطلاعات");
                return 0;
            }
            JTotalAccountTable TotalAccountTable = new JTotalAccountTable();
            try
            {
                
                TotalAccountTable.SetValueProperty(this);
                int Resualt = TotalAccountTable.Insert();
                if (Resualt > 0)
                {
                    this.Code = Resualt;
                    Histroy.Save(this, TotalAccountTable, Code, "Insert");
                    Nodes.DataTable.Merge(JTotalAccounts.GetDataTable(Code));
                }
                return Resualt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                TotalAccountTable.Dispose();
            }
        }
        /// <summary>
        /// به روز رسانی حساب کل
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (JPermission.CheckPermission("Finance.JTotalAccount.Update"))
            {
                if (Find(this.Code, this.TotalAccountCode))
                {
                    JMessages.Error("کد حساب کل تکرار می باشد", "خطا ذ ثبت اطلاعات");
                    return false;

                }
                if (Find(this.Name,Code))
                {
                    JMessages.Error("عنوان حساب کل تکراری می ابشد", "خطا در ثبت اطلاعات");
                    return false;
                }
                JTotalAccountTable JTAT = new JTotalAccountTable();
                try
                {
                    
                    JTAT.SetValueProperty(this);
                    if (JTAT.Update())
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JTotalAccounts.GetDataTable(Code).Rows[0]);
                        Histroy.Save(this, JTAT, Code, "Update");
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    JTAT.Dispose();
                }

            }
            else
                return false;
           
        }
        /// <summary>
        /// حذف حساب کل
        /// </summary>
        /// <returns></returns>
        public void Delete()
        {
            if (JPermission.CheckPermission("Finance.JTotalAccount.Delete"))
            {
                if ((JMessages.Question("آیا مطمئن از حذف این حساب کل هستید؟", "اخطار") != System.Windows.Forms.DialogResult.Yes))
                {
                    return;
                }
                JTotalAccountTable JTAT = new JTotalAccountTable();
                try
                {
                    JTAT.SetValueProperty(this);
                    if (JTAT.Delete())
                    {
                        Histroy.Save(this, JTAT, Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
                    }
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
                finally
                {
                    JTAT.Dispose();
                }
            }
        }
        
        #endregion
        #region ShowData
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Finance.JTotalAccount");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Finance.JTotalAccount.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Finance.JTotalAccount.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction Delete = new JAction("delete...", "Finance.JTotalAccount.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = Delete;
            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(Delete);
            return Node;
        }
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JTotalAccountsForm JTAF = new JTotalAccountsForm();
                JTAF.State = JFormState.Insert;
                JTAF.ShowDialog();

            }
            else
            {
                JTotalAccountsForm JTAF = new JTotalAccountsForm(this.Code);
                JTAF.State = JFormState.Update;
                JTAF.ShowDialog();
            }

        }
        #endregion
    }
    public class JTotalAccounts : JSystem
    {
        static string QoueryDataTable = "SELECT [Code],[TotalAccountCode],[Name],[Type] FROM "+JTableNamesFinance.TotalAccounts;
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = "";
            if (pCode > 0)
                Where = " where Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(QoueryDataTable + Where);
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
            Nodes.ObjectBase = new JAction("NewNode", "Finance.JTotalAccount.GetNode");
            Nodes.DataTable = GetDataTable(0);
            //اکشن جدید
            JAction newaction = new JAction("new...", "Finance.JTotalAccount.ShowDialog",null,null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }


}
