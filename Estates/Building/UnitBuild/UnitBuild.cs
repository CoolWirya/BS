using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;
using Finance;


namespace Estates
{
    /// <summary>
    /// کلاس مربوط به یک واحد از مستغلات
    /// </summary>
    class JUnitBuild:JEstate
    {
        #region Constructor
        public JUnitBuild()
        {
             PrimeryOwner = JPrimaryOwnerBuilds.GetDataTable(-1);
        }
        public JUnitBuild(int pCode)
        {
            GetData(pCode);
            PrimeryOwner = JPrimaryOwnerBuilds.GetDataTable(pCode);
        }

        #endregion
        #region property
        /// <summary>
        /// کد واحد ساختمان
        /// </summary>
        public int Code
        {
            set;
            get;
        }
        /// <summary>
        /// کد نوع واحد
        /// </summary>
        public int TypeCode
        {
            get;
            set;
        }

        /// <summary>
        /// کد ساختمانی که واحد در آن مستقر شده است
        /// </summary>
        public int MarketCode
        {
            get;
            set;
        }
        /// <summary>
        /// پلاک واحد
        /// </summary>
        public string Plaque
        {
            get;
            set;
        }
        /// <summary>
        /// طبقه ای که واحد در آن مستقر است
        /// </summary>
        public int FloorCode
        {
            get;
            set;
        }
        /// <summary>
        /// شماره واحد 
        /// </summary>
        public string Number
        {
            get;
            set;
        }
        /// <summary>
        /// مساحت واحد مربوطه
        /// </summary>
        public double Area
        {
            get;
            set;
        }
        /// <summary>
        /// کاربری
        /// </summary>
        public int UsageCode
        {
            get;
            set;
        }
        /// <summary>
        /// پلاک ثبتی
        /// </summary>
        public int PlaqueRegistration
        {
            get;
            set;
        }
        /// <summary>
        /// کددارایی
        /// </summary>
        public int AssetCode
        {
            get;
            set;
        }
        /// <summary>
        /// شغل
        /// </summary>
        public int UnitJob { get; set; }
        private DataTable _PrimeryOwner;
        public DataTable PrimeryOwner
        {
            get;
            set;
        }

                
        #endregion
        #region SearchMethod
        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = "select * from " + JTableNamesEstate.UnitBuild + " where Code=" + pCode;
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
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
            return false;
        }

