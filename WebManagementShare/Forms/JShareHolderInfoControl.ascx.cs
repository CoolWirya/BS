using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Controls
{
    public partial class JShareHolderInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            // Archive
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl1).CanDeleteFile = false;
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl1).ClassName = (new ClassLibrary.JPerson()).GetType().FullName;
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl1).ObjectCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson.Code;
            ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl1).LoadArchive();
        }

        public void GetData()
        {
            // Get Current Person Information
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            lblName.Text = person.Name + " " + person.Fam;
            lblFatherName.Text = person.FatherName;
            lblMelliCode.Text = person.ShMeli;
            lblShsh.Text = person.ShSh;
            ClassLibrary.JPersonAddress jPersonAddress = person.HomeAddress;
            lblAddress.Text = jPersonAddress.Address;
            lblMobile.Text = jPersonAddress.Mobile;
            lblTel.Text = jPersonAddress.Tel;
            lblEmail.Text = jPersonAddress.Email;
            LbBrithday.Text = ClassLibrary.JDateTime.FarsiDate(person.BthDate);
            LbSodoor.Text = person.SaderText;
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            
            try
            {
                if (archive.Retrieve(person.PersonImageCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                        imgPerson.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                }
                else
                    imgPerson.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage);
            }
            catch { }

            Globals.Property.JProperties P = new Globals.Property.JProperties("ClassLibrary.JRealPerson", 1);
            DataTable DT = P.GetPropertyTableData(person.Code);
            if (DT != null && DT.Rows.Count == 1)
            {
                cbMosh.Checked = (bool)DT.Rows[0]["فرم__مشخصات"];
                cbImage.Checked = (bool)DT.Rows[0]["عکس"];
                cbShMeli.Checked = (bool)DT.Rows[0]["کپی__کارت__ملی"];
                cbShSh.Checked = (bool)DT.Rows[0]["کپی__شناسنامه"];
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            ClassLibrary.JPersonAddress jPersonAddress = person.HomeAddress;
            txtAddress.Text = jPersonAddress.Address;
            txtMobile.Text = jPersonAddress.Mobile;
            txtTel.Text = jPersonAddress.Tel;
            txtEmail.Text = jPersonAddress.Email;
            Panel_ViewInfo.Visible = false;
            Panel_EditInfo.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Panel_EditInfo.Visible = false;
            Panel_ViewInfo.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ClassLibrary.JPersonAddress jPersonAddress = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson.HomeAddress;
            jPersonAddress.Address = txtAddress.Text;
            jPersonAddress.Mobile = txtMobile.Text;
            jPersonAddress.Tel = txtTel.Text;
            jPersonAddress.Email = txtEmail.Text;
            jPersonAddress.Update();
            Panel_EditInfo.Visible = false;
            Panel_ViewInfo.Visible = true;
            GetData();
        }

        private void SaveImage(Telerik.Web.UI.RadBinaryImage imgPerson, int pCode, String pComment)
        {
            if (pCode == 0) return;
            if (imgPerson.DataValue == null) return;
            ClassLibrary.JPerson person = new ClassLibrary.JPerson(pCode);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = imgPerson.DataValue;
                jFile.FileName = imgPerson.ToolTip;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (person.PersonImageCode > 0 && archive.Retrieve(person.PersonImageCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, pComment);
                else
                    person.PersonImageCode = archive.ArchiveDocument(jFile, person.GetType().FullName, person.Code, ClassLibrary.JLanguages._Text("PersonPicture"), true);
                if (person.UpdateAvl())
                {

                }
            }
            catch { }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}