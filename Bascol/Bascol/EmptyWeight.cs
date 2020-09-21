using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Bascol
{
    public class JEmptyWeight : JBascol
    {

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره باسکول توزین فعلی 
        /// </summary>
        public int BascoolNo { get; set; }
        /// <summary>
        /// شماره سریال توزین فعلی 
        /// </summary>
        public int WeightID { get; set; }
        /// <summary>
        /// شماره باسکول توزین قبلی 
        /// </summary>
        public int EmptyBascoolNo { get; set; }
        /// <summary>
        /// شماره سریال توزین قبلی 
        /// </summary>
        public int WeightSerial { get; set; }
        /// <summary>
        /// تاریخ توزین 
        /// </summary>
        public DateTime DateWeight { get; set; }
        /// <summary>
        /// وزن  
        /// </summary>
        public decimal EmptyWeight { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int EmptyID { get; set; }
        #endregion

        #region method

        public long Insert()
        {
            JDataBase Db = new JDataBase();
            try
            {
                return Insert(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase Db)
        {
            JEmptyWeightTable JLT = new JEmptyWeightTable();
            try
            {                
                JLT.SetValueProperty(this);
                Code = JLT.Insert(Db);
                if (Code > 0)
                    return Code;
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JLT.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(JDataBase db)
        {
            JEmptyWeightTable PDT = new JEmptyWeightTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(db))
                    return true;
                //Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {                
            JEmptyWeightTable PDT = new JEmptyWeightTable();

            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }

        }

        #endregion

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != -1)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from BascolEmptyWeights " + Where;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
