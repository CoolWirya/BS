using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class getIcon : System.Web.UI.Page
    {
        private System.Drawing.Image CreateHtmlStringPicture(int iconCode, bool IsMarker = true)
        {
            byte[] byteArrayIn = GetImageFromArcgive(iconCode, IsMarker);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        private byte[] GetImageFromArcgive(int IconCode, bool IsMarker = true)
        {
            if (IconCode < 1)
            {
                if (IsMarker)
                    return WebClassLibrary.JDataManager.LoadFile("~/WebAVL/Icons/default.png");
                else
                    return WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage); 
            }

            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(IconCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                        return WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                }
                if (IsMarker)
                    return WebClassLibrary.JDataManager.LoadFile("~/WebAVL/Icons/default.png");
                else
                    return WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage); 
            }
            catch
            {
                if (IsMarker)
                    return WebClassLibrary.JDataManager.LoadFile("~/WebAVL/Icons/default.png");
                else
                    return WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage); 
            }
        }

        public static System.Drawing.Image CropToCircle(System.Drawing.Image srcImage, Color backGround)
        {
            System.Drawing.Bitmap dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            dstImage.MakeTransparent(Color.Black);
            using (Graphics g = Graphics.FromImage(dstImage))
            {
                using (Brush br = new SolidBrush(backGround))
                {
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                }
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);
            }


          //  using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
         //   {
        //        dstImage.Save(ms, ImageFormat.Png);
               // dstImage = (Bitmap)Bitmap.FromStream(ms);
        //    }


            return dstImage;
        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;


                using (var wrapMode = new ImageAttributes())
                {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static System.Drawing.Image MergeTwoImages(System.Drawing.Image firstImage, System.Drawing.Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }

            int outputImageWidth = firstImage.Width < secondImage.Width ? firstImage.Width : secondImage.Width;

            int outputImageHeight = firstImage.Height < secondImage.Height ? firstImage.Height : secondImage.Height;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height + 1), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.ContentType = "image/png";
            if (Request["t"] == "hs")//GetHtmlString Icon. this use when popup show.
            {
                CreateHtmlStringPicture(int.Parse(Request["ic"])).Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (Request["t"] == "g")//when markers joined and need number of joined markers
            {
                if (!string.IsNullOrEmpty(Request["n"]))
                {
                    int number;
                    int.TryParse(Request["n"], out number);
                    string path = System.IO.Path.GetDirectoryName(Request.PhysicalPath);
                    System.Drawing.Image i = System.Drawing.Image.FromFile(path + "\\WebAVL\\Icons\\geotagMarker.png");
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(i);
                    g.DrawString(number.ToString(), new System.Drawing.Font("arial", 10f), new System.Drawing.SolidBrush(System.Drawing.Color.Red), new System.Drawing.PointF(15, 5));
                    i.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            else if (Request["t"] == "PicCode")
            {
                int photoid;
                int.TryParse(Request["id"], out photoid);
                try
                {
                    System.Drawing.Image image = ResizeImage(CropToCircle(CreateHtmlStringPicture(photoid), Color.White), 100, 100);
                    image.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {

                }
                //System.Drawing.Image outputImage = new Bitmap(i.Width, i.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                //using (Graphics graphics = Graphics.FromImage(outputImage))
                //{
                //    graphics.DrawImage(i, 0, 0, i.Width, i.Height);
                //    graphics.DrawImage(image, 14, 4, image.Width, image.Height);

                //}
            }
            else if (Request["tb"] == "DriverPCode")
            {
                int photoid;
                int DriverPCode;
                int.TryParse(Request["id"], out DriverPCode);
                ClassLibrary.JPerson person = new ClassLibrary.JPerson(DriverPCode);
                photoid = person.PersonImageCode;
                try
                {
                    System.Drawing.Image image = ResizeImage(CreateHtmlStringPicture(photoid, false), 100, 100);
                    image.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {

                }
            }
            else if (Request["tb"] == "StationImageCode")
            {
                int StationImageCode;
                int.TryParse(Request["id"], out StationImageCode);
                try
                {
                    System.Drawing.Image image = CreateHtmlStringPicture(StationImageCode, false);
                    image.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {

                }

                //ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                //try
                //{
                //    if (archive.Retrieve(StationImageCode))
                //    {
                //        ClassLibrary.JFile image = archive.Content;
                //        if (image != null)
                //            imgStation.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                //    }
                //    else
                //        imgStation.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage);
                //}
                //catch { }
            }
            else if (Request["t"] == "p")// zoom is more than a specified value,and show picture inside a geotagMarker
            {
                int id;
                int.TryParse(Request["id"], out id);
                string state = Request["d"];
                string path = System.IO.Path.GetDirectoryName(Request.PhysicalPath);
                if (state.Equals("t"))
                    path += "\\WebAVL\\Icons\\PersonMarker_red.png";
                else
                    path += "\\WebAVL\\Icons\\PersonMarker.png";
                System.Drawing.Image i = System.Drawing.Image.FromFile(path);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(i);

                int photoid = 0;
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery(@"select 
(select PersonImageCode from clsPerson where code =u.pcode) PicCode 
from AVLDevice AD 
inner join users u on u.code=AD.personCode  where  AD.Code=" + id.ToString());

                    System.Data.DataTable dt = DB.Query_DataTable();
                    if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString().Length > 0)
                        photoid = (int)dt.Rows[0][0];//get photoid using id
                }
                finally
                {
                    DB.Dispose();
                }
                if (photoid > 0)
                {
                    System.Drawing.Image image = ResizeImage(CropToCircle(CreateHtmlStringPicture(photoid), Color.Transparent), 36, 36);
                    System.Drawing.Image outputImage = new Bitmap(i.Width, i.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    using (Graphics graphics = Graphics.FromImage(outputImage))
                    {
                        graphics.DrawImage(i, 0, 0, i.Width, i.Height);
                        graphics.DrawImage(image, 14, 4, image.Width, image.Height);

                    }
                    outputImage.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                    i.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (Request["t"] == "s")
            {
                int argb = 0;
                int.TryParse(Request["color"], out argb);
                string IconUrl = "~/WebBusManagement/Images/station_s32.png";
                string ImagePath = Server.MapPath(IconUrl);

                System.Drawing.Image outputImage = System.Drawing.Image.FromFile(ImagePath);

                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    Brush brush = new SolidBrush(Color.FromArgb(argb));
                    graphics.DrawLine(new Pen(brush, 8), new Point(0, 0), new Point(0, outputImage.Height));
                    graphics.DrawLine(new Pen(brush, 8), new Point(0, 0), new Point(outputImage.Width, 0));
                    graphics.DrawLine(new Pen(brush, 8), new Point(0, outputImage.Height), new Point(outputImage.Width, outputImage.Height));
                    graphics.DrawLine(new Pen(brush, 8), new Point(outputImage.Width, 0), new Point(outputImage.Width, outputImage.Height));

                }
                outputImage.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

            }
            else if (Request["t"] == "a")
            {
                int AngleIndex = 0;
                string strStyle = "";
                int.TryParse(Request["AngleIndex"], out AngleIndex);
                strStyle = Request["Style"].ToString();
                List<string> Styles = strStyle.Split(',').ToList();
                if (Styles.Where(p => p == "").Count() > 0)
                    Styles.Remove(Styles.Where(p => p == "").First());
                //string ArrowUrl = "~/WebBusManagement/Images/arrow.png";
                //string ArrowPath = Server.MapPath(ArrowUrl);

                Bitmap outputImage = new Bitmap(42, 42);
                System.Drawing.Image Marker;
                if (WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                {
                    DataTable dtRules = (DataTable)WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesDataTable"];
                    Marker = WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker;
                    bool IsDefaultMarker = true;
                    int Top = 10;
                    using (Graphics graphics = Graphics.FromImage(outputImage))
                    {
                        foreach (string style in Styles)
                        {
                            if (IsDefaultMarker)
                            {
                                switch (style)
                                {
                                    case WebBusManagement.FormsManagement.JMapSetting.NearNextBus:
                                        if (WebBusManagement.FormsManagement.JOnlineMapNew.NearNextBus != null)
                                            Marker = WebBusManagement.FormsManagement.JOnlineMapNew.NearNextBus;
                                        break;
                                    case WebBusManagement.FormsManagement.JMapSetting.OutLine:
                                        if (WebBusManagement.FormsManagement.JOnlineMapNew.OutLine != null)
                                            Marker = WebBusManagement.FormsManagement.JOnlineMapNew.OutLine;
                                        break;
                                    case WebBusManagement.FormsManagement.JMapSetting.UnknownDriver:
                                        if (WebBusManagement.FormsManagement.JOnlineMapNew.UnknownDriver != null)
                                            Marker = WebBusManagement.FormsManagement.JOnlineMapNew.UnknownDriver;
                                        break;
                                    case WebBusManagement.FormsManagement.JMapSetting.Overspeed:
                                        if (WebBusManagement.FormsManagement.JOnlineMapNew.Overspeed != null)
                                            Marker = WebBusManagement.FormsManagement.JOnlineMapNew.Overspeed;
                                        break;
                                    case WebBusManagement.FormsManagement.JMapSetting.LongStop:
                                        if (WebBusManagement.FormsManagement.JOnlineMapNew.LongStop != null)
                                            Marker = WebBusManagement.FormsManagement.JOnlineMapNew.LongStop;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (!IsDefaultMarker)
                            {
                                DataRow row = dtRules.Select("Name = '" + style + "'").First();
                                int Color = Convert.ToInt32(row["Color"]);
                                if (Color != 0)
                                {
                                    Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(Color));
                                    Rectangle rec = new Rectangle(0, Top, 7, 7);
                                    graphics.FillEllipse(brush, rec);
                                    Top += 8;
                                }
                            }
                            IsDefaultMarker = false;
                        }
                        if (graphics != null && Marker != null)
                            graphics.DrawImage(Marker, new Point(10, 10));
                        if (AngleIndex > 0)
                        {
                            System.Drawing.Image Arrow = (System.Drawing.Image)WebBusManagement.FormsManagement.JOnlineMapNew.Arrows[AngleIndex];
                            graphics.DrawImage(Arrow, new Point(10, 0));
                        }
                        else 
                        { 
                        }
                        //    if (Styles.Contains("1"))
                        //    {
                        //            Brush brush = new SolidBrush(Color.Red);
                        //            Rectangle rec = new Rectangle(2, 2, outputImage.Width - 4, outputImage.Height - 4);
                        //            graphics.DrawEllipse(new Pen(brush, 4), rec);

                        //    }
                        //    if (Styles.Contains("2"))
                        //    {
                        //        Brush brush = new SolidBrush(Color.Yellow);
                        //        Rectangle rec = new Rectangle(outputImage.Width / 2 - 1, outputImage.Height / 2 - 1, 4, 4);
                        //        graphics.DrawEllipse(new Pen(brush, 4), rec);
                        //    }
                        //    if (Styles.Contains("3"))
                        //    {
                        //        Brush brush = new SolidBrush(Color.Blue);
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(0, 0), new Point(0, outputImage.Height));
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(0, 0), new Point(outputImage.Width, 0));
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(0, outputImage.Height), new Point(outputImage.Width, outputImage.Height));
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(outputImage.Width, 0), new Point(outputImage.Width, outputImage.Height));
                        //    }
                        //    if (Styles.Contains("4"))
                        //    {
                        //        Brush brush = new SolidBrush(Color.Blue);
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(0, 0), new Point(outputImage.Width, outputImage.Height));
                        //        graphics.DrawLine(new Pen(brush, 4), new Point(outputImage.Width, 0), new Point(0, outputImage.Height));
                        //    }
                        //    if (Styles.Contains("5"))
                        //    {
                        //        Brush brush = new SolidBrush(Color.Blue);
                        //        graphics.DrawEllipse(new Pen(brush, 4), new Rectangle(new Point(0, 0), new Size(outputImage.Width, outputImage.Height)));
                        //    }
                    }
                }
                else // Icons are not loaded from WebBusManagement.FormsManagement.JOnlineMapNew user control
                {
                    string MarkerUrl = "~/WebBusManagement/Images/station_s32.png";
                    string MarkerPath = Server.MapPath(MarkerUrl);
                    Marker = System.Drawing.Image.FromFile(MarkerPath);
                    using (Graphics graphics = Graphics.FromImage(outputImage))
                    {
                        graphics.DrawImage(Marker, new Point(10, 10));
                    } 
                }
                outputImage.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

            }
        }
    }
}