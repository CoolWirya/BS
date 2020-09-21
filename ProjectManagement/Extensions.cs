using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement
{
  public static  class Extensions
    {
        public const String CLASSNAME = "ProjectManagement.Extensions";
        public static Int32 ToInt32(this string val)
        {
            try
            {
                return Int32.Parse(val);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToFloat(this string val)
        {
            try
            {
                return float.Parse(val);
            }
            catch
            {
                return 0;
            }
        }
        public static Decimal ToDecimal(this string val)
        {
            try
            {
                return Decimal.Parse(val);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToFloat(this string val,int numberOfPointsToRound)
        {
            try
            {
                if (numberOfPointsToRound>0)
                    return (float)Math.Round(val.ToFloat(), numberOfPointsToRound);
                return float.Parse(val);
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(this string val)
        {
            try
            {
                return DateTime.Parse(val);
            }
            catch
            {
                return new DateTime();
            }
        }
        public static bool ContainsNonDigit(this string val)
        {
            try
            {
                decimal.Parse(val);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static decimal GetTotalSubItemsPercentage(this TemplateItem.JTemplateItem item)
        {
            if (item == null) return -1;
            string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmTemplateItem WHERE TemplateCode={0} AND ParentItemCode={1}", item.TemplateCode, item.Code);
            System.Data.DataTable dt = q.ExecuteQuery(true);
            if (dt == null)
                return -1;
            return dt.Rows[0][0].ToString().ToDecimal();
        }
        public static decimal GetTotalSubItemsPercentage(this Project.JProject project)
        {
            if (project == null) return -1;
            //  string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmItems WHERE ProjectCode={0} AND Code not in (select ParentItemCode from pmItems)", project.Code);
            string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmItems WHERE ProjectCode={0} AND ParentItemCode = -1", project.Code);
            System.Data.DataTable dt = q.ExecuteQuery(true);
            if (dt == null)
                return -1;
            return dt.Rows[0][0].ToString().ToDecimal();
        }
        public static decimal GetTotalSubItemsPercentage(this Item.JItem item)
        {
            if (item == null) return -1;
            string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmItems WHERE ProjectCode={0} AND ParentItemCode={1}", item.ProjectCode, item.Code);
            System.Data.DataTable dt = q.ExecuteQuery(true);
            if (dt == null)
                return -1;
            return dt.Rows[0][0].ToString().ToDecimal();
        }
        public static decimal GetTotalSubItemsPercentage(this Template.JTemplate template)
        {
            if (template == null) return -1;
            // string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmTemplateItem WHERE TemplateCode={0} AND Code not in (select ParentItemCode from pmTemplateItem)", template.Code);
            string q = string.Format("SELECT SUM(WeightPercentage) as total  FROM pmTemplateItem WHERE TemplateCode={0} AND ParentItemCode = -1", template.Code);
            System.Data.DataTable dt = q.ExecuteQuery(true);
            if (dt == null)
                return -1;
            return dt.Rows[0][0].ToString().ToDecimal();
        }

        public static System.Data.DataTable ExecuteQuery(this string query,bool checkPermission)
        {
            bool haspermission = true;
            if (checkPermission)
                haspermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".ExecuteQuery");
            if(!haspermission)
                return null;

            try
            {
              
                System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);
                if (dt == null || dt.Rows == null ) return null;
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public static bool HasItem<T>(this T[] values,T item)
        {
            foreach (T t in values) if (t.Equals(item)) return true;
            return false;
        }

    }
}
