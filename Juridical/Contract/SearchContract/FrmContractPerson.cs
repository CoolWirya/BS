using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Legal;

namespace Security
{
    public partial class FrmGetContract :JBaseForm
    {
        /// <summary>
        ///شخص انتخاب شده را باز مي گرداند
        /// </summary>
        public  JAllPerson Person;
        
        public  RealEstate.JUnitBuild Build;
        private RealEstate.JEnviroment Enviroment;
        /// <summary>
        ///اطلاعات اموال را باز مي گرداند
        /// </summary>
        public  Finance.JAsset Asset;
        private DataTable DtAmlak;
        /// <summary>
        ///قرارداد انتخاب شده را بر مي گرداند
        /// </summary>
        public  JSubjectContract Contract;
        /// <summary>
        ///اطلاعات ايتم انتخاب شده را به صور ت رشته اي بر مي گرداند
        /// </summary>
        public string FullReturnString;

        public FrmGetContract()
        {
            InitializeComponent();
            fillCombo();
            Contract = new JSubjectContract();
            Build = new RealEstate.JUnitBuild();
            Asset = new Finance.JAsset();
            Person = new JAllPerson();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
           
        }

        public FrmGetContract(JAllPerson PersonSelect)
        {
            InitializeComponent();
            fillCombo();
            GetData(" And PersonCode=" + PersonSelect.Code.ToString());
            
         
        }
        public void GetData(string Where)
        {
            DataTable dt = QueryAssetPerson(Where);
            if (dt != null && dt.Rows.Count > 0)
            {
                Contract = new JSubjectContract(Convert.ToInt32(dt.Rows[0]["Code"]));
                Person = new JAllPerson(Convert.ToInt32(dt.Rows[0]["PersonCode"]));
                Asset = new Finance.JAsset(Convert.ToInt32(dt.Rows[0]["FinanceCode"]));
                Build = new RealEstate.JUnitBuild(Asset.ObjectCode);
                txtBuild.Text = Build.Plaque;
                TxtNumber.Text = Contract.Number;
                txDatein.Text = JDateTime.FarsiDate(Contract.StartDate);
                txtDatetOut.Text = JDateTime.FarsiDate(Contract.EndDate);
                txtPerson.Text = Person.Name;
                CmbTypeGh.SelectedValue = dt.Rows[0]["Title"].ToString();
                CmbTypeGh.Text = dt.Rows[0]["Title"].ToString();

                grdContracts.bind(dt, "sss");

            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                JMessages.Information("هيچ مقداري يافت نشد", "dfdf");
            }
        }
        public FrmGetContract(int ContratcCode)
        {
            InitializeComponent();
            fillCombo();
            string Str = "Where SC.Code=" + ContratcCode.ToString();
            GetData(Str);
           
           
            

        }
        private DataTable QueryAssetPerson( string _query)
        {
            JDataBase db = new JDataBase();
            try
            {
//                if (TypeQuery == 1)
//                {
//                    db.setQuery("SELECT     SC.Code, DT.Title, SC.Number, " +

//                        "(SELECT     Fa_Date " +
//                             "FROM         dbo.StaticDates " +
//                             "WHERE     (En_Date = SC.Date)) AS ContractDate, " +
//                          "(SELECT     Fa_Date " +
//                             "FROM         dbo.StaticDates AS StaticDates_4 " +
//                             "WHERE     (En_Date = SC.DateDeliver)) AS DateDeliver, " +
//                          "(SELECT     Fa_Date " +
//                             "FROM         dbo.StaticDates AS StaticDates_3 " +
//                             "WHERE     (En_Date = SC.StartDate)) AS StartDate, " +
//                          "(SELECT     Fa_Date " +
//                             "FROM         dbo.StaticDates AS StaticDates_2 " +
//                             "WHERE     (En_Date = SC.EndDate)) AS EndDate, SC.FinanceCode, " +
//                          "(SELECT     Comment " +
//                             "FROM         dbo.finAsset " +
//                             "WHERE     (Code = SC.FinanceCode)) AS Asset, " +
//                          "(SELECT     name " +
//                             "FROM         dbo.subdefine " +
//                             "WHERE     (Code = SC.Job)) AS Job, " +
//                      "CASE [Status] WHEN 0 THEN '' WHEN 1 THEN N'جاری' WHEN 2 THEN N'اتمام' WHEN 3 THEN N'فسخ شده' WHEN 4 THEN N'غیر فعال' ELSE '' END AS StatusTitle," +
//                       "SC.Status, DT.AssetTransferType, dbo.VPersonContractG.PersonCode, DT.ClassName,(SELECT  STUFF   ( (   " +
//                    "SELECT ',' +Name+' ' " +
//                  "FROM VPersonContract  where  VPersonContract.ContractSubjectCode=SC.Code " +
//                    "FOR XML PATH ('')),1,1,'' ) AS 'ContractPerson') " +
//"FROM         dbo.LegSubjectContract AS SC INNER JOIN " +
//                      "dbo.LegContractType AS LT ON SC.Type = LT.Code INNER JOIN " +
//                      "dbo.legContractDynamicTypes AS DT ON DT.Code = LT.ContractType INNER JOIN " +
//                      "dbo.VPersonContractG ON SC.Code = dbo.VPersonContractG.ContractSubjectCode " + _query);
//                }
                
                    db.setQuery("SELECT     SC.Code,SC.Number, VPersonContract.Name As Tarfin, DT.Title,   (SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_3 WHERE     (En_Date = SC.StartDate)) AS StartDate "+
                        ",(SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_2 WHERE     (En_Date = SC.EndDate)) AS EndDate,  (SELECT     Comment FROM         dbo.finAsset WHERE     (Code = SC.FinanceCode)) AS Asset "+
                        ",(SELECT     name FROM         dbo.subdefine WHERE     (Code = SC.Job)) AS Job, CASE [Status] WHEN 0 THEN '' WHEN 1 THEN N'جاری' WHEN 2 THEN N'اتمام' WHEN 3 THEN N'فسخ شده' WHEN 4 THEN N'غیر فعال' ELSE '' END AS StatusTitle "+
                        ",(SELECT     STUFF ((SELECT     ' | ' + AP.Name  FROM          LegPersonContract PC INNER JOIN clsAllPerson AP ON PC.PersonCode = AP.Code AND PC.Type = 7  WHERE      PC.ContractSubjectCode = SC.Code FOR XML PATH('')), 1, 2, '')) AS 'StrSeller'/*-طرف اول*/ ,SC.FinanceCode,dbo.VPersonContract.PersonCode " +
                          ",(SELECT     STUFF  ((SELECT     ' | ' + AP.Name   FROM          LegPersonContract PC INNER JOIN    clsAllPerson AP ON PC.PersonCode = AP.Code AND PC.Type = 9   WHERE      PC.ContractSubjectCode = SC.Code FOR XML PATH('')), 1, 2, '')) AS 'StrBuyer' "+
                        "FROM         dbo.LegSubjectContract AS SC INNER JOIN dbo.LegContractType AS LT ON SC.Type = LT.Code INNER JOIN dbo.legContractDynamicTypes AS DT ON DT.Code = LT.ContractType INNER JOIN dbo.VPersonContract ON SC.Code = dbo.VPersonContract.ContractSubjectCode  " + _query);
                    
                
//                if (TypeQuery == 3)
//                {
//                    db.setQuery("SELECT     SC.Code, DT.Title, "+
//                          "(SELECT     Fa_Date "+
//                             "FROM         dbo.StaticDates "+
//                             "WHERE     (En_Date = SC.Date)) AS ContractDate, "+
//                          "(SELECT     Fa_Date "+
//                             "FROM         dbo.StaticDates AS StaticDates_4 "+
//                             "WHERE     (En_Date = SC.DateDeliver)) AS DateDeliver, "+
//                          "(SELECT     Fa_Date "+
//                             "FROM         dbo.StaticDates AS StaticDates_3 "+
//                             "WHERE     (En_Date = SC.StartDate)) AS StartDate, "+
//                          "(SELECT     Fa_Date "+
//                             "FROM         dbo.StaticDates AS StaticDates_2 "+
//                             "WHERE     (En_Date = SC.EndDate)) AS EndDate, SC.FinanceCode, "+
//                          "(SELECT     Comment "+
//                             "FROM         dbo.finAsset "+
//                             "WHERE     (Code = SC.FinanceCode)) AS Asset, "+
//                          "(SELECT     name "+
//                             "FROM         dbo.subdefine "+
//                             "WHERE     (Code = SC.Job)) AS Job, DT.AssetTransferType, DT.ClassName, SC.Number, dbo.SecLinkPerson.Hint, subdefine_1.name, "+
//                      "dbo.SecLinkPerson.PersonCode, "+
//                      "(SELECT  STUFF   ( (   " +
//                      "SELECT ',' +Name+' ' " +
//                    "FROM VPersonContract  where  VPersonContract.ContractSubjectCode=SC.Code " +
//                      "FOR XML PATH ('')),1,1,'' ) AS 'ContractPerson') " +
//"FROM         dbo.LegSubjectContract AS SC INNER JOIN "+
//                      "dbo.LegContractType AS LT ON SC.Type = LT.Code INNER JOIN "+
//                      "dbo.legContractDynamicTypes AS DT ON DT.Code = LT.ContractType INNER JOIN "+
//                      "dbo.SecLinkPerson ON SC.Code = dbo.SecLinkPerson.CodeContract INNER JOIN "+
//                      "dbo.subdefine AS subdefine_1 ON dbo.SecLinkPerson.JobPostion = subdefine_1.Code "+
//"WHERE     (1 = 1)" + _query);

                //}
                return db.Query_DataTable();
                
                

            }
            catch
            {
                return null;
            }
        }

       

