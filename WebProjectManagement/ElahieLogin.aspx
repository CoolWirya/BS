<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElahieLogin.aspx.cs" Inherits="WebProjectManagement.Test" %>

<html>
<head>
<title>پنل مدیریت پروژه شرکت آبادانی و مسکن الهیه خراسان </title>
<link rel="stylesheet" href="style.css" type="text/css" media="screen" />
<script type="text/javascript" src="script.js"></script>
    <style>
        @font-face {
    font-family: "yekan";
    src: url(fonts/Yekan.eot);
    src: url(fonts/Yekan.eot?#iefix) format("embedded-opentype"), url(fonts/Yekan.woff) format("woff"), url(fonts/Yekan.ttf) format("truetype"), url(fonts/Yekan.svg#BYekan) format("svg");

}


body {
    /*background: url(Images/back.jpg); */
    background-size:     cover;                      /* <------ */
    background-repeat:   no-repeat;
	font-family: yekan;
	margin:0;
	
}
input, button, select, textarea, optgroup, option {
    font-family: inherit;
    font-size: inherit;
    font-style: inherit;
    font-weight: inherit;
	padding:3px;
}
textarea
{
background:white;
}
a{
 text-decoration: none;
 color: rgb(255, 0, 0);
 font-weight: bold;
}
.login-form {
	background:#fff;
	width: 26%;
	margin:9% auto 4% auto;
 	position: relative;
	background-color: rgba(0, 0, 0, 0.4);
 	-webkit-border-radius: 0.4em;
	-o-border-radius: 0.4em;
	-moz-border-radius: 0.4em;
}

.head {
	position: absolute;
	top:-15%;
	left: 35%;
}
h1{color:seagreen;}
.head img {
	border-radius:50%;
	-webkit-border-radius:50%;
	-o-border-radius:50%;
	-moz-border-radius:50%;
	border:6px solid rgba(221, 218, 215, 0.23);
}
h2,h3
{
color:#4285F4;
}
.main{
	position:relative;
}
.main h1{
	font-size:25px;
	color:#ffffff;
	font-weight:400;
	padding-top: 19%;
	text-align: center;
}
.main form {
	width: 80%;
	margin: 0 auto;
	padding: 6% 0 9% 0;
}
.main p {
text-align: center;

}
.main form p a {
	color: white;
}
form p a:hover {
	color:#21A957;
}
 input[type="text"], input[type="password"]{
	text-align:right;
	position: relative;
	width:92%;
	padding:2%;
	margin-bottom: 6%;
	color: #000000;
	background:#f3f3f3;
	font-size: 16px;
	border: none;
	-webkit-appearance:none;
}

input[type="submit"]{
	width: 92%;
	padding: 3%;
	margin-bottom: 8%;
	background: #21A957;
	color: #ECECEC;
	box-shadow: inset 0px 0px 10px #666464;
	-webkit-text-shadow: 0px 0px 3px #000;
	-moz-text-shadow: 0px 0px 3px #000;
	-o-text-shadow: 0px 0px 3px #000;
	-ms-text-shadow: 0px 0px 3px #000;
	font-size: 20px;
	outline: none;
	border: none;
	cursor: pointer;
	font-weight:500;
	border-radius: 5px;
	transition: 0.5s;
	-webkit-appearance:none;
	-webkit-transition: 0.5s;
	-moz-transition: 0.5s;
	-o-transition: 0.5s;
	-ms-transition: 0.5s;
}
input[type="submit"]:hover{
	background:#128A42;
	color:#fff;
}

/*---------------------------------*/
.iconmenu
{
width:60px;
height:60px;
padding-top:8px;
}

#container{
padding:35px;
width:810px;
margin-left: auto;
margin-right: auto;
margin-top:50px;
overflow:hidden;
text-align: right;

}
a
{
text-decoration:none;
}
.box{
    float: right;
    text-align: center;
    width: 190px;
    height: 190px;
    margin-bottom: 10px;
	margin-left:10px;
	color:white;
}
.box a{
color:inherit;
text-decoration:none;
font-size:20px;
}
.box p
{
font-size:20px;
}
.fa{
font-size:40px;
float:left;
}
#toptext
{
float:right;
padding-top: 20px;
color: white;
margin-right: 10px;
}
.mp1,.mp8{
background-color:#4285f4;
}
.mp2,.mp7{
background-color:#fbbc05;
}
.mp3,.mp6{
background-color:#34a853;
}
.mp4,.mp5{
background-color:#ea4335;
}
.mp1:hover,.mp2:hover,.mp3:hover,.mp4:hover,.mp5:hover,.mp6:hover,.mp7:hover,.mp8:hover
{
background-color:#ffffff;
color:red;
}
.centerwrapper
 {
       margin: 0;
       width: 800px;
}
.space
{
padding:5px 20px;
}

.icontop
{
width:35px;
height:35px;
float:right;
}
.iconmenutop
{
width:35px;
height:35px;
position:absolute;
}

