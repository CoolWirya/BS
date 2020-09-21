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
        public int State { get; set; }
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
        public int ContractCode { get; set; }
        /// <summary>
        /// اطلاعات شخص
        /// </summary>

        /// <summary>
        /// پستهای شخص
        /// </summary>
        public int[] PersonPosts
        {
            get
            {
                return GetPersonPosts(PCode);
            }
        }
        #endregion

        public JEPersonPost(int pPCode)
        {
            PCode = pPCode;
        }
        /// <summary>
        /// پستهای مربوط به یک قرارداد خاص را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static int[] GetContractPosts(int ContractCode)
        {
            int[] _Posts = new int[0];
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery("SELECT code FROM personpost WHERE contractcode=" + ContractCode.ToString());
            DB.Query_DataReader();
            int Count = 0;
            while (DB.DataReader.Read())
            {
                _Posts[++Count] = Convert.ToInt32(DB.DataReader[0]);
            }
            return _Posts;
        }
        /// <summary>
        /// پستهای مربوط به یک شخص خاص را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static int[] GetPersonPosts(int pPCode)
        {
            int[] _Posts = new int[0];
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery("SELECT code FROM personpost WHERE pcode=" + pPCode.ToString());
            DB.Query_DataReader();
            int Count = 0;
            while (DB.DataReader.Read())
            {
                _Posts[++Count] = Convert.ToInt32(DB.DataReader[0]);
            }
            return _Posts;
        }
        /// <summary>
        /// اشخاص مربوط به یک پست خاص را برمیگرداند
        /// </summary>
        /// <param name="PostCode"></param>
        /// <returns></returns>
        public int[] GetPeople(int PostCode)
        {
            int[] _People = new int[0];
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            DB.setQuery("SELECT pcode FROM personpost WHERE postcode=" + PostCode.ToString());
            DB.Query_DataReader();
            int Count = 0;
            while (DB.DataReader.Read())
            {
                _People[++Count] = Convert.ToInt32(DB.DataReader[0]);
            }
            return _People;
        }
        /// <summary>
        /// اضافه کردن به پستهای شخص
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (Find(PCode, PostCode) > 0)
                return 0;
            JEPersonPostTable table = new JEPersonPostTable();
            table.SetValueProperty(this); 
            table.Insert();
            return Code;
        }
        /// <summary>
        /// حذف پست از لیست پستهای شخص
        /// </summary>
        /// <param name="PostCode"></param>
        /// <returns></returns>
        public bool DeletePost(int pPostCode)
        {
            JEPersonPostTable table = new JEPersonPostTable();
            PostCode = pPostCode;
            table.SetValueProperty(this);
            table.Delete();
            return true;
        }
        /// <summary>
        /// غیر فعال کردن پست یک شخص
        /// </summary>
        /// <param name="pPCode"></param>
        /// <param name="pPostCode"></param>
        /// <returns></returns>
        public int DeactivePost(int pPostCode)
        {
            this.State = JContractState.DeactiveContract.GetHashCode();
            JEPersonPostTable postTable = new JEPersonPostTable();
            postTable.SetValueProperty(this);
            //update = postTable.Update();
            return 0;
        }
        /// <summary>
        /// جستجو بر اساس کد شخص و کد پست
        /// </summary>
        /// <param name="pPCode"></param>
        /// <param name="pPostCode"></param>
        /// <returns>کد شخص - پست</returns>
        public int Find(int pPCode, int pPostCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT [code] FROM personpost WHERE pCode=" + pPCode.ToString() + " AND postcode=" + pPostCode.ToString() +
                    " AND State=" + JPostState.Active.GetHashCode().ToString());
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
                db.setQuery("SELECT * FROM personpost WHERE [Code] = " + Code.ToString());
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
        /// <summary>
        /// نمایش فرم پست - شخص
        /// </summary>
        public void ShowForm()
        {
            JEPersonPostForm form = new JEPersonPostForm();
            form.ShowDialog();
        }
        public void ListView(JTreeTypes treeType)
        {
            Nodes.Insert(JEStaticNode._PersonOrganizationPost());
        }
        public JNode[] TreeView()
        {
            JNode[] N = new JNode[1];
            N[0] = new JNode(0, "Employment.JPersonPost");
            N[0].Name = "PersonPost";
            return N;
        }
    }
}
