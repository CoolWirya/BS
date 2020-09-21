using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.TemplateItem
{
  public  class JTemplateItem : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.TemplateItem.JTemplateItem";

        public int Code{get;set;}
        public string Name{get;set;}
        public int ParentItemCode{get;set;}
        public decimal WeightPercentage{get;set;}
        public int TemplateCode{get;set;}

        public  decimal TotalWeight { get; set; }
        public int Ordered { get; set; }



        public JTemplateItem() { }
        public JTemplateItem(int code)
        {
            this.GetData(@"SELECT TOP 1 *,
(Select SUM(WeightPercentage) FROM pmTemplateItem WHERE  ParentItemCode="+code+@" ) as TotalWeight
FROM pmTemplateItem WHERE Code=" + code.ToString());
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
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Insert");
            if (!hasPermission)
                return 0;
            JTemplateItemTable AT = new JTemplateItemTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0, true);

            return Code;
        }


        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JTemplateItemTable AT = new JTemplateItemTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }

        public decimal FindTotalSubItemWeight()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = " SELECT SUM(WeightPercentage) FROM pmTemplateItem WHERE ParentItemCode= "+this.Code;
                DB.setQuery(query);
                object o = DB.Query_ExecutSacler();
                if (o == null) return 0;
               else return o.ToString().ToDecimal();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static JTemplateItem Create(System.Data.DataRow dr)
        {
            JTemplateItem t = new JTemplateItem();
            ClassLibrary.JTable.SetToClassProperty(t, dr);
            return t;
        }


        public void SetValue(string propertyname, object value)
        {
            switch (propertyname)
            {
                case "Code":
                    Code = value.ToString().ToInt32();
                    break;
                case "Name":
                    Name = value.ToString();
                    break;
                case "ParentItemCode":
                    ParentItemCode = value.ToString().ToInt32();
                    break;
                case "WeightPercentage":
                    WeightPercentage = value.ToString().ToDecimal();
                    break;
                case "TemplateCode":
                    TemplateCode = value.ToString().ToInt32();
                    break;
            }
        }
    }
}
