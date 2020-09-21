<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebERP.index" EnableEventValidation="False" %>

    <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/WebAVL/Style/bootstrap.min.css" rel="stylesheet" />
    <link href="Style/WebAVLstyle.css" rel="stylesheet" />
    <style>        
    body{
        background: url(/Images/concrete_seamless.png);
        /*background: url(/WebAVL/Image/pinlayer2.png),
            url(/WebAVL/Image/pinlayer1.png),
            url(/WebAVL/Image/back.png);*/    
    }
    button{
            padding: 10px;
            border-radius:5px;
    background-color: orange;
    border: 2px solid gray;
    font-family: "2 nazanin";
    }
    button:hover{
    background-color: gray;
    border: 2px solid orange;
    }
    .container{
        margin-top:100px;
    }
    .vertical-offset-100{

    }
    .varifyPanel{    
        position: absolute;
    width: 50%;
    height: auto;
    margin: 25%;
    background-color: gray;
    padding: 20px;
    direction: rtl;
    border: solid thin black;
    z-index:1;
    border-radius: 10px;
    }
    </style>
    <title>رهگیری خودرو</title>
         <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
        <script src="/WebAVL/Script/TweenLite.min.js"></script>
    
	<script src="Script/jquery-1.8.2.js"></script>
<script  lang="javascript">
    function MobileDigitCount(source, arguments) {
        console.log(arguments.Value.length);
        if (arguments.Value.length >= 10) {
            arguments.IsValid = true;
        } else {
            arguments.IsValid = false;
        }
    }
    function MobileCountryCode(source, arguments) {
        console.log(arguments.Value);
        if (arguments.Value.substring(0, 4) != "0098") {
            arguments.IsValid = true;
        } else {
            arguments.IsValid = false;
        }
    }
    function splashClick() {
        $("#imgSplashScreen").hide(100);
    }
    //setTimeout(function () {
    //    $("#imgSplashScreen").fadeOut('slow');
    //   // document.getElementById("imgSplashScreen").style.display = "none";
    //}, 3000);
</script>
</head>
<body>
    <img id="imgSplashScreen" src="/WebAvl/Images/splashScreen.jpg" height="100%" width="100%" style="z-index:100;position:absolute;top:0px;left:0px;" onclick="splashClick()" />
    <%--<div style="position:fixed;top:0px;right:0px;direction:rtl;">
            <button id="btnTopLogin" onclick="document.getElementById('divRegister').style.display='none';document.getElementById('divLogin').style.display='block';"> ورود</button>
             <button id="btnTopRegister" onclick="document.getElementById('divLogin').style.display='none';document.getElementById('divRegister').style.display='block';"> ثبت نام</button>
      </div>--%>
    <form id="form1" runat="server">
        
    <asp:Panel runat="server" ID="pnlForgetPass" CssClass="varifyPanel" Visible="false">		    	                                                                
    <table> 
            <tr>
                <td>          
                    <div class="form-group">
                       شماره همراه خودرا وارد کنید.
                    </div>                                                
                </td>
                <td>
                    <div class="form-group">
		                    <telerik:RadTextBox runat="server" ID="txtForgetpassMobile" Visible="true" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
	                </div>
                </td>
                <td>
                    <asp:Button runat="server" ID="Button2" Text="ارسال" AutoPostBack="true" Width="100px" Height="35px" CssClass="btn btn-lg btn-success btn-block"  OnClick="Button2_Click" Visible="true" ValidationGroup="Line" />
                </td>
            </tr>
        </table>
    </asp:Panel>
         
    <asp:Panel runat="server" ID="pnlVarify" CssClass="varifyPanel" Visible="false">
       
    <table>    
        <tr>
                <td> 
                    <div class="form-group">
			                شماره همراه
                    </div>                                                
                </td>
                <td>
                    <div class="form-group">  
                         <asp:CustomValidator ID="CustomValidator2" runat="server"  ControlToValidate="txtChangeNumber"   OnServerValidate="vldMobileDuplicate_ServerValidate" ErrorMessage="این شماره قبلا ثبت شده است."></asp:CustomValidator>
                            <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtChangeNumber"  ValidationExpression="^[0-9]+$" ErrorMessage="شماره همراه فقط عدد می توند باشد."></asp:RegularExpressionValidator>
			    	  	    <telerik:RadTextBox runat="server" ID="txtChangeNumber" Visible="true" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
	                </div>
                </td>
                <td>
                 <asp:Button runat="server" ID="Button1" Text="ارسال مجدد کد" AutoPostBack="true" Width="100px" Height="35px" CssClass="btn btn-lg btn-success btn-block"  OnClick="Button1_Click" ValidationGroup="Line" />

                </td>
            </tr>
            <tr>
                <td>                                     
                    <div class="form-group">
			                <asp:Label ID="lblVerificationCode" runat="server" Text="  کد تاییدیه برای شما پیامک شد. لطفا کد را وارد کنید. این ممکن است تا 30 ثانیه طول بکشد." Visible="false"></asp:Label>
                    </div>                                                
                </td>
                <td>
                    <div class="form-group">
		                    <telerik:RadTextBox runat="server" ID="txtVerificationCode" Visible="false" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
	                </div>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnVerificationCode" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" CssClass="btn btn-lg btn-success btn-block"  OnClick="btnVerificationCode_Click" ValidationGroup="Line" />
                  </td>
            </tr>
        </table>
    </asp:Panel>      
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                
                        <div id="divLogin" style="width: 100%;
