using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    public class JGroundPartitions:JSystem
    {
        #region Property


        public int Code { set; get; }
        public int PartitionCode { set; get; }
        public int GroundsPartition { set; get; }


        #endregion
        #region Method
        /// <summary>
        /// اطلاعات شئی را بر اساس  زمین افراز شده بر می گرداند
        /// </summary>
        /// <param name="Ground"></param>
        /// <param name="Db"></param>
        /// <returns></returns>
        public bool GetData(JGround Ground, JDataBase Db)
        {
            string Qouery = "select * from "+JTableNamesEstates.GroundPartitions+
                " where GroundsPartition="+JDataBase.Quote(Ground.Code.ToString());
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }

        }
        public int Insert(JDataBase Db)
        {
            JGroundPartitionsTable JGPT = new JGroundPartitionsTable();
            try
            {
                JGPT.SetValueProperty(this);
                return JGPT.Insert(Db);
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

        public bool upadte(JDataBase Db)
        {
            JGroundPartitionsTable JGPT = new JGroundPartitionsTable();
            try
            {
                JGPT.SetValueField(this);
                return JGPT.Update(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public bool Delete(JDataBase Db)
        {
            JGroundPartitionsTable JGPT = new JGroundPartitionsTable();
            try
            {
                JGPT.SetValueProperty(this);
                return JGPT.Delete(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

    }

    class JGroundPartitionsAll
    {

        public static bool save(JGroundPartition GroundPartion,int PartionCode,JDataBase db)
        {
            
            JGroundPartitions JGPs;
            bool flage = false;
            try
            {
                foreach (JGround Ground in GroundPartion.NewGrounds)
                {
                    Ground.MakeFromName = "Estates.JGroundPartition";
                    Ground.MakeFromCode = PartionCode;
                    int newGroundCode = Ground.Insert(db);
                    
                    if (newGroundCode > 0)
                    {
                        JGPs = new JGroundPartitions();
                        JGPs.PartitionCode = PartionCode;
                        JGPs.GroundsPartition = newGroundCode;
                        if (JGPs.Insert(db) > 0)
                        {
                            flage = true;
                        }
                    }

                }
                return flage;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public static bool Delete(JGroundPartition GroundPartion, JDataBase db)
        {
            bool flage = false;
            JGroundPartitions JGPs;
            foreach (JGround Ground in GroundPartion.NewGrounds)
            {
                /// حذف زمینهای حاصل از افراز
                if (Ground.Delete(db))
                {
                    JGPs = new JGroundPartitions();
                    JGPs.GetData(Ground, db);
                    if (JGPs.Delete(db))
                    {
                        flage = true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            return flage;

        }

        public static void GetGroundsPartition(ref JGround[] Grounds, int PartitionCode,JDataBase Db)
        {
            string Qouery="select * from "+JTableNamesEstates.GroundPartitions+
                " where PartitionCode="+JDataBase.Quote(PartitionCode.ToString());
            try
            {
                int i = 0;
                Db.setQuery(Qouery);
                DataTable GroundsPartitionTable = Db.Query_DataTable();
                Grounds = new JGround[GroundsPartitionTable.Rows.Count];
                foreach (DataRow row in GroundsPartitionTable.Rows)
                {
                    Grounds[i] = new JGround();
                    int GroundCode = Convert.ToInt32(row["GroundsPartition"]);
                    Grounds[i].GetData(GroundCode);
                    i++;


                }

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);

            }
            finally
            {
                Db.Dispose();
            }


        }
       
    }
}
