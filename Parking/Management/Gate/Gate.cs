using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  ClassLibrary;

namespace Parking
{
    public class JGate : JParking
    {
        /// <summary>
        /// كد شيفت
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// كد مجتمع
        /// </summary>
        public int Market { get; set; }
        /// <summary>
        /// نام مجتمع
        /// </summary>
        public string  MarketName { get; set; }
        /// <summary>
        /// نوع گيت ورودي / خروجي /ورودي وخروجي
        /// </summary>
        public int TypeGate { get; set; }
        /// <summary>
        ///نام دستگاه
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// IP سیستم پارکینگ
        /// </summary>
        public string IpSystem { get; set; }
        /// <summary>
        ///Ip  مركز
        /// </summary>
        public string  IpCenter{ get; set; }
        /// <summary>
        ///Ip  كلاينت
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        ///Ip  زير شبكه
        /// </summary>
        public string SubIp { get; set; }
        /// <summary>
        ///Ip  دوربين
        /// </summary>
        public string IpCamera { get; set; }
        /// <summary>
        ///پورت
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        ///پورت
        /// </summary>
        public Boolean State { get; set; }
      
        
        #region method

        public JGate()
        {
            
        }

        public Boolean CompareIP(string pIp,string pIpSystem)
        {
            JDataBase DB = new JDataBase();
            DB.setQuery("select count(*) from "+JTableNamesParking.Gate+" where Ip="+JDataBase.Quote(Ip)+" and IpSystem="+JDataBase.Quote(IpSystem));
            int Result = (Int32)DB.Query_ExecutSacler();
            if(Result==1)
                return true;
            else
                return false;
        }

        public Boolean CompareIP(string pIp, string pIpSystem, JDataBase DB)
        {
            
            DB.setQuery("select count(*) from " + JTableNamesParking.Gate + " where Ip=" + JDataBase.Quote(Ip) + " and IpSystem=" + JDataBase.Quote(IpSystem));
            int Result = (Int32)DB.Query_ExecutSacler();
            if (Result == 1)
                return true;
            else
                return false;
        }
        
        public Boolean GetGate(string IpSender)
        {
            object Res = null;
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT  Code  FROM  PrkGate  WHERE     (Ip = '" + IpSender.Trim() + "')");
                Res = DB.Query_ExecutSacler();
                if (Res != null)
                {
                    GetData(Convert.ToInt32(Res));
                    return true;
                }
                else
                {
                    return false;
                }
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

        public Boolean GetGate(string IpSender, JDataBase DB)
        {
            object Res = null;
          
            try
            {
                DB.setQuery("SELECT  Code  FROM  PrkGate  WHERE     (Ip = '" + IpSender.Trim() + "')");
                Res = DB.Query_ExecutSacler();
                if (Res != null)
                {
                    GetData(Convert.ToInt32(Res), DB);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;

            }
           
        }

        public Boolean GetGateIpSystem(string IpSystem)
        {
            object Res = null;

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT  Code  FROM  PrkGate  WHERE     (IpSystem = '" + IpSystem.Trim() + "')");
                Res = DB.Query_ExecutSacler();
                if (Res != null)
                {
                    GetData(Convert.ToInt32(Res));
                    return true;
                }
                else
                {
                    return false;
                }
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

        public Boolean GetGateIpSystem(string IpSystem, JDataBase DB)
        {
            object Res = null;

         
            try
            {
                DB.setQuery("SELECT  Code  FROM  PrkGate  WHERE     (IpSystem = '" + IpSystem.Trim() + "')");
                Res = DB.Query_ExecutSacler();
                if (Res != null)
                {
                    GetData(Convert.ToInt32(Res),DB);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;

            }
            
        }

        public static System.Data.DataTable GateMarket(int Market)
        {
            JDataBase jdb = new JDataBase();
            try
            {
                jdb.setQuery("SELECT * FROM [dbo].[PrkGate] where State='True' And Market=" + Market.ToString());
                return jdb.Query_DataTable();
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
        public int Save(JDataBase pDB,Boolean Sender)
        {
            try
            {
                if (JPermission.CheckPermission("Parking.JGate.Insert") || Sender)
                {
                    JGateTable JGCT = new JGateTable();
                    JGCT.SetValueProperty(this);
                    Code = JGCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JGates.GetDataTable(Code, Market));
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
                if (JPermission.CheckPermission("Parking.JGate.Insert"))
                {
                    JGateTable JGCT = new JGateTable();
                    JGCT.SetValueProperty(this);
                    Code = JGCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JGates.GetDataTable(Code,Market));
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
            if (JPermission.CheckPermission("Parking.JGate.Update"))
            {
                JGateTable JGCT = new JGateTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JGate.Delete"))
            {
                Code = pCode;
                JGateTable JGCT = new JGateTable();
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

        public System.Data.DataTable GetGateOFMarket(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Gate + " WHERE Market=" + pCode.ToString());

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

        public bool GetData(int pCode, JDataBase DB)
        {
          
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Gate + " WHERE Code=" + pCode.ToString());
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
           
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.Gate + " WHERE Code=" + pCode.ToString());
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

        public JGate(int PCode)
        {
            this.GetData(PCode);
        }

        public Boolean ConvertToIP(string Text)
        {

            System.Net.IPAddress newIP, subnet, serverIP;
            bool isIpTrue = true;
            isIpTrue = System.Net.IPAddress.TryParse(TrimForIP(Text), out newIP);
            isIpTrue = isIpTrue & System.Net.IPAddress.TryParse(TrimForIP(Text), out subnet);
            isIpTrue = isIpTrue & System.Net.IPAddress.TryParse(TrimForIP(Text), out serverIP);
            if (isIpTrue)
            {
                Text = TrimForIP(Text);
            }

            return isIpTrue;

        }

        public string TrimForIP(string ip)
        {
            string[] bytes = ip.Split('.');
            string ipOut = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                bool canConvert = false;
                for (int j = 0; j < bytes[i].Length; j++)
                {
                    if (bytes[i][j] != '0' || j == bytes[i].Length - 1)
                        canConvert = true;
                    if (canConvert && Char.IsDigit(bytes[i][j]))
                        ipOut += bytes[i][j];
                }
                if (i < bytes.Length - 1)
                    ipOut += ".";
            }
            return ipOut;
        }

        public void ShowForm(int pCode,int Market)
        {
            if (pCode == 0)
            {
                GateForm JGCF = new GateForm(this,Market);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {
                //JGroupCard Jgr = new JGroupCard(pCode);
                GetData(pCode);
                GateForm JGCF = new GateForm(this,Market);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["Name"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataGate", "Parking.JGate.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["Market"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JGate.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;
            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }

    }

    public class JGates : JParking
    {
        public static System.Data.DataTable GetDataTable()
        {
            return GetDataTable(0,0);
        }

        public static System.Data.DataTable GetDataTable(int pCode, int pMarketCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();
                if (pMarketCode > 0)
                    pWhere = pWhere + " AND Market = " + pMarketCode.ToString();
                DB.setQuery("SELECT Code, Name, MarketName, Ip, DeviceName,Market FROM " + JTableNamesParking.Gate + pWhere);
                
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
            return GetDataTable();
        }

        public void ListView(int pMarketCode)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JGate.GetNode");
            Nodes.DataTable = GetDataTable(0, pMarketCode);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("CardParking", "Parking.JGate.ShowForm", new object[] { 0, pMarketCode }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }
        #endregion

}
