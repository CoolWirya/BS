<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JWorkFlow.ascx.cs" Inherits="WebAutomation.WebCommunication.JWorkFlow" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<div class="FormContent" dir="rtl">
    <script> 
        function txtMaximumNumber_change(value)
        {
            var d = new Date();
            d.setTime(d.getTime() + 24 * 60 * 60 * 100);
            document.cookie = "MaximumNumber=" + value + ";" + "expires=" + d.toUTCString();
        }
        //var ClassName = '';
        //var DynamicClassCode = -1;
        //function ShowFlowChart()
        //{
        //    window.location.href = "WebAutomation/tessst4.aspx?ClassName=" + ClassName + "&DynamicClassCode=" + DynamicClassCode;
        //}
        //function LoadClasses()
        //{

        //    $.ajax({
        //        type: 'POST',
        //        url: 'Services/WebAutomationService.asmx/GetClasses',
        //        data: '',
		//	    contentType: "application/json; charset=utf-8",
		//	    dataType: "json",
		//	    success: function (msg) {
		//	        var tbClasses = document.getElementById('tblClasses').getElementsByTagName('tbody')[0];
		//	        var xmlDoc = $.parseXML(msg.d);
		//	        var xml = $(xmlDoc);
		//	        var dt = xml.find("datatable");
		//	        var i = 0;
		//	        $.each(dt, function () {
		//	            var row = tbClasses.insertRow(i);
		//	            var cell1 = row.insertCell(0);
		//	            var cell2 = row.insertCell(1);
		//	            cell1.innerHTML = $(this).find("ClassName").text();
		//	            cell2.innerHTML = $(this).find("DynamicClassCode").text();
		//	            i++;
		//	        });
		//	        tblClasses_click();
		//		},
		//	    error: function (xhr, status, error) {
		//	        var err = eval("(" + xhr.responseText + ")");
		//	        alert(err.Message);
		//	    }
		//	});
        //}

        //function tblClasses_click()
        //{
        //    var trClasses = document.getElementById('tblClasses').getElementsByTagName('tr');
        //    $(trClasses).click(function () {
        //        var row = this;
        //        ClassName = row.cells[0].innerHTML;
        //        DynamicClassCode = parseInt(row.cells[1].innerHTML);
        //        $(trClasses).css('background-color', 'white');
        //        $(this).css('background-color', '#5c96bc');
        //    });
        //}

        //$(document).ready(function () {
        //    LoadClasses();

        //});
    </script>
<%--    <table id="tblClasses">
        <thead>
        <tr>
            <th>کلاس</th>
            <th>کد پویا</th>
        </tr>
        </thead>
        <tbody>
        </tbody>
    </table>--%>
    <span>حداکثر تعداد گره ها:</span>
    <input id="txtMaximumNumber" type="text" name="name" value="30" onchange="txtMaximumNumber_change(this.value)"/>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td style="width: 100%; height: auto; overflow: auto">
                <uc1:JGridViewControl runat="server" id="RadGridReport" />
            </td>
        </tr>
    </table>
<%--    <input id="Button1" type="button" value="button" onclick="ShowFlowChart()" />--%>
</div>
