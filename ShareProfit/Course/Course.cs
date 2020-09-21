using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data.SqlClient;
using System.Data;

namespace ShareProfit
{
    public class JCourse : JSystem
    {

        public JCourse(int pCode)
        {

            if (pCode > 0)
            {
                getData(pCode);
            }

        }

		public void ShowDialogs()
		{
			ShareProfitReportForm spf = new ShareProfitReportForm();
			spf.ShowDialog();
		}

        /// <summary>
        /// کد دوره
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// عنوان دوره
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// سال مالی
        /// </summary>
        public int FinYear { get; set; }
        /// <summary>
        /// مبلغ سود هر سهم
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// تاریخ تصویب
        /// </summary>
        public string ApproveDate { get; set; }
        /// <summary>
        /// پرداخت نقدی
        /// </summary>
        public bool Pocket { get; set; }
        /// <summary>
        /// نوع پرداخت
        /// </summary>
        public int PaymentType { get; set; }
        /// <summary>
        /// مبلغ پایه
        /// </summary>
        public decimal BaseCost { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// خواندن اطلاعات سهام از نرم افزار سهام بصورت آنلاین
        /// </summary>
        public bool OnlinePayment { get; set; }
        /// <summary>
        /// از شماره برگه
        /// </summary>
        public int FromSheet { get; set; }
        /// <summary>
        /// تا شماره برگه
        /// </summary>
        public int ToSheet { get; set; }
        /// <summary>
        /// تعداد سهم
        /// </summary>
        public int ShareCount { get; set; }
        /// <summary>
        /// شرکت
        /// </summary>
        public int CompanyCode { get; set; }



        public string SheetTable
        {
            get
            {
                if (this.OnlinePayment)
                    return "ShareSheet";
                else
                    return "(select * from SahamSheet where CoursePaymentCode = " + this.Code.ToString()+")";
            }
        }
        
        
        public JCourse()
        {
           
        }
        

        /// <summary>
        /// جستجو بر اساس کد دوره
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT [code] FROM " + JTableNamesShareProfit.Cources + " WHERE [code] = " + pCode.ToString());
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
        /// <summary>
        /// جستجو بر اساس تاریخ شروع و پایان و سال مالی
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean find(string pStartDate, string pEndDate, int pFinYear)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"SELECT [code] FROM " + JTableNamesShareProfit.Cources + " WHERE [startdate] = " + JDataBase.Quote(pStartDate) +
                            " AND [enddate]=" + JDataBase.Quote(pEndDate) + " AND [finyear]=" + pFinYear.ToString());
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

