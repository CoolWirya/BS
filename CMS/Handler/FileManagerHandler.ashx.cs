using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Net;


namespace WebEstate.Land.Ground.Usage.Handler
{
    /// <summary>
    /// Summary description for FileManagerHandler
    /// </summary>
    public class FileManagerHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            GSFileManager fileManager = new GSFileManager(new GSFileSystemFileStorage());
            
            context.Response.Write(fileManager.process(context));
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class GSFileManager
    {
        private string[] options;
        private int opt_param = 0;
        public static string root_param = "rootDir";
        private GSFileSystemFileStorage fileStorage;
        private bool setUtf8Header = true;
        private string[] functions=new string[17];
        private string itemNameRegex = "[/?*;:{}\\\\]+";

        public GSFileManager(GSFileSystemFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
            //this.options = options;
            this.functions[0] = "listDir";
            this.functions[1] = "makeFile";
            this.functions[2] = "makeDirectory";
            this.functions[3] = "deleteItem";
            this.functions[4] = "copyItem";
            this.functions[5] = "renameItem";
            this.functions[6] = "moveItems";
            this.functions[7] = "downloadItem";
            this.functions[8] = "readfile";
            this.functions[9] = "writefile";
            this.functions[10] = "uploadfile";
            this.functions[11] = "jCropImage";
            this.functions[12] = "imageResize";
            this.functions[13] = "copyAsFile";
            this.functions[14] = "serveImage";
            this.functions[15] = "zipItem";
            this.functions[16] = "unZipItem";
        }

        public GSFileManager()
        {

        }

        public string listDir(GSFunctionParams args)
        {
            string directory = args.Directory;
            string path = Path.GetFullPath(directory);
            string [] directories=Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            string html = "";
            html += "var gsdirs = new Array();";
            html += "var gsfiles = new Array();";
            foreach(string dir in directories)
            {
                Uri uri = new Uri(dir);
                DirectoryInfo info = new DirectoryInfo(dir);
                html += "gsdirs.push(new gsItem('2', '"+HttpUtility.HtmlEncode(info.Name)+"', '"+HttpUtility.HtmlEncode(uri.AbsolutePath)+"', '0', '"+getMD5Hash(uri.AbsolutePath)+"', 'dir', '"+GSFileSystemFileStorage.FileTime(dir).ToLongTimeString()+"'));";
            }
            foreach(string file in files)
            {
                Uri uri = new Uri(file);
                html += "gsfiles.push(new gsItem('1', '" + HttpUtility.HtmlEncode(Path.GetFileName(file)) + "', '" + HttpUtility.HtmlEncode(uri.AbsolutePath) + "', '" + GSFileSystemFileStorage.FileSize(file) + "', '" + getMD5Hash(uri.AbsolutePath) + "', '"+Path.GetExtension(file).Substring(1,Path.GetExtension(file).Length-1)+"', '" + GSFileSystemFileStorage.FileTime(file).ToLongTimeString() + "'));";
            }

            return html;
        }

        public string getMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public string getOptionValue(int key, string defaultOpt)
        {
            string result = "";
            if (this.options[key] != "")
                result = this.options[key];
            else if(defaultOpt=="")
            {
                result = defaultOpt;
            }
            return result;
        }

        public void checkFileName(string fileName)
        {
            if (fileName == ".htaccess")
            {
                throw new Exception("ILlegalArgumentException: Source does NOT exists " + fileName);
            }
        }
        public string getRequestFunction(int index)
        {
            string result = "";
            if (this.functions[index] != "")
                result = this.functions[index];
            return result;
        }

        public string process(HttpContext args)
        {
            string dir = "";
            string root = root_param;
            string fileName = "";
            string newFileName = "";
            string response = "";
            string functionName = "";
            string files = "";
            HttpFileCollection UploadedFiles = args.Request.Files;
            if (args.Request.Form["dir"] == null || args.Request.Form["dir"].Length <= 0)
                dir = "/Amini/ERP/WebERP/WebERP/Images/";
            else
                dir=args.Request.Form["dir"];
            if (args.Request.Form["opt"] != null && args.Request.Form["opt"].Length > 0)
                this.opt_param = int.Parse(args.Request.Form["opt"]);
            if(args.Request.Form["filename"] != null && args.Request.Form["filename"].Length > 0)
            {
                fileName = args.Request.Form["filename"];
                checkFileName(fileName);
            }
            if (args.Request.Form["newfilename"] != null && args.Request.Form["newfilename"].Length > 0)
            {
                newFileName = args.Request.Form["newfilename"];
                checkFileName(newFileName);
            }
            if (args.Request.Form["files"] != null && args.Request.Form["files"].Length > 0)
            {
                files = args.Request.Form["files"];
            }
            if(args.Request.Files.Count > 0)
            {
                UploadedFiles = args.Request.Files;
            }

            GSFunctionParams functionParams = new GSFunctionParams();
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            functionParams.Directory = dir;
            functionParams.FileName = fileName;
            functionParams.NewFileName = newFileName;
            functionParams.Files = files;
            functionParams.UploadedFiles = UploadedFiles;
            if(this.opt_param != 0)
              functionName = this.getRequestFunction(this.opt_param - 1); 
            else
                functionName = this.getRequestFunction(this.opt_param);
            if(functionName != null)
            {
                response= this.Invoke(this.GetType().ToString(),functionName,functionParams).ToString();
            }
            else
                throw new Exception("ILlegalArgumentException: Unknown action " + args.Request.Form["opt"]);
            return response;

        }

        public object Invoke(string typeName, string methodName,GSFunctionParams functionParams)
        {
            Type type = Type.GetType(typeName);
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName);
            return method.Invoke(instance,new object[] {functionParams});
        }

