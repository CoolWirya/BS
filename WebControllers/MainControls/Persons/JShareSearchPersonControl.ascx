<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShareSearchPersonControl.ascx.cs" Inherits="WebControllers.MainControls.JShareSearchPersonControl" %>
<%--<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>--%>
<script src="WebControllers/FormManager/Js/jquery-1.8.2.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.min.js"></script>
<link href="Style/MainStyleSheet.css" rel="stylesheet" />
<style>
    .RadWindow_Simple .rwTopLeft,.RadWindow_Simple .rwTopRight,.RadWindow_Simple .rwTitlebar,.RadWindow_Simple .rwFooterLeft,.RadWindow_Simple .rwFooterRight,.RadWindow_Simple .rwFooterCenter,.RadWindow_Simple .rwTopResize,.RadWindow_Simple .rwStatusbar div,.RadWindow_Simple .rwStatusbar,.RadWindow_Simple .rwBodyLeft,.RadWindow_Simple .rwBodyRight,.RadWindow_Simple .rwStatusbarRow .rwCorner{background:#ececec}.RadWindow_Simple table.rwShadow .rwTopLeft,.RadWindow_Simple table.rwShadow .rwTopRight,.RadWindow_Simple.rwMinimizedWindow table.rwShadow .rwCorner.rwTopLeft,.RadWindow_Simple.rwMinimizedWindow table.rwShadow .rwCorner.rwTopRight,.RadWindow_Simple table.rwShadow .rwBodyLeft,.RadWindow_Simple table.rwShadow .rwBodyRight,.RadWindow_Simple table.rwShadow .rwFooterLeft,.RadWindow_Simple table.rwShadow .rwFooterRight{width:7px!important}.RadWindow_Simple .rwShadow td.rwFooterLeft,.RadWindow_Simple .rwShadow td.rwFooterRight,.RadWindow_Simple .rwShadow td.rwFooterCenter{height:7px}.RadWindow_Simple iframe{display:block}.RadWindow_Simple a.rwIcon{background:url('WebResource.axd?d=lr-2vYQC1gSzETjbpzJjdKQetXGTCOdF89kzpA1rNXumBDgE8evKtizQt7Umoblj_2KMxmmrzzS5MUlHfiWSNAI87ICBNKbfQRJQoxYVL4WoWuP457sPFX80VA8ciSCkMpybAWFZ_U2zq5RTzuxtb-DsHqb8DWmXYzu9nfYb3CY1&t=635005039420000000') no-repeat center}.RadWindow_Simple ul.rwControlButtons{margin:0}.RadWindow_Simple .rwControlButtons a{background-color:#c6c6c6;background-image:url('WebResource.axd?d=IyMDUgP6WnCDvSUHRuVCiTdj9ut1LrOq4ZBDZTJOPfbgJvYXICAR4HTHCNG65ntvHGUb5CahpTOYGQwJfFxulIxpQvXQ0BHr0LVegaf2_MSPYbi6JWZ4qzvcf5x24G_zTnpk_SGQeJ_ikaDrLiU9zn_o6N68zDKqoUjKEQF6SAlzQPkZgRNtK5HkIFnM92uE0&t=635005039420000000');width:29px;height:19px;border:1px solid #7e7e7e}.RadWindow_Simple .rwControlButtons a:hover{border-color:#c98400;background-color:#ffe79c}.RadWindow_Simple table.rwTitlebarControls em{color:black}.RadWindow_Simple input.rwDialogInput{border:1px solid #616161}.RadWindow_Simple input.rwDialogInput:hover{border:1px solid #c98400}.RadWindow_Simple table tr td.rwLoading{background-color:white}.RadWindow_Simple tr td.rwWindowContent.rwLoading{background-image:url('WebResource.axd?d=wMIi5RKYyTv2pDF7dMopiP9KY_t32ApDjO7JkT8qMNY1xWg18rt2MrEuspOuMYD0SwGzgDB8EeWRScStwS4VqRqevFoav5KiV-0U8n0pQyTq8PHXOa1C5YdAxUwcn8R57uOtyIxSswthwWU3LZY6G4pm1ABFy0bJTzwYq2Z6uPE1&t=635005039420000000')}.RadWindow_Simple input.rwLoading{background-image:url('WebResource.axd?d=aOnmoQUdU5UBewvNS0IS3puA9ZSsmBjYAI41kM0CvqcJByXoW9cl7UyaEI-xctf2N1Vbdzt94bCAqAXTyBi4EbTpdm-zKfSgIhxqkVu277ZOVjZyLIW2aSJ-vJd9IVYRld2clRMfWVswBlosvIQcrZqZdqf2SVMyEsPsQW3gPD_9Rof4wt924KtKDfEoitbP0&t=635005039420000000')}.RadWindow_Simple .rwDialogPopup a.rwPopupButton{background:#c6c6c6;border:1px solid #7e7e7e}.RadWindow_Simple .rwDialogPopup a.rwPopupButton:hover{background:#ffe79c;border-color:#c98400}.RadWindow_Simple .rwShadow .rwFooterLeft,.RadWindow_Simple .rwShadow .rwFooterRight,.RadWindow_Simple .rwShadow .rwFooterCenter{height:5px}.RadWindow_Simple.rwMinimizedWindowShadow .rwFooterRow{display:none}.RadWindow_Simple.rwMinimizedWindowShadow .rwTable{width:200px}.RadWindow_Simple .rwShadow a.rwIcon{margin:5px 5px 0 0}.RadWindow_Simple table.rwShadow em{padding:5px 0 0 1px}.RadWindow_Simple.rwMinimizedWindow .rwShadow .rwControlButtons{margin:2px 0 0 0}div.RadWindow_Simple a.rwCancel,div.RadWindow_Simple a.rwCancel span{background:none!important;cursor:pointer;border:0!important}div.RadWindow_Simple a.rwCancel span span,div.RadWindow_Simple a.rwCancel:hover span span{color:black;text-decoration:underline}
    .dv_PersonList {
    position: fixed;
    width:0%;
    height: 0px;
    right: 50%;
    top: 220px;
    z-index:101;
    /*
    padding: 0px 15px;
    -webkit-transition: all 0.4s;
    transition: all 0.4s;overflow:hidden;
    border-radius: 5px;
    box-shadow: 0px 3px 10px rgba(34, 25, 25, 0.4);*/
    background-color:rgba(255, 255, 255, 0.78);
    font-family: "Segoe UI",Arial,Helvetica,sans-serif;
    font-size: 12px;
    border: 1px solid #828282;
    }
    .a_close {
    float:left;
    margin: 10px 10px 10px -5px;
    color: rgba(170, 170, 170, 0.7);
    font-size: 1.4rem;
    line-height: 10px;
    font-weight: 600;
}
</style>
<style>
    .blue_values span {
        color:blue;
    }
    .blue_values td {
        font-size: 11.5px;
    }
    /*temprory*/
    .hidden {
        display:none;
    }
</style>
            <script type="text/javascript">
                var PersonCode = 0;
                $(document).ready(function(){
                    $('.a_close').bind('click',function(){ClosePersonList<%=Guid%>()});
                });
                function ShowMenu<%=Guid%>() {
                    var dv_properties = document.getElementById('dv_PersonList<%=Guid%>');
                        $(dv_properties).css('width');
                    $(dv_properties).css('height');
                    $(dv_properties).css('right');
                    $(dv_properties).css('top');
                    $(dv_properties).css({ 'width': '60%', 'height': '300px', 'right': '20%', 'top': '70px' });
                }

                function ClosePersonList<%=Guid%>()
                {
                    
                    var dv_properties = document.getElementById('dv_PersonList<%=Guid%>');
                    $(dv_properties).css({ 'width': '0%', 'height': '0px', 'right': '50%', 'top': '220px' });
                }

                function btnSearch_click<%=Guid%>()
                {
                    ShowWarining('در  حال بارگذاری ...', false, 3);
                    var SearchText = document.getElementById('txtSearchText<%=Guid%>').value;
                    $.ajax({
                        type: 'POST',
                        url: 'Services/WebBaseDefineService.asmx/GetPersons',
                        data: '{'
                                + '"SearchText":"' + SearchText + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            var tbl = document.getElementById("tblPersonList<%=Guid%>").getElementsByTagName('tbody')[0];
                            tbl.innerHTML = '';
                            var xmlDoc = $.parseXML(msg.d);
                            var xml = $(xmlDoc);
                            var dt = xml.find("datatable");
                            $.each(dt, function () {
                                var tr = document.createElement("tr");
                                var cell1 = tr.insertCell(0);
                                var cell2 = tr.insertCell(1);
                                cell1.innerHTML = $(this).find("Code").text();
                                cell2.innerHTML = $(this).find("Name").text();
                                tbl.appendChild(tr); 
                                $(tr).click(function(){
                                    PersonCode = cell1.innerHTML;
                                    $(this.parentNode.children).css('background-color','white');
                                    $(this).css('background-color','orange');
                                });
                            });
		                    HideWarining();
                        },
		                error: function (xhr, status, error) {
		                    var err = eval("(" + xhr.responseText + ")");
		                    ShowWarining(xhr.responseText, false, 1, true);
		                }
                    });
                }

                function btnSelect_click<%=Guid%>(){
                    if(PersonCode > 0){
                        ClosePersonList<%=Guid%>(); 
                        document.getElementById("txtPersonCode<%=Guid%>").value = PersonCode;
                    }
                }

                function txtSearchText_keypress<%=Guid%>(event)
                {
                    var keyCode = event.which || event.keyCode;
                    if(keyCode == 13)
                    {
                        event.preventDefault();
                        btnSearch_click<%=Guid%>();
                    }
                }
            </script>