        /// <summary>
        /// درج یک دوره جدید
        /// </summary>
        /// <returns></returns>
        public int insert()
        {
            int mCode = 0;
            if (Code == 0)
            {
                //if (this.StartDate.CompareTo(this.EndDate) > 0)
                //{
                //    JMessages.Error("StartDateBiggerThanEndDate", "InputError");
                //    return mCode;
                //}
                if (this.FinYear > 9999 || this.FinYear < 1000)
                {
                    JMessages.Error("InputYear4Digit", "InputError");
                    return mCode;
                }

                if (find(this.StartDate, this.EndDate, this.FinYear))
                {
                    JMessages.Error("CourseRepeated", "error");
                    return 0;
                }

                JCourseTable table = new JCourseTable();
                table.SetValueProperty(this);
                Code = table.Insert();
                if (Code > 0)
                {
                    Histroy.Save(this, table, Code, "Insert");
                    Nodes.DataTable.Merge(JCourses.GetDataTable(Code));
                    return Code;
                }
 
            }
            return 0;
        }
        /// <summary>
        /// ویرایش اطلاعات دوره
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            if (find(Code))
            {
                JCourseTable crsTable = new JCourseTable();
                crsTable.SetValueProperty(this);
                if (crsTable.Update())
                {
                    //Histroy.Save(this, crsTable, Code, "Update");
                    Nodes.Refreshdata(Nodes.CurrentNode, JCourses.GetDataTable(Code).Rows[0]);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// حذف
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string[] parameters = { "@Item" };
            string[] values = { "Course" };
            string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
            if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
            {
                return -1;
            }
            JDataBase db = JGlobal.MainFrame.GetDBO();
            if (find(this.Code))
            {
                try
                {
                    db.setQuery(@" if exists (Select * from sahamdocument WHERE coursecode=" + this.Code.ToString() + @")
                        Select  -1 AS Exs else Select 1 AS Exs ");
                    if ((int)db.Query_ExecutSacler() == -1)
                    {
                        JMessages.Error("CourseHasDocument", "Error");
                        return -1;
                    }
                    JCourseTable table = new JCourseTable();
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        db.setQuery(@"delete from SahamSheet where CoursePaymentCode="+ this.Code);
                        db.Query_Execute();
                        Nodes.Delete(Nodes.CurrentNode);
                        return 1;
                    }
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return 0;
                }
                finally
                {
                    db.Dispose();
                }
            }
            else
                return 0;
        }
        /// <summary>
        /// بررسی برابر بودن دو دوره
        /// </summary>
        /// <param name="course1"></param>
        /// <param name="course2"></param>
        /// <returns></returns>
        //public static bool operator ==(JCourse course1, JCourse course2)
        //{
        //    if (course1.StartDate == course2.StartDate && course1.EndDate == course2.EndDate && course1.StartDate == course2.EndDate)
        //        return true;
        //    return false;
        //}
        //public static bool operator !=(JCourse course1, JCourse course2)
        //{
        //    if (course1.StartDate != course2.StartDate || course1.EndDate != course2.EndDate || course1.StartDate != course2.EndDate)
        //        return true;
        //    return false;
        //}

        //public static void SetEqual(JCourse course1,ref JCourse course2)
        //{
        //    course2.Code = course1.Code;
        //    course2.Title = course1.Title;
        //    course2.StartDate = course1.StartDate;
        //    course2.EndDate = course1.EndDate;
        //    course2.FinYear = course1.FinYear;
        //}

        public override string ToString()
        {
            return this.Title;
        }

        public static string SelectQuery = " SELECT * FROM  " + JTableNamesShareProfit.Cources;

        public bool getData(int pCode)
        {
            string _SQL = SelectQuery + " WHERE Code=" + pCode.ToString();

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "ShareProfit.JCourse");
            node.Name = pRow[JCourseEnum.title.ToString()].ToString();
            node.Hint = JLanguages._Text("CostBenefit") + ": " + JGeneral.MoneyStr(pRow[JCourseEnum.cost.ToString()].ToString());
            node.Icone = JImageIndex.Courses.GetHashCode();
            node.Code = (int)pRow["Code"];

            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ShareProfit.JCourse.ShowDialog", null, new object[] { node.Code });
            
            /// لیست اسناد

            /// اکشن جدید
            JAction newAction = new JAction("New...", "ShareProfit.JCourse.ShowDialog", null, null);

            /// اکشن حذف
            JAction delAction = new JAction("Delete...", "ShareProfit.JCourse.Delete", null, new object[] { node.Code });
            node.DeleteClickAction = editAction;
            
            ///لیست اسناد
            node.MouseDBClickAction = editAction;
            
            node.Popup.Insert(newAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(delAction);
            //node.Popup.Insert(docAction);

            return node;
        }

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JCourseForm form = new JCourseForm();
                form.State = JFormState.Insert;
                form.ShowDialog();
            }
            else
            {
                JCourseForm form = new JCourseForm(this.Code);
                form.State = JFormState.Update;
                form.ShowDialog();
            }
        }
    }


    public class JCourses : JSystem
    {
        public string OrderName = "finyear";
        public JCourse[] Items = new JCourse[0];

        public void GetLists(string Where)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(JCourse.SelectQuery+ Where + " ORDER BY " + OrderName);
                DB.Query_DataReader();
                Array.Resize(ref Items, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Items[Count] = new JCourse((int)DB.DataReader["Code"]);
                    //Items[Count] = JCourse.FindCourse(DB.DataReader);
                    //JTable.SetToClassProperty(Items[Count], DB.DataReader);
                    Count++;
                }
            }
            finally
            {
                DB.Dispose();                
            }
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "";
                if (pCode != 0)
                    WHERE = " WHERE " + JTableNamesShareProfit.Cources + ".Code = " + pCode;
                DB.setQuery(JCourse.SelectQuery + WHERE);
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

        public static DataTable GetCompanyDataTable(int pCompanyCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "";
                if (pCompanyCode != 0)
                    WHERE = " WHERE " + JTableNamesShareProfit.Cources + ".CompanyCode = " + pCompanyCode;
                DB.setQuery(JCourse.SelectQuery + WHERE);
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

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetCourses", "ShareProfit.JCourse.GetNode");
            Nodes.DataTable = GetDataTable();


            JAction newAction = new JAction("New...", "ShareProfit.JCourse.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

        }

        public JNode[]  TreeView()
        {
            DataTable courses= GetDataTable();
            JNode[] gNodes = new JNode[0];
            int i=0;
            foreach (DataRow row in courses.Rows)
            {
                Array.Resize(ref gNodes, i + 1);

                JNode node = new JNode((int)row["Code"], "ShareProfit.JCourse");
                node.Name = row[JCourseEnum.title.ToString()].ToString();
                node.Hint = JLanguages._Text("CostBenefit") + ": " + JGeneral.MoneyStr(row[JCourseEnum.cost.ToString()].ToString());
                node.Icone = JImageIndex.Courses.GetHashCode();
                node.Code = (int)row["Code"];

                /// اکشن ویرایش
                JAction Action = new JAction("Edit...", "ShareProfit.JPayments.ListView", null, new object[] { node.Code });

                ///لیست اسناد
                node.MouseClickAction = Action;

                gNodes[i] = node;
                i++;
            }
            return gNodes;
        }

    }
}
