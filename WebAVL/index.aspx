<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebAVL.index" EnableEventValidation="False" %>

    <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>رهگیری خودرو</title>
	<%--<script src="Script/jquery-1.8.2.js"></script>--%>
         <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
        <script src="/WebAVL/Script/TweenLite.min.js"></script>
    <link href="/WebAVL/Style/bootstrap.min.css" rel="stylesheet" />
    <style>        
    body{
        background: url(/WebAVL/Image/back.png);
	    background-color: #444;
        background: url(/WebAVL/Image/pinlayer2.png),
            url(/WebAVL/Image/pinlayer1.png),
            url(/WebAVL/Image/back.png);    
    }

    .vertical-offset-100{
        padding-top:100px;

    }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).mousemove(function (e) {
                TweenLite.to($('body'),
                   .5,
                   {
                       css:
                         {
                           backgroundPosition: "" + parseInt(event.pageX / 8) + "px " + parseInt(event.pageY / '12') + "px, " + parseInt(event.pageX / '15') + "px " + parseInt(event.pageY / '15') + "px, " + parseInt(event.pageX / '30') + "px " + parseInt(event.pageY / '30') + "px"
                         }
                   });
            });
        });
    </script>
    <link href="Style/LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Style/MainStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="divLogo">
            <telerik:RadBinaryImage runat="server" ID="imgLogo" ResizeMode="Fit" Width="200px" Height="200px" /><br />
            <%=WebClassLibrary.JWebSettings.GetKey("WebSiteLogoText") %>
        </div>
        <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" Skin="Metro" />
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Metro" ShowChooser="false" />

        <div class="container">
            <div class="row vertical-offset-100">
    	        <div class="col-md-4 col-md-offset-4">
    		        <div class="panel panel-default">
                        <div style="width: 49%; float: right; background-color: rgb(255, 255, 255); height: 100%;border-radius: 4px;
border: 1px solid transparent;">
			  	            <div class="panel-heading">
			    	            <h3 class="panel-title">ورود</h3>
			 	                </div>
			  	            <div class="panel-body">   
                                 <asp:Label ID="lblError" runat="server" Text="نام کاربری یا کلمه عبور اشتباه می باشد." CssClass="lblError" Visible="False"></asp:Label>			    	   
                                <fieldset>
                                    <table>
                                        <tr>
                                            <td>
                                                نام کاربری:
                                            </td>
                                            <td>
			    	  	                        <div class="form-group">
                                                    <telerik:RadTextBox ID="txtUserlogin" runat="server" CssClass="form-control rfdDecorated" TextMode="SingleLine"></telerik:RadTextBox>
			    		                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                کلمه عبور:
                                            </td>
                                            <td>
			    		                        <div class="form-group">
                                                    <telerik:RadTextBox ID="txtPassLogin" runat="server" CssClass="form-control rfdDecorated" TextMode="Password"></telerik:RadTextBox>
			    		                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                کد امنیتی
                                            </td>
                                            <td>
                                                <div>
                                                    <telerik:RadCaptcha ID="RadCaptcha1" runat="server"
                                                        ErrorMessage="کد وارد شده صحیح نمی باشد." Display="Dynamic" ProtectionMode="Captcha" CaptchaImage-TextLength="4" CaptchaImage-TextChars="Numbers" OnCaptchaValidate="RadCaptcha1_CaptchaValidate" CaptchaTextBoxLabel="">
                                                    </telerik:RadCaptcha>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btnLogin" runat="server" Text="ورود" CssClass="btn btn-lg btn-success btn-block" OnClick="btnLogin_Click" />
			    	            </fieldset>
			                </div>
                        </div>
                        <div style="width: 49%; float: left; background-color: rgb(255, 255, 255); height: 100%;border-radius: 4px;
border: 1px solid transparent;">
			  	            <div class="panel-heading">
			    	            <h3 class="panel-title">ثبت نام</h3>
			 	            </div>
			  	            <div class="panel-body">
                                <fieldset>
                                    <table>
                                        <tr>
                                            <td>
                                                        نام:		
                                            </td>
                                            <td>
			    	  	                        <div class="form-group">	    
				                                        <telerik:RadTextBox runat="server" ID="txtName" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
		                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                      نام خانوادگی:
                                            </td>
                                            <td>
			    	  	                        <div class="form-group">
                                                      <telerik:RadTextBox runat="server" ID="txtLastname" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
		                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                      نام کاربری:
                                            </td>
                                            <td>
			    	  	                        <div class="form-group">
			                                          <telerik:RadTextBox runat="server" ID="txtUsername" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
			                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                    کلمه عبور:
                                            </td>
                                            <td>
                                                <div class="form-group">
				                                    <telerik:RadTextBox runat="server" ID="txtPassword" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
                                                </div> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                      پست الکترونیکی:
                                            </td>
                                            <td>                                 
			    	  	                        <div class="form-group">
				                                      <telerik:RadTextBox runat="server" ID="txtEmail" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
                                                </div> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                      شماره همراه:
                                            </td>
                                            <td>                                 
			    	  	                        <div class="form-group">
				                                      <telerik:RadTextBox runat="server" ID="txtMobile" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
			    	  	                        </div> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            </td>
                                            <td>                                                                     
			    	  	            <div class="form-group">
                                          <telerik:RadButton runat="server" ID="rdbResendVerificationCode" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnVerificationCode_Click" Visible="false" ValidationGroup="Line" />
                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group">
			                                          <asp:Label ID="lblVerificationCode" runat="server" Text="  کد تاییدیه را وارد کنید." Visible="false"></asp:Label>
                                                </div>                                                
                                            </td>
                                            <td>
                                                <div class="form-group">
		                                              <telerik:RadTextBox runat="server" ID="txtVerificationCode" Visible="false" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
	                                            </div>
                                            </td>
                                            <td>
                                                <telerik:RadButton runat="server" ID="btnVerificationCode" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" CssClass="btn btn-lg btn-success btn-block"  OnClick="btnVerificationCode_Click" Visible="false" ValidationGroup="Line" />
                                            </td>
                                        </tr>
                                    </table>                                    
                                    <asp:HiddenField ID="hdfasp" runat="server" />
                                    <asp:Button ID="btnRegister" runat="server" Text="ثبت" CssClass="btn btn-lg btn-success btn-block"  OnClick="btnRegister_Click" />
			    	            </fieldset>
			                </div>
                        </div>
			        </div>
		        </div>
	        </div>
        </div>
    </form>
</body>
</html>
