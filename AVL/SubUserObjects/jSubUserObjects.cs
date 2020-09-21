using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.SubUserObjects
{
    public class jSubUserObjects : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public int parentUserCode { get; set; }
        public int userCode { get; set; }
       public string objects { get; set; }


       public jSubUserObjects()
       {

       }
        public jSubUserObjects(string ParentUserCode, string UserCode)
        {
            GetData(ParentUserCode, UserCode);
        }

        public int Insert(bool checkPermission, bool isWeb = false)
        {
            bool haspermission = true;
            if (checkPermission)
                haspermission = ClassLibrary.JPermission.CheckPermission("AVL.SubUserObjects.jSubUserObjects.Insert");
            if (!haspermission)
                return 0;
            JAVLSubUserObjectsTable AT = new SubUserObjects.JAVLSubUserObjectsTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();

            return Code;
        }


        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.SubUserObjects.jSubUserObjects.Update"))
                return false;
            JAVLSubUserObjectsTable AT = new JAVLSubUserObjectsTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }
        public bool GetData(string ParentUserCode,string UserCode)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM [AVLSubUserObjects] WHERE [parentUserCode] = " + ParentUserCode + " AND [userCode]=" + UserCode);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }


        public bool GetData(int currentUserCode)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM [AVLSubUserObjects] WHERE  AND [userCode]=" + currentUserCode);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
