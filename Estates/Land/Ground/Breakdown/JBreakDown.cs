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

namespace Estates
{
    public partial class JGroundBreakDownForm : ClassLibrary.JBaseForm
    {
        JGround GroundMain;
        JGroundBreakDown BreakDown;
        int CountGrounds;
        double SumAreaGrounds = 0;
        public JGroundBreakDownForm()
        {
            InitializeComponent();
            BreakDown = new JGroundBreakDown();
            jArchiveList.ClassName = "Estates.JGroundBreakDown";
            jArchiveList.SubjectCode = 0;
            jArchiveList.PlaceCode = 0;
       
        }

        public JGroundBreakDownForm(int pCode)
        {
            InitializeComponent();
            BreakDown = new JGroundBreakDown(pCode);
            ShowData();
            jArchiveList.ClassName = "Estates.JGroundBreakDown";
            jArchiveList.SubjectCode = 0;
            jArchiveList.PlaceCode = 0;
            jArchiveList.ObjectCode = pCode;
        }

        public void ShowData()
        {
            foreach (JGround Ground in BreakDown.GroundsBreakdown)
            {
                libGroundsBreakdown.Items.Add(Ground);
            }
            JGround JAG = new JGround(BreakDown.GroundBreakDown);
            labArea.Text = JAG.Area.ToString();
            labBlockNum.Text = JAG.BlockNum;
            labLand.Text = new JLand( JAG.Land).Name;
            labPartNum.Text = JAG.PartNum;
            labSection.Text = JAG.Section;
            labSubAve.Text = JAG.SubNo;
            labUsage.Text =(new JUsageGround (JAG.Usage).Name);
            labMainAve.Text = JAG.MainAve;
            labNorth.Text = JAG.About.North;
            labSouth.Text = JAG.About.South;
            labWest.Text = JAG.About.West;
            labEast.Text = JAG.About.East;
            labSection.Text = JAG.Section;
            txtGroundCodeMain.Text = BreakDown.GroundBreakDown.ToString();
            txtLetterDate.Text = BreakDown.LetterDate.ToString();
            txtLetterNum.Text = BreakDown.LetterNum;
            txtRegistrationOffice.Text = BreakDown.RegistrationOffice;
            txtTextReuest.Text = BreakDown.TextReuest;
            //غیر فعال کردن آیتمهای فرم
            txtTextReuest.ReadOnly = true;
            txtRegistrationOffice.ReadOnly = true;
            txtLetterDate.ReadOnly = true;
            txtGroundCodeMain.ReadOnly = true;
            txtLetterNum.ReadOnly = true;
            btnGroundBreakDown.Enabled = false;
            btnGroundMainSearch.Enabled = false;
            btnNewGrounds.Enabled = false;
            btnUpadateNewGrounds.Enabled = false;
        }

        private void btnNewGrounds_Click(object sender, EventArgs e)
        {
            if (txtGroundCodeMain.Text == "")
            {
                JMessages.Error("زمین اصلی را که باید تفکیک شود انتخاب کنید", "خطا در ثبت اطلاعات");
                return;
            }
            JGround newGround = new JGround();
            JGroundBreakDown.ComputePrimaryOwner(newGround, Convert.ToInt32(txtGroundCodeMain.Text));
            JGroundForm JGF = new JGroundForm(newGround);
            JGF._newGround.Land = GroundMain.Land;
            JGF.cmbLand.Text = labLand.Text;
            JGF.txtMainAve.Text = labMainAve.Text;
            JGF.stateClass = StateClasses.BreakDown;
            JGF.State = JFormState.None;
            SumAreaGrounds -= JGF._newGround.Area;
            JGF.ShowDialog();
            if (JGF.DialogResult==DialogResult.OK)
            {
                libGroundsBreakdown.Items.Add(JGF._newGround);
                CountGrounds++;
                SumAreaGrounds += JGF._newGround.Area;
                labSumArea.Text = SumAreaGrounds.ToString();
            }
            

        }

        private void btnGroundMainSearch_Click(object sender, EventArgs e)
        {
            JSearchGroundForm JSGF = new JSearchGroundForm();
            JSGF.ShowDialog();
            if (CheckGround(JSGF.Code))
            {
                txtGroundCodeMain.Text = JSGF.Code.ToString();
                BreakDown.GroundBreakDown = JSGF.Code;
                //نمایش اطلاعات زمین تفکیکی
                GroundMain = new JGround(JSGF.Code);
                labArea.Text = GroundMain.Area.ToString();
                labBlockNum.Text = GroundMain.BlockNum.ToString();
                labLand.Text = (new JLand(GroundMain.Land)).Name;
                labPartNum.Text = GroundMain.PartNum.ToString();
                labSection.Text = GroundMain.Section;
                labSubAve.Text = GroundMain.SubNo;
                labUsage.Text = (new JUsageGround(GroundMain.Usage)).Name;
                labMainAve.Text = GroundMain.MainAve;
                labNorth.Text = GroundMain.About.North;
                labSouth.Text = GroundMain.About.South;
                labWest.Text = GroundMain.About.West;
                labEast.Text = GroundMain.About.East;
                labSection.Text = GroundMain.Section;
            }


        }

