using System;
using System.Data;

namespace WebProjectManagement
{
    public static class Tools
    {
        public static void LoadItemReportImages(System.Web.UI.WebControls.Panel pnlImages,DataTable DtReport)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetArchiveDB();

            foreach (DataRow dr in DtReport.Rows)
            {
                db.setQuery(String.Format(@" SELECT at.Code, '<img src=\""Images/FileTypes/' + CASE WHEN LEN(ct.[FileExtension])>0 THEN SUBSTRING(ct.[FileExtension],2,LEN(ct.[FileExtension])) ELSE 'unknown' END + '.png\""/>' as FileIcon 
                  , at.[ArchiveDesc]
                  , at.[ArchiveCode]
                  , CAST(at.[ArchiveDate] as Time(0))[ArchiveTime]
                  , at.[ArchiveDate]
                  , ct.[FileExtension]
                  , ct.[size]
                  , ct.Contents
                  FROM ArchiveInterface at INNER JOIN ArchiveContent ct ON ct.Code = at.[ArchiveCode] WHERE  at.Status = 1  AND(ClassName = 'ProjectManagement.ItemReport.JItemReport' AND ObjectCode = {0})  ORDER BY ArchiveDate


", dr["Code"].ToString()));
                DataTable dt = db.Query_DataTable();
                Telerik.Web.UI.RadBinaryImage img;
                if (dt != null)
                {
                    foreach (DataRow dr2 in dt.Rows)
                    {
                        ClassLibrary.JFile image = new ClassLibrary.JFile(ClassLibrary.JFileTypes.Image) { Content = (byte[])dr2["Contents"] };
                        if (image != null)
                        {
                            img = new Telerik.Web.UI.RadBinaryImage();
                            img.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                            img.Height = 200;
                            img.Width = 200;
                            img.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;

                            pnlImages.Controls.Add(img);
                        }
                    }
                }
            }
            db.Dispose();
        }

        public static char[] EnglishAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static char[] PersianAlphabet = { 'ا', 'آ', 'ب', 'پ', 'ت', 'ث', 'ج', 'چ', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز','س','ش','ص','ض', 'ع', 'غ', 'ف', 'ق', 'ک', 'گ', 'ل', 'م', 'ن', 'و', 'ه', 'ی' };
    }
}