using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Reflection;
using Janus.Windows.GridEX;

namespace RealEstate
{        
    /// <summary>
        /// وضعیت قرارداد
        /// </summary>
        public enum JContractStatus
        {
            None = 0,
            /// <summary>
            /// جاری
            /// </summary>
            CurrentContract = 1,
            /// <summary>
            /// اتمام
            /// </summary>
            ExpiredContract = 2,
            /// <summary>
            /// فسخ شده
            /// </summary>
            CanceledContract = 3,
            /// <summary>
            /// غیر فعال
            /// </summary>
            Disabled = 4,
        }

        /// <summary>
        /// وضعیت مالک
        /// </summary>
        public enum JMalekStatus
        {            
            /// <summary>
            /// زمین
            /// </summary>
            Ground = 1,
            /// <summary>
            /// واحد تجاری
            /// </summary>
            Build = 2,
            /// <summary>
            /// مشاعات
            /// </summary>
            Moshaat = 3,
            /// <summary>
            /// 
            /// </summary>
            //Disabled = 4,
        }
        /// <summary>
        /// طرف قرارداد
        /// </summary>
        public enum JContractPersonStatus
        {            
            /// <summary>
            /// طرف اول
            /// </summary>
            PersonFirst = 7,
            /// <summary>
            /// طرف دوم
            /// </summary>
            PersonSecond = 9,
            /// <summary>
            /// شاهد
            /// </summary>
            Viewer = 10,
            /// <summary>
            /// وکیل
            /// </summary>
            Advocate = 11,
        }
        /// <summary>
        /// انواع مالک
        /// </summary>
        public enum JMalekType
        {
            /// <summary>
            /// قطعی
            /// </summary>
            ghatee = 1,
            /// <summary>
            /// سرقفلی
            /// </summary>
            sarghofli = 2,
            /// <summary>
            /// مستاجر
            /// </summary>
            mostajer = 3,
            /// <summary>
            /// مستاجر صلح سرقفلی
            /// </summary>
            mostajerSolh = 4,
        }

    public partial class JReportContractFrom : ClassLibrary.JBaseForm
    {
        DataTable _dtReport1 = new DataTable();
        DataTable _dtReport2 = new DataTable();
        DataTable _dtReport3 = new DataTable();
        DataTable _dtReport4 = new DataTable();
        DataTable _dtReport5 = new DataTable();


        public JReportContractFrom()
        {
            InitializeComponent();
        }

        #region Fill
        
