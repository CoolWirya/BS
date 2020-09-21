using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{

  
    public class JTransferSheet :JManagementshares
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد برگه
        /// </summary>
        public int SCode { get; set; }
        /// <summary>
        /// فروشنده
        /// </summary>
        public int FPCode { get; set; }
        /// <summary>
        /// خریدار
        /// </summary>
        public int SPCode { get; set; }
        /// <summary>
        /// تاریخ انتقال
        /// </summary>
        public DateTime TDate { get; set; }
        /// <summary>
        /// تعداد سهم انتقال یافته
        /// </summary>
        public int TranSum { get; set; }
        /// <summary>
        /// شماره دفتر 
        /// </summary>
        public string ShNote { get; set; }
        /// <summary>
        /// شماره ردیف
        /// </summary>
        public int ShIndex { get; set; }
        /// <summary>
        /// انتقال بصورت مصالحه 
        /// </summary>
        public bool Mosalehe { get; set; }
        /// <summary>
        /// انتقال وکالت
        /// </summary>
        public bool Agent { get; set; }
        /// <summary>
        /// مالیات
        /// </summary>
        public decimal Tax { get; set; }
        /// <summary>
        /// مبلغ کل
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// تائید شده (در قرارداد استفاده میشود)
        /// </summary>
        public bool Confirmed { get; set; }

		public int CompanyCode { get; set; }
        
        #endregion Properties

        public JTransferSheet()
        {
        }
        public JTransferSheet(int pCode)
        {
            GetData(pCode);
        }


        public void GetData(int TCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * From ShareTransfer WHERE Code = " + TCode);
                DataTable tran = db.Query_DataTable();
                if (tran.Rows.Count > 0)
                    JTable.SetToClassProperty(this, tran.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

        public static bool FindTranfer(string pShNote, string pShIndex, int pCompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT Code From ShareTransfer WHERE ShNote = '" + pShNote.ToString()
                    + "' AND ShIndex='" + pShIndex.ToString() + "' AND CompanyCode="+pCompanyCode.ToString());
                DataTable tran = db.Query_DataTable();
                return tran.Rows.Count > 0;
            }
            finally
            {
                db.DisConnect();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "ManagementShares.JShareSheet");
            int FPCode = (int)pRow["FPCode"];
            int SPCode = (int)pRow["SPCode"];
            int SCode = (int)pRow["SCode"];
            //foreach (DataRow row in Nodes.Selected.Rows)
            //{
            //    Array.Resize(ref codes, codes.Length + 1);
            //    codes[codes.Length - 1] = Convert.ToInt32(row["Code"]);
            //}
            JTransferSheet transfer = new JTransferSheet(node.Code);
            JAction returnAction = new JAction("ReturnTransfer...", "ManagementShares.JShareSheet.ReturnTransfer", new object[] { transfer, false }, new object[] { SCode});
            node.MouseDBClickAction = returnAction;
            node.EnterClickAction = returnAction;
            node.Popup.Insert(returnAction);

            node.Popup.Insert("-");
            JAction buyerAction = new JAction("SellerInfo...", "ClassLibrary.JAllPerson.ShowDialog", null, new object[] { FPCode });
            node.MouseDBClickAction = buyerAction;
            node.EnterClickAction = buyerAction;
            node.Popup.Insert(buyerAction);

            JAction sellerAction = new JAction("BuyerInfo...", "ClassLibrary.JAllPerson.ShowDialog", null, new object[] { SPCode });
            node.MouseDBClickAction = sellerAction;
            node.EnterClickAction = sellerAction;
            node.Popup.Insert(sellerAction);

            node.Popup.Insert("-");
            JAction editAction = new JAction("ViewInfo...", "ManagementShares.JTransferSheet.ShowDialog", new object[] { SCode, node.Code }, null);
            node.Popup.Insert(editAction);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            return node;
        }

        public void ShowDialog( int codes, int transferCode)
        {
             JTransferSheetForm form = new JTransferSheetForm(codes,transferCode );
            form.ShowDialog();
        }

        public int Insert(JDataBase pDB)
        {
            JTransferSheetTable tranTable = new JTransferSheetTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JTransferSheet.Insert"))
                {
                    tranTable.SetValueProperty(this);
                    tranTable.Set_ComplexInsert(false);
                    Code = tranTable.Insert(pDB);
                    return Code;
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        public bool Update(JDataBase pDB)
        {
            JDataBase DB = pDB;
            if (pDB == null)
                DB = new JDataBase();
            JTransferSheetTable tranTable = new JTransferSheetTable();
            try
            {
                //if (JPermission.CheckPermission("ManagementShares.JTransferSheet.Update"))
                {
                    tranTable.SetValueProperty(this);
                    return tranTable.Update(DB);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }
        }
        public bool Delete(JDataBase pDB)
        {
            JTransferSheetTable tranTable = new JTransferSheetTable();
            try
            {
                    tranTable.SetValueProperty(this);
                    tranTable.Set_ComplexInsert(false);
                    return tranTable.Delete(pDB);
                        
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
    }

    public class JTransferSheets : JManagementshares
    {
		static string Query = @"SELECT ShareTransfer.Code, [SCode], SPCode, FPCode
                  ,Seller.Name AS Seller
                  ,PersonBuyer.SharePCode BuyerPCode 
                  ,Person.SharePCode SellerPCode
				  ,Person.Address AdressSeller
				  ,Person.BirthCityName AS BirthCitySeller
				  ,Person.BirthDate as BirthDateSeller
				  ,Person.BirthplaceCode as BirthPlaceSeller
				  ,Person.Blocked as SellerBlocked
				  ,Person.Code as SellerCodeSeller
				  ,Person.CompanyCode as SellerCompanyCode
				  ,Person.Died as SellerDied
				  ,Person.Fam_CompanyName as SellerFamCompanyName
				  ,Person.FatherName as SellerFatherName
				  ,Person.FullName as SellerFullname
				  ,Person.Gender as SellerGender
				  ,Person.GenderTitle as SellerGenderTitle
				  ,Person.HomeAddress as SellerHomeAdress
				  ,Person.HomeCity as SellerHomeCity
				  ,Person.HomePostCode as SellerHomePostCode
				  ,Person.HomeTel as SellerHomeTell
				  ,Person.IDNo as SellerIDNo
				  ,Person.IsBlockedTitle as SellerIsBlockedTitle
				  ,Person.IsDiedTitle as SellerIsDiedTitle
				  ,Person.IssueCityName as SellerIssueCityName
				  ,Person.Mobile as SellerMobile
				  ,Person.Name as SellerName
				  ,Person.NationalCode_CommercialCode as SellerNationalCode
				  ,Person.PersonName as SellerName
				  ,Person.PersonTitle as SellerTitle
				  ,Person.PersonType as SellerType
				  ,Person.Sader as SellerSader
				  ,Person.SharePCode as SellerShareCode
				  ,Person.Tel as SellerTell
				  ,Person.WorkAddress as SellerWorkAdress
				  ,Person.WorkCity as SellerWorkCity
				  ,Person.WorkPostCode as SellerWorkPostCode
				  ,Person.WorkTel as SellerWorkTell

                  ,PersonBuyer.SharePCode BuyerPCode
				  ,PersonBuyer.Address BuyerAdress
				  ,PersonBuyer.BirthCityName AS BuyerBirthCit
				  ,PersonBuyer.BirthDate as BuyerBirthDate
				  ,PersonBuyer.BirthplaceCode as BuyerBirthPlace
				  ,PersonBuyer.Blocked as BuyerBlocked
				  ,PersonBuyer.Code as BuyerCodeBuyer
				  ,PersonBuyer.CompanyCode as BuyerCompanyCode
				  ,PersonBuyer.Died as BuyerDied
				  ,PersonBuyer.Fam_CompanyName as BuyerFamCompanyName
				  ,PersonBuyer.FatherName as BuyerFatherName
				  ,PersonBuyer.FullName as BuyerFullname
				  ,PersonBuyer.Gender as BuyerGender
				  ,PersonBuyer.GenderTitle as BuyerGenderTitle
				  ,PersonBuyer.HomeAddress as BuyerHomeAdress
				  ,PersonBuyer.HomeCity as BuyerHomeCity
				  ,PersonBuyer.HomePostCode as BuyerHomePostCode
				  ,PersonBuyer.HomeTel as BuyerHomeTell
				  ,PersonBuyer.IDNo as BuyerIDNo
				  ,PersonBuyer.IsBlockedTitle as BuyerIsBlockedTitle
				  ,PersonBuyer.IsDiedTitle as BuyerIsDiedTitle
				  ,PersonBuyer.IssueCityName as BuyerIssueCityName
				  ,PersonBuyer.Mobile as BuyerMobile
				  ,PersonBuyer.Name as BuyerName
				  ,PersonBuyer.NationalCode_CommercialCode as BuyerNationalCode
				  ,PersonBuyer.PersonName as BuyerName
				  ,PersonBuyer.PersonTitle as BuyerTitle
				  ,PersonBuyer.PersonType as BuyerType
				  ,PersonBuyer.Sader as BuyerSader
				  ,PersonBuyer.SharePCode as BuyerShareCode
				  ,PersonBuyer.Tel as BuyerTell
				  ,PersonBuyer.WorkAddress as BuyerWorkAdress
				  ,PersonBuyer.WorkCity as BuyerWorkCity
				  ,PersonBuyer.WorkPostCode as BuyerWorkPostCode
				  ,PersonBuyer.WorkTel as BuyerWorkTell


				  ,(Select Fa_Date from StaticDates Where En_Date =Cast( [TDate] AS date))+' '+left(cast(cast(Tdate as time) as varchar),5) TransferDate
                  ,[TranSum]
                  ,[ShNote]
                  ,[ShIndex]
                  ,[Mosalehe]
                  ,[Tax]
                  ,[Price]
                  ,[Agent]
				  ,Prop.*
              FROM [ShareTransfer] 
              inner join ShareSheet ON [ShareTransfer].SCode = ShareSheet.Code and ShareTransfer.CompanyCode=ShareSheet.CompanyCode
              inner join clsAllPerson Seller ON [ShareTransfer].FPCode = Seller .Code
              inner join clsAllPerson Buyer ON [ShareTransfer].SPCode  = Buyer .Code 
			  Inner Join PersonAddressViewSharePCode Person On ShareTransfer.FPCode = Person .Code and ShareSheet.CompanyCode = Person.CompanyCode
			  Inner Join PersonAddressViewSharePCode PersonBuyer On ShareTransfer.SPCode = PersonBuyer .Code and ShareSheet.CompanyCode = PersonBuyer.CompanyCode ";

        public static string GetQuery(int pCompanyCode)
        {
            string sql = @"SELECT ShareTransfer.Code, [SCode], SPCode, FPCode
                  ,Seller.Name AS Seller
                  ,PersonBuyer.SharePCode BuyerPCode 
                  ,Person.SharePCode SellerPCode
				  ,Person.Address AdressSeller
				  ,Person.BirthCityName AS BirthCitySeller
				  ,Person.BirthDate as BirthDateSeller
				  ,Person.BirthplaceCode as BirthPlaceSeller
				  ,Person.Blocked as SellerBlocked
				  ,Person.Code as SellerCodeSeller
				  ,Person.CompanyCode as SellerCompanyCode
				  ,Person.Died as SellerDied
				  ,Person.Fam_CompanyName as SellerFamCompanyName
				  ,Person.FatherName as SellerFatherName
				  ,Person.FullName as SellerFullname
				  ,Person.Gender as SellerGender
				  ,Person.GenderTitle as SellerGenderTitle
				  ,Person.HomeAddress as SellerHomeAdress
				  ,Person.HomeCity as SellerHomeCity
				  ,Person.HomePostCode as SellerHomePostCode
				  ,Person.HomeTel as SellerHomeTell
				  ,Person.IDNo as SellerIDNo
				  ,Person.IsBlockedTitle as SellerIsBlockedTitle
				  ,Person.IsDiedTitle as SellerIsDiedTitle
				  ,Person.IssueCityName as SellerIssueCityName
				  ,Person.Mobile as SellerMobile
				  ,Person.Name as SellerName
				  ,Person.NationalCode_CommercialCode as SellerNationalCode
				  ,Person.PersonName as SellerName2
				  ,Person.PersonTitle as SellerTitle
				  ,Person.PersonType as SellerType
				  ,Person.Sader as SellerSader
				  ,Person.SharePCode as SellerShareCode
				  ,Person.Tel as SellerTell
				  ,Person.WorkAddress as SellerWorkAdress
				  ,Person.WorkCity as SellerWorkCity
				  ,Person.WorkPostCode as SellerWorkPostCode
				  ,Person.WorkTel as SellerWorkTell

                  ,PersonBuyer.SharePCode BuyerPCode2
				  ,PersonBuyer.Address BuyerAdress
				  ,PersonBuyer.BirthCityName AS BuyerBirthCit
				  ,PersonBuyer.BirthDate as BuyerBirthDate
				  ,PersonBuyer.BirthplaceCode as BuyerBirthPlace
				  ,PersonBuyer.Blocked as BuyerBlocked
				  ,PersonBuyer.Code as BuyerCodeBuyer
				  ,PersonBuyer.CompanyCode as BuyerCompanyCode
				  ,PersonBuyer.Died as BuyerDied
				  ,PersonBuyer.Fam_CompanyName as BuyerFamCompanyName
				  ,PersonBuyer.FatherName as BuyerFatherName
				  ,PersonBuyer.FullName as BuyerFullname
				  ,PersonBuyer.Gender as BuyerGender
				  ,PersonBuyer.GenderTitle as BuyerGenderTitle
				  ,PersonBuyer.HomeAddress as BuyerHomeAdress
				  ,PersonBuyer.HomeCity as BuyerHomeCity
				  ,PersonBuyer.HomePostCode as BuyerHomePostCode
				  ,PersonBuyer.HomeTel as BuyerHomeTell
				  ,PersonBuyer.IDNo as BuyerIDNo
				  ,PersonBuyer.IsBlockedTitle as BuyerIsBlockedTitle
				  ,PersonBuyer.IsDiedTitle as BuyerIsDiedTitle
				  ,PersonBuyer.IssueCityName as BuyerIssueCityName
				  ,PersonBuyer.Mobile as BuyerMobile
				  ,PersonBuyer.Name as BuyerName
				  ,PersonBuyer.NationalCode_CommercialCode as BuyerNationalCode
				  ,PersonBuyer.PersonName as BuyerName2
				  ,PersonBuyer.PersonTitle as BuyerTitle
				  ,PersonBuyer.PersonType as BuyerType
				  ,PersonBuyer.Sader as BuyerSader
				  ,PersonBuyer.SharePCode as BuyerShareCode
				  ,PersonBuyer.Tel as BuyerTell
				  ,PersonBuyer.WorkAddress as BuyerWorkAdress
				  ,PersonBuyer.WorkCity as BuyerWorkCity
				  ,PersonBuyer.WorkPostCode as BuyerWorkPostCode
				  ,PersonBuyer.WorkTel as BuyerWorkTell


				  ,(Select Fa_Date from StaticDates Where En_Date =Cast( [TDate] AS date)) TransferDate
                  ,[TranSum]
                  ,[ShNote]
                  ,[ShIndex]
                  ,[Mosalehe]
                  ,[Tax]
                  ,[Price]
                  ,[Agent]
				  ,Prop.Code Code2
				  ,Prop.ObjectCode
				  ,Prop.نوع__انتقال
				  ,Prop.RegisterPostCode
              FROM [ShareTransfer] 
              inner join ShareSheet ON [ShareTransfer].SCode = ShareSheet.Code and ShareTransfer.CompanyCode=ShareSheet.CompanyCode
              inner join clsAllPerson Seller ON [ShareTransfer].FPCode = Seller .Code
              inner join clsAllPerson Buyer ON [ShareTransfer].SPCode  = Buyer .Code 
			  Inner Join PersonAddressViewSharePCode Person On ShareTransfer.FPCode = Person .Code and ShareSheet.CompanyCode = Person.CompanyCode
			  Inner Join PersonAddressViewSharePCode PersonBuyer On ShareTransfer.SPCode = PersonBuyer .Code and ShareSheet.CompanyCode = PersonBuyer.CompanyCode "; ;
            Globals.Property.JProperties P = new Globals.Property.JProperties("ManagementShares.JTransferSheetForm", 0);
            sql += Environment.NewLine +
                " left join " + P.TableName + " Prop on ShareTransfer.Code = Prop.ObjectCode ";
            sql += " WHERE Confirmed = 1 AND  ShareSheet.CompanyCode = " + pCompanyCode;
            return sql;
        }

        public DataTable GetDataTable(int pCompanyCode)
        {
            JDataBase db = new JDataBase();
            try
            {
				string Q = JTransferSheets.Query;
				Globals.Property.JProperties P = new Globals.Property.JProperties("ManagementShares.JTransferSheetForm", 0);
				Q = Q + Environment.NewLine +
					" left join " + P.TableName + " Prop on ShareTransfer.Code = Prop.ObjectCode ";
				string sql = Q + " WHERE Confirmed = 1 AND  ShareSheet.CompanyCode = " + pCompanyCode;
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public void ListView(int pCompanyCode)
        {
            Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JTransferSheet.GetNode");
            Nodes.hidColumns = "SPCode;FPCode";
            Nodes.DataTable = GetDataTable(pCompanyCode);
        }
    }

}
