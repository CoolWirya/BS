using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JEnviroment : JRealEstate
    {
        #region Properties
                
        /// <summary>
        /// شماره محيط
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام محيط
        /// </summary>
        public string NameEnviroment { get; set; }
        /// <summary>
        /// نوع فضا
        /// </summary>
        public int CodeEnviroment { get; set; }
        /// <summary>
        /// عنوان محيط
        /// </summary>
        public int TypeEnviroment { get; set; }
        /// <summary>
        /// متراژ
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// قيمت پايه شارژ
        /// </summary>
        public decimal moneyBaseCharge { get; set; }
        /// <summary>
        /// مجتمع
        /// </summary>
        public int Complex { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// قيمت پايه
        /// </summary>
        public decimal moneyBase { get; set; }
        /// <summary>
        /// وضعيت
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// آرشيو
        /// </summary>
        public bool ISArchive { get; set; }
        /// <summary>
        /// کد طبقه
        /// </summary>
        public int CodeFloor { get; set; }
        /// <summary>
        /// کد در
        /// </summary>
        public int Door { get; set; }
        /// <summary>
        /// کد تفضيلي
        /// </summary>
        public int Tafsili { get; set; }
        public string MarketName
        {
            get
            {
                jMarket market = new jMarket(this.Complex);
                return market.Title;
            }
        }

        #endregion

        public override string ToString()
        {
            return "محیط مشاع " + this.NameEnviroment + " واقع در " + this.MarketName;
        }

        public string GetAssetComment(int Code)
        {
            GetData(Code);
//            string Seperator = " ";
            return ToString();
        }

        public bool Find(string NameEnviroments, int marketCode)
        {
            string Qoury = "select * from " + JRETableNames.EnviromentTable + " where NameEnviroment='" + NameEnviroments + "'And Complex=" + JDataBase.Quote(marketCode.ToString());

            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qoury);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
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

        public int Insert()
        {
            JDataBase Db = new JDataBase();
            try
            {
                return Insert(Db);
            }
            finally
            {
                Db.DisConnect();
            }

        }

        public int Insert(JDataBase pDB)
        {
            JDataBase DB = pDB;

            try
            {
                if (JPermission.CheckPermission("RealEstate.JEnviroment.Insert"))
                {
                    if (!Find(this.NameEnviroment, this.Complex))
                    {

                        JEnviromentTable Env = new JEnviromentTable();
                        DB.beginTransaction("InsertEnviroment");
                        // asset
                        Env.SetValueProperty(this);
                        this.ISArchive = false;
                        this.Code = Env.Insert(DB);
                        if (this.Code != 0)
                        {
                            //
                            JAsset Asset = new JAsset();
                            Asset.ClassName = this.GetType().FullName; //JAssetType.Estates_JUnitBuild;
                            Asset.ObjectCode = Code;
                            Asset.Comment = this.ToString();
                            Asset.Status = JStatusType.Active;
                            Asset.MaxCount = 6;
                            Asset.DivideType = JDivideType.DecimalDivide;
                            Asset.GroupCode = this.Complex;
                            /// ارزش دارایی
                            Asset.Value = Convert.ToDecimal(this.moneyBase + this.moneyBaseCharge);

                            int Assetcode = Asset.Insert(DB);
                            if (Assetcode < 1)
                            {
                                DB.Rollback("InsertEnviroment");
                                return 0;
                            }
                            //asset
                           
                            JAssetTransfer AssetTransfer = new JAssetTransfer(Assetcode, JOwnershipType.Definitive, DB);
                            if (AssetTransfer.Code == 0)
                            {
                                AssetTransfer.ClassName = "RealEstate.JPrimaryOwnerEnviroment";
                                AssetTransfer.ObjectCode = this.Code;
                                AssetTransfer.ACode = Assetcode;
                                AssetTransfer.Comment = this.NameEnviroment + "  :به ارزش تقريبي " + this.moneyBase + this.moneyBaseCharge + " واقع در " + this.Address;

                                JAssetShare AssetShare = new JAssetShare();
                                AssetShare.ACode = Assetcode;
                                //كد شركت الماس شرق بايد اينجا قرار گيرد. ميتوان اين كد را در مجتمع تجاري قرارداد
                                JSetDefultEnviroment SetEnv = new JSetDefultEnviroment();
                                AssetShare.PersonCode = SetEnv.GetPrimaryOwner(this.Complex);  //jallperson
                                AssetShare.Share = 6;
                                AssetShare.Status = JStatusType.Active;

                                AssetTransfer.AddItems(AssetShare);

                            }
                            if (!AssetTransfer.Insert(DB))
                            {
                                DB.Rollback("InsertEnviroment");
                            }
                            else
                            {
                                DB.Commit();
                               
                                  
                                   Nodes.DataTable.Merge(JEnviroments.GetDataTable(this.Code));


                            }
                            //
                        }
                        else
                        {
                            DB.Rollback("InsertEnviroment");
                        }
                        return Code;
                    }
                    else
                    {
                        JMessages.Message("اين مورد از قبل در سيستم وجود دارد", "توجه", JMessageType.Information);
                    }
                    return 0;
                }
                else
                    return 0;
            }
              
            catch (Exception ex)
            {

                Except.AddException(ex);
                return 0;
            }
            finally
            {
            }
        }
        
        //public int Insert(JDataBase pDB)
        //{
        //    try
        //    {
        //        if (JPermission.CheckPermission("RealEstate.JEnviroment.Insert"))
        //        {
        //            JEnviromentTable JCT = new JEnviromentTable();
        //            JCT.SetValueProperty(this);
        //            Code = JCT.Insert(pDB);
        //            if (Code > 0)
        //            {
        //                Nodes.DataTable.Merge(JEnviroments.GetDataTable(Code));
        //            }
        //            return Code;
        //        }
        //        else
        //            return -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return 0;
        //    }
        //}

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                return Update(Db);
            }
            finally
            {
                Db.DisConnect();
            }
        }

        public bool Update(JDataBase pDb)
        {
            JDataBase Db = pDb;
            try
            {
                if (JPermission.CheckPermission("RealEstate.JEnviroment.Update"))
                {
                  
                    Db.beginTransaction("UpdateEnviroment");
                    JEnviromentTable JCT = new JEnviromentTable();
                    JCT.SetValueProperty(this);
                    if (JCT.Update(Db))
                    {
                        //
                       
                        JAsset asset = new JAsset(this.GetType().FullName, this.Code, Db);
                        asset.Value = Convert.ToDecimal(this.moneyBase + this.moneyBaseCharge);
                        if (this.state != 1)
                        {
                            asset.Status = JStatusType.Block;
                        }
                        else
                        {
                            asset.Status = JStatusType.Active;
                        }
                        asset.Comment = this.ToString();
                        if (asset.Update(Db))
                        {
                            Histroy.Save(this, JCT, Code, "Update");
                            Db.Commit();
                          //  Nodes.Refreshdata(Nodes.CurrentNode, JEnviroments.GetDataTable(Code).Rows[0]);
                            return true;
                        }
                        else
                        {
                            Db.Rollback("UpdateEnviroment");
                            return false;
                        }
                        //
                      
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }

        }

        public bool Delete(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {

                System.Windows.Forms.DialogResult DialogResult = JMessages.Question("آيا از انجام عمليات حذف مطمئن هستيد" ,"هشدار");
                if (DialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (JPermission.CheckPermission("RealEstate.JEnviroment.Delete"))
                    {

                        Db.beginTransaction("DeleteAssest");
                        Code = pCode;
                        JEnviromentTable JCT = new JEnviromentTable();
                        GetData(pCode);
                        this.ISArchive = true;
                        JCT.SetValueProperty(this);


                        if (JCT.Update(Db))
                        {

                            JAsset assest = new JAsset("RealEstate.JEnviroment", pCode, Db);
                            if (assest.DeActive(Db))
                            {

                                Db.Commit();
                                Nodes.Delete(Nodes.CurrentNode);
                            }
                            else
                            {
                                Db.Rollback("DeleteAssest");
                                return false;
                            }
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
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
                Db.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                return GetData(pCode, DB);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode, JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.setQuery("SELECT * FROM ReEnviromentTable WHERE Code=" + pCode.ToString());
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
            }
        }

        public bool ShowForm(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                return ShowForm(pCode, Db);
            }
            finally
            {
                Db.DisConnect();
            }
        }

        public bool ShowForm(int pCode, JDataBase DB)
        {
            if (pCode == 0)
            {
                JEnviromentForm JEF = new JEnviromentForm(DB);
                JEF.State = JFormState.Insert;
                if (JEF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return true;
            }
            else
            {

                JEnviromentForm JEF = new JEnviromentForm(pCode, DB);
                JEF.State = JFormState.Update;
                if (JEF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return true;
            }
            return false;
        }

        public void ShowForm(int pCode, int pMCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                JEnviromentForm JEF = new JEnviromentForm(pCode, pMCode,db);
                JEF.ShowDialog();
            }
            finally
            {
                db.DisConnect();
            }
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["NameEnviroment"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataJoint", "RealEstate.JEnviroment.ShowForm", new object[] { (int)pDR["Code"] }, null);

            JAction DeleteAct = new JAction("Delete", "RealEstate.JEnviroment.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);


            //Node.Hint = "name is " + (char)13 + Node.Name;
            return Node;
        }


        /// <summary>
        /// نمايش اطلاعات محيط براساس شرط
        /// </summary>
        public DataTable Show()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT code,NameEnviroment FROM ReEnviromentTable where ISArchive='False' ");
                db.Query_DataSet();
                return db.DataSet.Tables[0];
            }
            finally
            {
                db.DisConnect();
            }

        }


        /// <summary>
        /// فیلدهای این دارایی را با توجه به فیلدهایی که برای قرارداد داریم برمیگرداند
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable FieldList()
        {
            return FieldList("", 0);
        }
        public System.Data.DataTable FieldList(string pClassName, int pObjectCode)
        {
            //try
            {
                System.Data.DataTable tmpdt = GetContractData(0, pClassName, pObjectCode);
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("text");
                for (int i = 0; i < tmpdt.Columns.Count; i++)
                {
                    if (tmpdt.Columns[i].ColumnName != "ClassName" && tmpdt.Columns[i].ColumnName != "ObjectCode"
                        && tmpdt.Columns[i].ColumnName != "نام کلاس" && tmpdt.Columns[i].ColumnName != "کد شی" && tmpdt.Columns[i].ColumnName != "کد")
                    {
                        System.Data.DataRow dr = dt.NewRow();
                        dr["name"] = tmpdt.Columns[i].Caption;
                        dr["text"] = JLanguages._Text(tmpdt.Columns[i].Caption);
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //    return null;
            //}
        }

        /// <summary>
        /// اطلاعاتی را که برای قرارداد احتیاج داریم را برمیگرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public System.Data.DataTable GetContractData(int pCode)
        {
            return GetContractData(pCode, "", 0);
        }
        public System.Data.DataTable GetContractData(int pCode, string pClassName, int pObjectCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                JJoint _joint = new JJoint();
                _joint.GetData(pCode);
                int MarketCode = _joint.MarketCode;
                string PrtTable = (new Globals.Property.JProperties(pClassName, pObjectCode).TableName);

                string Query = @"Select  M.Title 'Enviroments.MarketName' , MF.Name 'Enviroments.Floor' ,NameEnviroment 'Enviroments.NameEnviroment',
        En.Address 'Enviroments.Address' , S1.name 'Enviroments.State' , S2.name 'Enviroments.Staus' , En.Area 'Enviroments.Area'  
        from ReEnviromentTable En
        inner join estMarket M on En.Complex = M.Code
        left join estMarketFloors MF on En.CodeFloor = MF.Code 
        left join subdefine S1 on En.state = S1.Code
        left join subdefine S2 on En.Door = S2.Code ";
                Db.setQuery(Query + " Where En.Code=" + pCode);
                System.Data.DataTable tmpdt = Db.Query_DataTable();
                foreach (System.Data.DataColumn DC in tmpdt.Columns)
                {
                    DC.Caption = JLanguages._Text(DC.Caption);
                    DC.ColumnName = JLanguages._Text(DC.Caption);
                }
                return tmpdt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null; ;
            }
            finally
            {
                Db.Dispose();
            }
        }

    }

    public class JEnviroments : JRealEstate
    {

        public static System.Data.DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            return GetDataTable(pCode, 0);
        }

        public static System.Data.DataTable GetDataTable(int pCode ,int pMCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string pWhere = " WHERE IsArchive='False'";
                if (pCode > 0)
                    pWhere = pWhere + " And Code=" + pCode.ToString();

                if (pMCode > 0)
                    pWhere = pWhere + " And Complex=" + pMCode.ToString();                

                DB.setQuery("SELECT * FROM ReEnviromentTable " + pWhere + " And " +
                    JPermission.getObjectSql("RealEstate.JEnviroments.GetDataTable", "ReEnviromentTable.Code"));
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
         //   return GetDataTable();
        }

        public void ListView()
        {
            ListView(0);
        }
        public void ListView(int pMCode)
        {
            Nodes.ObjectBase = new JAction("GetNode", "RealEstate.JEnviroment.GetNode");
            Nodes.DataTable = GetDataTable(0, pMCode);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("Joint", "RealEstate.JEnviroment.ShowForm", new object[] { 0, pMCode }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "RealEstate.JEnviroment.ShowForm", new object[] { 0, pMCode }, null)); 
        }
    }
}
