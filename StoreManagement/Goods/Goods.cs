using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JGoods : JSystem
    {
        #region constructor
        public JGoods()
        {

        }
        public JGoods(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد کالا  
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام کالا  
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// نام لاتین 
        /// </summary>
        public string Latin_Name { get; set; }
        /// <summary>
        /// کد گروه 
        /// </summary>
        public int GroupCode { get; set; }
        /// <summary>
        /// نوع کالا 
        /// </summary>
        public int GoodsType { get; set; }
        /// <summary>
        /// نقطه سفارش 
        /// </summary>
        public int OrderQuantity { get; set; }
        /// <summary>
        /// حداقل 
        /// </summary>
        public int MinQuantity { get; set; }
        /// <summary>
        /// حداکثر 
        /// </summary>
        public int MaxQuantity { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime Create_Date_Time { get; set; }
        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// ایران کد
        /// </summary>
        public int IranCode { get; set; }
        /// <summary>
        /// واحد اندازه گیری
        /// </summary>
        public int Measure { get; set; }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StoreGoods where Code=" + pCode + "";
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
            string Query = @"select count(*) from  StoreGoods Where Name='" + Name + "' And GroupCode=" + GroupCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return Convert.ToInt32(db.Query_ExecutSacler()) > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (JPermission.CheckPermission("StoreManagement.JGoods.Insert"))
            {
                if (!(Find()))
                {
                        JDataBase tempDb = new JDataBase();
                        JGoodsTable JLT = new JGoodsTable();
                        try
                        {
                            tempDb.beginTransaction("EmployeeInfo");
                            JLT.SetValueProperty(this);
                            Code = JLT.Insert(tempDb);
                            if (Code > 0)
                                if (tempDb.Commit())
                                {
                                    Nodes.DataTable.Merge(JGoodss.GetDataTable(Code));
                                    return Code;
                                }
                                else
                                    return 0;

                            tempDb.Rollback("EmployeeInfo");
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                            tempDb.Rollback("EmployeeInfo");
                            return 0;
                        }
                        finally
                        {
                            tempDb.Dispose();
                            JLT.Dispose();
                        }
                    }
                    else
                        JMessages.Message(" شماره پرسنلی تکراری است ", "", JMessageType.Error);
            }
            return 0;
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("StoreManagement.JGoods.Delete"))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();                                
                JGoodsTable PDT = new JGoodsTable();
                try
                {
                    Code = pCode;
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (tmpJRelation.CheckRelation("StoreManagement.JGoods", Code, DB))
                    {
                        JMessages.Error(" برای این کالا فاکتور ثبت شده و امکان حذف وجود ندارد ", "");
                        return false;
                    }

                    
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
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
                    DB.Dispose();
                    PDT.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDataBase Db = new JDataBase();
            return Update(Db);
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
            if (JPermission.CheckPermission("StoreManagement.JGoods.Update"))
            {
                JGoodsTable PDT = new JGoodsTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        Nodes.DataTable.Merge(JGoodss.GetDataTable(Code));
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
                    PDT.Dispose();
                }
            }
            return false;
        }

        public void ShowForm()
        {
            ShowForm(0);
        }
        public void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                JGoodsForm LandForm = new JGoodsForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JGoodsForm LandForm = new JGoodsForm(pCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }


        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from  StoreGoods " + Where + " order by Name ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "StoreManagement.JGoods");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //Node.Hint = pRow["Date"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "StoreManagement.JGoods.ShowForm", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "StoreManagement.JGoods.Delete", new object[] { Node.Code }, null);
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "StoreManagement.JGoods.ShowForm", null, null);

            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            //Node.Popup.Insert(PersonAction);
            return Node;
        }
    }

    public class JGoodss : JSystem
    {
        public JGoodss[] Items = new JGoodss[0];
        public JGoodss()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable FindName(string pName)
        {
            string Where = " 1=1 ";
            if (pName != "")
                Where = Where + " And Name Like N'%" + pName + "%'";
            string Query = @"select Code,
Name,Latin_Name,
(Select Name From subdefine Where Code=GroupCode) 'Group',
(Select Name From subdefine Where Code=GoodsType) 'GoodsType',
(Select Name From subdefine Where Code=Measure) 'Measure',
OrderQuantity,MinQuantity,MaxQuantity,
case [status] when 0 then '' When 1 then '' end 'Status',
Description,
(Select Fa_Date From StaticDates Where En_Date=Cast(Create_Date_Time as date)) 'Create_Date_Time',
Price,IranCode
 from StoreGoods  Where " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select Code,
Name,Latin_Name,
(Select Name From subdefine Where Code=GroupCode) 'Group',
(Select Name From subdefine Where Code=GoodsType) 'GoodsType',
(Select Name From subdefine Where Code=Measure) 'Measure',
OrderQuantity,MinQuantity,MaxQuantity,
case [status] when 0 then '' When 1 then '' end 'Status',
Description,
(Select Fa_Date From StaticDates Where En_Date=Cast(Create_Date_Time as date)) 'Create_Date_Time',
Price,IranCode
 from StoreGoods  Where " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion GetData

        #region Node
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("StoreManagement", "StoreManagement.JGoods.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "StoreManagement.JGoods.ShowForm", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }

}
