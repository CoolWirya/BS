using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.TemplateItem
{
    public class JTemplateItems : ClassLibrary.JSystem
    {
        public const String CLASSNAME = "ProjectManagement.TemplateItem.JTemplateItems";
        public static System.Data.DataTable GetDataTable(int templateCode=-10, int parentCode = -10, bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT [Code],[Name],[ParentItemCode],[WeightPercentage],[TemplateCode]
                    FROM pmTemplateItem WHERE 1=1 ";
                if(templateCode!= -10) query+=" AND TemplateCode =" + templateCode;
                if (parentCode != -10) query += " AND ParentItemCode=" + parentCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static System.Data.DataTable GetDataTableWithFillField(int templateCode = -10, int parentCode = -10, bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT pi.[Code],pi.[Name],pi.[ParentItemCode],pi.[WeightPercentage],pi.[TemplateCode],SUM(pi2.WeightPercentage),
(CASE WHEN SUM(pi2.WeightPercentage)>=pi.[WeightPercentage] OR SUM(pi2.WeightPercentage) is null THEN 'TRUE' ELSE 'FALSE' END) as isFilled
                    FROM pmTemplateItem pi LEFT JOIN  pmTemplateItem pi2 ON pi.Code=pi2.ParentItemCode  
    WHERE 1=1 ";
                if (templateCode != -10) query += " AND pi.TemplateCode =" + templateCode;
                if (parentCode != -10) query += " AND pi.ParentItemCode=" + parentCode;
                query += " GROUP BY pi.[Code],pi.[Name],pi.[ParentItemCode],pi.[WeightPercentage],pi.[TemplateCode]";
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool Move(int itemCode, int newParentCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".MoveUp"))
                return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"  UPDATE pmTemplateItem set ParentItemCode={0}
  WHERE ParentItemCode = {1}",
newParentCode, itemCode);

                DB.setQuery(query);
                return DB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool DeleteItemAndLevelUpSubItems(int Code)
        {
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".DeleteItemAndLevelUpSubItems"))
                return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"  UPDATE pmTemplateItem set ParentItemCode=(SELECT TOP 1 ParentItemCode FROM pmTemplateItem WHERE Code={0})
  WHERE ParentItemCode = {0} 
  DELETE FROM pmTemplateItem WHERE Code={0} ",
Code);

                DB.setQuery(query);
                return DB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool DeleteItemIncludeSubItems(int Code)
        {
            if (!ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".DeleteItemIncludeSubItems"))
                return false;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"DELETE FROM pmTemplateItem WHERE Code={0} OR ParentItemCode={0}", Code);

                DB.setQuery(query);
                bool res = DB.Query_Execute() >= 0;
                if (res)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static System.Data.DataTable GetLatestChildren(int templateCode = -1, bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".GetLatestChildren");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"select * from pmTemplateItem i
where Code not in (select ParentItemCode from pmTemplateItem) ";
                if (templateCode > 0) query += " AND TemplateCode = " + templateCode;

                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
