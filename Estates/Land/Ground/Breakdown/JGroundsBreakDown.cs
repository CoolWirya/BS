using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
    class JGroundsBreakDown:JSystem
    {
        #region Property
        public int Code { set; get; }
        /// <summary>
        /// کد زمینی که تفکیک  شده است
        /// </summary>
        public int BreakDownCode { set; get; }
        /// <summary>
        /// کد زمین های حاصل از تفکیک
        /// </summary>
        public int GroundsBreakDown { set; get; }
        #endregion
          #region FindMethod
        /// <summary>
        /// اطلاعات شئی را براساس کد زمین تفکیک شده بر می گرداند
        /// </summary>
        public bool GetData(int GroundsBreakdownCode,JDataBase Db)
        {

           
            string Qoury="select * from estgroundsbreakdown where groundsbreakdown="
                +JDataBase.Quote(GroundsBreakdownCode.ToString());
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if(Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this,Db.DataReader);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
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
        #region MainMethod
        public int Insert(JDataBase Db)
        {
            JGroundsBreakDownTable JGsBKT = new JGroundsBreakDownTable();
            try
            {
                JGsBKT.SetValueProperty(this);
                return JGsBKT.Insert(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            
            
        }

        public bool Update()
        {

            JGroundsBreakDownTable JGsBKT = new JGroundsBreakDownTable();
            try
            {
                    JGsBKT.SetValueProperty(this);
                    return JGsBKT.Update();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JGsBKT.Dispose();
            }

        }

        public bool Delete(JDataBase Db)
        {

            JGroundsBreakDownTable JGsBKT = new JGroundsBreakDownTable();
            try
            {
                JGsBKT.SetValueProperty(this);
                return JGsBKT.Delete(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JGsBKT.Dispose();
            }
        }
        #endregion

    }
    class JGroundsBreakDownAll
    {
        public static bool Save(JGroundBreakDown GroundBreakDown, int BreakDownCode,JDataBase Db)
        {
            try
            {
                bool Flage = false;
                JGroundsBreakDown JGsBD;
                foreach (JGround NewGround in GroundBreakDown.GroundsBreakdown)
                {
                    NewGround.MakeFromName = "Estates.JGroundPartition";
                    NewGround.MakeFromCode = BreakDownCode;
                    //NewGround.Status = JGroundStatus.Main;
                    int NewGroundCode=NewGround.Insert(Db);
                    if (NewGroundCode>0)
                    {
                        JGsBD = new JGroundsBreakDown();
                        JGsBD.GroundsBreakDown = NewGroundCode;
                        JGsBD.BreakDownCode = BreakDownCode;
                        if (JGsBD.Insert(Db) > 0)
                        {
                            Flage = true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                return Flage;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }

        }
         public static bool Delete(JGroundBreakDown GroundBreakDown,JDataBase Db)
        {
            try
            {
                bool Flage = false;
                JGroundsBreakDown JGsBD;
                foreach (JGround NewGround in GroundBreakDown.GroundsBreakdown)
                {
                    
                    if (NewGround.Delete(Db))
                    {
                        JGsBD = new JGroundsBreakDown();
                        JGsBD.GetData(NewGround.Code,Db);
                        if (JGsBD.Delete(Db))
                        {
                           
                            Flage = true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                return Flage;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }

        }

         public static void GetGroundsBreakDown(ref JGround[] Grounds,int BreakDownCode)
         {
             JDataBase Db = JGlobal.MainFrame.GetDBO();
             string Qoery = "select Code,BreakDownCode,GroundsBreakDown from estGroundsBreakDown where BreakDownCode="
                 +JDataBase.Quote(BreakDownCode.ToString());
             try
             {
                 int i = 0;
                 Db.setQuery(Qoery);
                 DataTable BreakDownGrouns = Db.Query_DataTable();
                 Grounds = new JGround[BreakDownGrouns.Rows.Count];
                 foreach (DataRow Row in BreakDownGrouns.Rows)
                 {
                     int groundCode = Convert.ToInt32(Row["GroundsBreakDown"]);
                     Grounds[i] = new JGround(groundCode);
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
