using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace Employment
{
    public enum JPostState
    {
        Active = 1,
        DeActive = 0
    }
    /// <summary>
    /// کلاس پست سازمانی تشکیل شده از واحد سازمانی و عنوان شغلی
    /// </summary>
    public class JEPost : JSystem
    {
        public int Code { get; set; }
        /// <summary>
        /// کد واحد سازمانی
        /// </summary>
        public int UnitCode { get; set; }
        /// <summary>
        /// کد عنوان شغل
        /// </summary>
        public int MetierCode { get; set; }
        /// <summary>
        /// وضعیت فعال یا غیر فعال بودن
        /// </summary>
        public JPostState State { get; set; }
        /// <summary>

        public string UnitName;
        public string MetierName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        public JEPost(int pCode)
        {
            GetData(pCode);
        }
        public JEPost()
        {
        }

        public override string ToString()
        {
            return MetierName + " " + UnitName;
        }
        /// <summary>
        /// جستجوی پست سازمانی برای شخص خاص
        /// </summary>
        /// <param name="pUnitCode"></param>
        /// <param name="pMetierCode"></param>
        /// <param name="pActiveUser"></param>
        /// <returns></returns>
        public int Find(int pUnitCode, int pMetierCode)
        {
            return Find(pUnitCode, pMetierCode, 0);
        }
        public int Find(int pUnitCode, int pMetierCode, int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [Code] FROM empposts WHERE unitcode=" + pUnitCode.ToString() +
                            " AND metiercode = " + pMetierCode.ToString() + " AND Code <>" + pCode);
                DB.Query_DataReader();
                if (DB.DataReader.HasRows)
                {
                    JMessages.Error("این سمت قبلا تعریف شده است", "error");
                    DB.DataReader.Read();
                    return (int)DB.DataReader["Code"];
                }
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// لیست همه افراد در پست سازمانی خاص
        /// </summary>
        /// <param name="pUnitCode">واحد سازمانی</param>
        /// <param name="pMetierCode">عنوان شغلی</param>
        /// <param name="pGetActiveUsers">در صورتی که درست باشد کاربران فعال را هم برمیگرداند </param>
        /// <returns></returns>
        public int[] GetAllUsers(int pUnitCode, int pMetierCode)
        {
            int[] _UserCodes = new int[0];
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string _Query = "SELECT * FROM  empposts  WHERE unitcode=" + pUnitCode.ToString() +
                            " AND metiercode = " + pMetierCode.ToString();

                DB.setQuery(_Query);
                DB.Query_DataReader();
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Array.Resize(ref _UserCodes, ++Count);
                    _UserCodes[Count - 1] = Convert.ToInt32(DB.DataReader["activeuser"]);
                }
                return _UserCodes;
            }
            finally
            {
                DB.Dispose();
            }

        }
        /// <summary>
        /// درج در پست سازمانی
        /// </summary>
        /// <returns></returns>        
        public int Insert()
        {
            int DefaultCode = 999;
            if (Find(UnitCode, MetierCode) > 0)
                return 0;
            if (JPermission.CheckPermission("Employment.JEPost.Insert"))
            {
                JEPostTable table = new JEPostTable();
                table.SetValueProperty(this);
                Code=table.Insert(DefaultCode);
                if (Code>0)
                {
                    Histroy.Save(this, table, Code, "insert");
                    Nodes.DataTable.Merge(JEPosts.GetData(Code));
                    return Code;
                }
                return 0;
            }
            else
                return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (Find(UnitCode, MetierCode, Code) > 0)
                return false;
            if (JPermission.CheckPermission("Employment.JEPost.Update"))
            {
                JEPostTable table = new JEPostTable();
                table.SetValueProperty(this);
                if (table.Update())
                {
                    Histroy.Save(this, table, Code, "Upadate");
                    Nodes.Refreshdata(Nodes.CurrentNode,JEPosts.GetData(this.Code).Rows[0]);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// حذف پست سازمانی
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Delete()
        {
            string[] parameters = { "@Item" };
            string[] values = { "Post" };
            string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
            if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }
            if (JPermission.CheckPermission("Employment.JEPost.Delete"))
            {
                JEPostTable table = new JEPostTable();
                table.SetValueProperty(this);
                if (table.Delete())
                {
                    Histroy.Save(this, table, Code, "Delete");
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean GetData(int pCode)
        {
            Code = pCode;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM empposts WHERE code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    if (DB.DataReader.HasRows)
                    {
                        JTable.SetToClassProperty(this, DB.DataReader);
                        return true;
                    }
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JEPostForm JEPF = new JEPostForm();
                JEPF.State = JFormState.Insert;
                JEPF.ShowDialog();
            }
            else
            {
                JEPostForm JEPF = new JEPostForm(Code);
                JEPF.State = JFormState.Update;
                JEPF.ShowDialog();
            }
        }

        public bool ShowForm()
        {
            return ShowForm(0);
        }
        public bool ShowForm(int pCode)
        {
            Employment.JEPostForm form = new JEPostForm(pCode);
            form.ShowDialog();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDR"></param>
        /// <returns></returns>
        public JNode GetNode(System.Data.DataRow pDR)
        {
            string _name = pDR["MetierName"].ToString() + " " + pDR["UnitName"].ToString();
            int _code = (int)pDR["Code"];
            JNode Node = new JNode(Code, "Employment.JPostState");
            Node.Code = _code;
            Node.Name = _name;
            JAction Edit = new JAction("edit...", "Employment.JEPost.ShowDialog",null , new object[] { _code });
            Node.MouseDBClickAction = Edit;
            Node.MouseClickAction = Edit;
            JAction NewAction = new JAction("New...", "Employment.JEPost.ShowDialog", null, null);
            JAction DelAction = new JAction("delete...", "Employment.JEPost.Delete",null ,new object[] { _code });
            Node.DeleteClickAction = DelAction;
            JPopupMenu JPM = new JPopupMenu("Employment.JEPost", _code);
            JPM.Insert(DelAction);
            JPM.Insert(Edit);
            JPM.Insert(NewAction);
            Node.Popup = JPM;
            return Node;
        }
        
    }

    public class JEPosts : JSystem
    {
        public JEPost[] Items = new JEPost[0];
        public static String OrderName;
        public JEPosts()
        {
            OrderName = "unitname";
            GetLists();
        }

        public void ShowList()
        {
        }

        public void GetLists()
        {
            GetLists("");
        }
        public void GetLists(string Where)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + @"posts.code, unitcode, metiercode, state, units.name unitname, metiers.name metiername  from empposts posts
                    left outer join subdefine units on units.code = posts.unitcode
                    left outer join subdefine metiers on metiers.code = posts.metiercode"
                    + Where +
                    " ORDER BY " + OrderName);
                DB.Query_DataReader();
                Array.Resize(ref Items, DB.RecordCount);
                int Count = 0;
                while (DB.DataReader.Read())
                {
                    Items[Count] = new JEPost();
                    JTable.SetToClassProperty(Items[Count], DB.DataReader);
                    Items[Count].MetierName = DB.DataReader["metiername"].ToString();
                    Items[Count].UnitName = DB.DataReader["unitname"].ToString(); 
                    Count++;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetData(int pCode)
        {
            string Where = "";
            if (pCode > 0)
                Where = " where posts.code=" + pCode;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Qoury = @"SELECT TOP " + JGlobal.MainFrame.GetConfig().MaxLenghList + @"posts.code, unitcode, metiercode, state, units.name unitname, metiers.name metiername  from empposts posts
                    left outer join subdefine units on units.code = posts.unitcode
                    left outer join subdefine metiers on metiers.code = posts.metiercode";
                    
                DB.setQuery(Qoury+Where);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public  DataTable GetData()
        {
            return GetData(0);

        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetNode", "Employment.JEPost.GetNode");
            Nodes.DataTable = GetData();
            JAction NewAction = new JAction("new...", "Employment.JEPost.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(NewAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Hint = "new...";
            JTN.Click = NewAction;
            Nodes.GlobalMenuActions.Insert(NewAction);
            Nodes.AddToolbar(JTN);
        }
    }

}