        /// <summary>
        /// پر کردن اطلاعات قرارداد
        /// </summary>        
        private void Fill_Contract()
        {
            try
            {
                //DataTable dtLocation = (new JOrganizations()).GetOrganization(0);
                //DataRow dr = dtLocation.NewRow();
                //dr["Code"] = -1;
                //dr["name"] = "-----------";
                //dtLocation.Rows.Add(dr);
                //C1Location.DisplayMember = "name";
                //C1Location.ValueMember = "Code";
                //C1Location.DataSource = dtLocation;
                //C1Location.Text = "";

                //DataTable dt = Legal.JContractdefines.GetDataTable(0, 0, null);
                DataTable dt = Legal.JContractDynamicTypes.GetDataTable();
                DataRow dr1 = dt.NewRow();
                dr1["Code"] = -1;
                dr1["Title"] = "-----------";
                dt.Rows.Add(dr1);
                C1Type.DisplayMember = "Title";
                C1Type.ValueMember = "Code";
                C1Type.DataSource = dt;
                C1Type.Text = "";
                C1Type.SelectedValue = -1;
                C1Status.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("RealEstate.JContractStatus")));
                chkStatusMalek.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("RealEstate.JMalekStatus")));
                chkContractPType.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("RealEstate.JContractPersonStatus")));
                chkMalekType.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("RealEstate.JMalekType")));
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// پر کردن اطلاعات اعیان
        /// </summary>
        private void Fill_UnitBuild()
        {
            try
            {
                RealEstate.JUnitTypes UnitType = new RealEstate.JUnitTypes();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                //B1TypeCode.Items.Clear();
                //B1TypeCode.Items.Add(nullDeff);
                //B1TypeCode.SelectedItem = nullDeff;
                //UnitType.SetComboBox(B1TypeCode);
                //foreach (JSubBaseDefine city in UnitType.Items)
                //    B1TypeCode.Items.Add(city);

                RealEstate.JUnitJobs UnitJobs = new RealEstate.JUnitJobs();
                B1UnitJob.Items.Clear();
                B1UnitJob.Items.Add(nullDeff);
                B1UnitJob.SelectedItem = nullDeff;
                UnitJobs.SetComboBox(B1UnitJob);                

                DataTable Markets = RealEstate.jMarkets.GetDataTable(0);
                DataRow dr = Markets.NewRow();
                dr["Code"] = -1;
                dr[RealEstate.estMarket.Title.ToString()] = "-----------";
                Markets.Rows.Add(dr);
                B1MarketCode.DisplayMember = RealEstate.estMarket.Title.ToString();
                B1MarketCode.ValueMember = RealEstate.estMarket.Code.ToString();
                B1MarketCode.DataSource = Markets;
                B1MarketCode.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        private void JReportContractFrom_Load(object sender, EventArgs e)
        {
            Fill_Contract();
            Fill_UnitBuild();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable[] SubReports = new DataTable[4];

            SubReports[0] = _dtReport1;
            SubReports[0].TableName = "همه قراردادها";

            SubReports[1] = _dtReport2;
            SubReports[1].TableName = "قرادادهای فعال";

            SubReports[2] = _dtReport3;
            SubReports[2].TableName = "طرفین قرارداد";

            SubReports[3] = _dtReport4;
            SubReports[3].TableName = "واحد تجاری";

            JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.ReportContract.GetHashCode());
            DRF.AddRange(SubReports);
            DRF.ShowDialog();
        }

        string _Where = " Where 1=1 ";

        string MainQuery = @"Select S.Code As 'ContractCode',FA.Code as 'FCode',P.Code 'PersonCode',UB.Code 'UnitBuildCode',FA.ObjectCode 
from LegSubjectContract S inner join LegPersonContract P on P.ContractSubjectCode=S.Code 
inner join finAsset FA On FA.Code=S.FinanceCode
inner join estUnitBuild UB ON UB.Code=FA.ObjectCode and FA.ClassName='RealEstate.JUnitBuild'";


        private void subWhere()
        {
            string value = "";
            _Where = " Where 1=1 ";
            if (Convert.ToInt32(B1UnitJob.SelectedValue) > 0)
                _Where = _Where + " and S.Job= " + B1UnitJob.SelectedValue.ToString();
            if (Convert.ToInt32(C1Type.SelectedValue) > 0)
                _Where = _Where + " and S.Type= " + C1Type.SelectedValue.ToString();
            if (Convert.ToInt32(B1FloorCode.SelectedValue) > 0)
                _Where = _Where + " and UB.FloorCode= " + B1FloorCode.SelectedValue.ToString();
            if (Convert.ToInt32(B1MarketCode.SelectedValue) > 0)
                _Where = _Where + " and UB.MarketCode= " + B1MarketCode.SelectedValue.ToString();
            else
            {
                for (int i = 0; i < B1MarketCode.Items.Count; i++)
                    value = value + ((System.Data.DataRowView)(B1MarketCode.Items[i])).Row.ItemArray[0].ToString() + ",";
                if (value != "")
                    _Where = _Where + " And UB.MarketCode in (" + value + "-1)";
            }
            if (chkActiveContract.Checked)
                _Where = _Where + " And S.Code in (Select Code From VActiveContract)";
            if (B1Plaque.Text != "")
                _Where = _Where + " And  UB.Plaque='" + B1Plaque.Text + "'";
            if (B1Number.Text != "")
                _Where = _Where + " And  UB.Number='" + B1Number.Text + "'";
            if (B1PlaqueRegistration.Text != "")
                _Where = _Where + " And  UB.PlaqueRegistration=" + B1PlaqueRegistration.Text;
            value = "";
            for (int i = 0; i < C1Status.Items.Count; i++)
                if (C1Status.GetItemChecked(i))
                    value = value + (Convert.ToInt32(((ClassLibrary.JKeyValue)C1Status.Items[i]).Value)).ToString() + ",";
            if (value != "")
                _Where = _Where + " And S.Status in (" + value + "-1)";

            //value = "";
            //for (int i = 0; i < chkStatusMalek.Items.Count; i++)
            //    if (chkStatusMalek.GetItemChecked(i))
            //        value = value + (Convert.ToInt32(((ClassLibrary.JKeyValue)chkStatusMalek.Items[i]).Value)).ToString() + ",";
            //if (value != "")
            //    _Where = _Where + " And F.Active=1 And F.Status in (" + value + "-1)";

            if (jucPersonContract.SelectedCode > 0)
                _Where = _Where + " and P.PersonCode= " + jucPersonContract.SelectedCode.ToString();

            if (VS1PersonCode.SelectedCode > 0)
                _Where = _Where + " and FA.Code in (select ACode from finAssetShare where PersonCode=" + VS1PersonCode.SelectedCode.ToString() + ") ";

            value = "";
            for (int i = 0; i < chkMalekType.Items.Count; i++)
                if (chkMalekType.GetItemChecked(i))
                    value = value + (Convert.ToInt32(((ClassLibrary.JKeyValue)chkMalekType.Items[i]).Value)).ToString() + ",";
            if (value != "")
                _Where = _Where + " And FA.Active=1 And FA.Code in (select ACode from finassettransfer where ownershiptype in (" + value + "-1))";

            value = "";
            for (int i = 0; i < chkContractPType.Items.Count; i++)
                if (chkContractPType.GetItemChecked(i))
                    value = value + (Convert.ToInt32(((ClassLibrary.JKeyValue)chkContractPType.Items[i]).Value)).ToString() + ",";
            if (value != "")
                _Where = _Where + " And P.Type in (" + value + "-1)";

            
            if (C1Number.Text != "")
                _Where = _Where + " And S.Number  >= '" + C1Number.Text + "'";
            if (C1Number2.Text != "")
                _Where = _Where + " And S.Number  <= '" + C1Number2.Text + "'";

            if (C1StartDate.Date != DateTime.MinValue)
                _Where = _Where + " And S.StartDate  >= '" + C1StartDate.StringDate + "'";
            if (C1StartDate2.Date != DateTime.MinValue)
                _Where = _Where + " And S.StartDate  <= '" + C1StartDate2.StringDate + "'";

            if (C1EndDate.Date != DateTime.MinValue)
                _Where = _Where + " And S.EndDate  >= '" + C1EndDate.StringDate + "'";
            if (C1EndDate2.Date != DateTime.MinValue)
                _Where = _Where + " And S.EndDate  <= '" + C1EndDate2.StringDate + "'";

            if (C1Date.Date != DateTime.MinValue)
                _Where = _Where + " And S.Date  >= '" + C1Date.StringDate + "'";
            if (C1Date2.Date != DateTime.MinValue)
                _Where = _Where + " And S.Date <= '" + C1Date2.StringDate + "'";

            if (txtArea.Text != "")
                _Where = _Where + " And UB.Area  >= " + txtArea.Text;
            if (txtArea2.Text != "")
                _Where = _Where + " And UB.Area  <= " + txtArea2.Text;

            if (txtBalcon.Text != "")
                _Where = _Where + " And UB.Balcon  >= " + txtBalcon.Text;
            if (txtBalcon2.Text != "")
                _Where = _Where + " And UB.Balcon  <= " + txtBalcon2.Text;

        }

        private void Report1()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {                
                DB.setQuery(@"
Select  
S.Code,
(Select Name from subdefine where S.Job=Code) 'JobContractName',
(Select Title From legContractDynamicTypes where Code = S.Type) 'TitleContractType',
S.Number,
F.Comment,
(Select Fa_Date from staticDates where en_Date =  Cast(S.Date as date)) 'Date',
(Select Fa_Date from staticDates where en_Date =  Cast(S.DateDeliver as date))'DateDeliver',
(Select Fa_Date from staticDates where en_Date =  Cast(S.StartDate as date)) 'StartDate',
(Select Fa_Date from staticDates where en_Date =  Cast(S.EndDate as date)) 'EndDate',
S.Description,
S.Guarantee,
S.Condition,
Case S.Status 
	            when 0 then N'هیچکدام'	
	            when 1 then N'جاری'
	            when 2 then N'اتمام'
	            when 3 then N'فسخ شده'
                when 4 then N'غبر فعال'
	            else '' end 'StatusName',
S.PriceMonth,
S.Sharj,
S.Price,
S.TotalPrice
from LegSubjectContract S inner join finasset F on S.FinanceCode=F.Code where S.code in (select A.ContractCode from (" + MainQuery + ") A )");
                 _dtReport1 = DB.Query_DataTable();
                string _Key = "";
                foreach (System.Data.DataColumn DC in _dtReport1.Columns)
                    _Key += DC.ColumnName;               
                jdgvReport1.DataSource = _dtReport1;
                //jdgvReport1.SaveComponentSettings();
                //jdgvReport1.RetrieveStructure();
                //jdgvReport1.SettingsKey = _Key;
                //jdgvReport1.LoadComponentSettings();
                //jdgvReport1.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                //jdgvReport1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                //SetColumnsHeaderCaption(jdgvReport1);
                //uC_GridLetter.Bind(_dtReport1, JJanusGrid.JSettingKeys.RelatedLetter);
                jdgvReport1.bind(_dtReport1, "Janus", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// ترجمه عنوان ستون ها
        /// </summary>
        private void SetColumnsHeaderCaption(Janus.Windows.GridEX.GridEX _JanusGrid)
        {
            if (_JanusGrid == null || _JanusGrid.CurrentTable == null) return;
            try
            {
                for (int j = 0; j < _JanusGrid.CurrentTable.Columns.Count; j++)
                {
                    _JanusGrid.CurrentTable.Columns[j].Caption = JLanguages._Text(_JanusGrid.CurrentTable.Columns[j].Key);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Report2()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = " 1=1 ";
                DB.setQuery(@"Select V.Code,
(Select Title From legContractDynamicTypes where Code = V.Type) 'TitleContractType',
V.Type,
V.Number,
F.Comment,
V.Date,
V.DateDeliver,
V.StartDate,
V.EndDate,
V.Description,
V.Guarantee,
V.Condition,
Case V.Status 
	            when 0 then N'هیچکدام'	
	            when 1 then N'جاری'
	            when 2 then N'اتمام'
	            when 3 then N'فسخ شده'
                when 4 then N'غبر فعال'
	            else '' end 'StatusName',
V.PriceMonth,
V.Sharj,
V.Price,
V.TotalPrice from vactivecontract V inner join finasset F on V.FinanceCode=F.Code 
where  V.code in (select A.ContractCode from (" + MainQuery + ") A )");
                _dtReport2 = DB.Query_DataTable();
                string _Key = "";
                foreach (System.Data.DataColumn DC in _dtReport2.Columns)                
                    _Key += DC.ColumnName;                
                //jdgvReport2.SaveComponentSettings();
                //jdgvReport2.DataSource = _dtReport2;
                //jdgvReport2.RetrieveStructure();
                //jdgvReport2.SettingsKey = _Key;
                //jdgvReport2.LoadComponentSettings();
                //jdgvReport2.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                //jdgvReport2.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                //SetColumnsHeaderCaption(jdgvReport2);
                jdgvReport2.bind(_dtReport2, "Janus2", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void Report3()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //DB.setQuery("Select * from LegSubjectContract where Status=1 and EndDate = ");
                //_dtReport3 = DB.Query_DataTable();
                int sellerType = ClassLibrary.Domains.Legal.JPersonPetitionType.Seller;
                int buyerType = ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer;
                int buyerAdType = ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate;
                int sellerAdType = ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate;
                int intuitionType = ClassLibrary.Domains.Legal.JPersonPetitionType.intuition;
                DB.setQuery(@"Select 
                (Select Name From clsAllPerson where Code=PC.PersonCode) 'PersonName',
UB.Plaque,
(Select Fa_date from StaticDates where En_Date = Cast(SC.startdate as date)) 'startdate',
(Select Fa_date from StaticDates where En_Date = Cast(SC.EndDate as date)) 'EndDate',
SC.TotalPrice, SC.Price, Sc.PriceMonth, 
PA.[Address] 'Address',PA.Tel,

                Case PC.Type 
	            when " + sellerType.ToString() + @" then 
	            (Select Top 1 SettingValue  from legContractTypeSettings where ContractTypeCode = CDT.Code  and SettingName = 'T1Lable')
	            when " + sellerAdType.ToString() + @" then N'وکیل طرف اول'	
	            when " + buyerType.ToString() + @" then 		
	            (Select Top 1 SettingValue  from legContractTypeSettings where ContractTypeCode = CDT.Code  and SettingName = 'T2Lable')
	            when " + buyerAdType.ToString() + @" then N'وکیل طرف دوم'
	            when " + intuitionType.ToString() + @" then N'شهود'
	            else '' end PersonParty,
                CDT.Title, (Select Fa_date from StaticDates where En_Date = Cast(SC.Date as date)) ContractDate,SC.Number ContractNo,
                PC.Share ,Case  SC.Status
	            when 0 then ''
	            when 1 then N'جاری'
	            when 2 then N'اتمام'
	            when 3 then N'فسخ شده'
	            when 4 then N'غیر فعال'
	            else '' end StatusTitle, SC.Status, FA.Comment	            
                from LegPersonContract  PC
	            inner join legSubjectContract SC on PC.ContractSubjectCode= SC.Code and PC.Type 
                IN(" + sellerType.ToString() + "," + buyerType.ToString() + "," + buyerAdType.ToString() + "," + sellerAdType.ToString() + "," + intuitionType.ToString() + @")

                inner join PersonAddressView PA on PA.Code = PC.PersonCode
	            inner join LegContractType CT on SC.Type = CT.Code 
	            inner join legContractDynamicTypes CDT on CDT.Code = CT.ContractType
	            inner join finAsset FA on SC.FinanceCode = FA.Code
inner join estUnitBuild UB ON UB.Code=FA.ObjectCode and FA.ClassName='RealEstate.JUnitBuild'

	            where SC.Confirmed = 1 And SC.code in (select A.ContractCode from (" + MainQuery +
                    ") A )Order By SC.Date");
                //JSubjectContracts.PersonContractHistory(VS1PersonCode.SelectedCode);                
                string _Key = "";
                _dtReport3 = DB.Query_DataTable();
                foreach (System.Data.DataColumn DC in _dtReport3.Columns)
                    _Key += DC.ColumnName;
                //jdgvReport3.SaveComponentSettings();
                //jdgvReport3.DataSource = _dtReport3;
                //jdgvReport3.RetrieveStructure();
                //jdgvReport3.SettingsKey = _Key;
                //jdgvReport3.LoadComponentSettings();
                //jdgvReport3.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                //jdgvReport3.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                //SetColumnsHeaderCaption(jdgvReport3);
                jdgvReport3.bind(_dtReport3, "Janus3", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
//(Select Name from subdefine where S.Job=Code) 'JobContractName', 
//UB.Code
        private void Report4()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"Select distinct 
UB.Plaque,
(select Number from estMarketFloors Where Code=UB.FloorCode) 'FloorCode' ,
UB.Number,
UB.Area,
UB.PlaqueRegistration,
(select Name from subdefine where code=UB.UnitJob) 'JobBuildName',
UB.InitialRental,
UB.InitialArea,
S.TotalPrice,
S.PriceMonth,
S.Price,
UB.UDesc,
UB.Balcon
from estUnitBuild UB inner join finasset F on UB.Code=F.ObjectCode 
and F.ClassName='RealEstate.JUnitBuild' inner join
LegSubjectContract S on S.FinanceCode=F.Code
Where UB.Code in (Select A.UnitBuildCode from (" + MainQuery + ") A )");
                _dtReport4 = DB.Query_DataTable();
                string _Key = "";
                foreach (System.Data.DataColumn DC in _dtReport4.Columns)                
                    _Key += DC.ColumnName;                
                //jdgvReport4.SaveComponentSettings();
                //jdgvReport4.DataSource = _dtReport4;
                //jdgvReport4.RetrieveStructure();
                //jdgvReport4.SettingsKey = _Key;
                //jdgvReport4.LoadComponentSettings();
                //jdgvReport4.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                //jdgvReport4.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                //SetColumnsHeaderCaption(jdgvReport4);
                jdgvReport4.bind(_dtReport4, "Janus4", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

//        private void Report5()
//        {
//            JDataBase DB = JGlobal.MainFrame.GetDBO();
//            try
//            {
//                DB.setQuery(@"Select * from vactivecontract V inner join LegPersonContract P on P.ContractSubjectCode=V.Code inner join PersonAddressView PA on PA.Code=P.PersonCode
//inner join finAsset FA On FA.Code=V.FinanceCode
//inner join estUnitBuild UB ON UB.Code=FA.ObjectCode and FA.ClassName='RealEstate.JUnitBuild'");
//                _dtReport5 = DB.Query_DataTable();
//                string _Key = "";
//                foreach (System.Data.DataColumn DC in _dtReport5.Columns)                
//                    _Key += DC.ColumnName;                
//                jdgvReport5.SaveComponentSettings();
//                jdgvReport5.DataSource = _dtReport5;
//                jdgvReport5.RetrieveStructure();
//                jdgvReport5.SettingsKey = _Key;
//                jdgvReport5.LoadComponentSettings();
//                jdgvReport5.FilterMode = Janus.Windows.GridEX.FilterMode.None;
//                jdgvReport5.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
//                SetColumnsHeaderCaption(jdgvReport5);
//            }
//            catch (Exception ex)
//            {
//                //Except.AddException(ex);
//            }
//            finally
//            {
//                DB.Dispose();
//            }
//        }

        public void ShowForm()
        {
            JReportContractFrom tmp = new JReportContractFrom();
            tmp.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {            
            jdgvReport1.DataSource = null;
            jdgvReport2.DataSource = null;
            jdgvReport3.DataSource = null;
            jdgvReport4.DataSource = null;

            _Where = "";
            string tmp = MainQuery;
            subWhere();
            MainQuery = MainQuery + _Where;
            Report1();
            Report2();
            Report3();
            Report4();
            MainQuery = tmp;
            //Report5();
        }

        private void B1MarketCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //نمایش طبقات مجتمع بر اساس مجتمع انتخاب شده
            int CodeMarket = Convert.ToInt32(B1MarketCode.SelectedValue);
            RealEstate.jMarketFloors Floor = new RealEstate.jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

            B1FloorCode.DataSource = TableFloor;
            B1FloorCode.DisplayMember = RealEstate.estMarketFloors.Name.ToString();
            B1FloorCode.ValueMember = RealEstate.estMarketFloors.Code.ToString();
            B1FloorCode.Text = "";
            B1FloorCode.SelectedItem = null;
        }

        /// <summary>
        /// خالی کردن کنترل ها
        /// </summary>
        /// <param name="sender"></param>
        public void ClearControl(object sender)
        {
            try
            {
                Type type = sender.GetType();
                FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
                for (int count = 0; count < Finfo.Length; count++)
                {
                    object Obj = Finfo[count].GetValue(sender);
                    if (Obj is DataGridView)
                    {
                    }
                    //--------------------------------------------
                    if (Obj is UserControl)
                    {
                        ClearControl(Obj);
                    }
                    if ((Obj is TextEdit) && (((TextEdit)Obj).Text != ""))
                    {
                        ((TextEdit)Obj).Text = "";
                    }
                    if (Obj is ComboBox)
                    {
                        if (((ComboBox)Obj).SelectedValue != null && Convert.ToInt32(((ComboBox)Obj).SelectedValue) != -1)
                            ((ComboBox)Obj).SelectedValue = -1;
                        else if (((ComboBox)Obj).SelectedValue == null && ((ComboBox)Obj).SelectedItem != null)
                        {
                            if ((Convert.ToInt32(((ComboBox)Obj).SelectedValue)) != -1)
                                (((ComboBox)Obj).SelectedValue) = -1;
                        }
                    }
                    if ((Obj is DateEdit) && (((DateEdit)Obj).Date != DateTime.MinValue))
                    {
                        ((DateEdit)Obj).Text = "";
                    }

                    if (Obj is CheckedListBox)
                    {
                        for (int i = 0; i < ((CheckedListBox)Obj).Items.Count; i++)
                            if (((CheckedListBox)Obj).GetItemChecked(i))
                                ((ClassLibrary.JKeyValue)((CheckedListBox)Obj).Items[i]).Value = false;
                    }

                    if ((Obj != null) && !(Obj is TextBox) && !(Obj is ComboBox) && !(Obj is MaskedTextBox))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl(this);//تمام کنترل ها را پاک کند            
        }
        GridEXPrintDocument printDoc = new GridEXPrintDocument();
 //           printDoc.DefaultPageSettings.Landscape = true;
 //           //printDoc.PageFooterLeft = printDoc.Page.ToString();
 //           printDoc.GridEX = jdgvReport1;
 //           printPreviewDialog1.Document = printDoc;
 //           printPreviewDialog1.ShowDialog();
    }
}
