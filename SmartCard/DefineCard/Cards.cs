using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace SmartCard
{
    public enum JCardTypeEnum
    {
        UdDefine = 1,
        Passenger = 100,
        Driver = 101,
    }

    public class JCards : JSystem
    {
        #region constructor
        public JCards()
        {

        }
        public JCards(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from Cards where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// کد   
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// RFID
        /// </summary>
        public Int64 RfidNumber { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// نوع کارت
        /// </summary>
        public int CardType { get; set; }
        /// <summary>
        /// کد کارت
        /// </summary>
        public int CardCode { get; set; }
        /// <summary>
        /// صاحب کارت
        /// </summary>
        public int pCode { get; set; }
        /// <summary>
        /// نوع کارت مسافر
        /// </summary>
        public int PassengerCardType { get; set; }
        #endregion

        #region Method

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select Cards.*,clsAllPerson.Name PersonName
	                FROM Cards inner join clsAllPerson on clsAllPerson .Code = Cards.PCode ";
                if (pCode > 0)
                    query += " WHERE Code = " + pCode;
                DB.setQuery(query);
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

        public bool GetDataSerial(string pSerial)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from Cards where rfidnumber=" + pSerial + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
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
        public bool Find()
        {
            return Find(RfidNumber);
        }
        public bool Find(Int64 pRfidNumber)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select Count(*) from Cards Where RfidNumber=" + pRfidNumber.ToString();
                Db.setQuery(Query);
                if (Convert.ToInt32(Db.Query_ExecutSacler()) > 0)
                    return true;
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
                Db.Dispose();
            }
        }

        public int Insert()
        {
            return Insert(false);
        }
        public int Insert(bool isAdmin, bool IsWeb = false)
        {
            if (!isAdmin && !(JPermission.CheckPermission("SmartCard.JCards.Insert")))
                return -1;

            JCardsTable JPOT = new JCardsTable();
            JDataBase db = new JDataBase();
            try
            {
                if (Find())
                {
                    JMessages.Error(" این سریال کارت قبلا ثبت شده است ", "");
                    return -1;
                }
                db.beginTransaction("InsertCard");
                if (this.Status && this.pCode > 0 && this.pCode != 11000003)
                {
                    db.setQuery("update cards set Status = 0 where pCode = " + this.pCode.ToString());
                    db.Query_Execute();
                }
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(db);
                if (Code > 0)
                {
                    if (!IsWeb)
                    {
                        Nodes.DataTable.Merge(JCards.GetDataTable(Code));
                    }
                    db.Commit();
                    return Code;
                }
                else
                {
                    db.Rollback("InsertCard");
                    return 0; 
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("InsertCard");
                return 0;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Delete(bool IsWeb = false)
        {
            if (!(JPermission.CheckPermission("SmartCard.JCards.Delete")))
                return false;
            if (!IsWeb)
            {
                if (JMessages.Question("آیا میخواهید کارت انتخاب شده حذف شود؟", "") != System.Windows.Forms.DialogResult.Yes)
                    return false;
            }
            try
            {
                JCardsTable JPOT = new JCardsTable();
                JPOT.SetValueProperty(this);
                if (JPOT.Delete())
                {
                    if (!IsWeb)
                        Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Update(bool IsWeb = false)
        {
            if (!(JPermission.CheckPermission("SmartCard.JCards.Update")))
                return false;
            JCardsTable JPOT = new JCardsTable();
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("UpdateCard");
                if (this.Status && this.pCode > 0 && this.pCode != 11000003)
                {
                    db.setQuery("update cards set Status = 0 where pCode = " + this.pCode.ToString() + " and Code <> " + this.Code.ToString());
                    db.Query_Execute();
                }
                JPOT.SetValueProperty(this);
                if (JPOT.Update(db))
                {
                    if (!IsWeb)
                    {
                        Nodes.Refreshdata(Nodes.CurrentNode, JCardss.GetDataTable(Code).Rows[0]);
                    }
                    db.Commit();
                    return true;
                }
                else
                {
                    db.Rollback("UpdateCard");
                    return false; 
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("UpdateCard");
                return false;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public void ShowDialog(int pCode)
        {
            JCardsForm CF = new JCardsForm(pCode);
            if (CF.ShowDialog() == System.Windows.Forms.DialogResult.Retry)
                this.ShowDialog(0);
        }

        #endregion

        #region Node

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "SmartCard.JCards");
            Node.MouseDBClickAction = new JAction("Edit...", "SmartCard.JCards.ShowDialog", new object[] { (int)pRow["Code"] }, null);
            JAction DeleteItem = new JAction("Delete", "SmartCard.JCards.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "SmartCard.JCards.ShowDialog", new object[] { 0 }, null);
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(Node.MouseDBClickAction);
            Node.Popup.Insert(NewItem);

            return Node;
        }
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Cards";
            Node.MouseClickAction = new JAction("Cards", "SmartCard.JCardss.ListView");

            return Node;
        }
        #endregion
    }


    public class JCardss : JSystem
    {
        public JCardss()
        {
            //GetData();
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " WHERE 1=1 ";
            try
            {
                if (pCode != 0)
                    Where = Where + "  And Cards.Code=" + pCode;
                Db.setQuery(@" select 
	                Cards .Code , RfidNumber , CardCode , Status , Description 
	                , Case CardType  WHEN 100 then N'مسافر' WHEN 101 then N'راننده' else '' end CardType 
	                , clsAllPerson.Name PersonName
                    from Cards 
                 Left Join clsAllPerson ON Cards.PCode = clsAllPerson.Code  " + Where);
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
            Nodes.ObjectBase = new JAction("JCards", "SmartCard.JCards.GetNode");
            Nodes.DataTable = GetDataTable(0);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JCards", "SmartCard.JCards.ShowDialog", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;
            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "SmartCard.JCards.ShowDialog", new object[] { 0 }, null));
        }

        public JNode[] TreeView()
        {
            return null;
        }
    }


}