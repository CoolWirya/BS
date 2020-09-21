using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Finance;
using ClassLibrary;

namespace Estates
{
    /// <summary>
    /// افراز زمین
    /// </summary>
     class JGroundPartition:JSystem
     {
         #region Constructor
         public JGroundPartition()
         {
         }
         public JGroundPartition(int pCode)
         {
             GetData(pCode);
         }
         #endregion
         #region Property
         public int Code { set; get; }
        /// <summary>
        /// کد زمین تفکیک شده
        /// </summary>
       public int GroundMainCode { get; set; }
        /// <summary>
        /// کد حکمی که طی آن زمین تفکیک می شود
        /// </summary>
      public  int CourtCode { get; set; }

        /// <summary>
        /// تاریخ تفکیک در سیستم
        /// </summary>
      public  DateTime DatePartition { set; get; }
        /// <summary>
        /// زمین های حاصل از افراز زمین اصلی
        /// </summary>
      public JGround[] NewGrounds;


        #endregion
      #region FindMethod
      public bool GetData(int pCode)
      {
          JDataBase Db = JGlobal.MainFrame.GetDBO();
          string Qouery = "select * from "+JTableNamesEstates.GroundPartition+" where Code="+JDataBase.Quote(pCode.ToString());
          try
          {
              
              Db.setQuery(Qouery);
              Db.Query_DataReader();
              if (Db.DataReader.Read())
              {
                  JTable.SetToClassProperty(this, Db.DataReader);
                  JGroundPartitionsAll.GetGroundsPartition(ref this.NewGrounds, this.Code,Db);
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
          finally
          {
              Db.Dispose();
          }
      }
      #endregion
      #region MainMethod
      public int Insert()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundPartition.Insert"))
                {
                    Db.beginTransaction("insertPartion");
                    JGroundPartitionTable JGPT = new JGroundPartitionTable();
                    JGPT.SetValueProperty(this);
                    int PartionCode = JGPT.Insert(Db);
                    if (PartionCode > 0)
                    {
                        if (JGroundPartitionsAll.save(this, PartionCode, Db))
                        {
                            //غیر فعال کردن زمین تفکیک شده
                            JGround GroundMain = new JGround(GroundMainCode, Db);
                            if (GroundMain.InactiveGround(Db, JGroundStatus.Partitioned))
                            {
                                Db.Commit();
                                return PartionCode;
                            }
                            else
                            {
                                Db.Rollback("insertPartion");
                                return 0;
                            }

                        }
                        else
                        {
                            Db.Rollback("insertPartion");
                            return 0;

                        }
                    }
                    else
                    {
                        Db.Rollback("insertPartion");
                        return 0;
                    }
                }
            }
            finally
            {
                Db.Dispose();
            }

            return 0;
        }
        public bool Delete()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            JGroundPartitionTable JGPT = new JGroundPartitionTable();
            try
            {
                if (JPermission.CheckPermission("Estates.JGroundPartition.Delete"))
                {
                    JGPT.SetValueProperty(this);
                    Db.beginTransaction("DeletePartition");
                    if (JGPT.Delete(Db))
                    {
                        if (JGroundPartitionsAll.Delete(this, Db))
                        {
                            //فعال کردن زمین افراز شده
                            JGround MainGround = new JGround(this.GroundMainCode);
                            if (MainGround.ActivateGround(Db))
                            {
                                Db.Commit();
                                return true;
                            }
                            else
                            {
                                Db.Rollback("DeletePartition");
                                return false;
                            }
                        }
                        else
                        {
                            Db.Rollback("DeletePartition");
                            return false;
                        }

                    }
                    else
                    {
                        Db.Rollback("DeletePartition");
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

        public void ComputeNewGround(int GoundMain)
        {
            JGround MainGround = new JGround(GoundMain);
            JAsset Asset = new JAsset("Estates.JGround", GoundMain);
            DataTable Owner = JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
            NewGrounds = new JGround[Owner.Rows.Count];
            int i=0;
            foreach (DataRow Row in Owner.Rows)
            {
                this.NewGrounds[i] = new JGround();
                this.NewGrounds[i].MainAve = MainGround.SubNo;
                this.NewGrounds[i].Usage = MainGround.Usage;
                this.NewGrounds[i].Land = MainGround.Land;
                DataRow NewRow = this.NewGrounds[i].PrimeryOwners.NewRow();
                NewRow[JPrimaryOwnerField.Share.ToString()] = 6;
                NewRow[JPrimaryOwnerField.PCode.ToString()] = Row[JPrimaryOwnerField.PCode.ToString()];
                NewRow["Name"] = Row["Name"];
                this.NewGrounds[i].PrimeryOwners.Rows.Add(NewRow);
                i++;
            }
        }
         
        

        #endregion
         #region ShowMethod
        public void showDialog()
        {
            if (this.Code == 0)
            {
                JGroundPartitionForm JGPF = new JGroundPartitionForm();
                JGPF.State = JFormState.Insert;
                JGPF.ShowDialog();
            }
            else
            {
                JGroundPartitionForm JGPF = new JGroundPartitionForm(this.Code);
                JGPF.State = JFormState.ReadOnly;
                JGPF.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode(Convert.ToInt32(pRow[JGroundPartitionEnum.Code.ToString()]), "Estates.JGroundPartition");
            Node.Name = JLanguages._Text("CourtCode ") +" "+ pRow[JGroundPartitionEnum.CourtCode.ToString()] + "\n" + JLanguages._Text("MainAve ") + pRow[JGroundTableEnum.MainAve.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction newaction = new JAction("new...", "Estates.JGroundPartition.showDialog", null, null);
            //اکشن نمایش
            JAction ShowAction = new JAction("Show...", "Estates.JGroundPartition.showDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = ShowAction;
            Node.EnterClickAction = ShowAction;
            //اکشن حذف
            JAction delAction = new JAction("del...", "Estates.JGroundPartition.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delAction;
            JPopupMenu pMenu = new JPopupMenu("Estates.JGroundPartition", Node.Code);
            pMenu.Insert(delAction);
            pMenu.Insert(ShowAction);
            pMenu.Insert(newaction);
            Node.Popup = pMenu;
            return Node;

        }

        #endregion
     }

     class JGroundPartitionAll:JSystem
     {
         public DataTable GetDataTable()
         {
             return GetDataTable(0);
         }
         public DataTable GetDataTable(int pCode)
         {
             string qouery = "select " + JTableNamesEstates.GroundPartition + "." + JGroundPartitionEnum.Code +
                 "," + JGroundPartitionEnum.CourtCode + ",(select fa_date from StaticDates where En_Date=Cast(DatePartition as Date)) 'DatePartition'," 
                 + JTableNamesEstate.GroundTable +
                 "." + JGroundTableEnum.MainAve + "," + JTableNamesEstate.GroundTable + "." + JGroundTableEnum.SubNo +
                 " from " + JTableNamesEstates.GroundPartition + " inner join " + JTableNamesEstate.GroundTable +
                 " on " + JTableNamesEstates.GroundPartition + "." + JGroundPartitionEnum.GroundMainCode +
                 "=" + JTableNamesEstate.GroundTable + ".Code "; 
             JDataBase Db = JGlobal.MainFrame.GetDBO();
             string Where = " where " +
                JPermission.getObjectSql("Estates.JGroundPartitionAll.GetDataTable", JTableNamesEstates.GroundPartition + ".Code");
             if (pCode > 0)
                 Where = Where + " And Code=" + JDataBase.Quote(pCode.ToString());
             try
             {
                 Db.setQuery(qouery + Where);
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
             Nodes.ObjectBase = new JAction("GroundParttion", "Estates.JGroundPartition.GetNode");
             Nodes.DataTable = GetDataTable();
             JToolbarNode JTN = new JToolbarNode();
             //اکشن جدید
             JAction newaction = new JAction("new...", "Estates.JGroundPartition.showDialog", null, null);
             JTN.Icon = JImageIndex.Add;
             JTN.Click = newaction;
             Nodes.AddToolbar( JTN);
         }
     }
}