<%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtPersonCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtPersonCode" />
                <telerik:AjaxUpdatedControl ControlID="lblName" />
                <telerik:AjaxUpdatedControl ControlID="lblLastName" />
                <telerik:AjaxUpdatedControl ControlID="lblBrthDate" />
                <telerik:AjaxUpdatedControl ControlID="lblIDNo" />
                <telerik:AjaxUpdatedControl ControlID="lblFatherName" />
                <telerik:AjaxUpdatedControl ControlID="lblNationalNo" />
            </UpdatedControls>
        </telerik:AjaxSetting>


    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
       // var ElementsID = '{!::!}<%=txtPersonCode.ClientID %>{!::!}<%=pnlRealPersonDetails.ClientID%>{!::!}<%=lblRealPersonName.ClientID %>{!::!}<%=lblLastName.ClientID %>{!::!}<%=lblBrthDate.ClientID %>{!::!}<%=lblIDNo.ClientID %>{!::!}<%=lblFatherName.ClientID %>{!::!}<%=lblNationalNo.ClientID %>'
       //             + '{!::!}<%=pnlLegalPersonDetails.ClientID%>{!::!}<%=lblLegalPersonName.ClientID %>{!::!}<%=lblRegNo.ClientID %>{!::!}<%=lblSubject.ClientID %>{!::!}<%=lblType.ClientID %>{!::!}<%=lblRegPlace.ClientID %>{!::!}<%=lblEcoNo.ClientID %>'
       //             + '{!::!}<%=pnlOtherPersonDetails.ClientID%>{!::!}<%=lblTitle.ClientID %>{!::!}<%=lblPhone.ClientID %>{!::!}<%=lblAddress.ClientID %>{!::!}<%=lblDesc.ClientID %>{!::!}<%=lblMobile.ClientID %>';
       // function CallShowMenu_<%=txtPersonCode.ClientID %>() {
       //     ShowMenu('<%=(new WebClassLibrary.JActionsInfo("PersonList", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.JPersonLists.GetPersonWindowForShare",null,null)).ActionToString() %>{!::!}<%=CompanyCode%>' + ElementsID);
        }
    </script>
