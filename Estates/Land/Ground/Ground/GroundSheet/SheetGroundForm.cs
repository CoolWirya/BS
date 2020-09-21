using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;


namespace Estates
{
    public partial class JSheetGroundForm : ClassLibrary.JBaseForm
    {
        int _Code;
        int _PCode;
        int _GCode;

        public JSheetGroundForm()
        {
            InitializeComponent();
            jPropertyValueUserControl1.ClassName = "Estates.JSheetGroundForm";
            jPropertyValueUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode(); ;
            ArchiveListSheet.ClassName = "Estates.JSheetGroundForm";
            ArchiveListSheet.PlaceCode = 0;
            ArchiveListSheet.SubjectCode = 0;
        }

        public JSheetGroundForm(int pCode)
        {
            InitializeComponent();
            jPropertyValueUserControl1.ClassName = "Estates.JSheetGroundForm";
            jPropertyValueUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode(); ;
            _Code = pCode;
            ArchiveListSheet.ClassName = "Estates.JSheetGroundForm";
            ArchiveListSheet.ObjectCode = _Code;
            ArchiveListSheet.PlaceCode = 0;
            ArchiveListSheet.SubjectCode = 0;
        }

        private void JSheetGroundForm_Load(object sender, EventArgs e)
        {
            if (_Code != 0)
                Set_Form();

            GetHistory();
            //Finance.JAsset Asset = new Finance.JAsset("Estates.JGround", _GCode);
            //SetDefinitContractGrid(Asset.Code);
        }

        private void GetHistory()
        {
            string StrCode = "";
            JGroundSheet tmpSheet = new JGroundSheet(_Code);
            StrCode = _Code.ToString();
            while (tmpSheet.Parent != 0)
            {
                tmpSheet.GetData(tmpSheet.Parent);
                StrCode = StrCode + "," + tmpSheet.Code.ToString();
            }
            StrCode = "(" + StrCode + ")";
            jdgHistory.DataSource = JGroundSheet.HistorySheet(StrCode);
        }

        private void Set_Form()
        {
            Estates.JGroundSheet tmpJGroundSheet = new JGroundSheet(_Code);            
            txtTarefeCode.Text = _Code.ToString();
            if (tmpJGroundSheet.PCode == 0)
                jucPerson1.ReadOnly = false;
            else
                jucPerson1.SelectedCode = tmpJGroundSheet.PCode;
            lblNumPrint.Text = tmpJGroundSheet.NumPrint.ToString();
            if(tmpJGroundSheet.DeActive == 1)
                lblActive.Text = " غیر فعال ";
            else
                lblActive.Text = "فعال";
            lblShare.Text = Math.Round(tmpJGroundSheet.Area,4).ToString();
            txtDate.Date = DateTime.Now;
            if (tmpJGroundSheet.DeliveryDate == DateTime.MinValue)
                txtDateDelivery.Date = DateTime.Now;
            else
            {
                txtDateDelivery.Date = tmpJGroundSheet.DeliveryDate;
                //btnConfirmDateD.Enabled = false;
            }
            _PCode = tmpJGroundSheet.PCode;
            _GCode = tmpJGroundSheet.GCode;
            btnInfoGround.Enabled = true;

            _newGround = new JGround(tmpJGroundSheet.GCode);
            _ShowData();
            if (tmpJGroundSheet.DeliveryDate != DateTime.MinValue)
            {
                btnSheetPrint.Enabled = true;
                btnKoroki.Enabled = true;
            }
            else
            {
                btnSheetPrint.Enabled = false;
                btnKoroki.Enabled = false;
            }

            jPropertyValueUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode(); ;
            jPropertyValueUserControl1.ValueObjectCode = _Code;
        }

        #region Ground

        public JGround _newGround = new JGround();

        private void _ShowData()
        {
            txtMainAve.Text = _newGround.MainAve;
            txtSubAve.Text = _newGround.SubNo;
            txtBlockNum.Text = _newGround.BlockNum;
            txtPartNum.Text = _newGround.PartNum;
            txtArea.Text = _newGround.Area.ToString();
            JUsageGround tmpUsage = new JUsageGround(_newGround.Usage);
            txtUsage.Text = tmpUsage.Name.ToString();
            lblTotalShare.Text = _newGround.TotalShare.ToString();
        }
        #endregion

