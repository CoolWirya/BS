using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
namespace Estates
{
    /// <summary>
    /// تفکیک زمین
    /// </summary>
    class JGroundBreakDown:JSystem
    {
        #region Constractor
        public JGroundBreakDown()
        {
        }

        public JGroundBreakDown(int pCode)
        {
            GetData(pCode);
        }
        #endregion
        #region Property
        /// <summary>
        /// کد تفکیک زمین
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        /// شماره نامه درخواست تفکیک
        /// </summary>
       public string LetterNum { set; get; }
        /// <summary>
        /// تاریخ درخواست تفکیک
        /// </summary>
       public DateTime LetterDate { set; get; }
        /// <summary>
        /// اداره مخاطب برای در خولاست تفکیک
        /// </summary>
       public string RegistrationOffice { set; get; }
        /// <summary>
        /// متن درخواست تفکیک زمین
        /// </summary>
       public string TextReuest { set; get; }
        /// <summary>
        /// کد زمینی که تفکیک خواهد شد
        /// </summary>
       public int GroundBreakDown { set; get; }
        /// <summary>
        /// زمین های حاصل از تفکیک
        /// </summary>
       public JGround[] GroundsBreakdown;

        #endregion
        #region FindMethod
       public bool GetData(int pCode)
       {
           JDataBase Db = JGlobal.MainFrame.GetDBO();
           string Qouery = "select * from " + JTableNamesEstates.GroundBreakDown + " where Code=" + JDataBase.Quote(pCode.ToString());
           try
           {
               Db.setQuery(Qouery);
               Db.Query_DataReader();
               if (Db.DataReader.Read())
               {
                   this.Code = pCode;
                   JTable.SetToClassProperty(this, Db.DataReader);
                   JGroundsBreakDownAll.GetGroundsBreakDown(ref this.GroundsBreakdown, this.Code);
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


       #endregion
       #region mainMethod
       public int Insert()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundBreakDown.Insert"))
                {
                    Db.beginTransaction("BreakDownInsert");
                    JGroundBreakDownTable JGBDT = new JGroundBreakDownTable();
                    JGBDT.SetValueProperty(this);
                    int BreakDownCode = JGBDT.Insert(Db);
                    if (BreakDownCode > 0)
                    {
                        if (JGroundsBreakDownAll.Save(this, BreakDownCode, Db))
                        {
                            //غیر فعال کردن زمین تفکیک  شده در جدول زمین و دارایی ها
                            JGround GroundOld = new JGround(this.GroundBreakDown, Db);

                            if (GroundOld.InactiveGround(Db, JGroundStatus.BrokeDown))
                            {
                                Db.Commit();
                                Histroy.Save(this, JGBDT, Code,"Insert");
                                Nodes.DataTable.Merge(JGroundBreakDownAll.GetDataTable(BreakDownCode));
                                return BreakDownCode;
                            }
                            else
                            {
                                Db.Rollback("BreakDownInsert");
                                return 0;
                            }

                        }
                        else
                        {
                            Db.Rollback("BreakDownInsert");
                            return 0;
                        }
                    }
                    else
                    {
                        Db.Rollback("BreakDownInsert");
                        return 0;
                    }
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("BreakDownInsert");
                return 0;
            }
            finally
            {
                Db.Dispose();
            }


        }
        public bool Delete()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundBreakDown.Delete"))
                {
                    Db.beginTransaction("BreakDownDelete");
                    //حذف از جدول تفکیک جزءو از جدول زمین-زمین های ایجاد شده از تفکیک
                    if (JGroundsBreakDownAll.Delete(this, Db))
                    {
                        //حذف از جدول تفکیک کل
                        JGroundBreakDownTable JGBDT = new JGroundBreakDownTable();
                        JGBDT.SetValueProperty(this);
                        if (JGBDT.Delete(Db))
                        {
                            //فعال کردن زمین خارج شده از تفکیک
                            JGround Ground = new JGround(this.GroundBreakDown, Db);
                            if (Ground.ActivateGround(Db))
                            {
                                Db.Commit();
                                return true;
                            }
                            else
                            {
                                Db.Rollback("BreakDownDelete");
                                return false;
                            }
                        }
                        else
                        {
                            Db.Rollback("BreakDownDelete");
                            return false;
                        }
                    }
                    else
                    {
                        Db.Rollback("BreakDownDelete");
                        return false;
                    }
                }
                else
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
        /// <summary>
        /// مالک اولیه زمین های جدید را بدست می آورد
        /// </summary>
        /// <param name="newGround"></param>
        /// <param name="GroundMainCode"></param>
        /// <returns></returns>
        public static JGround ComputePrimaryOwner(JGround newGround,int GroundMainCode)
        {
            try
            {
                JAsset Asset = new JAsset("Estates.JGround", GroundMainCode);
               
                DataTable OwnerGroundMain = JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
                if (OwnerGroundMain.Rows.Count > 1)
                {
                    JMessages.Error("زمین تفکیک شده باید دارای فقط یک مالک باشد.", "Error");
                    return null;
                }
                DataRow Row = newGround.PrimeryOwners.NewRow();
                Row[JPrimaryOwnerField.PCode.ToString()] = OwnerGroundMain.Rows[0][JPrimaryOwnerField.PCode.ToString()];
                Row[JPrimaryOwnerField.Share.ToString()] = JGround.MaxShare;//OwnerGroundMain.Rows[0][JPrimaryOwnerField..ToString()];
                Row["Name"] = OwnerGroundMain.Rows[0]["Name"];
                newGround.PrimeryOwners.Rows.Add(Row);
                return newGround;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }
        #endregion

        #region Show&GetNode
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JGroundBreakDownForm JGBDF = new JGroundBreakDownForm();
                JGBDF.State = JFormState.Insert;
                JGBDF.ShowDialog();
            }
            else
            {
                JGroundBreakDownForm JGBDF = new JGroundBreakDownForm(this.Code);
                JGBDF.State = JFormState.ReadOnly;
                JGBDF.ShowDialog();

            }

        }


        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JGroundBreakDownEnum.Code.ToString()], "Estates.JGroundBreakDown");
            //مشخصات زمین تفکیک شده برای قرار گرفتن در نود
            JGround BreakdownGround=new JGround((int)pRow[JGroundBreakDownEnum.GroundBreakDown.ToString()]);
            Node.Name = JLanguages._Text("MainAve ") +" "+ pRow[JGroundTableEnum.MainAve.ToString()]+"\n"+ JLanguages._Text("Subave") +" "+pRow[JGroundTableEnum.SubNo.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Estates.JGroundBreakDown.ShowDialog", null, null);
           
            //اکشن نمایش
            JAction ViewAction=new JAction("Show...","Estates.JGroundBreakDown.ShowDialog",null,new object [] {Node.Code});
            Node.MouseDBClickAction = ViewAction;
            Node.EnterClickAction = ViewAction;
            //اکشن حذف
            JAction DelAction = new JAction("del...", "Estates.JGroundBreakDown.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DelAction;
            JPopupMenu pMenu = new JPopupMenu("Estates.JGroundBreakDown", Node.Code);
            pMenu.Insert(DelAction);
            pMenu.Insert(ViewAction);
            pMenu.Insert(NewAction);
            Node.Popup = pMenu;
            return Node;

        }
        #endregion

    }

