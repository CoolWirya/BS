using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public enum JPostStates
    {
        Active = 1, DeActive = 0
    }
   
    public class JEPersonPost :JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// کد پست
        /// </summary>
        public int PostCode { get; set; }
        /// <summary>
        /// وضعیت پست
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string ContractCode { get; set; }
        

        #endregion
        public JEPersonPost()
        {
           
        }
        
        public JEPersonPost(int pPCode)
        {
            getData(pPCode);
        }
        

        /// <summary>
        /// اشخاص مربوط به یک پست خاص را برمیگرداند
        /// </summary>
        /// <param name="PostCode"></param>
        /// <returns></returns>
        public DataTable GetPeople(int PostCode)
        {
            int[] _People = new int[0];
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery("SELECT pcode FROM personpost WHERE postcode=" + PostCode.ToString());
            return DB.Query_DataTable();
        }
        /// <summary>
        /// اضافه کردن به پستهای شخص
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            
            {
                
                JEPersonPostTable table = new JEPersonPostTable();
                table.SetValueProperty(this);
                Code=table.Insert();
                if (Code > 0)
                {
                    Histroy.Save(this, table, Code, "Insert");
                    return Code;

                }
                else
                    return 0;

            }
           
        }
        /// <summary>
        /// حذف یک پست از لیست پستهای شخص
        /// </summary>
        /// <param name="PostCode"></param>
        /// <returns></returns>
        public bool DeletePost()
        {
            JEPersonPostTable table = new JEPersonPostTable();
            table.SetValueProperty(this);
            if (table.Delete())
            {
                Histroy.Save(this, table, Code, "Delete");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// به روز رسانی اطلاعات یک پست 
        /// </summary>
        /// <returns></returns>
        public bool Upadte()
        {
            JEPersonPostTable table = new JEPersonPostTable();
            table.SetValueProperty(this);
            if (table.Update())
            {
                Histroy.Save(this, table, Code, "update");
                return true;
            }
            else
                return false;

        }
       
        /// <summary>
        /// جستجو بر اساس کد شخص 
        /// </summary>
        /// <param name="pPCode"></param>
        /// <param name="pPostCode"></param>
        /// <returns>کد شخص </returns>
        public static int Find(int pPCode)
        {
            JDataBase DB = new JDataBase();
            string Qouey = "SELECT [code] FROM "+JTableNameEmployment.PersonPostTable+" WHERE pCode=" + pPCode.ToString() +
                    " AND Active=" + JPostState.Active.GetHashCode().ToString();
            try
            {
                DB.setQuery(Qouey);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return Convert.ToInt32(DB.DataReader["code"]);
                }
                else return 0;
            }
            catch
            {
                return 0;
            }

            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// دریافت اطلاعات پست - شخص
        /// </summary>
        /// <param name="PostCode">کد پست</param>
        /// <param name="PCOde">کد شخص</param>
        /// <returns></returns>
        public Boolean getData(int Code)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qoury = "SELECT * FROM " + JTableNameEmployment.PersonPostTable + " WHERE [Code] = " + Code.ToString();
                db.setQuery(Qoury);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        #region oldcode
        ///// <summary>
        ///// پستهای مربوط به یک قرارداد خاص را برمیگرداند
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable GetContractPosts(int ContractCode)
        //{
        //    int[] _Posts = new int[0];
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    DB.setQuery("SELECT code FROM personpost WHERE contractcode=" + ContractCode.ToString());
        //    return  DB.Query_DataTable();
        //}
        ///// <summary>
        ///// نمایش فرم پست - شخص
        ///// </summary>
        //public void ShowForm()
        //{
        //    JEPersonPostForm form = new JEPersonPostForm();
        //    form.ShowDialog();
        //}

        ///// <summary>
        ///// غیر فعال کردن پست یک شخص
        ///// </summary>
        ///// <param name="pPCode"></param>
        ///// <param name="pPostCode"></param>
        ///// <returns></returns>
        //public bool DeactivePost(int pPostCode)
        //{
        //    this.Active = true;
        //    JEPersonPostTable postTable = new JEPersonPostTable();
        //    postTable.SetValueProperty(this);
        //    return postTable.Update();
        //}

        ///// <summary>
        ///// پستهای مربوط به یک شخص خاص را برمیگرداند
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable GetPersonPosts(int pPCode)
        //{
        //    int[] _Posts = new int[0];
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    DB.setQuery("SELECT code FROM personpost WHERE pcode=" + pPCode.ToString());
        //    return DB.Query_DataTable();
        //}

        //public JNode GetNode(DataRow pDR)
        //{
        //    int _code = (int)pDR["Code"];
        //    string _name = pDR["Title"].ToString();
        //    JNode Node = new JNode(_code,this.GetType().FullName);
        //    Node.Name = _name;

        //    return Node;
        //}

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
        #endregion 


        
    }

    public class JEPersonPosts : JSystem
    {
        #region Property
        /// <summary>
        /// کد شخص 
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// لیست پست های سازمانی یک شخص
        /// </summary>
        public DataTable ListPost { get; set; }
        #endregion
        #region Constructor
        public JEPersonPosts()
        {
            ListPost = GetEmptyPostTable();

        }

        public JEPersonPosts(int pCode)
        {
           ListPost=GetData(pCode);
        }
        #endregion
        #region GetDataMethod
        /// <summary>
        /// پست های سازمانی یک شخص را برمی گرداند-بر اساس کد شخص
        /// </summary>
        /// <returns></returns>
        public  DataTable GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            PersonCode = pCode;
            string Qouery = "select emppersonpost.Code, metiers.name+' '+units.name  as " + JEPersonPostEnum.PostName + "," +
                JEPersonPostEnum.PCode + "," + JEPersonPostEnum.PostCode + "," + JEPersonPostEnum.Active + ","
                +JEPersonPostEnum.DateStart+","+JEPersonPostEnum.DateEnd+","+JEPersonPostEnum.ContractCode+
                " from "+JTableNameEmployment.PersonPostTable+" inner join( "+JTableNameEmployment.PostTable+
                " inner join subdefine units on units.code = "+JTableNameEmployment.PostTable+".unitcode inner join subdefine metiers on metiers.code = "
                + JTableNameEmployment.PostTable + ".metiercode) on " + JTableNameEmployment.PersonPostTable + ".PostCode=" + JTableNameEmployment.PostTable + 
                ".code where " + JTableNameEmployment.PersonPostTable + ".PCode=" + pCode; 
            try
            {

                db.setQuery(Qouery);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// یک جدول خالی از پست های سازمانی بر می گرداند
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmptyPostTable()
        {
            return GetData(-1);
        }
        #endregion


        #region MainMethod

        public bool  SavePost(JFormState FormState)
        {
            try
            {
                if (JPermission.CheckPermission("Employment.JEPersonPost"))
                {
                    bool Flage = false;
                    foreach (DataRow Row in ListPost.Rows)
                    {

                        JEPersonPost JEPNEW;
                        if (Row.RowState == DataRowState.Added)
                        {
                            JEPNEW = new JEPersonPost();
                            JEPNEW.PCode = this.PersonCode;
                            JEPNEW.PostCode = Convert.ToInt32(Row[JEPersonPostEnum.PostCode.ToString()]);
                            JEPNEW.ContractCode = Row[JEPersonPostEnum.ContractCode.ToString()].ToString();
                            JEPNEW.Active = (bool)Row[JEPersonPostEnum.Active.ToString()];
                            JEPNEW.DateStart = Convert.ToDateTime(Row[JEPersonPostEnum.DateStart.ToString()]);
                            JEPNEW.DateEnd = Convert.ToDateTime(Row[JEPersonPostEnum.DateEnd.ToString()]);
                            if (JEPNEW.Insert() > 0)
                                Flage = true;

                        }
                        else if (Row.RowState == DataRowState.Deleted)
                        {
                            Row.RejectChanges();
                            if (Row[JEPersonPostEnum.Code.ToString()] != DBNull.Value)
                            {
                                JEPNEW = new JEPersonPost((int)Row[JEPersonPostEnum.Code.ToString()]);
                                if (JEPNEW.DeletePost())
                                    Flage = true;
                                Row.Delete();

                            }
                            else
                                Row.Delete();
                        }
                        else if (Row.RowState == DataRowState.Modified)
                        {
                            if (Row[JEPersonPostEnum.Code.ToString()] != DBNull.Value)
                            {
                                JEPNEW = new JEPersonPost((int)Row[JEPersonPostEnum.Code.ToString()]);
                                JEPNEW.ContractCode = Row[JEPersonPostEnum.ContractCode.ToString()].ToString();
                                JEPNEW.Active = (bool)Row[JEPersonPostEnum.Active.ToString()];
                                JEPNEW.DateStart = Convert.ToDateTime(Row[JEPersonPostEnum.DateStart.ToString()]);
                                JEPNEW.DateEnd = Convert.ToDateTime(Row[JEPersonPostEnum.DateEnd.ToString()]);
                                Flage=JEPNEW.Upadte();

                            }
                        }


                    }
                    if (Flage == true)
                    {
                        if (FormState == JFormState.Insert)
                        {
                            Nodes.DataTable.Merge(GetDataTable(PersonCode));
                            return true;
                        }
                        else 
                        {
                            Nodes.Refreshdata(Nodes.CurrentNode,GetDataTable(PersonCode).Rows[0]);
                            return true;
                        }

                    }
                    else
                    {
                        JMessages.Error("Information Not Changed.", "error");
                        return false;

                    }
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
        /// <summary>
        /// کلیه پست های یک شخص را حذف میکند
        /// </summary>
        /// <returns></returns>
        public bool DelPosts()
        {
            try
            {
                if (JPermission.CheckPermission("Employment.JEPersonPost"))
                {
                    bool Flage = false;
                    foreach (DataRow Row in ListPost.Rows)
                    {
                        JEPersonPost JEPNEW=new JEPersonPost((int)Row[JEPersonPostEnum.Code.ToString()]);
                        if(JEPNEW.DeletePost())
                           Flage=true;

                    }
                    if (Flage == true)
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        return Flage;
                    }
                    else
                        return Flage;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
                

        }

        #endregion

        #region ShowMethod

        public void ShowDialog()
        {
            if (PersonCode < 0)
            {
                JEPersonPostForm JEPPF = new JEPersonPostForm();
                JEPPF.State = JFormState.Insert;
                JEPPF.ShowDialog();
            }
            else
            {
                JEPersonPostForm JEPPF = new JEPersonPostForm(PersonCode);
                JEPPF.State = JFormState.Update;
                JEPPF.ShowDialog();

            }

        }

       
        public JNode GetNode(DataRow pRow)
        {
            int NCode=((int)pRow[JEPersonPostEnum.PCode.ToString()]);
            JNode Node = new JNode(NCode, "Employment.JEPersonPosts");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            JAction EditAction = new JAction("edit...", "Employment.JEPersonPosts.ShowDialog", null, new object[] { NCode });
            Node.MouseDBClickAction = EditAction;
            Node.EnterClickAction = EditAction;
            JAction DelAction = new JAction("delete...", "Employment.JEPersonPosts.DelPosts", null, new object[] { NCode });
            Node.DeleteClickAction = DelAction;
            JAction NewAction = new JAction("new...", "Employment.JEPersonPosts.ShowDialog", null, null);
            Node.Popup.Insert(DelAction);
            Node.Popup.Insert(EditAction);
            Node.Popup.Insert(NewAction);
            return Node;


        }
        #endregion
        /// <summary>
        /// لیست اشخاص دارای پست سازمانی را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(int pCode)
        {
            string Where="";
            if(pCode>0)
                Where=" where PCode="+pCode;
            string SelectQoury = "select distinct "+JEPersonPostEnum.PCode+",clsAllPerson.Name from "
            +JTableNameEmployment.PersonPostTable+"  inner join clsAllPerson on clsAllPerson.Code="
            +JTableNameEmployment.PersonPostTable+"."+JEPersonPostEnum.PCode+Where;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQoury);
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

        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("PersonPosts", "Employment.JEPersonPosts.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction NewAction = new JAction("new...", "Employment.JEPersonPosts.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(NewAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Hint = "new...";
            JTN.Click = NewAction;
            Nodes.AddToolbar(JTN);

            
        }

        public JNode[] TreeView()
        {
            return null;
        }
    }
}