/*background-image:url(/Images/purple-755266__180.png);*/ background-color: #206BA4; height:100px;border-radius: 4px;
border-bottom: 5px solid gray;margin:auto;direction:rtl;color:#EBF4FA">
			  	            <div class="panel-body">   
                                 <asp:Label ID="lblError" runat="server" Text="نام کاربری یا کلمه عبور اشتباه می باشد." ForeColor="red" CssClass="lblError" Visible="False"></asp:Label>			    	   
			    	            
                                  <asp:Label ID="lblVarifyError" runat="server" Text="کاربر شما تایید نشده است." ForeColor="red" CssClass="lblError" Visible="False"></asp:Label>			    	   
                               
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
                                            <td>
                                                کلمه عبور:
                                            </td>
                                            <td>
			    		                        <div class="form-group">
                                                    <telerik:RadTextBox ID="txtPassLogin" runat="server"  CssClass="form-control rfdDecorated" TextMode="Password"></telerik:RadTextBox>
			    		                        </div>
                                            </td>
                                            <td>
                                                کد امنیتی
                                            </td>
                                            <td>
                                                    <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ForeColor="red"
                                                        ErrorMessage="کد وارد شده صحیح نمی باشد." Display="Dynamic" ProtectionMode="Captcha" CaptchaImage-TextLength="4" CaptchaImage-TextChars="Numbers" OnCaptchaValidate="RadCaptcha1_CaptchaValidate" CaptchaTextBoxLabel="">
                                                    </telerik:RadCaptcha>
                                            </td>
                                            <td>
                                                     <asp:Button ID="btnLogin" Width="100px" runat="server" Text="ورود" CssClass="btn btn-lg btn-success btn-block" OnClick="btnLogin_Click" />
                                    <asp:Button runat="server" ID="lnkForgetPass"  CssClass="btn btn-lg btn-success btn-block" Text="ارسال اطلاعات" OnClick="lnkForgetPass_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                               </fieldset>
                               
			                </div>
                        </div>
        <div style="position:absolute;top:250px;left:15px; background-color:violet;border:solid thin black;">
            <iframe src="/eNamadLogo.htm" frameborder="0" scrolling="no" allowtransparency="true" style="width: 150px; height:150px;"></iframe>
        </div>
        <div style="position:absolute;top:400px;left:15px; background-color:violet;border:solid thin black;">
            <img src="Images/Logos/BPMLogo/BPMLogo.jpg" title="به پرداخت"  alt="به پرداخت" style="width: 150px; height:150px;"/>
            <a href="http://shaparak.ir" title="شاپرک" style="display:block;">شاپرک</a>
        </div>
        <div class="container">
            <div id="divRegister" style="width: 40%;  background-color: gainsboro; height: 100%;border-radius: 4px;