        private void fillCombo()
        {

            DtAmlak = JContractDynamicTypes.GetDataTable(0);
            CmbTypeGh.DataSource = DtAmlak;
            CmbTypeGh.ValueMember = "Title";
            CmbTypeGh.DisplayMember = "Title";
            
        }
       
        private void FrmContractPerson_Load(object sender, EventArgs e)
        {
            CmbTypeGh.Text = "";
            
           

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string svalue = DtAmlak.Rows[CmbTypeGh.SelectedIndex]["ClassName"].ToString();

                switch (svalue)
                {
                    case "RealEstate.JUnitBuild":
                        RealEstate.JSearchUnitForm frmSearchUnitBuild = new RealEstate.JSearchUnitForm();
                        label1.Text = "كد اعيان :";
                        frmSearchUnitBuild.ShowDialog();
                        Build.GetData(frmSearchUnitBuild.SelectedCode);

                        txtBuild.Text = Build.Plaque.ToString();
                        break;
                    case "RealEstate.JEnviroment":
                        label1.Text = "كد مشاعات :";
                        //Enviroment.GetData(frmSearchUnitBuild.SelectedCode);
                        Asset = new Finance.JAsset();
                        Asset.GetData("RealEstate.JEnviroment", Enviroment.Code);
                        txtBuild.Text = Asset.Code.ToString();
                        break;
                }
            }
            catch
            {
                JMessages.Information("نوع قرارداد نا مشخص است", "dfdf");
            }

        }

