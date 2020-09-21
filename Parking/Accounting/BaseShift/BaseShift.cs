using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JBaseShift : JParking
    {

        /// <summary>
        /// كد شيفت
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام شيفت
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ساعت شروع
        /// </summary>
        public string StatrtTime { get; set; }
        /// <summary>
        /// ساعت پايان
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// كد مجتمع
        /// </summary>
        public int Market { get; set; }
        /// <summary>
        /// شيفت مي تواند حساب را ببندد
        /// </summary>
        public Boolean Isclose { get; set; }

        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return Insert(DB);
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

        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("Parking.JBaseShift.Insert"))
                {
                    JBaseShiftTable JGCT = new JBaseShiftTable();
                    JGCT.SetValueProperty(this);
                    Code = JGCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JBaseShifts.GetDataTable(Code,Market));
                    }
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

        public bool Update()
        {
            if (JPermission.CheckPermission("Parking.JBaseShift.Update"))
            {
                JBaseShiftTable JGCT = new JBaseShiftTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JBaseShift.Delete"))
            {
                Code = pCode;
                JBaseShiftTable JGCT = new JBaseShiftTable();
                JGCT.SetValueProperty(this);
                if (JGCT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.DefShift + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
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
        public bool GetTime()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.DefShift +" WHERE     (StatrtTime <= '"+StatrtTime+"') AND (EndTime >= '"+EndTime+"') AND (Market ="+ Market.ToString()+") ");
                DB.Query_DataReader();
                //if (DB.DataReader.Read())
                //{
                //    JTable.SetToClassProperty(this, DB.DataReader);
                //    return true;
                //}
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
        public Boolean CompareTime(string TimeOne, string TimeTo, int Width)
        {
            try
            {
             
                DateTime DtOne, DtEnd;
                DtOne = Convert.ToDateTime("2011/10/02 " + TimeOne);
                DtEnd = Convert.ToDateTime("2011/10/02 " + TimeTo);
                TimeSpan tm = DtEnd.Subtract(DtOne);
                if ((tm.Hours < Width))
                   return true;
                else if ((tm.Hours == 0) && (tm.Minutes < Width * 60))
                        return true;
                    return false;
            }
            catch
            {
                return false;
            }
            
        }
        public bool GetTime(string Time,int MarketS)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.DefShift + " WHERE     (StatrtTime < '" + Time + "') And (EndTime >'" + Time + "') AND (Market =" + MarketS.ToString() + ") ");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
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
        public JBaseShift()
        {
        }
         public static int GetShiftOfTime()
        {
               int Code = 0;
            try
            {
                JDataBase jdb = new JDataBase();
                string StrBegin = "";
                string StrEnd = "";
                TimeSpan TM = jdb.GetCurrentDateTime().TimeOfDay;


                jdb.setQuery("Select * from " + JTableNamesParking.DefShift);
              
                System.Data.DataTable Dt = jdb.Query_DataTable();
                for (int j = 0; Dt.Rows.Count - 1 >= j; j++)
                {

                    DateTime DtBegin = Convert.ToDateTime(Convert.ToDateTime(StrBegin = "2011-02-01 " + Dt.Rows[j]["StatrtTime"].ToString().Trim()).ToString("yyyy / MM / dd HH: mm: ss"));
                    DateTime DtEnd = Convert.ToDateTime(Convert.ToDateTime(StrBegin = "2011-02-01 " + Dt.Rows[j]["EndTime"].ToString().Trim()).ToString("yyyy / MM / dd HH: mm: ss"));
                    if ((TimeSpan.Compare(TM, DtBegin.TimeOfDay) > 0 || TimeSpan.Compare(TM, DtBegin.TimeOfDay) == 0) && (TimeSpan.Compare(TM, DtEnd.TimeOfDay) < 0 || TimeSpan.Compare(TM, DtEnd.TimeOfDay) == 0))
                    {
                        Code = Convert.ToInt32(Dt.Rows[j]["Code"]);
                    }
                }
                return Code;
            }
                
            catch(Exception Ex)
            {
                return 0;
                JMessages.Error("در قسمت تعريف شيفت هاي روزانه ساعتهاي وارد شده در فرمت صحيح نمي باشد"+" "+Ex.Message,"JBaseShift");
            }
        }
         public JBaseShift(int PCode)
        {
            this.GetData(PCode);
        }

        public void ShowForm(int pCode,int Market)
        {
            if (pCode == 0)
            {
                DefShift JGCF = new DefShift(this,Market);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {
                GetData(pCode);
                DefShift JGCF = new DefShift(this,Market);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["Name"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JBaseShift.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["Market"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JBaseShift.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }

    }


    public class JBaseShifts : JParking
    {
        public static System.Data.DataTable GetDataTable(int Market)
        {
            return GetDataTable(0,Market);
        }

        public static System.Data.DataTable GetDataTable(int pCode,int Market)
        {
            JDataBase DB = new JDataBase();
            try
            {

                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();
                if (Market > 0)
                    pWhere = pWhere + " And Market=" + Market.ToString();
                DB.setQuery("SELECT * FROM " + JTableNamesParking.DefShift + pWhere + " And " +
                   JPermission.getObjectSql("Parking.JBaseShifts.GetDataTable", "JBaseShift.Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return GetDataTable(Market);
        }
       
        public void ListView(int Market)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JBaseShift.GetNode");
            Nodes.DataTable = GetDataTable(Market);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JBaseShift", "Parking.JBaseShift.ShowForm", new object[] { 0,Market }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }

}