        public string makeDirectory(GSFunctionParams args)
        {
            string dir = args.Directory;
            string fileName = "";
            if (args.FileName != "")
                fileName = args.FileName;
            else
                fileName = "NewFolder" + DateTime.Now;
            return GSFileSystemFileStorage.MakeDirectory(dir+fileName);
        }

        public string deleteItem(GSFunctionParams args)
        {
            string[] files = { };
            string dir = args.Directory;
			string response = "{result: \"1\"}";
            string[] sep = new string[] { ",,," };
            if (args.Files != "")
            {
                files = HttpContext.Current.Server.UrlDecode(args.Files).Split(sep,StringSplitOptions.None);

                foreach (string file in files)
                {
                        if (GSFileSystemFileStorage.IsDir(dir + file))
                            GSFileSystemFileStorage.DeleteDirectory(dir + file);
                        else
                            if (GSFileSystemFileStorage.FileExists(dir + file))
                                 GSFileSystemFileStorage.DeleteFile(dir + file);
                    else throw new Exception("ILlegalArgumentException: Source does NOT exists " + file);

                }
                return response;
            }
            else
                throw new Exception("ILlegalArgumentException: files can NOT be null");
        }

        public string uploadfile(GSFunctionParams args)
        {
            HttpFileCollection files = args.UploadedFiles;
            string dir = args.Directory;
            string response = "{result: \"1\"}";
            string[] sep = new string[] { ",,," };
            if (files.Count == 0)
                return "ILlegalArgumentException: files can NOT be null";
            if(args.UploadedFiles != null)
            {
                files = args.UploadedFiles;
                for (int i = 0; i < files.Count;i++ )
                {
                    HttpPostedFile file=files.Get(i);
                    if (file.ContentLength < 1000000000)
                    {
                        if (GSFileSystemFileStorage.FileExists(dir + file.FileName))
                        {
                            string path = Path.GetFullPath(dir);
                            string fname = path + file.FileName.Substring(0, file.FileName.LastIndexOf(".")) + "_1" + file.FileName.Substring(file.FileName.LastIndexOf("."));
                           // string fname = HttpContext.Current.Server.MapPath("../test/" + file.FileName.Substring(0,file.FileName.LastIndexOf(".")) + "_1" + file.FileName.Substring(file.FileName.LastIndexOf(".")));
                            file.SaveAs(fname);
                        }
                        else
                        {
                            string path = Path.GetFullPath(dir);
                            string fname = path + file.FileName;
                           // string fname = HttpContext.Current.Server.MapPath("../test/" + file.FileName);
                            file.SaveAs(fname);
                        }
                    }
                    else
                        return "ILlegalArgumentException: File is too large ";
                }
            }
            return response;
        }
     
