using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL
{
    public partial class Reciever : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = Request.BinaryRead(Request.ContentLength);
                if (bytes.Length>0)
                {
                    ClassLibrary.JDataBase jd = new ClassLibrary.JDataBase();
                    jd.AddParams("@b", bytes);
                    jd.setQuery("exec Sp_ParserBinary @b");
                    jd.Query_Execute();
                    Response.Write("GPS Data successfully Saved");
                }
                Page.Response.Write("GPS Data successfully SavedError");
            }
            catch (Exception er)
            {
                System.IO.File.AppendAllText(HttpRuntime.AppDomainAppPath + @"\WebAVL\Log\ReceiverERROR.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                Page.Response.Write("GPS Data successfully SavedError");
            }
            finally
            {

            }
        }
    }
}