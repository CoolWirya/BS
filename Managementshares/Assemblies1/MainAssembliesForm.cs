using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using ArchivedDocuments;

namespace ManagementShares
{
    public partial class JMainAssembliesForm : JBaseForm
    {
        private int _AssembliesCode;
        private DataTable _List;
        private int _Counter = -1;

        public JMainAssembliesForm(int pAssembliesCode)
        {
            _AssembliesCode = pAssembliesCode;
            InitializeComponent();
        }

        public void Refresh()
        {
            JDataBase DB= new JDataBase();
            try
            {
                DB.setQuery(@"
            select 
(
select Title+' '+
	(select Fa_Date from StaticDates where En_Date = DATE)
from ShareAssemblies where Code = " + _AssembliesCode.ToString() + @") Name,
isnull(SUM(Share) ,0) share,
isnull((select count(DISTINCT PCode) as a from dbo.ShareholdersAssembly where present = 1 AND CCode=1),0) count,
(select SUM(ShareCount) from ShareSheet where Status=1) AllShare,
round(isnull(SUM(Share) ,0) * 100.0 /(select SUM(ShareCount) from ShareSheet where Status=1),2,0) PersentPresent,
cast(MIN(presentDate) as time(0)) MinDate,
cast(MAX(presentDate) as time(0)) MaxDate
 from dbo.ShareholdersAssembly
where present = 1 AND CCode=" + _AssembliesCode.ToString());
                DataTable _DT = DB.Query_DataTable();
                lbName.Text = _DT.Rows[0]["Name"].ToString();
                lbCol.Text = _DT.Rows[0]["AllShare"].ToString()+" سهم";
                lbMaxTime.Text = _DT.Rows[0]["MaxDate"].ToString();
                lbMinTime.Text = _DT.Rows[0]["MinDate"].ToString();
                lbPresentCount.Text = _DT.Rows[0]["count"].ToString()+" نفر";
                lbPresentShare.Text = _DT.Rows[0]["share"].ToString() + " سهم " +
                    " معادل " + 
                    Math.Round(decimal.Parse( _DT.Rows[0]["PersentPresent"].ToString()),0).ToString() + "% از کل سهام";
                _DT.Clear();
                _DT.Dispose();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }


        }
        private void GetList()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"
    SELECT CP.Code,CP.Fam +' '+CP.Name Fam,SUM(SHA.Share) share,SDF.name CityName FROM ShareholdersAssembly SHA
    inner join clsPerson CP on CP.Code = SHA.PCode
    inner join clsPersonAddress CPA on CPA.PCode= CP.Code and CPA.AddressType=1
    inner join subdefine SDF on SDF.Code = CPA.City
    where SHA.present=1  and SHA.CCode=" +_AssembliesCode.ToString()+
    @" group by CP.Code,CP.Fam,CP.Name,SDF.name
    order by Fam ");
                DataTable _DT = DB.Query_DataTable();
                if (_List == null || _DT.Rows.Count != _List.Rows.Count)
                {
                    if (_List != null)
                        _List.Clear();
                    _List = _DT;
                    cmbShareHolderSelect.DataSource = _List;
                    cmbShareHolderSelect.DisplayMember = "Fam";
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }

        }

        private void SetImage(PictureBox pImgPicture, int pPCode)
        {
            pImgPicture.Image = null;
            JPerson _Person = new JPerson(pPCode);
            JFile _PersonImage;
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(_Person.PersonImageCode))
                {
                    _PersonImage = archive.Content;
                    if (_PersonImage != null)
                    {
                        pImgPicture.Image = System.Drawing.Image.FromStream(_PersonImage.Stream);
                        _PersonImage.Stream.Close();
                        _PersonImage.Stream.Dispose();
                        _PersonImage.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                archive.Dispose();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            GetList();

            if (tabControl1.SelectedIndex == 0)
            {
                try
                {
                    if (_List != null && _List.Rows.Count > 0)
                    {
                        _Counter++;
                        if (_Counter >= _List.Rows.Count)
                        {
                            _Counter = 0;
                        }
                        SetImage(imgPicture, (int)_List.Rows[_Counter][0]);
                    }
                }
                catch
                {
                }
            }
        }

        private void cmbShareHolderSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbLName.Text = "";
            lbCity.Text = "";
            lbShare.Text = "";
            pictureBox1.Image = null;
            try
            {
                DataRowView _DR = (DataRowView)cmbShareHolderSelect.SelectedItem;
                lbLName.Text = _DR["Fam"].ToString();
                lbShare.Text = _DR["Share"].ToString();
                lbCity.Text = _DR["CityName"].ToString();
                SetImage(pictureBox1, (int)_DR["Code"]);
            }
            catch
            {
            }
        }
    }
}