        public string serveImage(GSFunctionParams args)
        {
            string fileName = args.FileName;
            string dir = args.Directory;
           string data = "";
            if(GSFileSystemFileStorage.FileExists(dir + fileName))
            {
                data = GSFileSystemFileStorage.ReadFile(dir + fileName);
            }
            return data;
        }
    }

    public class GSFileSystemFileStorage
    {
        public static bool IsDir(string dir)
        {
            string path = Path.GetFullPath(dir);
            return Directory.Exists(HttpContext.Current.Server.UrlDecode(path));
        }

        public static bool FileExists(string file)
        {
            FileInfo info = new FileInfo(file);
            string path = Path.GetFullPath(info.FullName);
            return File.Exists(HttpContext.Current.Server.UrlDecode(path));
        }
        public static string[] ScanDir(string directory)
        {
            string path = Path.GetFullPath(HttpContext.Current.Server.UrlDecode(directory));
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            string[] result = new string[directories.Length+files.Length];
            directories.CopyTo(result, 0);
            files.CopyTo(result, directories.Length);
            return result;

        }

        public static string[] GetFiles(string directory)
        {
            string path = Path.GetFullPath(directory);
            return Directory.GetFiles(HttpContext.Current.Server.UrlDecode(path));
        }

        public static long FileSize(string file)
        {
            long size;
            FileInfo info = new FileInfo(file);
            size = info.Length;
            return size;
        }

        public static void DeleteFile(string file)
        {
            string path = Path.GetFullPath(HttpContext.Current.Server.UrlDecode(file));
            FileInfo info = new FileInfo(path);
            info.Delete();
        }

        public static void DeleteDirectory(string directory)
        {
            string[] files = ScanDir(directory);
            foreach (string file in files)
            {
                if (GSFileSystemFileStorage.IsDir(file))
                    GSFileSystemFileStorage.DeleteDirectory(file);
                else if(GSFileSystemFileStorage.FileExists(file))
                {
                    FileInfo info = new FileInfo(file);
                    info.Delete();
                }
                
            }
            DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.UrlDecode(directory));
            dir.Delete();
        }

        public static DateTime FileTime(string directory)
        {
            string path=Path.GetFullPath(directory);
            if (GSFileSystemFileStorage.IsDir(path))
                return Directory.GetLastWriteTimeUtc(path);
            else if (FileExists(path))
                return File.GetLastWriteTimeUtc(path);
            else
                throw new Exception("ILlegalArgumentException: Source does NOT exists " + directory);
        }

        public static string MakeDirectory(string path)
        {
            if (FileExists(path) || Directory.CreateDirectory(HttpContext.Current.Server.UrlDecode(path)) != null)
                return "{result: \"1\"}";
            return "{result: \"0\"}";
        }
        public static string ReadFile(string directory)
        {
            string data = "";
            byte[] dataByte = null;
            string path = Path.GetFullPath(directory);
            if(FileExists(path))
            {
                FileInfo info = new FileInfo(path);
                dataByte = new byte[info.Length];
                data = Convert.ToBase64String(dataByte);
                //using (FileStream fs = info.OpenRead())
                //{
                //    fs.Read(dataByte, 0, dataByte.Length);
                //}
                //info.Delete();
                //MemoryStream ms = new MemoryStream(dataByte, 0,dataByte.Length);

                //// Convert byte[] to Image
                //ms.Write(dataByte, 0, dataByte.Length);
                //System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //using (MemoryStream ms2 = new MemoryStream())
                //{
                //    // Convert Image to byte[]
                //    image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                //    byte[] imageBytes = ms2.ToArray();

                //    // Convert byte[] to Base64 String
                //    string base64String = Convert.ToBase64String(imageBytes);
                //    return base64String;
                //}
                
            }
            return data;
        }
    }

    public class GSFunctionParams
    {
        public string Directory { get; set; }
        public string FileName { get; set; }
        public string NewFileName { get; set; }
        public string Files { get; set; }
        public HttpFileCollection UploadedFiles { get; set; }

        public GSFunctionParams()
        { }
    }
}