        /// <summary>
        /// جستجو بر اساس نام مجتمع و پلاک واحد
        /// </summary>
        /// <returns></returns>
        public bool Find(string Plaque,int marketCode)
        {
            string Qoury = "select * from " + JTableNamesEstate.UnitBuild + " where Plaque='" + Plaque + "'and MarketCode=" +JDataBase.Quote(marketCode.ToString());

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if(Db.DataReader.Read())
                {
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
        #region Method
        /// <summary>
        /// درج اعیان
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if(Find(this.Plaque,this.MarketCode))
            {
                JMessages.Error("این واحد قبلا ثبت شده است","خطا در ثبت اطلاعات");
                return 0;
            }
            int DefaultCode = 999999;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            Db.beginTransaction("InsertPrimeryOwner");
            JUnitBuildTable JUBT = new JUnitBuildTable();
           
            try
            {
                JUBT.SetValueProperty(this);
                Code = JUBT.Insert(Db);
                if (Code > 0)
                {
                    //ذخیره اعیان در جدول دارایی
                    JAsset Asset = new JAsset();
                    Asset.ClassName = JAssetType.Estates_JUnitBuild;
                    Asset.ObjectCode = Code;
                    int Assetcode = Asset.Insert(Db);
                    if (Assetcode < 1)
                    {
                        Db.Rollback("InsertPrimeryOwner");
                        return 0;
                    }
                    else
                    {
                        JUBT.AssetCode = Assetcode;
                        JUBT.Update(Db);
                    }
                    if (JPrimaryOwnerBuilds.Save(Code, this.PrimeryOwner, Db,Assetcode))
                    {
                        Histroy.Save(JUBT, Code, "Insert");
                        Db.Commit();
                        Nodes.DataTable.Merge(JUnitBuilds.GetDataTable(Code));
                       
                        return Code;
                        
                    }
                    Db.Rollback("InsertPrimeryOwner");
                    return 0;
                }
                Db.Rollback("InsertPrimeryOwner");
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("InsertPrimeryOwner");
                return 0;
            }
            finally
            {
                JUBT.Dispose();
            }
           
        }

        /// <summary>
        /// در لیست مالکین اولیه شخص خاصی را جستجو میکند
        /// </summary>
        /// <param name="pPCode">کد شخص</param>
        /// <returns></returns>
        public bool FindPrimaryOwner(int pPCode)
        {
            return PrimeryOwner.Select(" PCode = " + pPCode.ToString()).Count() > 0;
        }
        /// <summary>
        /// ویرایش اعیان
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            //if (Find(this.Plaque, this.MarketCode))
            {
             //   JMessages.Error("این واحد قبلا ثبت شده است", "خطا در ثبت اطلاعات");
            //    return false;
            }
            JUnitBuildTable JUBT = new JUnitBuildTable();
            
            JDataBase Db=JGlobal.MainFrame.GetDBO();
            try
            {
                Db.beginTransaction("UpdateBuild");

                JUBT.SetValueProperty(this);
                if (JUBT.Update())
                {
                    JAsset asset = new JAsset();
                   
                    if (JPrimaryOwnerBuilds.Save(this.Code, this.PrimeryOwner, Db,0))
                    {

                        Histroy.Save(JUBT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JUnitBuilds.GetDataTable(this.Code).Rows[0]);

                    }
                    else
                    {
                        Db.Rollback("UpdateBuild");
                        return false;
                    }
                }
                else
                {
                    Db.Rollback("UpdateBuild");
                    return false;
                }
                Db.Commit();
                return true;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                Db.Rollback("UpdateBuild");
                return false;
            }
            finally
            {
                JUBT.Dispose();
                
                Db.Dispose();
            }
            
        }
        /// <summary>
        /// حذف اعیان
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            string[] parameters = { "@Item" };
            string[] values = { "UnitBuild" };
            string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
            if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            } 
            
                JUnitBuildTable JUBT = new JUnitBuildTable();
                JDataBase Db = JGlobal.MainFrame.GetDBO();
                Db.beginTransaction("DeleteBuild");
                try
                {
                    JPrimaryOwnerBuildTable JPOBT = new JPrimaryOwnerBuildTable();
                    JPOBT.DeleteManual(JPrimaryOwnerBuildTableEnum.BuildCode.ToString() + "=" + this.Code, Db);
                    JUBT.SetValueProperty(this);
                    if (JUBT.Delete(Db))
                    {
                        //حذف اعیان از جدول دارایی ها
                        JAsset Asset = new JAsset();
                        Asset.Code = JUBT.AssetCode;
                        if (Asset.Delete(Db))
                        {
                            ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                            AD.DeleteArchive(this.GetType().FullName, Code, true);
                            Nodes.Delete(Nodes.CurrentNode);
                            Db.Commit();
                            return true;
                        }
                        else
                        {
                            Db.Rollback("DeleteBuild");
                            return false;

                        }
                    }
                    else
                    {
                        Db.Rollback("DeleteBuild");
                        return false;
                    }



                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    Db.Rollback("DeleteBuild");
                }
                finally
                {
                    JUBT.Dispose();
                    Db.Dispose();
                }
            return false;
        }
        
        #endregion

        #region Node
        public JNode GetNode(DataRow DR)
        {
            int _code = int.Parse(DR["Code"].ToString());
            JNode Node = new JNode(_code, this);
            Node.Name = JLanguages._Text("Plaque Unit")+" "+ DR[JUnitBuildTableEnum.Plaque.ToString()].ToString()+
                "\n"+ JLanguages._Text("Name Market") +" "+ DR[JUnitBuildTableEnum.Market.ToString()].ToString();
            Node.Icone = JImageIndex.unitbuild.GetHashCode();
            //اکشن جدید
            JAction newAction=new JAction("new...", "Estates.JUnitBuild.ShowDialog", null, null);
           
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Estates.JUnitBuild.ShowDialog", new object[] { Node.Code }, null);
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction DelAction = new JAction("delete...", "Estates.JUnitBuild.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DelAction;

            JPopupMenu pMenu = new JPopupMenu("Estates.JUnitBuild", Node.Code);
            pMenu.Insert(DelAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);
            Node.Popup = pMenu;
            return Node;
        }

        public void ShowDialog()
        {
           
            JUnitBuildForm UBf = new JUnitBuildForm();
            UBf.State = JFormState.Insert;
            UBf.ShowDialog();
        }

        public void ShowDialog(int pCode)
        {
            
            JUnitBuildForm UBf = new JUnitBuildForm(pCode);
            UBf.State = JFormState.Update;
            UBf.ShowDialog();
        }
        #endregion
    }

    class JUnitBuilds:JEstate
    {

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JUnitBuild", "Estates.JUnitBuild.GetNode");
            Nodes.DataTable = GetDataTable();

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JUnitBuild", "Estates.JUnitBuild.ShowDialog");
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert( new JAction("new...", "Estates.JUnitBuild.ShowDialog", null, null)); 
        }

        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Qouery = "select "+JTableNamesEstate.UnitBuild+".Code,"
                +JTableNamesClassLibrary.SubBaseDefine+".name Type,"+JTableNamesEstate.Market+
                ".Title Market,Plaque,"+JTableNamesEstate.MarketFloors+".Name Floor,"
                +JTableNamesEstate.UnitBuild+".Number,Area,Usage.name Usage,PlaqueRegistration from "
                +JTableNamesEstate.UnitBuild+" left outer join "+JTableNamesClassLibrary.SubBaseDefine+
                " on "+JTableNamesClassLibrary.SubBaseDefine+".Code="+JTableNamesEstate.UnitBuild+
                ".TypeCode inner join "+JTableNamesEstate.Market+" on "+JTableNamesEstate.Market+
                ".Code="+JTableNamesEstate.UnitBuild+".MarketCode inner join "+JTableNamesEstate.MarketFloors+
                " on "+JTableNamesEstate.MarketFloors+".Code="+JTableNamesEstate.UnitBuild+".FloorCode left outer join "+
                JTableNamesClassLibrary.SubBaseDefine+" Usage on Usage.Code="+JTableNamesEstate.UnitBuild+".UsageCode ";
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = "";
            try
            {
                if (pCode > 0)
                {
                    Where = " where " + JTableNamesEstate.UnitBuild + ".Code=" + pCode;
                }
                Db.setQuery(Qouery + Where);
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
    }
}