.topmenu{
    background:#849aad;
    height: 60px;
}
.diviconmenutop
{
float:right;
padding: 12px;
width: 36px;
height: 36px
}
.diviconmenutop:hover
{
background:tomato;
}
#logo
{
float:left;
padding-top:10px;
padding-left:10px;
}

.submenu
{
background:red;
color:#ffffff;
padding:10px;
float:right;
width: 230px;
text-align: center;
height: 45px;
margin-left: 2px;
font-size:20px;
}
.mohtava2,.mohtava3,.mohtava6,.mohtava7,.mohtava9,.mohtava11  
{
display:none;
}
.content
{
    background: white;
    width: 694px;
    float: right;
    direction: rtl;
    padding: 30px;
	height:450px;
}
.sm1
{
	background-color: seagreen;
}
.sm2
{

}
.sm3
{

}
.sm4,.sm18
{
width: 734px;
background:seagreen;
}
.sm10,.sm11,.sm8,.sm9
{
width:356px;
}
.sm8,.sm9
{
width:428px;
}
.sm5,.sm16,.sm8,.sm10,.sm12
{
background-color: seagreen;
}
.sm14,.sm15,.sm16,.sm17
{
width:167px;
}
.sm12,.sm13
{
width:356px;
}
.mohtava4
{
height:180px;
}
.control-label, .control-box {
padding: 7px 5px;
text-align: right;
border-top: 1px solid #eee;
color: #0787F5;
text-align: justify;
vertical-align:middle;
border: 1px solid #ddd;
}
.control-label2
{
color: #0787F5;
text-align: justify;
font-weight:bold;
}
.control-label3
{
padding: 7px 5px;
text-align: center;
}
.control-select
{
width: 200px;
margin-bottom:10px;
}
.tbcontent
{
margin:auto;
margin-top:20px;
background: #eee;
padding:10px 50px;
border-collapse: collapse;
}
.trmsga
{
background:#f2f2f2;
border: 1px solid #ddd;
}
.trmsgb
{
background:#fff;
border: 1px solid #ddd;
}
.trmsgsb
{
height:40px;
color:white;
background:#4CAF50;
border:1px solid #4CAF50;
}
.tbcontent tr
{
padding:10px;
}
.tdinput
{
padding:5px 30px;
}
.control-input
{
width:170px!important;
margin:0px!important;
}
.control-input2
{
background:white!important;
border:solid 1px #ddd!important;
}
.apartment-list,.msg,.buyshares,.saleshares
{
margin-bottom: 20px;
border: 1px solid #DDDEF1;
direction: rtl;
border-collapse: collapse;
border-spacing: 0;
width:100%;
}
.spnaplist
{
color: #009688;
padding-left: 20px;
padding-right: 3px;
}
.apartmentlist
{
text-align: center;
background-color: #34A853;
padding: 50px 10px 50px 1px;
width: 130px;
color: #ffffff;
font-size: 20px;
}
.trapcolor
{
background:#f2f2f2;
}
.appartmentspam
{
font-size:13px;
margin-left: 15px;
}
.apartmentlist:hover {
    background-color: #4285F4;
}
.subject-label
{
padding: 10px 5px;
color: #0787F5;
font-size: 14px;
font-weight: bold;
}
.msgtableopen
{
background:#949494;
margin:3px 0;
}
.msgtableclose
{
background:#666464;
margin:3px 0;
}

.showonemsg
{
background:#eee;
padding:10px;
width:97%;
}
.subjecttext
{
font-size:20px;
padding:10px;
vertical-align:middle;
color:blue;
/*border: 1px solid #ddd; */
}

