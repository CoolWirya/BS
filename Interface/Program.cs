using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace ERP
{

    static class Program
    {

        /// <summary>
        /// 1 Main - 2 AVL - 3 School
        /// </summary>
        private static int FormId = 1;
        /// <summary>
        /// The main entry pointfor the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {

            //Update();
            switch (FormId)
            {
                case 1:
                    {
						try
						{
							System.Reflection.Assembly assembly = typeof(Program).Assembly;
							var attribute = (System.Runtime.InteropServices.GuidAttribute)assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true)[0];
							var _GUID = attribute.Value;

							Application.EnableVisualStyles();
							Application.SetCompatibleTextRenderingDefault(false);
							Application.Run(new MainForm(_GUID));
						}
						catch
						{
						}
						break;
					}
                case 2:
                    {
						try
						{
							//Application.Run(new AVLServiceForm());
						}
						catch
						{
						}
                        break;
                    }
                case 3:
                    {
						//Application.Run(new SchoolServiceForm());
						break;
                    }
            }
            //Update();
        }


        //private static void ReadFTP(string FTPServerFile, string LocalAdd)
        //{
        //    try
        //    {
        //        WebClient request = new WebClient();
        //        string url = FTPServerFile.Replace("\\", "/");
        //        request.Credentials = new NetworkCredential("erp", "123zxcPOI");

        //        try
        //        {
        //            byte[] newFileData = request.DownloadData(url);
        //            //string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
        //            if (System.IO.File.Exists(LocalAdd))
        //                System.IO.File.Delete(LocalAdd);
        //            System.IO.File.WriteAllBytes(LocalAdd, newFileData);
        //            //Console.WriteLine(LocalAdd);
        //        }
        //        catch
        //        {

        //        }
        //    }
        //    catch
        //    {
        //    }

        //}


        //private static void Update()
        //{
        //    try
        //    {

        //        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument(); //* create an xml document object.
        //        xmlDoc.Load("Config.xml"); //* load the XML document from the specified file.

        //        //* Get elements.
        //        string LocAdd = xmlDoc.GetElementsByTagName("LocAdd").Item(0).FirstChild.Value;
        //        string RemAdd = xmlDoc.GetElementsByTagName("RemAdd").Item(0).FirstChild.Value;
        //        string RemAddWeb = xmlDoc.GetElementsByTagName("RemAddWeb").Item(0).FirstChild.Value;
        //        if (System.IO.File.Exists(RemAdd + "\\" + "Interface.exe"))
        //        {
        //            System.IO.File.Delete(LocAdd + "\\Interface.exe");
        //            System.IO.File.Copy(RemAdd + "\\Interface.exe", LocAdd + "\\Interface.exe", true);

        //            System.IO.File.Delete(LocAdd + "\\Config.xml");
        //            System.IO.File.Copy(RemAdd + "\\Config.xml", LocAdd + "\\Config.xml", true);
        //        }
        //        else
        //        {
        //            ReadFTP(RemAddWeb + "/Interface.exe", LocAdd + "\\Interface.exe");
        //            ReadFTP(RemAddWeb + "/Config.xml", LocAdd + "\\Config.xml");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //    }
        //}

    }
}
