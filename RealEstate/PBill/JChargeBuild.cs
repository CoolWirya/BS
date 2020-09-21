using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;


namespace RealEstate
{
    public class JChargeBuild
    {
        public int Code{get;set;}
        public decimal CurrentCharge { get; set; }
        public decimal PeriodCharge { get; set; }

        public decimal FirstPeriodCharges { get; set; }
        public int CodeMarket { get; set; }
        public int CodeUnitBuild { get; set; }
        public int Yaraneh { get; set; }
        public string Hint { get; set; }

        public JChargeBuild()
        {
           
        }
        public JChargeBuild(int pCode)
        {
            if (!GetDataBuild(pCode))
            {
                JUnitBuild Build = new JUnitBuild(pCode);
                CurrentCharge = 0;
                PeriodCharge = 0;
                FirstPeriodCharges = 0;
                CodeMarket = Build.MarketCode;
                CodeUnitBuild = Build.Code;
            }
        }

        
        #region Method
        public int insert(JDataBase pDb)
        {
            JChargeBuildTable JCBT = new JChargeBuildTable();
       
            try
            {
                int Code;
                JCBT.SetValueProperty(this);
                Code = JCBT.Insert(pDb);
                if (Code > 0)
                {
                    return Code;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JCBT.Dispose();
            }
        }
        public void Show(int pShopCode)
        {

            if (!GetDataBuild(pShopCode))
            {
                JUnitBuild Build = new JUnitBuild(pShopCode);
                CurrentCharge = 0;
                PeriodCharge = 0;
                FirstPeriodCharges = 0;
                CodeMarket = Build.MarketCode;
                CodeUnitBuild = Build.Code;
            }
            FSetCharege FC = new FSetCharege(this);
            FC.ShowDialog();
        }
        public bool Delete(JDataBase PDb)
        {
            try
            {
                JChargeBuildTable JCBT = new JChargeBuildTable();
                JCBT.SetValueProperty(this);
                if (JCBT.Delete(PDb))
                {
                  return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }                          
        }

        
        public bool Update(JDataBase pDb)
        {
            JChargeBuildTable JCBT = new JChargeBuildTable();
            try
            {
                JCBT.SetValueProperty(this);
                return JCBT.Update(pDb);
               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JCBT.Dispose();
            }
        }

        public bool Save()
        {
            JDataBase jdb = new JDataBase();
           
            try
            {
                if (Code!=0)
                {
                 
                    return Update(jdb);
                }
                else
                {
                    
                    Code = insert(jdb);
                    
                    if (Code != 0) return true; else return false;
                 
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                jdb.Dispose();
            }
        }
        public  Boolean GetListOFUnitBuild(JComboBox CmbShow,string Display,int CodeBazar)
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT *  FROM [dbo].[estUnitBuild] where MarketCode=" + CodeBazar + " order by estUnitBuild.Tafsili2 ");
                CmbShow.DataSource = DB.Query_DataTable();
                CmbShow.DisplayMember = Display;
                CmbShow.ValueMember = "Tafsili2";
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
                
            }
            finally
            {
                DB.Dispose();
            }
          

        }
        private bool GetDataBuild(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("Select * from ReChargeBuild Where CodeUnitBuild=" + pCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
               JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("Select * from ReChargeBuild Where Code=" + pCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        public Boolean GetData(string Query)
        {
            JDataBase Jdb = new JDataBase();
            try
            {
                
                JChargeBuildTable JCBT = new JChargeBuildTable();
                Jdb.setQuery(Query);
                JCBT.SetValueProperty(Jdb.Query_ExecutSacler());
                if (JCBT.Code != 0) return true; else return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Jdb.Dispose();
            }
        }
        public string GetMaliBuild(int MarketCode,int Tafsili)
        {
             JDataBase jdb = new JDataBase();
            try
            {
                string MondehKol = "";
                jdb.setQuery("SELECT  MondehKol From MaliErp"+MarketCode+" where UnitBuildMaliCode="+Tafsili);

                MondehKol=Convert.ToString( jdb.Query_ExecutSacler());
                if (MondehKol == null) return "0"; else return MondehKol;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error("لطفا اطلاعات مالی را بروز رسانی کنید", "خطا در اجرای عملیات");
                return null;
            }
            finally
            {
                jdb.Dispose();
            }
            
        }
        public DataTable  GetListOfCharge(string Query)
        {

            JDataBase jdb = new JDataBase();
            try
            {
                JChargeBuildTable JCBT = new JChargeBuildTable();
                jdb.setQuery("SELECT     dbo.estUnitBuild.Code, ISNULL(dbo.estUnitBuild.Tafsili2, 0) AS TAfsiliBazar, dbo.estUnitBuild.Number,ISNULL(dbo.ReChargeBuild.CurrentCharge, 0) AS CurrentCharges, ISNULL(dbo.ReChargeBuild.PeriodCharge, 0) AS PeriodCharges, " +
                          "ISNULL(dbo.ReChargeBuild.FirstPeriodCharges, 0) AS FirstPeriodCharges,ISNULL(dbo.ReChargeBuild.Yaraneh, 0) AS Yaraneh, ISNULL(dbo.MaliErp" + CodeMarket + ".MondehKol, 0) AS MondehKol, dbo.estUnitBuild.Area, " +
                          "dbo.estMarketFloors.Name As Floor " +
    "FROM         dbo.estMarketFloors  RIGHT OUTER JOIN " +
                          "dbo.estUnitBuild ON dbo.estMarketFloors.Code = dbo.estUnitBuild.FloorCode LEFT OUTER JOIN " +
                          "dbo.ReChargeBuild ON dbo.estUnitBuild.Code = dbo.ReChargeBuild.CodeUnitBuild LEFT OUTER JOIN " +
                          "dbo.MaliErp" + CodeMarket + " ON dbo.estUnitBuild.Tafsili2 = dbo.MaliErp" + CodeMarket + ".UnitBuildMaliCode " +

                          "WHERE  1=1 " + Query + "ORDER BY dbo.estUnitBuild.Number");

                return jdb.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error("لطفا اطلاعات مالی را بروز رسانی کنید", "خطا در اجرای عملیات");
                return null;
            }
            finally
            {
                jdb.Dispose();
            }
        }

        
      
       
        #endregion

        public DataTable GetMaliInformation(int CodeMarket)
        {
          
            JConnection connection = new JConnection();
            System.Data.SqlClient.SqlConnectionStringBuilder conn = connection.GetConnection("RealEstate.jMarket", CodeMarket);

            JDataBase jdb = new JDataBase(conn);
            try
            {
                JUnitBuild Build=new JUnitBuild(this.CodeUnitBuild);
                jdb.setQuery("SELECT [San02] AS NewNumber,[San06] AS DateSanad,[San05] AS HintSanad,[San03] AS Daryfatha ,[San04] AS Pardakhtha from [amlak-sharj] where [San02]=" + Build.Tafsili2 + " Order By [San06]");
               return  jdb.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                jdb.Dispose();
            }

        }
       
       
    }
    
    public class JChargeBuilds :JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JREsStaticNode._PrintBillFormNode());
        }
    }
        
}