        private void btnGroundBreakDown_Click(object sender, EventArgs e)
        {
            if (CheckItems())
            {
                if (Save())
                {
                    Close();
                }
            }
        }
        private bool Save()
        {
            //مجموع مساحت زمین های انتخاب شده برای تفکیک
            //double GroundsArea=0;
            BreakDown.GroundsBreakdown = new JGround[libGroundsBreakdown.Items.Count];
            int i = 0;
            foreach (JGround Ground in libGroundsBreakdown.Items)
            {
                BreakDown.GroundsBreakdown[i] = Ground;
                i++;
                //GroundsArea += Ground.Area;
            }
            //if(GroundsArea>Convert.ToInt32(labArea.Text))
            //{
            //    JMessages.Error("مجموع مساحت های زمین های تفکیک شده از زمین اصلی بیشتر است", "خطا در ثبت اطلاعات");
            //    return false;
            //}

            BreakDown.GroundBreakDown = Convert.ToInt32(txtGroundCodeMain.Text);
            BreakDown.LetterNum = txtLetterNum.Text;
            BreakDown.LetterDate = txtLetterDate.Date;
            BreakDown.RegistrationOffice = txtRegistrationOffice.Text;
            BreakDown.TextReuest = txtTextReuest.Text;
            if (this.State == JFormState.Insert)
            {
                int _Code=BreakDown.Insert();
                if (_Code > 0)
                {
                    return true;
                    jArchiveList.ObjectCode = _Code;
                    jArchiveList.ArchiveList();
                }
            }
            return false;
        }

        private void btnUpadateNewGrounds_Click(object sender, EventArgs e)
        {
            try
            {
                if (libGroundsBreakdown.SelectedItem == null)
                    return;
                JGroundForm GroundForm = new JGroundForm((JGround)libGroundsBreakdown.SelectedItem);
                SumAreaGrounds -= ((JGround)libGroundsBreakdown.SelectedItem).Area;
                GroundForm.State = JFormState.None;
                GroundForm.ShowDialog();
                if (GroundForm.DialogResult == DialogResult.OK)
                {
                    
                    libGroundsBreakdown.Items.Remove(libGroundsBreakdown.SelectedItem);
                    libGroundsBreakdown.Items.Add(GroundForm._newGround);
                    SumAreaGrounds += GroundForm._newGround.Area;
                    labSumArea.Text = SumAreaGrounds.ToString();
                }
                else
                    SumAreaGrounds += ((JGround)libGroundsBreakdown.SelectedItem).Area;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckItems()
        {
            if (txtGroundCodeMain .Text== "")
            {
                JMessages.Error(" زمینی که تفکیک خواهد شد را انتخاب کنید", "خطا در ثبت اطلاعات");
                return false;
            }
            if (txtLetterNum.Text == "")
            {
                JMessages.Error("شماره نامه تفکیک را وارد کنید", "خطا در ثبت اطلاعات");
                return false;
            }
            if (txtRegistrationOffice.Text =="")
            {
                JMessages.Error(" فیلد اداره مخاطب را پرکنید", "خطا در ثبت اطلاعات");
                return false;
            }
            if (CountGrounds < 2)
            {
                JMessages.Error(" حداقل دو زمین جدید ایجاد کنید", "خطا در ثبت اطلاعات");
                return false;
            }

            if (SumAreaGrounds != GroundMain.Area)
            {
                JMessages.Error("مجموع مساحت زمینهای تفکیک شده باید با زمین اصلی برابر باشد.", "خطا در ثبت اطلاعات");
                return false;
            }
            return true;

        }

        private void JGroundBreakDownForm_Load(object sender, EventArgs e)
        {
            labSumArea.Text = "0";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckGround(int Ground)
        {
            JAsset Asset = new JAsset("Estates.JGround", Ground);
            if (Asset.Code == 0)
            {
                JMessages.Error("مشخصات این دارایی در سیستم مو جود نیست", "خطا");
                return false;
            }
            JGround MainGround = new JGround(Ground);
            if (MainGround.PrimeryOwners.Rows.Count > 1)
            {
                JMessages.Error("این دارایی بیش از یک مالک دارد و قابل تفکیک نیست", "خطا");
                return false;
            }
            
            return true;

        }
            

    }
}
