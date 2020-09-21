using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Finance
{
    public enum TypeOfLedgerAccount
    {
        NoMather=1,//مهم نیست
        DuringDebtor=2,//بدهکار طی دوره
        DuringCreditor=3,//بستانکار طی دوره
        EndDebtor=4,//بدهکار پایان دوره
        EndCreditor=5,//بستانکار پایان دوره

    }
    class JLedgerAccount:JSystem
    {
        #region Constructor
        public JLedgerAccount()
        {
        }
        public JLedgerAccount(int pCode)
        {
            
        }
        #endregion
        #region property
        public int Code { get; set; }
        /// <summary>
        /// کدحساب معین
        /// </summary>
        public int LedgerAccountCode { get; set; }
        /// <summary>
        /// کد حساب کل
        /// </summary>
        public int TotalAccountCode { get; set; }
        /// <summary>
        /// عنوان حساب معین
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ماهیت حساب
        /// </summary>
        public TypeOfLedgerAccount Type { get; set; }
        #endregion
        #region SearchMethod
        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qouery = "select * from " + JTableNamesFinance.LedgerAccount + " Code=" + pCode;
                Db.setQuery(Qouery);
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
        /// جستجو بر اساس کد حساب معین
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="LedgerAccountCode"></param>
        /// <param name="TotalAcoountCode"></param>
        /// <returns></returns>
        public bool Find(int pCode, int LedgerAccountCode, int TotalAcoountCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qouery = "select * from " + JTableNamesFinance.LedgerAccount +
                    " where Code<>" + pCode + " and LedgerAccountCode=" + LedgerAccountCode +
                    " and TotalAccountCode=" + TotalAcoountCode;
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                    return true;
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
        /// جستجو بر اساس عنوان حساب معین
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="LedgerAccountCode"></param>
        /// <param name="TotalAcoountCode"></param>
        /// <returns></returns>
        public bool Find(int pCode, string Name)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qouery = "select * from " + JTableNamesFinance.LedgerAccount +
                    " where Code<>" + pCode + " and Name=" + Name;
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                    return true;
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
        public int Insert()
        {
            if(this.Find(this.Code,this.Name))
            {
                
                JMessages.Error("عنوان حساب معین تکراری می باشد.", "خطا در ثبت اطلاعات");
                return 0;
            }
            if(this.Find(this.Code,this.LedgerAccountCode,this.TotalAccountCode))
            {
                
                JMessages.Error("کد حساب معین تکرار می باشد", "خطا در ثبت اطلاعات");
                return 0;
            }
            try
            {
                JLedgerAccountTable JLAT=new JLedgerAccountTable();
                JLAT.SetValueProperty(this);
                int result=JLAT.Insert();
                if(result>0)
                {
                    this.Code=result;
                    Histroy.Save(this,JLAT,result,"insert");
                }
                return result;
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
          

        }
        public bool Update()
        {
            if (this.Find(this.Code, this.Name))
            {

                JMessages.Error("عنوان حساب معین تکراری می باشد.", "خطا در ثبت اطلاعات");
                return false;
            }
            if (this.Find(this.Code, this.LedgerAccountCode, this.TotalAccountCode))
            {

                JMessages.Error("کد حساب معین تکرار می باشد", "خطا در ثبت اطلاعات");
                return false;
            }
            try
            {
                JLedgerAccountTable JLAT = new JLedgerAccountTable();
                JLAT.SetValueProperty(this);
                if (JLAT.Update())
                {
                    Histroy.Save(this, JLAT,Code,"update");
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
            JLedgerAccountTable JTN = new JLedgerAccountTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotary.Delete"))
                {
                    JTN.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && JTN.Delete())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(this, JTN, Code, "Delete");
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JTN.Dispose();
            }
        }
        #endregion
        #region ShowDate
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JLedgerAccountForm JNF = new JLedgerAccountForm();
                JNF.State = JFormState.Insert;
                JNF.ShowDialog();
            }
            else
            {
                JLedgerAccountForm JNF = new JLedgerAccountForm(this.Code);
                JNF.State = JFormState.Update;
                JNF.ShowDialog();
            }
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JLedgerAccountEnum.Code.ToString()], "Finance.JLedgerAccount");
            Node.Name = pRow[JLedgerAccountEnum.Name.ToString()] + "-" + pRow[JLedgerAccountEnum.TotalAccountCode.ToString()] + "-" + pRow[JLedgerAccountEnum.LedgerAccountCode.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Finance.JLedgerAccount.Insert", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Finance.JLedgerAccount.Update", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Finance.JLedgerAccount.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;
            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);
            return Node;

        }
        #endregion

     


    }

    public class JLedgerAccounts : JSystem
    {


    }
}