border: 5px solid gray;margin:auto; float:right;direction:rtl; visibility:hidden ;">
			  	            <div class="panel-heading">
			    	            <h3 class="panel-title">ثبت نام</h3>
			 	            </div>
			  	            <div class="panel-body">        
                                <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="NF"  ForeColor="Red"  />                                        		    	                                       			    	  	                      
                                <fieldset>
                                    <table>
                                        <tr>
                                            <td>
                                                  نام:    
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ValidationGroup="NF" ForeColor="Red" ErrorMessage="نام را وارد کنید"  >*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>                                                
			    	  	                        <div class="form-group">	    
				                                        <telerik:RadTextBox runat="server" ID="txtName" ValidationGroup="NF" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
		                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                   نام خانوادگی:   
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="NF"  ControlToValidate="txtLastname" ForeColor="Red" ErrorMessage="نام خانوادگی را وارد کنید"  >*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
			    	  	                        <div class="form-group">
                                                      <telerik:RadTextBox runat="server" ID="txtLastname" ValidationGroup="NF" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
		                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                               نام کاربری: 
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server"  ValidationGroup="NF" ControlToValidate="txtUsername" ForeColor="Red"  ErrorMessage="نام کاربری را وارد کنید">*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server"  ControlToValidate="txtUsername"   ValidationGroup="NF"  OnServerValidate="CustomValidator1_ServerValidate" display="None" ErrorMessage="این نام کاربری قبلا ثبت شده است."></asp:CustomValidator>
                                            </td>
                                            <td>                                                
			    	  	                        <div class="form-group">
			                                          <telerik:RadTextBox runat="server" ID="txtUsername" ValidationGroup="NF" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
			                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 کلمه عبور:
                                                <asp:RegularExpressionValidator ID="revValidPassword" runat="server"  Display="None" ControlToValidate="txtPassword" ValidationGroup="NF" ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" ErrorMessage="پسورد حداقل 8 حرف و دارای عدد،حرف بزرگ و کوچک و سیمبل می باشد." ForeColor="Red"></asp:RegularExpressionValidator>
				                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Visible="false" runat="server" ValidationGroup="NF"  ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="کلمه عبور را وارد کنید" >*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>   
                                               <div class="form-group">
                                                   <telerik:RadTextBox runat="server" ID="txtPassword" ValidationGroup="NF" CssClass="form-control rfdDecorated"  TextMode="Password"></telerik:RadTextBox>
                                                </div> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                              پست الکترونیکی:
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="NF"  ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="ایمیل را وارد کنید" >*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="vldEmailDuplicate" runat="server"  ControlToValidate="txtEmail"   ValidationGroup="NF"  OnServerValidate="vldEmailDuplicate_ServerValidate" display="None" ErrorMessage="این ایمیل قبلا ثبت شده است."></asp:CustomValidator>
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  ValidationGroup="NF" runat="server" ControlToValidate="txtMobile" ForeColor="Red" display="None" ErrorMessage="شماره همراه را وارد کنید">*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="vldMobileCountryCode" runat="server" ControlToValidate="txtMobile"   ValidationGroup="NF"  ClientValidationFunction="MobileCountryCode" display="None" ErrorMessage="شماره موبایل را بدون پیش شماره کشور وارد کنید."></asp:CustomValidator>
                                                <asp:CustomValidator ID="vldMobileDigitsCount" runat="server" ControlToValidate="txtMobile"   ValidationGroup="NF"  ClientValidationFunction="MobileDigitCount" display="None" ErrorMessage="شماره موبایل نمی تواند کمتر از 10 رقم باشد. لطفا شماره معتبر وارد کنید."></asp:CustomValidator>
                                                <asp:CustomValidator ID="vldMobileDuplicate" runat="server"  ControlToValidate="txtMobile"   ValidationGroup="NF"  OnServerValidate="vldMobileDuplicate_ServerValidate" display="None" ErrorMessage="این شماره قبلا ثبت شده است."></asp:CustomValidator>
                                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1"  ValidationGroup="NF" runat="server" ControlToValidate="txtMobile" display="None"  ValidationExpression="^[0-9]+$" ErrorMessage="شماره همراه فقط عدد می تواند باشد."></asp:RegularExpressionValidator>
			    	  	                      </td>
                                            <td>
                                               <div class="form-group">
				                                      <telerik:RadTextBox runat="server" ID="txtMobile" CssClass="form-control rfdDecorated"  TextMode="SingleLine"></telerik:RadTextBox>
			    	  	                        </div> 
                                            </td>
                                        </tr>
                                        
                                    </table>                         
                                    <asp:HiddenField ID="hdfasp" runat="server" />
                                    <asp:HiddenField ID="hduasp" runat="server" />
                                    <asp:HiddenField ID="hdmasp" runat="server" />
                                    <asp:Button ID="btnRegister" runat="server" Text="ثبت" ValidationGroup="NF"   CssClass="btn btn-lg btn-success btn-block"  OnClick="btnRegister_Click" />
			    	            </fieldset>
			                </div>
                        </div>
			       
        </div>
    </form>                  
</body>
</html>