.rtnimg
{
margin: 20px 0;
}
.msgtableclose td,.msgtableopen td,.msgsubject a
{
padding-right:5px;
color:#ffffff;
}
.msgsubject
{
width:450px;
}
.mohtava14,.mohtava15,.mohtava17
{
display:none;
}
.savabegh
{
border-collapse: collapse;
border-spacing: 0;
width:100%;
}
.savabegh td
{
padding:5px;
text-align:center;
border-left: solid 1px white;
}
.savabeghtr
{
 background: #f2f2f2;
}
.savabegh th
{
color: #ffffff;
padding: 10px;
background: #4CAF50;
border-left: solid 1px;
}
.subjectmsg
{
width: 50%;
}
.apartmenttbl
{
 border-spacing: 21px;
 margin:auto;
}
.subtext
{
margin:auto 5px;
}
.notif
{
    background-color: #ea4335;
    border-radius: 2px;
    color: #fff;
    padding: 1px 3px;
    background-clip: padding-box;
    display: inline-block;
    font-family: 'helvetica neue', helvetica, arial, sans-serif;
    font-size: 10px;
    -webkit-font-smoothing: subpixel-antialiased;
    line-height: 1.3;
    min-height: 13px;
    position: absolute;
}
#previewing {
height: 200px;
width: 200px;
}
#image_preview {
    text-align: center;
    background-color: #FFFFFF;
    padding: 10px 10px;
    border-radius: 10px;
}
#selectImage {
    padding: 19px 21px 14px 15px;
    width: 414px;
    background-color: #FEFFED;
    margin: auto;
}
#fileToUpload {
    color: red;
    padding: 5px;
    border-radius: 5px;
}
.controls
{
font-size:22px;
}
#submitpic,.submitpic
{
width:100%;
}
.errormsg
{
color:red;
}
.pictureloading
{
display:none;
position:fixed;
top:50%;
left:50%;
width:50px;
height:50px;
z-index:100;
}
.chart
{
width: 898px;
padding: 0;
}
#chartcontainer
{
padding: 35px;
width: 900px;
margin-left: auto;
margin-right: auto;
margin-top: 50px;
overflow: hidden;
text-align: right;
}
.bar
{
float:left;
width:30px;
height:300px;
background:red;
margin:0 15px;
}
.displayhidden 
{
display:none;
height
}
table td
{
vertical-align: bottom;
}
.vertical
{
font-size: 15px;
font-family: yekan;
text-align: center;
background: #03A9F4;
color: white;
}
.tablechart
{
margin: 0 auto;
padding-top: 100px;
}
.price
{
background: seagreen;
margin-bottom: 10px;
padding: 1px;
color: white;
text-align:center;
}
#price0,#price1,#price2,#price3,#price4,#price5,#price6,#price7,#price8,#price9,#pricesood0,#pricesood1,#pricesood2,#pricesood3,#pricesood4,#pricesood5,#pricesood6,#pricesood7,#pricesood8,#pricesood9
{
display:none;
}
.back{
position: absolute;
top: 686px;
float:left;
font-size: 20px;
padding: 2px 5px;
background: #21a957;
color: white;
margin-left: 2px;
}
.backprice
{
top: 626px;
}
.backfinancial
{
top: 416px;
}
.topp
{
width:100%;
min-width:1000px;
}

--------------------------------- ------------------------------------------------------- */
/*-----start-responsive-design------*/
@media (max-width:1440px){
	.login-form {
	width:30%;
	margin: 11% auto 4% auto;
	}
	.main h1 {
	padding-top: 23%;
	}
	.copy-right {
	bottom: -26%;
	}
}
@media (max-width:1366px){
	.login-form {
	width: 32%;
	margin: 10% auto 4% auto;
	}
}
@media (max-width:1280px){
	.login-form  {
		margin:8% auto 0;
		width:34%;
	}
	.copy-right {
	left: 41%;
	bottom:-18%;
	}
}
@media (max-width:1024px){
.login-form  {
		margin:12% auto 0;
		width:45%;
	}
	.copy-right {
	left: 41%;
	bottom:-18%;
	}
}
@media (max-width:768px){
	.login-form  {
		margin: 16% auto 0;
		width: 59%;
	}
	.copy-right {
	left:38%;
	bottom:-14%;
	}
}
@media (max-width:640px){                                  
	.login-form {
	margin: 20% auto 0;
	width: 63%;
	}
	.copy-right {
	left:36%;
	bottom:-18%;
	}
}
@media (max-width:480px){                                  
	.login-form {
	margin: 32% auto 0;
	width: 74%;
	}
	.copy-right {
	left:30%;
	bottom:-17%;
	}
	.main h1 {
	font-size: 22px;
	}
	.head img {
	width: 78%;
	}
	.head {
	top: -15%;
	left: 34%;
	}
	input[type="text"], input[type="password"], input[type="submit"] {
	font-weight: 600;
	margin-bottom: 4%;
	}
@media (max-width:320px){                                  
	.login-form  {
		margin:20% auto 0;
		width: 85%;
	
	}
	.main h1 {
	padding-top: 20%;
	font-size: 20px;
	}
	.head img {
	width: 60%;
	border: 5px solid rgba(221, 218, 215, 0.23);
	}
	.head {
	top: -15%;
	left: 36%;
	}
	input[type="text"], input[type="password"],input[type="submit"] {
	font-weight:600;
	font-size: 15px;
	}
	.main form p a {
	font-size: 15px;
	}
	input[type="submit"] {
	padding: 4%;
	}
		
}
/*------------------------------ home page ----------------------------------*/


    </style>
</head>
<body background="http://www.panel.elahieh.com/images/back.jpg"> 

<div class="main">
<div class="login-form">
			<h1></h1>
					<div class="head">
						<img src="http://www.panel.elahieh.com/Images/user.png" alt="">
					</div>
				<form  runat="server">
                        <asp:TextBox runat="server" ID="txtUsername" Text="نام کاربری" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'نام کاربری';}" />
						<asp:TextBox runat="server" id="txtPassword" TextMode="password" text="گذر واژه" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'گذر واژه';}" />
						<%--<input type="text" class="text" id="userid" name="userid" value="نام کاربری" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'نام کاربری';}">
						<input type="password" id="pass" name="pass" value="گذر واژه" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'گذر واژه';}">
						--%>
                    <div class="submit">
                        <asp:Button runat="server" ID="btnLogin" Text="ورود" OnClick="btnLogin_Click" />
							<%--<input type="submit"  value="ورود" >--%>
					</div>
				</form>
 </div>
</div>

</body>
</html>