        System.Data.DataTable[] _DataTables = new System.Data.DataTable[4];
        private void FillReportDt()
        {
            Estates.JGroundSheet tmpJGroundSheet = new JGroundSheet(_Code);
            tmpJGroundSheet.NumPrint = tmpJGroundSheet.NumPrint + 1;
            tmpJGroundSheet.Update();

            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("PersonCode");
            dtInfo.Columns.Add("Name");
            dtInfo.Columns.Add("Fam");
            dtInfo.Columns.Add("Meli");
            dtInfo.Columns.Add("No");
            dtInfo.Columns.Add("FatherName");
            dtInfo.Columns.Add("Address");
            DataRow dr = dtInfo.NewRow();
            JAllPerson tmpallperson = new JAllPerson(tmpJGroundSheet.PCode);
            if (tmpallperson.PersonType == JPersonTypes.LegalPerson)
            {
                dr["PersonCode"] = _PCode;
                JOrganization tmpOrg = new JOrganization();
                dr["Name"] = tmpOrg.Name;
                dr["No"] = tmpOrg.RegisterNo;
                dr["Address"] = tmpOrg.Address.FullAddress;
            }
            else
            {
                JPerson tmpPerson = new JPerson(tmpJGroundSheet.PCode);
                dr["PersonCode"] = _PCode;
                dr["Name"] = tmpPerson.Name;
                dr["Fam"] = tmpPerson.Fam;
                dr["No"] = tmpPerson.ShSh;
                dr["Meli"] = tmpPerson.ShMeli;
                dr["FatherName"] = tmpPerson.FatherName;
                dr["Address"] = tmpPerson.HomeAddress.FullAddress;
            }
            dtInfo.Rows.Add(dr);
            dtInfo.TableName = "اطلاعات شخص";
            _DataTables[0] = dtInfo;

            _DataTables[1] = JGroundSheets.GetDataTable(_Code);
            _DataTables[1].TableName = "اطلاعات زمین و تعرفه";

            ArchivedDocuments.JArchiveDocument tmpArchive = new ArchivedDocuments.JArchiveDocument();
            DataTable dtArchive = tmpArchive.Retrieve("JGroundForm.Koroki", _newGround.Code);
            if (dtArchive.Rows.Count > 0)
                _DataTables[2] = JGrounds.FindKoroki(Convert.ToInt32(dtArchive.Rows[0]["ArchiveCode"]));
            else
                _DataTables[2] = JGrounds.FindKoroki(0);
            _DataTables[0].TableName = "کروکی ";

            _DataTables[3] =JGroundSheet.ListShoraka(_GCode);
            _DataTables[3].TableName = "اطلاعات شرکا";
        }


        private void btnSheetPrint_Click(object sender, EventArgs e)
        {
            Estates.JGroundSheet tmpJGroundSheet = new JGroundSheet(_Code);
            tmpJGroundSheet.PrintSheet();
        }

        private void txtTarefeCode_Leave(object sender, EventArgs e)
        {
            if (txtTarefeCode.Text != "")
            {
                _Code = Convert.ToInt32(txtTarefeCode.Text); ;
                Set_Form();
            }
        }

        private void btnInfoGround_Click(object sender, EventArgs e)
        {
            JGroundForm tmp = new JGroundForm(_GCode);
            tmp.State = JFormState.Update;
            tmp.ShowDialog();
        }

        private void btnConfirmDateD_Click(object sender, EventArgs e)
        {
            Estates.JGroundSheet tmpJGroundSheet = new JGroundSheet(_Code);
            tmpJGroundSheet.DeliveryDate = txtDateDelivery.Date;
            tmpJGroundSheet.State = 2;
            tmpJGroundSheet.Update();
            btnSheetPrint.Enabled = true;
            btnKoroki.Enabled = true;

            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                jPropertyValueUserControl1.ValueObjectCode = _Code;
                jPropertyValueUserControl1.Save(db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }

            ArchiveListSheet.ObjectCode = _Code;
            ArchiveListSheet.ArchiveList();
        }

