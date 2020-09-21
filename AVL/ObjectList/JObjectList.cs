using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.ObjectList
{
    public class JObjectList:ClassLibrary.JSystem
    {
        /// <summary>
        /// each developer should add his/her new table (car,person,bus,...) to this table.
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Insert class name as AVL.ObjectList.JObjectList
        /// Insert fullname of class into database.
        /// </summary>
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public int DynamicObjectCode { get; set; }

		public DateTime RegisterDateTime { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        
        public int personCode { get; set; }
        //پرداختی
        public decimal paid { get; set; }
        //کارکرد
        public decimal cost { get; set; }
        
        public JObjectList()
        {

        }
        public JObjectList(int code)
        {
            GetData(code.ToString(), "0");
        }
        public JObjectList(System.Data.SqlClient.SqlDataReader data)
        {
            ClassLibrary.JTable.SetToClassProperty(this, data);
        }
        public JObjectList(int code,int personCode)
        {
            GetData(code.ToString(),personCode.ToString());
        }

        public static System.Data.DataTable FindByLabel(string label, int userCode)
        {
           ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
           System.Data.SqlClient.SqlDataReader dr;
            try
            {
                DB.setQuery("SELECT ObjectCode FROM AVLObjectList WHERE Type=N'" + label + "' AND personCode=" + userCode);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static JObjectList FindByObjectCode(string objectCode,string userCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = "SELECT * FROM AVLObjectList WHERE ObjectCode=" + objectCode ;
                if (int.Parse(userCode) > 0)
                    query+=" AND personCode=" + userCode;
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    AVL.ObjectList.JObjectList ol = new JObjectList();
                    ClassLibrary.JTable.SetToClassProperty(ol, DB.DataReader);
                    return ol;
                }
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.Insert"))
                return 0;
            JObjectListTable AT = new JObjectListTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();


            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.ObjectList.JObjectList", Code, 0, 0, 0, "ثبت متحرک", "", 0);
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JObjectLists.GetDataTable(Code));
            return Code;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.Delete"))
                return false;
            JObjectListTable AT = new JObjectListTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.ObjectList.JObjectList", AT.Code, 0, 0, 0, "حذف متحرک", "", 0);
                return true;
            }
            else return false;
        }
        public bool Update(bool isWeb = false,bool checkPermission=true)
        {
            bool hasperission=true;
            if(checkPermission)
                hasperission=ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.Update");
            if (!hasperission)
                return false;
            JObjectListTable AT = new JObjectListTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JObjectLists.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.ObjectList.JObjectList", AT.Code, 0, 0, 0, "ویرایش متحرک", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool GetData(string pCode,string personCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLObjectList where Code=" + pCode + " AND personCode=" + personCode);
                if(int.Parse(personCode)<1)
                    DB.setQuery("select top 1 * from AVLObjectList where Code=" + pCode);
                if (int.Parse(pCode) < 1)
                    DB.setQuery("select top 1 * from AVLObjectList where personCode=" + personCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }


    }
}
