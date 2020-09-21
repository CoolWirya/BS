<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AreaUpdate.ascx.cs" Inherits="WebAVL.Forms.AreaUpdate" %>

    
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="Map" TagName="OpenLayersMap" %>

<style>
    
@font-face {
    font-family: 'BMitra';
    src: url('../WebAVL/Fonts/BMitra.eot');
    src: url('../WebAVL/Fonts/BMitra.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BMitra.woff') format('woff'),
         url('../WebAVL/Fonts/BMitra.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'BMitraBold';
    src: url('../WebAVL/Fonts/BMitraBold.eot');
    src: url('../WebAVL/Fonts/BMitraBold.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BMitraBold.woff') format('woff'),
         url('../WebAVL/Fonts/BMitraBold.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}

@font-face {
    font-family: 'B Roya';
    src: url('../WebAVL/Fonts/BRoya.eot');
    src: url('../WebAVL/Fonts/BRoya.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BRoya.woff') format('woff'),
         url('../WebAVL/Fonts/BRoya.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'BTabassom';
    src: url('../WebAVL/Fonts/BTabassom.eot');
    src: url('../WebAVL/Fonts/BTabassom.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTabassom.woff') format('woff'),
         url('../WebAVL/Fonts/BTabassom.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}


@font-face {
    font-family: 'BTitr';
    src: url('../WebAVL/Fonts/BTitr.eot');
    src: url('../WebAVL/Fonts/BTitr.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTitr.woff') format('woff'),
         url('../WebAVL/Fonts/BTitr.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}

@font-face {
    font-family: 'BTitrTGE';
    src: url('../WebAVL/Fonts/BTitrTGE.eot');
    src: url('../WebAVL/Fonts/BTitrTGE.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTitrTGE.woff') format('woff'), 
         url('../WebAVL/Fonts/BTitrTGE.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}


@font-face {
    font-family: 'BYekan';
    src: url('../WebAVL/Fonts/BYekan.eot');
    src: url('../WebAVL/Fonts/BYekan.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BYekan.woff') format('woff'),
         url('../WebAVL/Fonts/BYekan.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}


@font-face {
    font-family: 'BTraffic';
    src: url('../WebAVL/Fonts/BTraffic.eot');
    src: url('../WebAVL/Fonts/BTraffic.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BTraffic.woff') format('woff'),
         url('../WebAVL/Fonts/BTraffic.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
}


 @font-face {
    font-family: 'BNasim';
    src: url('../WebAVL/Fonts/BNasim.eot');
    src: url('../WebAVL/Fonts/BNasim.eot?#iefix') format('embedded-opentype'),
         url('../WebAVL/Fonts/BNasim.woff') format('woff'),
         url('../WebAVL/Fonts/BNasim.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
}
    ul{
        list-style:none;
        direction: ltr;
    }
    li {
        padding: 10px;
        margin-top: 1px;
        border-bottom: thin solid white;
    }
    span{
        font-family: "B Roya";
    }
    input[type=submit]{
        width: 100%;
        height: 100%;
        background-color: #F00;
        padding: 6px;
        border: medium none;
        text-align: center;
        background-position: 100%;
        background-repeat: no-repeat;
        font-family: "B Roya";
    }
    label {
        font-family: "B Roya";
    }
    input[type=text]{
        font-family: "B Roya";
        border: solid thin white;
    }
    .dropdown {
        border: solid thin white;
        width: 100%;
        height: 30px;
        font-family: "B Roya";
    }
    .dropdown option {
        font-family: "B Roya";
    }
    .textbox {
        font-family: "B Roya";
        border: solid thin white;
        width: 100px;
        border:solid thin white;
    }
    input[type=text]:active{
        border:solid thin yellow ;
    }  
    .HeightSpace0 {
        clear: both;
        height: 0px;
    }
    .checkboxesObjects{
        display:block;
        
        overflow:scroll;
    }
    .HeightSpace05 {
        clear: both;
        height: 05px;
    }

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }

    .HeightSpace15 {
        clear: both;
        height: 15px;
    }

    .HeightSpace20 {
        clear: both;
        height: 20px;
    }

    .HeightSpace30 {
        clear: both;
        height: 30px;
    }

    .trasparentBackground {
        background: rgba(8, 19, 137, 0.70);
    }
</style>
<!--<div runat="server" id="divMap"></div>-->

<div class="BigTitle">انتخاب محدوده</div>
<div style="width: 100%; height: 80%">
<Map:openlayersmap runat="server" id="OpenLayersMap"  />
</div>
<div id="OpenControlPanel" style="width: 40px; height: 100px; position: absolute; top: 40px; right: 0px; cursor: pointer; z-index: 998; display: none"
    onclick="FuncOpenControlPanel();">
    <img src="<%= ResolveClientUrl("~/WebAVL/Image/OpenControlPanel.png") %>"
        style="width: 40px; height: 100px" alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>
<div id="Mnu_ControlPanel" class="trasparentBackground" style="width: 20%; height: 100%; position: absolute; top: 0px; right: 0px; z-index: 999; color: white; display: block">
    <div class="HeightSpace20"></div>

    <div style="position: absolute; top: 40px; left: 0px; cursor: pointer" onclick="FuncCloseControlPanel();">
        <img src="<%= ResolveClientUrl("~/WebAVL/Image/CloseControlPanel.png") %>"
            style="width: 40px; height: 100px" alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>
    <div class="HeightSpace10"></div>

    <%--Path Div--%>
    <div id="PathShowMenuBot" style="width: 100%; height: 100%; overflow: scroll">
        <div class="HeightSpace10"></div>
        <div style="width: 96%; height: auto; text-align: right; opacity: 1; padding-right: 5px; direction: rtl">
           نام
             <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
             <asp:CheckBoxList ID="chbListOfData" runat="server" Height="200px"  Width="100%" CssClass="checkboxesObjects"></asp:CheckBoxList>
       <span>    محدوده تعیین شده از کدام نوع است :</span>
            <br />
                <asp:RadioButtonList ID="rdbGeoKind" runat="server"  Height="10%" Width="80%" >
                    <asp:ListItem Text="خط" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="منطقه" Value="1" Selected="False"></asp:ListItem>
                 </asp:RadioButtonList>
            <br />
          
        </div>
    </div>

    <input type="hidden" runat="server" id="LineMapActionString" />
    <script type="text/javascript">
        function FuncOpenControlPanel() {
            $("#Mnu_ControlPanel").fadeIn();
            $("#OpenControlPanel").fadeOut();
        }

        function FuncCloseControlPanel() {
            $("#Mnu_ControlPanel").fadeOut();
            $("#OpenControlPanel").fadeIn();
        }


    </script>

<div style="clear: both; height: 10px"></div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف مارکرها" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft"  />
    <telerik:RadButton runat="server" ID="btnDeleteArea" Text="حذف خط یا منطقه" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDeleteArea_Click" CssClass="floatLeft" />
</div>

<input type="hidden" runat="server" id="PathMapStationAc" />
<input type="hidden" runat="server" id="LineCode" />
<script type="text/javascript">
    GetStation();
    function GetStation() {
        var paramStr = new Array();
        paramStr[0] = $("#<%=LineCode.ClientID%>").val();
        var data = "{actionString:'" + $("#<%=PathMapStationAc.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        ResultAjaxRequet = $.ajax({
            url: "../WebControllers/WebService/Action.asmx/RunActilon",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            },
            success: function (data) {
                SetMarkerAndloadIt(data.d);
            }
        });
    }
</script>
    </div>