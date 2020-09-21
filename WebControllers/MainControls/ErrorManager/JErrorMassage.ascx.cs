using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.ErrorManager
{
    public partial class JErrorMassage : System.Web.UI.UserControl
    {
        #region Initilization
        ////___________________________________________________________________________
        private WebClassLibrary.MessageType errorType;
        private string imageUrl;
        private string messageText;
        private string messageDescription;
        public WebClassLibrary.MessageType ErrorType
        {
            get
            {
                switch (imgErrorIcon.ImageUrl)
                {
                    case "~\\WebErp\\Images\\Controls\\Messages\\Error.png":
                        return WebClassLibrary.MessageType.Error;

                    case "~\\WebErp\\Images\\Controls\\Messages\\Info.png":
                        return WebClassLibrary.MessageType.Information;

                    case "~\\WebErp\\Images\\Controls\\Messages\\warning.png":
                        return WebClassLibrary.MessageType.Warning;

                    default:
                        return WebClassLibrary.MessageType.Normal;

                }
            }

            set
            {
                ViewState["errorType"] = value;
                if (ImageUrl == string.Empty)
                    switch (value)
                    {
                        case WebClassLibrary.MessageType.Error:
                            imgErrorIcon.ImageUrl = "~\\WebErp\\Images\\Controls\\Messages\\Error.png";
                            break;

                        case WebClassLibrary.MessageType.Information:
                            imgErrorIcon.ImageUrl = "~\\WebErp\\Images\\Controls\\Messages\\Info.png";
                            break;

                        case WebClassLibrary.MessageType.Warning:
                            imgErrorIcon.ImageUrl = "~\\WebErp\\Images\\Controls\\Messages\\warning.png";
                            break;

                        case WebClassLibrary.MessageType.Normal:
                            // imgErrorIcon.ImageUrl = ;
                            break;
                    }
                else
                    imgErrorIcon.ImageUrl = ImageUrl;
            }
        }
        private string ImageUrl
        {
            get
            {
                if (ViewState["imageUrl"] != null)
                    imageUrl = (string)ViewState["imageUrl"];
                return (imageUrl == null) ? string.Empty : (string)ViewState["imageUrl"];

            }

            set
            {
                ViewState["imageUrl"] = value;
            }
        }
        ////___________________________________________________________________________
        private string MessageText
        {
            get
            {
                
                messageText = lblMessage.InnerHtml;
                return lblMessage.InnerHtml;

            }

            set
            {
                lblMessage.InnerHtml += value;
            }
        }
        ////___________________________________________________________________________
        private string MessageDescription
        {
            get
            {

                messageDescription = lblErrorDescription.Text;
                return lblErrorDescription.Text;

            }

            set
            {
                lblErrorDescription.Text = value;
            }
        }
        ////___________________________________________________________________________
        #endregion Initilization

        #region Global
        ////___________________________________________________________________________
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["url"] != string.Empty)
            {
               // ImageUrl = Request["url"];
                MessageText = Request["message"].Replace(" \n ", " <br /> ");
                MessageDescription = Request["messageDesc"];
                ErrorType = WebClassLibrary.MessageType.Error;
            }
        }
        ////___________________________________________________________________________
        #endregion Global

        #region Events
        ////___________________________________________________________________________
        protected void Close_Btn_Click(object sender, EventArgs e)
        {

        }
        ////___________________________________________________________________________
        #endregion Events

        #region Methods
        ////___________________________________________________________________________
        public string ShowMessage(string url, string message, string messageDesc, WebClassLibrary.MessageType errTyp)
        {
            if (lblMessage == null)
                return string.Empty;
            ImageUrl = url;
            MessageText = message;
            MessageDescription = messageDesc;
            ErrorType = errTyp;

            return WebClassLibrary.JWebManager.LoadClientControl("ErrorMessaage"
               , "~/WebControllers/MainControls/ErrorManager/JErrorMassage.ascx"
               , ClassLibrary.JLanguages._Text(ErrorType.ToString())
               , null
               , WebClassLibrary.WindowTarget.NewWindow
               , true, false, true, 600, 200);
        }
        ////___________________________________________________________________________
        #endregion Methods

    }
}