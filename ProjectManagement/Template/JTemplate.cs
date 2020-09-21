using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Template
{
    public class JTemplate : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Template.JTemplate";
        public int Code { get; set; }
        public string Name { get; set; }

        public decimal TotalFilledWeight { get; set; }
        public decimal TotalWeight { get; set; }

        public JTemplate() { }
        public JTemplate(int code)
        {
            this.GetData("SELECT TOP 1 *,(Select SUM(WeightPercentage) FROM pmTemplateItem WHERE TemplateCode=" + code + " AND ParentItemCode=-1 ) as TotalFilledWeight FROM pmTemplate WHERE Code=" + code.ToString());
        }
        public Boolean GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
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

        public int Insert(bool checkPermission = true)
        {
            return Insert(-1, checkPermission);
        }
        public int Insert(int templateToCopyItems,bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Insert");
            if (!hasPermission)
                return 0;
            JTemplateTable AT = new JTemplateTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0, true);

            if (Code > 0 && templateToCopyItems > 0) { templateCode=templateToCopyItems;
                ImportTemplateItems(); }

            return Code;
        }
        private int templateCode;
        private void CopyItems(int parentCode, int newParentCode)
        {
            int insertedCode;
            System.Data.DataTable dt;
                dt = TemplateItem.JTemplateItems.GetDataTable(templateCode, parentCode);
            
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                ProjectManagement.TemplateItem.JTemplateItem i = new TemplateItem.JTemplateItem();
                ClassLibrary.JTable.SetToClassProperty(i, dr);
                i.ParentItemCode = newParentCode;
                i.TemplateCode = this.Code;
                insertedCode = i.Insert();
                CopyItems(dr[0].ToString().ToInt32(), insertedCode);
            }
        }
        public void ImportTemplateItems()
        {
            //    if (templateType == 2)//copy items from project
            //   {
            CopyItems(-1, -1);
            //  }

        }

        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JTemplateTable AT = new JTemplateTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }

        public bool Delete(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Delete");
            if (!hasPermission)
                return false;

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            string query = "DELETE FROM pmTemplateItem WHERE TemplateCode=" + this.Code;
            DB.setQuery(query);
            DB.Query_Execute();
            JTemplateTable AT = new JTemplateTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }


    }
}
