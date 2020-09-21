using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JComparativeCode : JSystem
    {
        public int Code { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public int CreatorPostCode { get; set; }
        public int CreatorUserCode { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int DivideType { get; set; }
        public decimal Value { get; set; }
        public int State { get; set; }

        public JComparativeCode()
        {
        }
        public int Insert()
        {
            JComparativeCodeTable AT = new JComparativeCodeTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Delete(bool IsWeb = false)
        {
            JComparativeCodeTable AT = new JComparativeCodeTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!IsWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
        }
        public bool Update()
        {
            JComparativeCodeTable AT = new JComparativeCodeTable();
            AT.SetValueProperty(this);
            return (AT.Update());
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select Top 1 * from finComparativeCode where ObjectCode = " + pCode.ToString() + " ORDER BY Code Desc ");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode, string ClassName)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select Top 1 * from finComparativeCode where ClassName = '" + ClassName + @"' and ObjectCode = " + pCode.ToString() + " ORDER BY Code Desc");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetDataWithCode(int Code)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from finComparativeCode where Code=" + Code.ToString() + "");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"select top 100 percent * from finComparativeCode";
        }

    }

    public class JComparativeCodes : JSystem
    {
        public static DataTable GetDataMultiTafzili(string[] pCode, string ClassName)
        {
            JDataBase DB = new JDataBase();
            try
            {
                //// آخرین شماره حساب شخص که در سیستم ثبت شده لود میشود
                DB.setQuery("select distinct Value from finComparativeCode where ClassName = '" + ClassName + @"' and ObjectCode  " + string.Join(",", pCode) + " ORDER BY Code Desc");
                DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count == 1)
                    return DT;
                return null;
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
    }
}