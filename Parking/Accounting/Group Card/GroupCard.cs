using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JGroupCard : JParking
    {
        #region Property

        /// <summary>
        /// کد گروه
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره گروه
        /// </summary>
        public int GroupNumber { get; set; }
        /// <summary>
        /// عنوان گروه
        /// </summary>
        public string TypeGroup { get; set; }
        /// <summary>
        /// مبلغ اولیه
        /// </summary>
        public decimal FirstAmount { get; set; }
        /// <summary>
        /// مبلغ ساعت اول به بعد
        /// </summary>
        public decimal SecondAmount { get; set; }
        /// <summary>
        /// اخذ مبلغ در
        /// </summary>
        public Boolean AmountReceived { get; set; }
        /// <summary>
        ///مجتمع
        /// </summary>
        public int MarketCode { get; set; }
        /// <summary>
        /// دقايقي كه در نظر گرفته نمي شوند
        /// </summary>
        public int Offers { get; set; }
        /// <summary>
        /// درصد تخفيف
        /// </summary>
        public int Abate { get; set; }
        /// <summary>
        /// گرد كردن مبلغ تا چند رقم
        /// </summary>
        public int Round { get; set; }
        /// <summary>
        /// هر واحد زمانی
        /// </summary>
        public int UnitTime { get; set; }
        /// <summary>
        /// پرداخت روزانه یا مرتبه ای
        /// </summary>
        public Boolean PayByDialy { get; set; }
        /// <summary>
        /// پرداخت با كيف پول الكترونيك
        /// </summary>
        public Boolean PayIsElectronic { get; set; }
        /// <summary>
        /// گرد كردن رو به بالا فعال
        /// </summary>
        public Boolean UpRound { get; set; }
        /// <summary>
        /// مبلغ هزينه روزانه
        /// </summary>
        public int DailyPrice { get; set; }
        /// <summary>
        /// هزينه ساعت اول مجزا محاسبه گردد
        /// </summary>
        public Boolean IsFirstHourApart { get; set; }
        /// <summary>
        /// /// هزينه روزانه مجزا محاسبه گردد
        /// </summary>
        public Boolean IsDailyApart { get; set; }
        /// <summary>
        /// /// گروه فعال است
        /// </summary>
        public Boolean IsActive { get; set; }
        #endregion

        #region method


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
                if (JPermission.CheckPermission("Parking.JGroupCard.Insert"))
                {
                    JGroupCardTable JGCT = new JGroupCardTable();
                    JGCT.SetValueProperty(this);
                    Code = JGCT.Insert(pDB);
                    if (Code > 0)
                    {
                        // Nodes.DataTable.Merge(JGroupCards.GetDataTable(Code,MarketCode));
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
            if (JPermission.CheckPermission("Parking.JGroupCard.Update"))
            {
                JGroupCardTable JGCT = new JGroupCardTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }
        public bool UpdateRole()
        {
            if (JPermission.CheckPermission("Parking.JGroupCard.Update") || 1 == 1)
            {
                JGroupCardTable JGCT = new JGroupCardTable();
                JGCT.SetValueProperty(this);
                return JGCT.Update();
            }
            else
                return false;
        }
        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("Parking.JGroupCard.Delete"))
            {
                Code = pCode;
                JGroupCardTable JGCT = new JGroupCardTable();
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

        public bool GetDataGroupNumber(int pCode, int Market)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE GroupNumber=" + pCode.ToString() + " And MarketCode=" + Market.ToString());
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

        public bool GetDataGroupNumber(int pCode, JDataBase DB)
        {

            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE GroupNumber=" + pCode.ToString());
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
        public bool GetDataGroupNumber(int pCode)
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE GroupNumber=" + pCode.ToString());
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
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE Code=" + pCode.ToString());
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
        public bool Find()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE GroupNumber=" + this.GroupNumber + " And MarketCode=" + this.MarketCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {

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
        public JGroupCard()
        {
        }

        public JGroupCard(int PCode)
        {
            this.GetData(PCode);
        }
        public System.Data.DataTable ShowData(string Where, int MarketCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesParking.GroupCard + " WHERE MarketCode=" + MarketCode + " " + Where);
                return DB.Query_DataTable();


            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public void ShowForm(int pCode, int Market)
        {
            if (pCode == 0)
            {
                this.MarketCode = Market;
                JGroupCardForm JGCF = new JGroupCardForm(this);
                JGCF.State = JFormState.Insert;
                JGCF.ShowDialog();
            }
            else
            {
                //JGroupCard Jgr = new JGroupCard(pCode);
                GetData(pCode);
                JGroupCardForm JGCF = new JGroupCardForm(this);
                JGCF.State = JFormState.Update;
                JGCF.ShowDialog();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["TypeGroup"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JGroupCard.ShowForm", new object[] { (int)pDR["Code"], (int)pDR["MarketCode"] }, null);

            JAction DeleteAct = new JAction("Delete", "Parking.JGroupCard.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "نام گروه " + (char)13 + Node.Name;
            return Node;
        }
    }

    public class JGroupCards : JParking
    {
        public static System.Data.DataTable GetDataTable(int  Pmarket)
        {
            return GetDataTable(0, Pmarket);
        }

        public static System.Data.DataTable GetDataTable(int pCode, int Pmarket)
        {
            JDataBase DB = new JDataBase();
            try
            {
                
                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();
                if(Pmarket>0)
                    pWhere = pWhere + " And MarketCode=" + Pmarket.ToString();
                DB.setQuery("SELECT  Code,GroupNumber, TypeGroup, FirstAmount, SecondAmount,Offers, Round, PayIsElectronic,PayByDialy,PayIsElectronic,UnitTime,UpRound,MarketCode FROM " + JTableNamesParking.GroupCard + pWhere);
                    //+ " And " + JPermission.getObjectSql("Parking.JGroupCard.GetDataTable", "PrkGroups.Code"));
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
            return null;
        }

        public void ListView(int Pmarket)
        {
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JGroupCard.GetNode");
            Nodes.DataTable = GetDataTable(Pmarket);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("CardParking", "Parking.JGroupCard.ShowForm", new object[] {0,Pmarket }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }
        #endregion
}
