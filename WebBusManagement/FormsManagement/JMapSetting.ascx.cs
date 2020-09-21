using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JMapSetting : System.Web.UI.UserControl
    {
        string Argument;
        public const string DefaultMarker = "DefaultMarker", NearNextBus = "NearNextBus", OutLine = "OutLine"
            , UnknownDriver = "UnknownDriver", Overspeed = "Overspeed", LongStop = "LongStop";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request["__EVENTARGUMENT"] != null)
                    Argument = Request["__EVENTARGUMENT"]; // parameter
            }
            else 
            {
                LoadImage();
            }
        }

        private void LoadImage()
        {
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            JDataBase db = new JDataBase();
            db.setQuery("select Code, Name, ImageCode, Color from AUTMapRule");
            try
            {
                DataTable dt = db.Query_DataTable();
                DataRow row;
                int ImageCode;
                int Color;
                if (dt != null && dt.Rows.Count > 0)
                {
                    row = dt.Select("Name = '" + DefaultMarker + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            DefaultMarkerImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        DefaultMarkerImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);

                    row = dt.Select("Name = '" +NearNextBus + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    Color = Convert.ToInt32(row["Color"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            NearNextBusImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        NearNextBusImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);
                    if(Color != 0)
                        cpNearNextBus.SelectedColor = System.Drawing.Color.FromArgb(Color);

                    row = dt.Select("Name = '" + OutLine + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    Color = Convert.ToInt32(row["Color"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            OutLineImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        OutLineImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);
                    if (Color != 0)
                        cpOutLine.SelectedColor = System.Drawing.Color.FromArgb(Color);

                    row = dt.Select("Name = '" +UnknownDriver + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    Color = Convert.ToInt32(row["Color"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            UnknownDriverImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        UnknownDriverImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);
                    if (Color != 0)
                        cpUnknownDriver.SelectedColor = System.Drawing.Color.FromArgb(Color);

                    row = dt.Select("Name = '" +Overspeed + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    Color = Convert.ToInt32(row["Color"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            OverspeedImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        OverspeedImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);
                    if (Color != 0)
                        cpOverspeed.SelectedColor = System.Drawing.Color.FromArgb(Color);

                    row = dt.Select("Name = '" + LongStop + "'").First();
                    ImageCode = Convert.ToInt32(row["ImageCode"]);
                    Color = Convert.ToInt32(row["Color"]);
                    if (archive.Retrieve(ImageCode))
                    {
                        ClassLibrary.JFile image = archive.Content;
                        if (image != null)
                            LongStopImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                    }
                    else
                        LongStopImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoCar);
                    if (Color != 0)
                        cpLongStop.SelectedColor = System.Drawing.Color.FromArgb(Color);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        protected void upldPhoto_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            Telerik.Web.UI.RadAsyncUpload upldPhoto = (Telerik.Web.UI.RadAsyncUpload)sender;
            switch (upldPhoto.ID)
            {
                case "upldDefaultMarker":
                    if (Argument == DefaultMarker)
                    {
                        DefaultMarkerImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        DefaultMarkerImage.ToolTip = e.File.FileName;
                        if (DefaultMarkerImage.DataValue != null)
                            SaveImage(Argument, DefaultMarkerImage.DataValue, e.File.FileName);
                    }
                    break;
                case "upldNearNextBus":
                    if (Argument == NearNextBus)
                    {
                        NearNextBusImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        NearNextBusImage.ToolTip = e.File.FileName;
                        if (NearNextBusImage.DataValue != null)
                            SaveImage(Argument, NearNextBusImage.DataValue, e.File.FileName);
                    }
                    break;
                case "upldOutLine":
                    if (Argument == OutLine)
                    {
                        OutLineImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        OutLineImage.ToolTip = e.File.FileName;
                        if (OutLineImage.DataValue != null)
                            SaveImage(Argument, OutLineImage.DataValue, e.File.FileName);
                    }
                    break;
                case "upldUnknownDriver":
                    if (Argument == UnknownDriver)
                    {
                        UnknownDriverImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        UnknownDriverImage.ToolTip = e.File.FileName;
                        if (UnknownDriverImage.DataValue != null)
                            SaveImage(Argument, UnknownDriverImage.DataValue, e.File.FileName);
                    }
                    break;
                case "upldOverspeed":
                    if (Argument == Overspeed)
                    {
                        OverspeedImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        OverspeedImage.ToolTip = e.File.FileName;
                        if (OverspeedImage.DataValue != null)
                            SaveImage(Argument, OverspeedImage.DataValue, e.File.FileName);
                    }
                    break;
                case "upldLongStop":
                    if (Argument == LongStop)
                    {
                        LongStopImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
                        LongStopImage.ToolTip = e.File.FileName;
                        if (LongStopImage.DataValue != null)
                            SaveImage(Argument, LongStopImage.DataValue, e.File.FileName);
                    }
                    break;
            }
            WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded = false;
        }

        private void SaveImage(string Argument, byte[] DataValue, string FileName)
        {
            JDataBase db = new JDataBase();
            int RuleCode = 0, ImageCode = 0;
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            db.setQuery("select Code, ImageCode from AUTMapRule where Name = N'" + Argument + "'");
            try
            {
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    RuleCode = Convert.ToInt32(dt.Rows[0]["Code"]);
                    ImageCode = Convert.ToInt32(dt.Rows[0]["ImageCode"]);
                    ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                    jFile.Content = DataValue;
                    jFile.FileName = FileName;
                    jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                    jFile.FileText = jFile.FileName;
                    if (ImageCode > 0 && archive.Retrieve(ImageCode))
                        archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر اتوبوس");
                    else
                    {
                        ImageCode = archive.ArchiveDocument(jFile, "WebBusManagement.FormsManagement.JMapSetting", RuleCode, JLanguages._Text("BusPicture"), true);
                        db.setQuery("update AUTMapRule set ImageCode = " + ImageCode + " where code = " + RuleCode);
                        if (db.Query_Execute() >= 0)
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد');", "ConfirmDialog");
                        }
                        else
                        {
                            archive.DeleteArchive(ImageCode, true);
                            WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "ConfirmDialog");
                        }
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "ConfirmDialog");
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            string Query = @"
                update AUTMapRule set Color = " + cpNearNextBus.SelectedColor.ToArgb() + @" where Name = N'NearNextBus'
                update AUTMapRule set Color = " + cpOutLine.SelectedColor.ToArgb() + @" where Name = N'OutLine'
                update AUTMapRule set Color = " + cpUnknownDriver.SelectedColor.ToArgb() + @" where Name = N'UnknownDriver'
                update AUTMapRule set Color = " + cpOverspeed.SelectedColor.ToArgb() + @" where Name = N'Overspeed'
                update AUTMapRule set Color = " + cpLongStop.SelectedColor.ToArgb() + @" where Name = N'LongStop'";
            db.setQuery(Query);
            try
            {
                if (db.Query_Execute() >= 0)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد');", "ConfirmDialog");
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "ConfirmDialog");
                }
            }
            catch (Exception ex)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "ConfirmDialog");
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}