</telerik:RadCodeBlock>--%>
<div id="dv_PersonList<%=Guid%>" class="RadWindow_Simple dv_PersonList"><%--id="dv_PersonSearch"--%>
    <table cellspacing="0" cellpadding="0" class="rwTable" style="height: 298px;">
        <tbody>
            <tr class="rwTitleRow">
                <td class="rwCorner rwTopRight" style="cursor: ne-resize;">&nbsp;</td>
                <td class="rwTitlebar" style="cursor: move;">
                    <div class="rwTopResize" style="cursor: n-resize;"><!-- / --></div>
                    <table align="left" cellspacing="0" cellpadding="0" class="rwTitlebarControls">
                        <tbody>
                            <tr>
                                <td style="width: 16px;">
                                    <a class="rwIcon" tabindex="0"></a></td>
                                <td><em unselectable="on" style="width: 190px;">جستجوی اشخاص حقیقی و حقوقی</em></td>
<%--                                <td nowrap="" style="white-space: nowrap;">
                                    <ul class="rwControlButtons" style="width: 160px;"><li><a href="javascript:void(0);" class="rwPinButton" title="Pin on" tabindex="0"><span>Pin on</span></a></li><li><a href="javascript:void(0);" class="rwReloadButton" title="Reload" tabindex="0"><span>Reload</span></a></li><li><a href="javascript:void(0);" class="rwMinimizeButton" title="Minimize" tabindex="0"><span>Minimize</span></a></li><li><a href="javascript:void(0);" class="rwMaximizeButton" title="Maximize" tabindex="0"><span>Maximize</span></a></li><li><a href="javascript:void(0);" class="rwCloseButton" title="Close" tabindex="0"><span>Close</span></a></li></ul></td>--%>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td class="rwCorner rwTopLeft" style="cursor: nw-resize;">&nbsp;</td>
            </tr>
            <tr class="rwContentRow">
                <td class="rwCorner rwBodyRight" style="cursor: e-resize;">&nbsp;</td>
                <td class="rwWindowContent rwExternalContent" valign="top">
                    <%--<iframe name="جستجوی اشخاص حقیقی و حقوقی" src="/Controls.aspx?SUID=PersonSearch" frameborder="0" style="width: 100%; height: 100%; border: 0px;" tabindex="0"></iframe>--%>
                    <%--<div style="position: absolute; z-index: 1; top: 31px; left: 8px; opacity: 0; width: 382px; height: 259px; display: none; background-color: white;"></div>--%>
                    <%--<a class="a_close" href="#">x</a>--%>
                    <div style="margin-top:15px; margin-right:10px"> 
                    <input type="text" id="txtSearchText<%=Guid%>" onkeypress="txtSearchText_keypress<%=Guid%>(event)"/>
                    <input id="btnSearch<%=Guid%>" type="button" value="جستجو" onclick="btnSearch_click<%=Guid%>()" />
                    </div>
                    <div style="height:200px;overflow-y:scroll">   
                        <table id="tblPersonList<%=Guid%>" style="border-spacing: 0px;">
                            <thead>
                                <tr>
                                    <th>
                                        کد پرسنلی
                                    </th>
                                    <th>
                                        نام شخص
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <div> 
                        <input type="button" id="btnSelect<%=Guid%>" value="انتخاب" onclick='btnSelect_click<%=Guid%>()'/>
                    </div>
                </td>
                <td class="rwCorner rwBodyLeft" style="cursor: w-resize;">&nbsp;</td></tr>
            <tr class="rwStatusbarRow" style="display: none;">
                <td class="rwCorner rwBodyRight" style="cursor: e-resize;">&nbsp;</td>
                <td class="rwStatusbar">
                </td>
                <td class="rwCorner rwBodyLeft" style="cursor: w-resize;">&nbsp;</td>
            </tr>
            <tr class="rwFooterRow">
                <td class="rwCorner rwFooterRight" style="cursor: se-resize;">&nbsp;</td>
                <td class="rwFooterCenter" style="cursor: s-resize;">&nbsp;</td><td class="rwCorner rwFooterLeft" style="cursor: sw-resize;">&nbsp;</td>
            </tr>
        </tbody>
    </table>
