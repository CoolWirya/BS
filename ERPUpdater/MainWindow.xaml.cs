using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Xml;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;


namespace ERPUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(new Action(() =>
                {
                    Update(sender);

                }))).Start();
            }
            catch
            {
            }
            
        }

        private void FormFadeOut_Completed(object sender, EventArgs e)
        {
        }


        private static void CopyFile(string From, string To, bool WebAccess)
        {
                System.IO.File.Copy(From, To,true);
        }

        private static void getFileList()
        {
            XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
            xmlDoc.Load("Config.xml"); //* load the XML document from the specified file.
            string RemAdd = xmlDoc.GetElementsByTagName("RemAdd").Item(0).FirstChild.Value;

            string[] Files = System.IO.Directory.GetFiles(RemAdd);
            string[] FilesNet = new string[Files.Length];
            System.Reflection.AssemblyName asmLoc = null; 
            int i=0;

            foreach (string File in Files)
            {
                if (File.IndexOf(".dll") >= 0 || File.IndexOf(".exe") >= 0)
                {
                    asmLoc = System.Reflection.AssemblyName.GetAssemblyName(File);
                    FilesNet[i++] = System.IO.Path.GetFileName(File) + "=" + asmLoc.Version.ToString();
                }
                else
                {
                    FilesNet[i++] = System.IO.Path.GetFileName(File) + "=0.0.0.0";
                }
            }
            System.IO.File.WriteAllLines("c:\\version.txt", FilesNet);

        }

        private static void Update(object sender)
        {
            //getFileList();
            string LocAdd = "";
            bool WebAccess = false;
            try
            {
                System.Diagnostics.Process[] Notification = System.Diagnostics.Process.GetProcessesByName("NotificationProjects");
                if (Notification.Length == 1)
                    Notification[0].Kill();
                System.Diagnostics.Process[] Interface = System.Diagnostics.Process.GetProcessesByName("ERP");
                if (Interface.Length == 1)
                    Interface[0].Kill();


                XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
                xmlDoc.Load("Config.xml"); //* load the XML document from the specified file.

                //* Get elements.
                LocAdd = xmlDoc.GetElementsByTagName("LocAdd").Item(0).FirstChild.Value;
                string RemAdd = xmlDoc.GetElementsByTagName("RemAdd").Item(0).FirstChild.Value;
                string RemAddWeb = xmlDoc.GetElementsByTagName("RemAddWeb").Item(0).FirstChild.Value;
                if (MessageBox.Show("آیا میخواهید برنامه بروز شود", "بروز رسانی", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;

                if (!System.IO.File.Exists(RemAdd + "\\" + "Version.txt"))
                {
                    WebAccess = true;
                    RemAdd = RemAddWeb;
                }

                string Versions = "";
                CopyFile(RemAdd + "/" + "Version.txt", LocAdd + "\\" + "Version.txt", WebAccess);
                if (System.IO.File.Exists(LocAdd + "\\" + "Version.txt"))
                {
                    Versions = System.IO.File.ReadAllText(LocAdd + "\\" + "Version.txt");
                }
                else
                {
                    return;
                }


                System.Reflection.AssemblyName asmLoc = null;


                foreach (string Version in Versions.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    string[] NameValue = Version.Split(new char[] { '=' });
                    string _file = NameValue[0];
                    try
                    {
                        string LocFile = LocAdd +"\\"+ _file;

                        if (!System.IO.File.Exists(LocFile))
                        {

                            CopyFile(RemAdd + "/" + _file, LocAdd + "\\" + _file, WebAccess);

                        }
                        else
                        {
                            try
                            {
                                if (_file.IndexOf(".dll") >= 0 || _file.IndexOf(".exe") >= 0)
                                {
                                    if (NameValue[1] != "0.0.0.0")
                                    {
                                        asmLoc = System.Reflection.AssemblyName.GetAssemblyName(LocFile);
                                        string VRem = asmLoc.Version.ToString();
                                        if (NameValue[1] != VRem)
                                        {
                                            CopyFile(RemAdd + "/" + _file, LocAdd + "\\" + _file, WebAccess);

                                        }
                                    }
                                }
                                else
                                {
                                    CopyFile(RemAdd + "/" + _file, LocAdd + "\\" + _file, WebAccess);
                                }
                            }


                            catch
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                try
                {
					System.Diagnostics.Process.Start(LocAdd + "\\ERP.exe");
					System.Diagnostics.Process.Start(LocAdd + "\\NotificationProjects.exe");
                }
                catch
                {
                }
				System.Environment.Exit(1);
			}
        }

        private void mainWindow_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