        private void PersonSearch_Click(object sender, EventArgs e)
        {
            //Financ
            ClassLibrary.JFindPersonForm searchPerson = new JFindPersonForm(JPersonTypes.None);
            if (searchPerson.ShowDialog() == DialogResult.OK)
            {
                /// انتخاب یکی
                Person = searchPerson.SelectedPerson;
                txtPerson.Text = Person.Name;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        //ContractHistory(int pFinanceCode, Finance.JOwnershipType pAssetTransferType, bool CurrentContracts)

        }
        private string CreateQuery(ref int TypeViwe)
        {
            string Str = "Where (1=1) ";
           TypeViwe = 1;
            if (txtBuild.Text != string.Empty)
            {
                if (Build != null)
                {
                    Asset.GetData("RealEstate.JUnitBuild", Build.Code);
                    Str = Str + "And " + "SC.FinanceCode=" + Asset.Code.ToString();
                }

            }
            if (txDatein.Date.ToString("yyyy") != "0001")
            {
                Str = Str + " And StartDate>'" + txDatein.Date.ToString("yyyy/MM/dd") + "'";
            }
            if (txtDatetOut.Date.ToString("yyyy") != "0001") 
            {
                Str = Str + " And EndDate<'" + txtDatetOut.Date.ToString("yyyy/MM/dd") + "'";

            }
            
            if (CmbTypeGh.Text != "")
            {
                Str = Str + " And DT.Title='" + CmbTypeGh.SelectedValue.ToString() + "'";
            }
            if (txtPerson.Text != string.Empty)
            {
                TypeViwe = 2;
                Str = Str + " And PersonCode=" + Person.Code.ToString();
            }
            if (ChkActive.Checked == true)
            {
                Str = Str + " And  SC.Status=1";
            }
           
            if (TxtNumber.Text!=string.Empty)
            {
                Str = Str + " And  SC.Number='"+TxtNumber.Text+"'";
            }
            return Str;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int code = 0;
          string Query=CreateQuery(ref code);
          DataTable dt = QueryAssetPerson(Query);
          if ( dt.Rows.Count > 0)
          {
              grdContracts.bind(dt, "sss");

          }
          else
          {
              if (txtPerson.Text != string.Empty)
              {
                  Query = " And SecLinkPerson.PersonCode='" + Person.Code.ToString() + "'";
                  dt = QueryAssetPerson(Query);
                  grdContracts.bind(dt, "sss", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown);

              }
          }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CmbTypeGh_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void grdContracts_Click(object sender, EventArgs e)
        {
           
            //if (grdContracts.gridEX1.Row > 0)
            //{
            //    DataTable DtSelect = (DataTable)grdContracts.DataSource;
            //    //grdContractsGoodwill.ClearActions();
            //    List<JAction> actions = CreateActions(Convert.ToInt32(Convert.ToInt32(DtSelect.Rows[grdContracts.gridEX1.Row]["PersonCode"]));
                  
            //    foreach (JAction action in actions)
            //    {
            //        grdContractsGoodwill.AddAction(action);
            //    }
            //}
        }

        private void grdContracts_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            try
            {
                if (e.Row.DataRow != null)
                {
                    DataRow _DR = ((System.Data.DataRowView)(e.Row.DataRow)).Row;
                    Contract.GetData(Convert.ToInt32(_DR["Code"]));
                    Person.GetData(Convert.ToInt32(_DR["PersonCode"]));
                }
              
               
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            catch
            {
                JMessages.Error("هيچ موردي در حال انتخاب نيست", "نكته");
            }
        }

       

        
       
       
    }
}