</div>
<table>
    <tr>
        <td style="width: 70px">کد شخص:</td>
        <td style="width: 70px">
            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" AutoPostBack="true" ID="txtPersonCode" OnTextChanged="txtPersonCode_TextChanged" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" AutoPostBack="false" ID="txtPersonCode" CssClass="personCode" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <%--<JJson:JJsonNumericTextBox ID="txtPersonCode" CssClass ="personCode" Width="70px" runat="server" Event="textchange"></JJson:JJsonNumericTextBox>--%>
            <input id="txtPersonCode<%=Guid%>" type="text" class="personCode" style="width:70px">
        </td>
        <td style="width: 50px">

            <input type="button" onclick='ShowMenu<%=Guid%>()' />
           <%-- <telerik:RadButton runat="server" ID="btnSearch" Text="..." TabIndex="-1" AutoPostBack="false"></telerik:RadButton>--%>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlRealPersonDetails" runat="server" GroupingText="مشخصات شخص حقیقی" CssClass="blue_values">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 25%">نام:</td>
            <td style="width: 25%">
                <asp:Label ID="lblRealPersonName" runat="server" /></td>
            <td style="width: 25%">نام خانوادگی:</td>
            <td style="width: 25%">
                <asp:Label ID="lblLastName" runat="server" /></td>
        </tr>
        <tr class="Table_RowC">
            <td>تاریخ تولد:</td>
            <td>
                <asp:Label ID="lblBrthDate" runat="server" /></td>
            <td>شماره شناسنامه:</td>
            <td>
                <asp:Label ID="lblIDNo" runat="server" /></td>
        </tr>
        <tr class="Table_RowB">
            <td>نام پدر:</td>
            <td>
                <asp:Label ID="lblFatherName" runat="server" /></td>
            <td>شماره ملی:</td>
            <td>
                <asp:Label ID="lblNationalNo" runat="server" /></td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlLegalPersonDetails" runat="server" GroupingText="مشخصات شخص حقوقی" CssClass="blue_values hidden">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 25%">نام موسسه:</td>
            <td style="width: 25%">
                <asp:Label ID="lblLegalPersonName" runat="server" /></td>
            <td style="width: 25%">شماره ثبت:</td>
            <td style="width: 25%">
                <asp:Label ID="lblRegNo" runat="server" /></td>
        </tr>
        <tr class="Table_RowC">
            <td>موضوع:</td>
            <td>
                <asp:Label ID="lblSubject" runat="server" /></td>
            <td>نوع موسسه:</td>
            <td>
                <asp:Label ID="lblType" runat="server" /></td>
        </tr>
        <tr class="Table_RowB">
            <td>محل ثبت:</td>
            <td>
                <asp:Label ID="lblRegPlace" runat="server" /></td>
            <td>کد اقتصادی:</td>
            <td>
                <asp:Label ID="lblEcoNo" runat="server" /></td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlOtherPersonDetails" runat="server" GroupingText="مشخصات اشخاص متفرقه" CssClass="blue_values hidden">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 25%">عنوان:</td>
            <td style="width: 25%">
                <asp:Label ID="lblTitle" runat="server" /></td>
            <td style="width: 25%">تلفن:</td>
            <td style="width: 25%">
                <asp:Label ID="lblPhone" runat="server" /></td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr class="Table_RowC">
            <td style="width: 25%">آدرس:</td>
            <td style="width: 75%">
                <asp:Label ID="lblAddress" runat="server" /></td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 25%">توضیحات:</td>
            <td style="width: 75%">
                <asp:Label ID="lblDesc" runat="server" />
                <asp:Label ID="lblMobile" runat="server" style="margin-right:10px" /></td>
        </tr>
    </table>
</asp:Panel>
