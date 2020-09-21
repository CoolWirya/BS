using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
  public   class JDamge:JParking
    {
      public int Code { get; set; }
      public int Type { get; set; }
      public string Hint { get; set; }
      public DateTime DateStop { get; set; }
        public string Time { get; set; }
        public int Gate { get; set; }
        public int Code_Traffic { get; set; }
        public int Market { get; set; }
        public int Oprator { get; set; }

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
               
                    JDamgeTable JGCT = new  JDamgeTable();
                    JGCT.SetValueProperty(this);
                    pDB.setQuery("Select Max(Code) from [dbo].[PrkDamage]");
                    this.Code =Convert.ToInt32( pDB.Query_ExecutSacler())+1;
                    pDB.setQuery("INSERT INTO [dbo].[PrkDamage] ([Code],[Type],[Hint],[DateStop],[Time],[Gate],[Code_Traffic],[Market],[Oprator]) VALUES('"+this.Code.ToString()+"','"+JGCT.Type.ToString()+"','"+JGCT.Hint.ToString()+"','"+JGCT.DateStop.Date.ToString()+"','"+JGCT.Time.ToString()+"','"+JGCT.Gate+"','"+JGCT.Code_Traffic.ToString()+"','"+JGCT.Market.ToString()+"','"+JGCT.Oprator.ToString() + "')");
                    if (pDB.Query_Execute() > 0)
                    {
                        return Code;
                    }
                    else
                    {
                        return 0;
                    }
                  
                                 
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

        public bool Update()
        {
            if (JPermission.CheckPermission("Parking.JDamge.Update"))
            {
                JDamgeTable JGCT = new JDamgeTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JDamge.Delete"))
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Damge + " WHERE Code=" + pCode.ToString());
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
        public bool GetDataCode_Traffic(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Damge + " WHERE Code_Traffic=" + pCode.ToString());
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
        public JDamge()
        {
        }

        public JDamge(int PCode)
        {
            this.GetData(PCode);
        }

        public void ShowForm(int pCode,int Pmarket)
        {
            if (pCode == 0)
            {
                DamgeForm JGCF = new DamgeForm(this,Pmarket);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {
                //JGroupCard Jgr = new JGroupCard(pCode);
                GetData(pCode);
                DamgeForm JGCF = new DamgeForm(this,Pmarket);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }
        public void ShowForm(JDamge Damge)
        {

            DamgeForm JGCF = new DamgeForm(Damge);
                JGCF.ShowDialog();
           
        }
        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
          
            Node.MouseDBClickAction = new JAction("ShowDamge", "Parking.JDamge.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["Market"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JDamge.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }

    }


    public class JDamges : JParking
    {
        public static System.Data.DataTable GetDataTable(int PmarketCode)
        {
            return GetDataTable(0,PmarketCode);
        }

        public static System.Data.DataTable GetDataTable(int pCode,int PmarketCode)
        {
            JDataBase DB = new JDataBase();
            try
            {

                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And dbo.PrkDamage.Code=" + pCode.ToString();
                if (PmarketCode > 0)
                pWhere = pWhere + " And Market=" + PmarketCode.ToString();
                DB.setQuery("SELECT     dbo.PrkDamage.Code, dbo.subdefine.name, dbo.PrkDamage.Hint,"+JDataBase.SQLMiladiToShamsi("dbo.PrkDamage.DateStop","DateStop")+", dbo.PrkDamage.Time, dbo.PrkDamage.Code_Traffic,dbo.users.username, dbo.PrkDamage.Market " +
"FROM         dbo.PrkDamage INNER JOIN dbo.subdefine ON dbo.PrkDamage.Type = dbo.subdefine.Code LEFT OUTER JOIN "+
                      "dbo.users ON dbo.PrkDamage.Oprator = dbo.users.code" + pWhere);
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
        public void ListView(int PmarketCode)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JDamge.GetNode");
            Nodes.DataTable = GetDataTable(PmarketCode);
            
        }

    }

}
