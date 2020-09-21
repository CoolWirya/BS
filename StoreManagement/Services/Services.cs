using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JServices: JSystem   
    {
        #region constructor
        public JServices()
        {

        }
        public JServices(int pCode)
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
        /// کد گروه 
        /// </summary>
        public int GroupCode { get; set; }        
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
        /// واحد اندازه گیری
        /// </summary>
        public int Measure { get; set; }
        /// <summary>
        /// نوع سرویس
        /// </summary>
        public int ServiceType { get; set; }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StoreServices where Code=" + pCode + "";
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
            string Query = @"select count(*) from  StoreServices Where Name=N'" + Name + "' And GroupCode=" + GroupCode;
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
            if (JPermission.CheckPermission("StoreManagement.JServices.Insert"))
            {
                if (!(Find()))
                {
                    JServicesTable JLT = new JServicesTable();
                    try
                    {
                        JLT.SetValueProperty(this);
                        Code = JLT.Insert();
                        if (Code > 0)
                        {
                            Nodes.DataTable.Merge(JServicess.GetDataTable(Code));
                            return Code;
                        }
                        else
                            return 0;

                        return 0;
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        return 0;
                    }
                    finally
                    {
                        JLT.Dispose();
                    }
                }
                else
                    JMessages.Message(" نام خدمات تکراری است ", "", JMessageType.Error);
            }
            return 0;
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("StoreManagement.JServices.Delete"))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JServicesTable PDT = new JServicesTable();
                try
                {
                    //PDT.SetValueProperty(this);

                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (tmpJRelation.CheckRelation("StoreManagement.JServices", pCode, DB))
                    {
                        JMessages.Error(" برای این کالا فاکتور ثبت شده و امکان حذف وجود ندارد ", "");
                        return false;
                    }
                    PDT.Code = pCode;
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
            if (JPermission.CheckPermission("StoreManagement.JServices.Update"))
            {
                JServicesTable PDT = new JServicesTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        Nodes.DataTable.Merge(JServicess.GetDataTable(Code));
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
                JServicesForm LandForm = new JServicesForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JServicesForm LandForm = new JServicesForm(pCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from  StoreServices " + Where;
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
            JNode Node = new JNode((int)pRow["Code"], "StoreManagement.JServices");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            //Node.Hint = pRow["Date"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "StoreManagement.JServices.ShowForm", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "StoreManagement.JServices.Delete", new object[] { Node.Code }, null);
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "StoreManagement.JServices.ShowForm", null, null);

            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            //Node.Popup.Insert(PersonAction);
            return Node;
        }
    }
    public class JServicess : JSystem
    {
        public JServicess[] Items = new JServicess[0];
        public JServicess()
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
            string Query = @"select Code,Name,
(Select Name From subdefine Where Code=GroupCode) 'Group',
(Select Name From subdefine Where Code=ServiceType) 'ServiceType',
(Select Name From subdefine Where Code=Measure) 'Measure',
case [status] when 0 then '' When 1 then '' end 'Status',
Description,
(Select Fa_Date From StaticDates Where En_Date=Cast(Create_Date_Time as date)) 'Create_Date_Time',
Price
 from StoreServices  Where " + Where;
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
            string Query = @"select Code,Name,
(Select Name From subdefine Where Code=GroupCode) 'Group',
(Select Name From subdefine Where Code=ServiceType) 'ServiceType',
(Select Name From subdefine Where Code=Measure) 'Measure',
case [status] when 0 then '' When 1 then '' end 'Status',
Description,
(Select Fa_Date From StaticDates Where En_Date=Cast(Create_Date_Time as date)) 'Create_Date_Time',
Price
 from StoreServices  Where " + Where;
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
            Nodes.ObjectBase = new JAction("StoreManagement", "StoreManagement.JServices.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "StoreManagement.JServices.ShowForm", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }
}