    class JGroundBreakDownAll:JSystem
    {
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Qopury = "select "+JTableNamesEstates.GroundBreakDown+"."+JGroundBreakDownEnum.Code+","+
                JGroundBreakDownEnum.LetterNum+","+JGroundBreakDownEnum.LetterDate+","
                +JGroundBreakDownEnum.RegistrationOffice+","+JGroundBreakDownEnum.TextReuest+","
                +JGroundBreakDownEnum.GroundBreakDown+","+JTableNamesEstate.GroundTable+"."
                +JGroundTableEnum.MainAve+","+JTableNamesEstate.GroundTable+"."+JGroundTableEnum.SubNo
                +" from "+JTableNamesEstates.GroundBreakDown+" inner join "
                +JTableNamesEstate.GroundTable+" on "+JTableNamesEstates.GroundBreakDown+"."
                +JGroundBreakDownEnum.GroundBreakDown+"="+JTableNamesEstate.GroundTable+"."
                +JGroundTableEnum.Code;
            string where = " Where " +
                JPermission.getObjectSql("Estates.JGroundBreakDownAll.GetDataTable", 
                JTableNamesEstates.GroundBreakDown + ".Code");
            if (pCode > 0)
                where = " And " + JTableNamesEstates.GroundBreakDown + "." +
                    JGroundBreakDownEnum.Code + "=" + pCode;

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qopury+where);
                return Db.Query_DataTable();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("BreakDown", "Estates.JGroundBreakDown.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("new...","Estates.JGroundBreakDown.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode jtn = new JToolbarNode();
            jtn.Click = newAction;
            jtn.Icon = JImageIndex.Add;
            Nodes.AddToolbar(jtn);
        }
    }
}
