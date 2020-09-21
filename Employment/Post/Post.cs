using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

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
        public Boolean Find(int pUnitCode, int pMetierCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT [Code] FROM empposts WHERE unitcode=" + pUnitCode.ToString() +
                            " AND metiercode = " + pMetierCode.ToString());//+ " AND activeuser = "+pActiveUser.ToString());
                DB.Query_DataReader();
                return DB.DataReader.HasRows;
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
            //if (Find(this.ClassName, this.ObjectCode, this.TreeCode) > 0)
            //    return -1;
            JEPostTable table = new JEPostTable();
            table.SetValueProperty(this);
            return table.Insert();
        }
        /// <summary>
        /// حذف پست سازمانی
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Delete(int pCode)
        {
            JEPost post = new JEPost(pCode);
            JEPostTable table = new JEPostTable();
            table.SetValueProperty(this);
            table.Delete();
            return true;
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
        public bool ShowForm()
        {
            Employment.JEPostForm form = new JEPostForm();
            form.ShowDialog();
            return true;
        }

        public JNode GetNode()
        {
            return GetNode(Code);
        }

        public JNode[] TreeView()
        {
            JNode[] J = new JNode[0];
            return J;
        }

        public JNode GetNode(int pCode)
        {
            if (GetData(pCode))
            {
                JNode Node = new JNode(Code, "Employment.JPostState");
                Node.Name = this.ToString();
                JAction DBClick = new JAction("ListView", "Employment.JEPosts.ListView");//, null, new object[] { Code }, true);
                Node.MouseDBClickAction = DBClick;
                Node.MouseClickAction = DBClick;
                return Node;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        
    }

    public class JEPosts : JSystem
    {
        public JEPost[] Items = new JEPost[0];
        public String OrderName;
        public JEPosts()
        {
            OrderName = "unitname";
        }

        public void ShowList()
        {
            JAPostsList postlist = new JAPostsList(Items);
            postlist.ShowDialog();
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

        public void ListView()
        {
            ListView(OrderName, "");
        }

        public void ListView(IDictionary<string, object> Fields)
        {
            string Where = "";
            string And = "";
            if (Fields != null)
                foreach (KeyValuePair<string, object> Field in Fields)
                {
                    Where += And + Field.Key + " Like " + JDataBase.Quote("%" + Field.Value + "%");
                    And = " AND ";
                }
            if (Where.Length > 0)
                Where = " WHERE " + Where;
            ListView(OrderName, Where);
        }

        public void ListView(string pOrderName, string Where)
        {
            OrderName = pOrderName;
            GetLists(Where);
            foreach (JEPost post in Items)
            {
                Nodes.Insert(post.GetNode(post.Code));
            }
            Nodes.GlobalMenuActions = new JPopupMenu("Employment.JEPost",0);
            Nodes.GlobalMenuActions.Insert(JEStaticAction._PostNew());
            Nodes.AddColumn("unitname");
            Nodes.AddColumn("metiername");
        }
    }

}