        private DataTable GetPropertySheet()
        {
            try
            {
                DataTable Dt = new DataTable(); ;
                if (jPropertyValueUserControl1.GetDataRowValue() != null)
                {
                    DataRow DR = jPropertyValueUserControl1.GetDataRowValue();
                    foreach (DataColumn DC in DR.Table.Columns)
                    {
                        Dt.Columns.Add(DC.Caption);
                        if (Dt.Rows.Count == 0)
                            Dt.Rows.Add(0);
                        Dt.Rows[0][DC.Caption] = DR[DC.Caption];
                    }
                }
                return Dt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DataTable _DT = JGroundSheets.GetWordPrintData(_Code);

            JGroundSheet GS = new JGroundSheet(_Code);
            DataTable _Korooki = JGroundSheets.Korooki(GS.GCode);

            DataTable _SharePerson = JGroundSheets.GetSharePersonGroundData(GS.GCode);
            _SharePerson.TableName = "SharePerson";

            Globals.Property.JPropertyTables tmpProperty = new Globals.Property.JPropertyTables("Estates.JSheetGroundForm", ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode());
            DataTable DtProperty = new DataTable();
            DtProperty = tmpProperty.GetData(_Code);
            DtProperty.TableName = "ویژگی تعرفه";

            JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.SheetGround.GetHashCode());
            DRF.Add(_DT);
            DRF.Add(DtProperty);
            if (_Korooki != null)
                DRF.Add(_Korooki);
            DRF.Add(_SharePerson);
            DRF.ShowDialog();
        }

        private void btnInfoPerson_Click(object sender, EventArgs e)
        {
            JAllPerson tmp = new JAllPerson(jucPerson1.SelectedCode);
            if (tmp.PersonType == JPersonTypes.RealPerson)
            {
                JPerson _Person = new JPerson(jucPerson1.SelectedCode);
                JPersonIn p = new JPersonIn(_Person);
                p.State = JFormState.Update;
                p.ShowDialog();
            }
            else
            {
                JOrganization pOrgan = new JOrganization(jucPerson1.SelectedCode);
                JLegalPerson p = new JLegalPerson(pOrgan);
                p.State = JFormState.Update;
                p.ShowDialog();
            }
        }

        private void btnContractPrint_Click(object sender, EventArgs e)
        {
            JGroundSheet tmp=new JGroundSheet();
            tmp.CreateContractPrint(JSystem.Nodes.CurrentNode.Row);
            //tmp.CreateContractPrint(JSystem.Nodes.Selected.Rows[0]);
        }

        private void btnKoroki_Click(object sender, EventArgs e)
        {
            JGroundSheet GS = new JGroundSheet(_Code);
            GS.PrintKorooki();
            GS.PrintKorooki();
        }

        private void jucPerson1_Leave(object sender, EventArgs e)
        {
            if (jucPerson1.Enabled == true)
            {
                JGroundSheet tmp = new JGroundSheet(_Code);
                tmp.PCode = jucPerson1.SelectedCode;
                if (!(tmp.Update()))
                    JMessages.Error(" اطلاعات مالک ثبت نشد ","");
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            JChangeSahmForm p = new JChangeSahmForm(_Code, _GCode, _PCode);
            p.ShowDialog();
            //if (p.ShowDialog() == DialogResult.OK)
            //    Close();
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            JPropertySheetForm p = new JPropertySheetForm(_Code);
            p.ShowDialog();
        }

        private void btnAggregate_Click(object sender, EventArgs e)
        {
            JAggregateSheetForm p = new JAggregateSheetForm(_GCode, _PCode);
            p.ShowDialog();
        }

        //private void SetDefinitContractGrid(int pAssetCode)
        //{
        //    jdgHistory.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Definitive);
        //    (jdgHistory.DataSource as DataTable).Select("Share <> 0");
        //    jdgHistory.Columns["StartDate"].Visible = false;
        //    jdgHistory.Columns["EndDate"].Visible = false;
        //    jdgHistory.Columns["GoodwillPrice"].Visible = false;
        //    jdgHistory.Columns["Price"].Visible = false;
        //    jdgHistory.Columns["PriceMonth"].Visible = false;
        //}
    }
}
