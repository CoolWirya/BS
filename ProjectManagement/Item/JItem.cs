using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement;

namespace ProjectManagement.Item
{
    public class JItem : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Item.JItem";
        public int Code { get; set; }
        public string Name { get; set; }
        public int ParentItemCode { get; set; }
        public decimal WeightPercentage { get; set; }
        public int ProjectCode { get; set; }
        public string ItemDescription { get; set; }
        public int Ordered { get; set; }


        public JItem() { }
        public JItem(int code)
        {
            this.GetData("SELECT TOP 1 * FROM pmItems WHERE Code=" + code.ToString());
        }
        private string GetChild(int parentCode,bool justDirectChildrenCodes)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string codes = "";
                System.Data.DataTable dt;
                int parentcode = parentCode;
                //   do
                //   {
                // codes += parentcode + ",";

                DB.setQuery("SELECT Code from pmItems where ParentItemCode=" + parentcode);
                dt = DB.Query_DataTable();
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    codes += dr[0].ToString() + ",";
                    if (!justDirectChildrenCodes)
                        codes += GetChild(dr[0].ToString().ToInt32(), justDirectChildrenCodes);

                }

                //  } while (parentcode > 0);
                return codes;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return "";
            }
            finally
            {
                DB.Dispose();
            }
        }
        public decimal GetChildWeight(int childCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"select it.WeightPercentage  from pmItems it where it.Code = {0}", childCode);
                DB.setQuery(query);
                return DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public decimal GetParentWeight()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"select itParent.WeightPercentage as parentWeight  from pmItems it 
 inner join pmItems itParent on itParent.Code=it.ParentItemCode  and it.ProjectCode = {0} AND it.Code = {1}", this.ProjectCode, this.Code);
                DB.setQuery(query);
                return DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }
        private decimal GetReportedPercentage(int parentCode)
        {
            Item.JItem item = new JItem(parentCode);

            string codes = item.GetChild(parentCode, true);
            if (codes.Length > 0)//have children
            {
                decimal total = 0;//, parentWeight, SelfWeight,improvePercent ;
                bool first = true;
                string[] codesArray = codes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in codesArray)
                {
                    if (item.WeightPercentage == 0)
                    {
                        total += 0;
                        continue;
                    }
                    if (item.ParentItemCode == -1)
                    {
                        total += GetReportedPercentage(s.ToInt32()) * item.GetChildWeight(s.ToInt32()) / item.WeightPercentage;
                        continue;
                    }
                    total += item.GetReportedPercentage(s.ToInt32()) * item.GetChildWeight(s.ToInt32()) / item.WeightPercentage;//item.WeightPercentage / item.GetParentWeight();
                }
                return total;
            }
            else//no children
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    //                   string query = string.Format(@"select  sum(a.totalWeight) from (select sum(ir2.WeightPercentage)  as totalWeight  from pmItemReport ir2 
                    //inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1})) a  ", this.ProjectCode, item.Code);
                    string query = string.Format(@"select top 1 ir2.WeightPercentage as totalWeight  from pmItemReport ir2 
                    inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1}) order by ir2.Code desc", this.ProjectCode, item.Code);
                    DB.setQuery(query);
                    return DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                    return 0;
                }
                finally
                {
                    DB.Dispose();
                }
            }

        }
        public decimal ReportedPercentage()
        {
            return GetReportedPercentage(this.Code);
//            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
//            try
//            {
//                string codes = GetChild(this.Code,false);
//                codes += this.Code;

//                string query = string.Format(@"select  sum(a.totalWeight)"+//*100/parentItem.WeightPercentage 
//@" from (select CASE WHEN {2}>0 THEN sum(ir2.WeightPercentage)/{2} ELSE sum(ir2.WeightPercentage) END " +//*it.WeightPercentage/100)
//@" as totalWeight from pmItemReport ir2 
//inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1})
//) a 
//", this.ProjectCode, codes,codes.Split(',').Length-2);

//                DB.setQuery(query);
//                decimal res = DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
//                return res;
//            }
//            catch (Exception ex)
//            {
//                Except.AddException(ex);
//                return -1;
//            }
//            finally
//            {
//                DB.Dispose();
//            }
        }
        public decimal TotalReportedPercentage()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string codes = GetChild(this.Code,false);
                codes += this.Code;

                //                string query = string.Format(@"select sum(ir2.WeightPercentage) as totalWeight from pmItemReport ir2 
                //inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1})", this.ProjectCode, codes);
                string query = string.Format(@"select top 1(ir2.WeightPercentage) as totalWeight from pmItemReport ir2 
inner join pmItems it on it.Code=ir2.ItemCode AND it.ProjectCode = {0} AND it.Code in ({1}) order by ir2.RegisterDate desc", this.ProjectCode, codes);

                DB.setQuery(query);
                decimal res = DB.Query_DataTable().Rows[0][0].ToString().ToDecimal();
                return res;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public Boolean GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                ItemDescription = "";
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
            JItemTable AT = new JItemTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0,true);

            return Code;
        }


        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JItemTable AT = new JItemTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }



        public static JItem Extract(System.Data.DataRow dr)
        {
            JItem p = new JItem();
            if (ClassLibrary.JTable.SetToClassProperty(p, dr))
                return p;
            return null;
        }

        public void SetValue(string propertyname,object value)
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
                case "ProjectCode":
                    ProjectCode = value.ToString().ToInt32();
                    break;
                case "ItemDescription":
                    ItemDescription = value.ToString();
                    break;
            }
        }
    }
}
