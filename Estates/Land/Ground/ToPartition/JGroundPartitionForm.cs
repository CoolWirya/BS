using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Finance;
using Legal;

namespace Estates
{
    public partial class JGroundPartitionForm : ClassLibrary.JBaseForm
    {
        JGroundPartition Partion;
        public JGroundPartitionForm()
        {
            InitializeComponent();
            Partion = new JGroundPartition();
            jArchiveListGroundPartition.ClassName="Estates.JGroundPartition";
        }
        public JGroundPartitionForm(int pCode)
        {
            InitializeComponent();
            Partion = new JGroundPartition(pCode);
            showdata();
            ReadOnly();
            jArchiveListGroundPartition.ClassName = "Estates.JGroundPartition";
            jArchiveListGroundPartition.ObjectCode = pCode;

            
        }

        public void showdata()
        {
            ShowGroundInfo();
            txtCourtCode.Text = Partion.CourtCode.ToString();

        }
        public void ReadOnly()
        {
            btnSearchCourt.Enabled = false;
            btnSearchGroundMain.Enabled = false;
            btnPartition.Enabled = false;

        }

        private void btnSearchGroundMain_Click(object sender, EventArgs e)
        {
            JSearchGroundForm JSGF = new JSearchGroundForm();
            JSGF.ShowDialog();
            if (CheckGround(JSGF.Code))
            {
                txtGroundCodeMain.Text = JSGF.Code.ToString();
                Partion.GroundMainCode= JSGF.Code;
                Partion.ComputeNewGround(JSGF.Code);
                ShowGroundInfo();
            }
        }
        private bool CheckGround(int Ground)
        {
            JAsset Asset = new JAsset("Estates.JGround", Ground);
            if (Asset.Code == 0)
            {
                JMessages.Error("مشخصات این دارایی در سیستم مو جود نیست", "خطا");
                return false;
            }
            DataTable Owners=JAssetShares.GetDataTableAssetShareOwner(Asset.Code, JOwnershipType.Definitive);
            if (Owners.Rows.Count <1)
            {
                JMessages.Error("این دارایی  یک مالک دارد و قابل افراز نیست", "خطا");
                return false;
            }

            return true;

        }

        public void ShowGroundInfo()
        {
            //نمایش اطلاعات زمین افراز شده
            JGround GroundMain = new JGround(Partion.GroundMainCode);
            labArea.Text = GroundMain.Area.ToString();
            labBlockNum.Text = GroundMain.BlockNum.ToString();
            labLand.Text = Convert.ToString(GroundMain.Land);
            labPartNum.Text = GroundMain.PartNum.ToString();
            labSection.Text = GroundMain.Section;
            labSubAve.Text = GroundMain.SubNo;
            labUsage.Text = Convert.ToString(GroundMain.Usage);
            labMainAve.Text = GroundMain.MainAve;
            labNorth.Text = GroundMain.About.North;
            labSouth.Text = GroundMain.About.South;
            labWest.Text = GroundMain.About.West;
            labEast.Text = GroundMain.About.East;
            labSection.Text = GroundMain.Section;
            
            //نمایش اطلاعات زمین های افراز شده
            foreach (JGround Ground in Partion.NewGrounds)
            {
                libGroundsPatition.Items.Add(Ground);
            }
        }

        private void btnUpdateNewGround_Click(object sender, EventArgs e)
        {
            if (libGroundsPatition.SelectedItem == null)
                return;
            JGroundForm JGF = new JGroundForm((JGround)libGroundsPatition.SelectedItem);
            JGF.State = JFormState.None;
            JGF.stateClass = StateClasses.BreakDown;
            JGF.ShowDialog();
            if (JGF.DialogResult == DialogResult.OK)
            {
                libGroundsPatition.Items.Remove(libGroundsPatition.SelectedItem);
                libGroundsPatition.Items.Add(JGF._newGround);
            }
        }

        private void btnPartition_Click(object sender, EventArgs e)
        {
            if (CheckItems())
            {
                //  Partion.NewGrounds = null;
                int i = 0;
                foreach (JGround Ground in libGroundsPatition.Items)
                {
                    Partion.NewGrounds[i] = Ground;
                    i++;
                }
                Partion.CourtCode = Convert.ToInt32(txtCourtCode.Text);
                Partion.DatePartition = ClassLibrary.JDateTime.Now();
                Partion.GroundMainCode = Convert.ToInt32(txtGroundCodeMain.Text);
                if (this.State == JFormState.Insert)
                {
                    int _Code= Partion.Insert();
                    jArchiveListGroundPartition.ObjectCode = _Code;
                    jArchiveListGroundPartition.ArchiveList();
                }
            }
            

        }

        private bool CheckItems()
        {
            if (txtCourtCode.Text =="")
            {
                JMessages.Error("کد حکم وارد نشده است", "خطا در ثبت اطلاعات");
                return false;
            }
            if (txtGroundCodeMain.Text == "")
            {
                JMessages.Error("زمین اصلی برای تفکیک راانتخاب کنید", "خطا در ثبت اطلاعات");
                return false;
            }
            return true;
        }

        private void btnSearchCourt_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm p = new JDecisionSearchForm();
            p.ShowDialog();
            if (p._Code != 0)
                LoadData(p._Code);
        }

        private void LoadData(int pCode)
        {
            try
            {
                Partion.CourtCode = pCode;
                JDecision tmp = new JDecision(pCode);
                txtCourtCode.Text = tmp.Code.ToString();
                labCourtDate.Text = tmp.Date.ToString();
                labCourtNumber.Text = tmp.number;
                JPetition petition = new JPetition(tmp.PetitionCode);
                JJudicialComplex JudicialComplex = new JJudicialComplex(petition.judicialCode);
                labjudicialCode.Text = JudicialComplex.Name;
                txtDecisionDesc.Text = tmp.DecisionDesc;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



       

      
       
        


            

        
    }
}
