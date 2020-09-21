using System;
using ProjectManagement;
using System.Data;

namespace WebProjectManagement.Forms
{
    public partial class EnterDataTreeview : System.Web.UI.UserControl
    {
        int projectCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["projectCode"], out projectCode);

            LoadRootNodes();
            pnlEnterData.Visible = false;

            //   if (Request.QueryString["id"] != null)
            //   {
            //       string id = Request.QueryString["id"];
            //       foreach (Telerik.Web.UI.RadTreeNode node in trvOrg.GetAllNodes())
            //       {
            //           if (node.Value.EndsWith("," + id))
            //           {
            //               node.ExpandParentNodes();
            //               node.Selected = true;
            //               break;
            //           }
            //           else if (node.Value.EndsWith(",-1")) node.ExpandChildNodes();
            //       }
            //   }
            //WebClassLibrary.JWebManager.RunClientScript("console.log(window.location.href);", "ConfirmDialog1");
        }
        private void LoadRootNodes()
        {
            if (IsPostBack) return;
            trvOrg.Nodes.Clear();
            ProjectManagement.MixedObjects.ItemAndProjectDetails mixedItem = new ProjectManagement.MixedObjects.ItemAndProjectDetails(-1, projectCode);

            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = mixedItem.Project.Name + "(وزن پروژه: " + mixedItem.Project.TotalWeight.ToString("000.00").ToDecimal() +
                " - وزن آیتم های اصلی: " + mixedItem.TotalSubItemPercentage.ToString("000.00").ToDecimal() +
                   " - وزن کل وارد شده: " + mixedItem.Project.GetTotalReportedWeight().ToString("000.00").ToDecimal() + ")";
            node.Value = mixedItem.Project.Code.ToString() + ",-1";
            node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.WebService;

            if (mixedItem.Item != null && mixedItem.Item.Code > 0 && mixedItem.TotalSubItemPercentage == mixedItem.Project.TotalWeight)
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_green.png";
            else
                node.ImageUrl = "~/WebProjectManagement/Images/double-left-arrow_red.png";


            //  node.ExpandChildNodes();
            trvOrg.Nodes.Add(node);
            //TrvOrg_NodeExpand(trvOrg, new Telerik.Web.UI.RadTreeNodeEventArgs(node));

        }

        //protected void trvOrg_NodeExpand1(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        //{
        //    TrvOrg_NodeExpand(sender, e);
        //}
        //protected void TrvOrg_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        //{
        //    e.Node.Nodes.Clear();
        //    System.Collections.Generic.List<Telerik.Web.UI.RadTreeNodeData> result = new System.Collections.Generic.List<Telerik.Web.UI.RadTreeNodeData>();

        //    int projectCode = 0, parentCode = 0;
        //    int.TryParse(e.Node.Value.ToString().Split(',')[0], out projectCode);
        //    int.TryParse(e.Node.Value.ToString().Split(',')[1], out parentCode);
        //    if (projectCode == 0 || parentCode == 0) return;
        //    System.Data.DataTable dt = ProjectManagement.Item.JItems.GetDataTable(projectCode, parentCode, false);
        //    if (dt == null) return;
        //    Telerik.Web.UI.RadTreeNode _node;
        //    foreach (System.Data.DataRow row in dt.Rows)
        //    {
        //        _node = new Telerik.Web.UI.RadTreeNode();
        //        ProjectManagement.MixedObjects.ItemAndProjectDetails i = new ProjectManagement.MixedObjects.ItemAndProjectDetails();
        //        i.GetData(row["Code"].ToString().ToInt32(), row["ProjectCode"].ToString().ToInt32(), false);
        //        //  if(i.TotalSubItemPercentage==0)
        //        _node.Text = row[1].ToString() + "(<span class='treeviewPart1'>وزن آیتم: " + i.Item.WeightPercentage.ToString("000.00").ToDecimal() +
        //        "</span> - <span class='treeviewPart2'> وزن زیرمجموعه: " + i.TotalSubItemPercentage.ToString("000.00").ToDecimal() +
        //        "</span> - <span class='treeviewPart3'> وزن پیشرفت آیتم: " + i.Item.ReportedPercentage().ToString("000.00").ToDecimal() + "%</span>)";
        //        //      else
        //        //    _node.Text = row[1].ToString() + "(" + i.Item.WeightPercentage + "/" + i.TotalSubItemPercentage + ")";
        //        _node.Value = row["ProjectCode"].ToString() + "," + row["Code"].ToString();
        //        _node.ExpandMode = Telerik.Web.UI.TreeNodeExpandMode.ServerSide;
        //        if (i.Item != null && i.Item.Code > 0 && i.TotalSubItemPercentage == i.Item.WeightPercentage)
        //            _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_green.png";
        //        else if (i.Item != null && i.Item.Code > 0 && i.TotalSubItemPercentage > 0)
        //            _node.ImageUrl = "/WebProjectManagement/Images/double-left-arrow_red.png";
        //        else if (i.TotalReportedPercentage >= 100)//==i.Item.WeightPercentage)
        //            _node.ImageUrl = "/WebProjectManagement/Images/checked.png";
        //        else
        //            _node.ImageUrl = "/WebProjectManagement/Images/left_arrow_blue.png";
        //      e.Node.Nodes.Add(_node);
        //    }

        //    return;
        //}

        private void _SetForms(ProjectManagement.MixedObjects.ItemAndProjectDetails i)
        {
            if (i == null) return;
            if (i.Project != null) txtProjectName.Text = i.Project.Name;
            if (i.ParentItem != null) txtParentNodes.Text = i.ParentItem.Name;
            if (i.Item != null) txtName.Text = i.Item.Name;
            //     txtAllowedPercentage.Text = "(0-" + (100 - i.Item.TotalReportedPercentage()).ToString("000.00").ToDecimal() + ")";
            txtAllowedPercentage.Text = "(0- 100)";
            pnlEnterData.Visible = true;
           // ((WebControllers.MainControls.Date.JDateControl)date).SetDate(DateTime.Today);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int itemcode = trvOrg.SelectedNode.Value.Split(',')[1].ToInt32();
            //if (((WebControllers.MainControls.Date.JDateControl)date).GetDate() < DateTime.Now)
            //{
            //    WebClassLibrary.JWebManager.RunClientScript("alert('برای روزهای گذشته و آینده نمیتوان گزارش وارد کرد!');", "ConfirmDialog3");
            //    return;
            //}
            if (txtImprovementPercent.Text.ContainsNonDigit())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('برای وزن فقط عدد باید وارد کرد.');", "ConfirmDialog2");
                return;
            }
            ProjectManagement.MixedObjects.ItemAndProjectDetails i = null;
            i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(itemcode, projectCode);
            ProjectManagement.ItemReport.JItemReport p = new ProjectManagement.ItemReport.JItemReport();
            //get today last itemreport 
            int latestItemReportCode = -1;
            float todayReportedPercent = 0;
            DataTable dt = ("SELECT Code,WeightPercentage FROM pmItemReport WHERE CONVERT(date,RegisterDate)=CONVERT(DATE,getdate()) AND ItemCode=" + itemcode + "AND UserCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode).ExecuteQuery(true);
            if (dt != null && dt.Rows.Count > 0)
            {
                p.Code = latestItemReportCode = dt.Rows[0][0].ToString().ToInt32();
                todayReportedPercent = dt.Rows[0][1].ToString().ToFloat();
            }

            //if( txtImprovementPercent.Text.ToFloat() + (float)i.Item.ReportedPercentage()-todayReportedPercent>100)
            if (txtImprovementPercent.Text.ToFloat() > 100)
            {
                //WebClassLibrary.JWebManager.RunClientScript("alert('درصد وارد شده باید کمتر از "+(100- ( (float)i.Item.ReportedPercentage()- todayReportedPercent)) +" باشد.');", "ConfirmDialog3");
                WebClassLibrary.JWebManager.RunClientScript("alert('درصد وارد شده باید کمتر از " + (txtImprovementPercent.Text.ToFloat() - 100) + " باشد.');", "ConfirmDialog3");
                return;
            }




            p.ItemCode = itemcode;
            p.RegisterDate = DateTime.Now;// ((WebControllers.MainControls.Date.JDateControl)date).GetDate();// DateTime.Now;
            p.ReportDescription = txtReportDescription.Text;
            p.UserCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            p.WeightPercentage = txtImprovementPercent.Text.ToDecimal();
            p.HasPic = uploadPhoto.UploadedFiles.Count > 0;
            if (latestItemReportCode > 0 && p.Update())
            {

            }
            else if (p.Insert() > 0)
            {
                SaveImages(p.Code);//window.location.href = '"+ newHref + "';"
                string newHref = this.Context.Request.Url.AbsoluteUri;
                if (newHref.Contains("&id=")) newHref = newHref.Remove(newHref.IndexOf("&id="));
                else newHref += "&id=" + itemcode;

                //    WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعات وارد شد.');", "ConfirmDialog4");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات.');", "ConfirmDialog5");
            trvOrg.DataBind();

            trvOrg.SelectedNode.Text = i.Item.Name + "(<span class='treeviewPart1'>وزن آیتم: " + i.Item.WeightPercentage.ToString("000.00").ToDecimal() +
                    "</span> - <span class='treeviewPart2'> وزن زیرمجموعه: " + i.TotalSubItemPercentage.ToString("000.00").ToDecimal() +
                    "</span> - <span class='treeviewPart3'> وزن پیشرفت آیتم: " + i.Item.ReportedPercentage().ToString("000.00").ToDecimal() + "%</span>)";

        }

        private void SaveImages(int itemReportCode)
        {
            Telerik.Web.UI.RadBinaryImage img;
            ClassLibrary.JFile jFile;
            foreach (Telerik.Web.UI.UploadedFile f in uploadPhoto.UploadedFiles)
            {
                img = new Telerik.Web.UI.RadBinaryImage();
                img.DataValue = WebClassLibrary.JDataManager.ReadToEnd(f.InputStream);
                img.ToolTip = f.FileName;
                img.Height = 200;
                img.Width = 200;
                img.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;

                jFile = new ClassLibrary.JFile();
                jFile.Content = img.DataValue;
                jFile.FileName = itemReportCode + "-" + DateTime.Now.ToString() + ".jpg";
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                pnlImages.Controls.Add(img);
                SaveImage(jFile, itemReportCode);
            }
        }


        private void SaveImage(ClassLibrary.JFile jFile, int itemReportCode)
        {

            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                //  archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر شخص");
                archive.ArchiveDocument(jFile, typeof(ProjectManagement.ItemReport.JItemReport).FullName, itemReportCode, "ItemReportImages", true);


            }
            catch (Exception er)
            {
            }
        }


        protected void trvOrg_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        {
            int itemcode = trvOrg.SelectedNode.Value.Split(',')[1].ToInt32();
            if (itemcode > 0)
            {
                int projectCode = trvOrg.SelectedNode.Value.Split(',')[0].ToInt32();
                ProjectManagement.MixedObjects.ItemAndProjectDetails i = null;
                i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(itemcode, projectCode);
                if (i.Item.ReportedPercentage() >= 100)//>= i.Item.WeightPercentage)
                    WebClassLibrary.JWebManager.RunClientScript("alert('این آیتم 100 درصد پیشرفت داشته است.');", "ConfirmDialog6");
                else if (i.TotalSubItemPercentage == 0)
                    _SetForms(i);
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('فقط برای آخرین آیتم ها در شاخه میتوان اطلاعات وارد کرد.');", "ConfirmDialog7");
            }
        }

    }
}