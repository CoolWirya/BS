using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JAggregateForm : ClassLibrary.JBaseForm
    {
        private JAggregateGround JAG;
        /// <summary>
        /// تعداد زمین هایی که قرار است تجمیع شوند را مشخص می کند
        /// </summary>
        public int CountGrounds=0;
        public JAggregateForm()
        {
            InitializeComponent();
            JAG = new JAggregateGround();
            jArchiveListAggregate.ClassName = "Estates.JAggregateGround";

            
           
        }
        public JAggregateForm(int pCode)
        {
            InitializeComponent();
            JAG = new JAggregateGround(pCode);
            ShowData();
            jArchiveListAggregate.ClassName = "Estates.JAggregateGround";
            jArchiveListAggregate.ObjectCode = pCode;
            
        }
        //private void btnSaveClose_Click(object sender, EventArgs e)
        //{
           


        //}

        private void ShowData()
        {
            txtRegistrationOffice.Text = JAG.RegistrationOffice;
            txtTextReuest.Text = JAG.TextReuest;
            dgvGroundsAggregationby.DataSource = JAG.GroundsAggregationby;
            labArea.Text = JAG.GroundAggregationby.Area.ToString();
            labBlockNum.Text = JAG.GroundAggregationby.BlockNum;
            labLand.Text = Convert.ToString(JAG.GroundAggregationby.Land);
            labPartNum.Text = JAG.GroundAggregationby.PartNum;
            labSection.Text = JAG.GroundAggregationby.Section;
            labSubAve.Text = JAG.GroundAggregationby.SubNo;
            labUsage.Text = Convert.ToString(JAG.GroundAggregationby.Usage);
            labMainAve.Text = JAG.GroundAggregationby.MainAve;
            labNorth.Text = JAG.GroundAggregationby.About.North;
            labSouth.Text = JAG.GroundAggregationby.About.South;
            labWest.Text = JAG.GroundAggregationby.About.West;
            labEast.Text = JAG.GroundAggregationby.About.East;
            labSection.Text = JAG.GroundAggregationby.Section;
            dgvGroundsAggregationby.ReadOnly = Enabled;
            txtLetterDate.ReadOnly = Enabled;
            txtLetterNum.ReadOnly = Enabled;
            btnAddAgregatedGrands.Enabled = false;
            btnDelAgregatedGrands.Enabled = false;
            btnSaveClose.Enabled = false;
            btnAddGround.Enabled = false;

            


        }
       
        private void save()
        {
            
            //ورود اطلاعات تجمیع
            JAG.LetterDate = txtLetterDate.Date;
            JAG.LetterNum = txtLetterNum.Text;
            JAG.TextReuest = txtTextReuest.Text;
            JAG.RegistrationOffice = txtRegistrationOffice.Text;

            if (this.State == JFormState.Insert)
            {
                int _Code= JAG.Insert();
                if (_Code > 0)
                {
                    jArchiveListAggregate.ObjectCode = _Code;
                }

            }
            else if(this.State==JFormState.Update)
            {
            }
        }

        private void JAggregateForm_Load(object sender, EventArgs e)
        {
            dgvGroundsAggregationby.DataSource = JAG.GroundsAggregationby;
            dgvGroundsAggregationby.Columns[JAggregateGroundsTableEnum.Code.ToString()].Visible = false;
            dgvGroundsAggregationby.Columns[JAggregateGroundsTableEnum.GroundAggregationbyCode.ToString()].Visible = false;

        }

        private void btnAddAgregatedGrands_Click(object sender, EventArgs e)
        {
            JSearchGroundForm JSGF = new JSearchGroundForm();

            if (JSGF.ShowDialog() == DialogResult.OK)
            {
                if (JAG.FindGroundAggregate(JSGF.Code))
                {
                    JMessages.Error("این زمین قبلا انتخاب شده است", "error");
                    return;
                }

                //چک کردن برابر بودن مالکین اولیه و سهام آن ها برای تجمیع
                if (!JAG.CheckSharePrimaryOwner(JSGF.Code))
                    return;

                //
                JGround Newground = new JGround(JSGF.Code);
                DataRow Row = JAG.GroundsAggregationby.NewRow();
                Row[JAggregateGroundsTableEnum.GroundsAggregationbyCode.ToString()] = Newground.Code;
                Row[JGroundTableEnum.MainAve.ToString()] = Newground.MainAve;
                Row[JGroundTableEnum.SubNo.ToString()] = Newground.SubNo;
                Row[JGroundTableEnum.Area.ToString()] = Newground.Area;
                //محاسبه مساحت زمین جدید
                double Area = 0;
                Area = JAG.GroundAggregationby.Area;
                CountGrounds++;
                Area += Newground.Area;
                JAG.GroundAggregationby.Area = Area;
                JAG.GroundsAggregationby.Rows.Add(Row);


              


            }
        }
        private bool _CheckControl()
        {
            
            
            if (txtLetterDate.Text == "")
            {
                JMessages.Error("تاریخ نامه تجمیع را وارد کنید", "خطادر ورود اطلاعات");
                return false;
            }
            if (txtLetterNum.Text == "")
            {
                JMessages.Error("شماره نامه را واردکنید", "خطادر ورود اطلاعات");
                return false;
            }
            return true;

        }

        private void btnAddGround_Click(object sender, EventArgs e)
        {
            if (JAG.GroundsAggregationby.Rows.Count < 2)
            {
                JMessages.Error("حداقل 2زمین برای تجمیع انتخاب کنید", "خطادر ورود اطلاعات");
                return;
            }
            //JAG.GroundAggregationby.PrimeryOwners.Rows.Clear();
            JAG.SumPrimeryOwnerNewGround();
            JGroundForm JGF = new JGroundForm(JAG.GroundAggregationby);
            JGF.State = JFormState.None;
            JGF.stateClass = StateClasses.Aggregate;
            JGF.ShowDialog();
            JAG.GroundAggregationby = JGF._newGround;
            ShowNewground();

        }
        private void ShowNewground()
        {
            labArea.Text = JAG.GroundAggregationby.Area.ToString();
            labBlockNum.Text = JAG.GroundAggregationby.BlockNum;
            labLand.Text =Convert.ToString(JAG.GroundAggregationby.Land);
            labPartNum.Text = JAG.GroundAggregationby.PartNum;
            labSection.Text = JAG.GroundAggregationby.Section;
            labSubAve.Text = JAG.GroundAggregationby.SubNo;
            labUsage.Text =Convert.ToString(JAG.GroundAggregationby.Usage);
            labMainAve.Text = JAG.GroundAggregationby.MainAve;
            labNorth.Text = JAG.GroundAggregationby.About.North;
            labSouth.Text = JAG.GroundAggregationby.About.South;
            labWest.Text = JAG.GroundAggregationby.About.West;
            labEast.Text = JAG.GroundAggregationby.About.East;
            labSection.Text = JAG.GroundAggregationby.Section;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_CheckControl())
            {
                save();
              
            }

        }

        private void btnSaveClose_Click_1(object sender, EventArgs e)
        {
            if (_CheckControl())
            {
                save();
                Close();
            }

        }

        private void btnDelAgregatedGrands_Click(object sender, EventArgs e)
        {
            if (dgvGroundsAggregationby.Rows.Count == 0)
                return;
            if (dgvGroundsAggregationby.SelectedRows.Count == 0)
            {
                JMessages.Error("یک زمین برای حذف انتخاب کنید", "خطا");
                return;
            }
            dgvGroundsAggregationby.Rows.RemoveAt(dgvGroundsAggregationby.SelectedRows[0].Index);


        }

        
       
    }
}
