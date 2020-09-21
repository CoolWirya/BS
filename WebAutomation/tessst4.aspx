<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tessst4.aspx.cs" Inherits="WebAutomation.tessst4" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
<%--        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
		<meta name="viewport" content="width=device-width">--%>
        <title></title>
		

<link href="temp2/font-awesome.css" rel="stylesheet">
<link rel="stylesheet" href="temp2/jsplumb.css">
        
<link rel="stylesheet" href="temp2/demo.css">
    </head>
    
    <body data-demo-id="statemachine" dir="rtl">
        <form runat="server">

        <div id="dv_properties" class="hidden" style="background-color:rgba(128, 128, 128, 0.5); position: fixed; width:0%; height: 0px;margin-right: 20%; 
            margin-top: 100px; z-index:101;-webkit-transition: all 0.5s;  transition: all 0.5s;overflow-y:hidden;border-radius: 5px;
            box-shadow: 5px 5px 7px rgba(0, 0, 0, 0.2);  padding: 0px 15px;">
            <div style="height: 30px;"> 
            <a href='#' class='close-reveal-modal' style="float:left;margin: 10px" onclick="ResetAndHideProperties()">×</a>    
            </div>
            <div id="dv_basic_properties" style="float:right; width:50%">
                <table style="width: 97%;margin-left: 3%;">
                    <tr>
                        <td style="width:25%">
                            <label>نام</label>

                        </td>
                        <td>  
                            <input id="txtName" type="text" value="جدید" style="width: 100%"/>  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>نوع</label>

                        </td>
                        <td>  
                            <select id="cmbTypes" onchange="ShowPropertiesControls(parseInt(this.value))" style="width: 100%;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>فیلدها</label>

                        </td>
                        <td>  
                            <select id="cmbConditions" style="width: 100%;">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <label>شرایط</label>

                        </td>
                        <td>  
                            <textarea id="txtConditions" style="width: 100%" dir="ltr"></textarea>
                            <input id="Button1" type="button" value="?"  style="border-radius: 6px;"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <input id="btnSaveProperties" type="button" value="تایید" style="float:left; margin: 20px;" onclick="btnSaveProperties_click()"/>
                        </td>
                    </tr>    
                </table>
            </div>
            <div id="dv_posts" class="hidden" style="float:right; width:50%">
                <table style="width: 97%;margin-right: 3%;">
                    <tr>
                        <td style="width:25%;vertical-align: top;">
                            <label>انتخاب پست</label>
                        </td>
                        <td>
                            <select id="cmbPosts" style="width: 100%;">
                            </select>
                            <textarea id="txtPostsSQL" style="width: 100%"></textarea>    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>پست ها</label>
                        </td>
                        <td>
                            <input id="txtPostCodes" type="text" dir="ltr" value=""  style="width: 100%"/>    
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <input id="btnAddPostCode" type="button" value="افزودن" style="float:left;  margin: 20px;" onclick="btnAddPostCode_click()"/>    
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="width:70px;padding-right: 8px;">   
        <div class="w" id="temp">جدید
            <div class="ep"></div>
        </div>
        </div>

        <div id="main">
    <div class="demo statemachine-demo" id="statemachine-demo">
    </div>
        <input id="btnSave" type="button" value="Save" onclick="btnSave_click()" />	
        </div>
		
		<script src="temp2/jquery-1.9.0-min.js"></script>
        <script src="temp2/jquery-ui-1.9.2.min.js"></script>
        <script src="temp2/jquery.ui.touch-punch-0.2.2.min.js"></script>
        <script src="temp2/jquery.jsPlumb-1.7.5-min.js"></script>
		<script src="temp2/demo.js"></script>
		<script src="temp2/demo-list.js"></script>
		
		<script type="text/javascript">
		    var temp;
		    var instance;
		    var NewNode = {
		        MouseEvents: { IsDown: false },
		        Number: 1
		    };
		    var Nodes = {
		        SelectedNumber: 0,
		        HighLightedNumber: 0,
		        NumbersOfVisibles: [],
		        ClassName: '',
		        DynamicClassCode: -1,
		        MaximumNumber: 20,
		        SetNumber: function () {
		            var that = this;
		            if (that.NumbersOfVisibles.length > 0)
		                for (var i = 0; i < that.MaximumNumber; i++) {
		                    if (that.NumbersOfVisibles.indexOf(i + 1) == -1) {
		                        NewNode.Number = i + 1;
		                        break;
		                    }
		                }
		        }
		    }

		    function SetForm()
		    {
		        $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/LoadFlowChart',
		            data: '{"ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            success: function (data) {
		                ////  ---------------------- Fill Types ComboBox --------------------------
		                var combo = document.getElementById('cmbTypes');
		                var xmlDoc = $.parseXML(data.d.Types);
		                var xml = $(xmlDoc);
		                var dt = xml.find("datatable");
		                //combo.innerHTML = "";
		                $.each(dt, function () {
		                    var option = document.createElement("option");
		                    option.text = $(this).find("Full_Title").text();
		                    option.value = $(this).find("code").text();
		                    combo.add(option);
		                });
		                ////  ---------------------- Fill Posts ComboBox --------------------------
		                combo = document.getElementById('cmbPosts');
		                xmlDoc = $.parseXML(data.d.Posts);
		                xml = $(xmlDoc);
		                dt = xml.find("datatable");
		                //combo.innerHTML = "";
		                $.each(dt, function () {
		                    var option = document.createElement("option");
		                    option.text = $(this).find("Full_Title").text();
		                    option.value = $(this).find("Code").text();
		                    combo.add(option);
		                });
		                ////  -------------------- Fill Conditions ComboBox ------------------------
		                combo = document.getElementById('cmbConditions');
		                xmlDoc = $.parseXML(data.d.Conditions);
		                xml = $(xmlDoc);
		                dt = xml.find("datatable");
		                //combo.innerHTML = "";
		                $.each(dt, function () {
		                    var option = document.createElement("option");
		                    option.text = $(this).find("Full_Title").text();
		                    option.value = $(this).find("Code").text();
		                    combo.add(option);
		                });
		                ////  ----------------- Set Maximum Numbers of Nodes -----------------------
		                Nodes.MaximumNumber = data.d.NodeMax;
		                ////  -------- Add Maximum Number of Nodes As Hidden Elements --------------
		                for (var i = 0; i < Nodes.MaximumNumber; i++)
		                    document.getElementById('statemachine-demo').innerHTML += "<div class='w hidden' rel='" + (i + 1) + "' id='window" + (i + 1) + "'>جدید<div class='ep'></div></div>";
		                Load_jsPlumb();
		                ////  ----------- Show Visible Nodes and Create Connections  ---------------
		                for (var i = 0; i < data.d.Nodes.length; i++)
		                {
		                    $('#window' + data.d.Nodes[i].Ordered).removeClass('hidden');
		                    var NextNodes = data.d.Nodes[i].NextNodes;
		                    if (NextNodes.length > 0)
		                    {
		                        var targets = NextNodes.split(',');
		                        for (var j = 0; j < targets.length; j++)
		                        {
		                            instance.connect({ source: "window" + data.d.Nodes[i].Ordered, target: "window" + targets[j] });
		                        }
		                    }
		                    Nodes.NumbersOfVisibles.push(data.d.Nodes[i].Ordered);
		                }
		                ////  ---------------- Animate Nodes To Their Positions --------------------
		                for (var i = 0; i < data.d.Nodes.length; i++)
		                {
		                    instance.animate($('#window' + data.d.Nodes[i].Ordered),
                                { "left": data.d.Nodes[i].Left, "top": data.d.Nodes[i].Top }, { duration: 1000 });
		                }

		            },
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function ShowPropertiesControls(TypeCode)
		    {
		        var dv_properties = document.getElementById('dv_properties');
		        var dv_basic_properties = document.getElementById('dv_basic_properties');
		        var cmbPosts = document.getElementById('cmbPosts');
		        var tr_posts = document.getElementById('txtPostCodes').parentNode.parentNode;
		        var txtPostsSQL = document.getElementById('txtPostsSQL');
		        var dv_posts = document.getElementById('dv_posts');
		        var btnAddPostCode = document.getElementById('btnAddPostCode');
		        var NodeTypes1 = [2, 4, 9, 12];//برای "پایان" یا "یک یا چند پست مشخص همه در یک رکورد" یا "سطل زباله" یا "یک یا چند پست مشخص هر کدام در یک رکورد مجزا" می باشد

		        $(dv_properties).removeClass('hidden');
		        if (NodeTypes1.indexOf(TypeCode) != -1) {
		            $(cmbPosts).removeClass('hidden');
		            $(tr_posts).removeClass('hidden');
		            $(txtPostsSQL).addClass('hidden');
		            $(dv_posts).removeClass('hidden');
		            $(btnAddPostCode).removeClass('hidden');
		        }
		        else if (TypeCode == 11) {//  SQL Query برای
		            $(cmbPosts).addClass('hidden');
		            $(tr_posts).addClass('hidden');
		            $(txtPostsSQL).removeClass('hidden');
		            $(dv_posts).removeClass('hidden');
		            $(btnAddPostCode).addClass('hidden');
		        }
		        else {
		            $(dv_posts).addClass('hidden');
		        }
		        if (NodeTypes1.indexOf(TypeCode) != -1 || TypeCode == 11)
		        {
		            $(dv_properties).css('width');
		            $(dv_properties).css('height');
		            $(dv_properties).css('margin-right');
		            $(dv_properties).css({ 'width': '60%', 'height': '300px', 'margin-right': '20%' });
		            $(dv_basic_properties).css({ 'width': '50%'});
		        }
		        else {
		            $(dv_properties).css('width');
		            $(dv_properties).css('height');
		            $(dv_properties).css('margin-right');
		            $(dv_properties).css({ 'width': '30%', 'height': '300px', 'margin-right': '35%' });
		            $(dv_basic_properties).css({ 'width': '100%'});
		        }
		    }

		    function ResetAndHideProperties()
		    {
		        Nodes.SelectedNumber = 0;
		        $('#dv_properties').addClass('hidden').css({ 'width': '0%', 'height': '0px', 'margin-right': '20%' });
		        $('#dv_posts').addClass('hidden');
		        document.getElementById('cmbTypes').selectedIndex = 0;
		        document.getElementById('cmbPosts').selectedIndex = 0;
		        document.getElementById('txtName').value = '';
		        document.getElementById('txtPostCodes').value = '';
		        document.getElementById('txtPostsSQL').value = '';
		    }

		    function btnAddPostCode_click()
		    {
		        var cmbPosts = document.getElementById('cmbPosts');
		        var txtPostCodes = document.getElementById('txtPostCodes');
		        var PostCode = cmbPosts.options[cmbPosts.selectedIndex].value;
		        if (txtPostCodes.value.trim() == '')
		            txtPostCodes.value = PostCode;
		        else
		            txtPostCodes.value += ', ' + PostCode;
		    }

		    function InsertNode(Ordered) {
		        return $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/InsertWorkFlowNode',
		            data: '{"Ordered":' + Ordered + ', "ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function DeleteNode(Ordered) {
		        return $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/DeleteWorkFlowNode',
		            data: '{"Ordered":' + Ordered + ', "ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function LoadNodeProperties(Ordered) {
		        return $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/LoadWorkFlowNode',
		            data: '{"Ordered":' + Ordered + ', "ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function UpdateNodeProperties(Name, TypeCode, Ordered, PostCode) {
		        return $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/UpdateWorkFlowNode',
		            data: '{"Name":"' + Name + '", "TypeCode":' + TypeCode + ',"Ordered":' + Ordered
                        + ', "PostCode":"' + PostCode + '", "ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function btnSaveProperties_click()
		    {
		        var Name = document.getElementById('txtName').value;
		        var cmbTypes = document.getElementById('cmbTypes');
		        var TypeCode = cmbTypes.options[cmbTypes.selectedIndex].value;
		        var PostCodes = '';
		        if (TypeCode != '11')
		            PostCodes = document.getElementById('txtPostCodes').value;
		        else  //  Type == SQL Query برای
		            PostCodes = document.getElementById('txtPostsSQL').value;
		        $.when(UpdateNodeProperties(Name, TypeCode, Nodes.SelectedNumber, PostCodes)).done(function (result) {
		            if (result.d) {
		                document.getElementById('window' + Nodes.SelectedNumber).innerHTML = Name + '<div class="ep"></div>';
		                ResetAndHideProperties();
		            }
		        });

		    }

		    function btnSave_click()
		    {
		        var _nodes = [];
		        for (var i = 0; i < Nodes.NumbersOfVisibles.length; i++)
		        {
		            var _node = document.getElementById('window' + Nodes.NumbersOfVisibles[i]);
		            var connections = instance.getConnections({ source: 'window' + Nodes.NumbersOfVisibles[i] });
                    var NextNodes = '';
                    if (i in Nodes.NumbersOfVisibles)
                    {
                        for (var j = 0; j < connections.length; j++) {
                            var TargeID = connections[j].targetId;
                            var TargeNumber = TargeID.substring(6, TargeID.length);
                            if (j == 0)
                                NextNodes = TargeNumber.toString();
                            else
                                NextNodes += ',' + TargeNumber;
                    }
                    var NodeInfo = { Ordered: Nodes.NumbersOfVisibles[i], NextNodes: NextNodes, Left: _node.offsetLeft, Top: _node.offsetTop };
                    _nodes.push(NodeInfo);
                    }
		        }
		        $.when(SaveForm(_nodes)).done(function (result) {
		            if (result.d) {
		            }
		        });
		    }

		    function SaveForm(_nodes)
		    {
		        var Data = { ClassName: Nodes.ClassName, DynamicClassCode: Nodes.DynamicClassCode, Nodes: _nodes }
		        var StringifiedData = JSON.stringify(Data);
		        return $.ajax({
		            type: 'POST',
		            url: '/Services/WebAutomationService.asmx/SaveFlowChart',
		            data: StringifiedData,
		            contentType: "application/json; charset=utf-8",
		            dataType: "json",
		            error: function (xhr, status, error) {
		                var err = eval("(" + xhr.responseText + ")");
		                alert(err.Message);
		            }
		        });
		    }

		    function getParameterByName(name) {
		        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
		        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(location.search);
		        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
		    }

		    $(document).ready(function () {////////////////////////////   document ready    ////////////////////////////////////////
		        Nodes.ClassName = getParameterByName('ClassName');
		        Nodes.DynamicClassCode = parseInt(getParameterByName('DynamicClassCode'));
		        SetForm();
		        $('#temp').mousedown(function () {
		            if (Nodes.SelectedNumber != 0) return;
		            Nodes.SetNumber();
		           NewNode.MouseEvents.IsDown = true;
		            temp = this.cloneNode(true);
		            temp.id = "temp_shadow";
		            $(temp).css({ 'position': 'absolute'});
		            document.body.appendChild(temp);
		        });

		        $(window).mousemove(function (event) {
		            if (Nodes.SelectedNumber != 0) return;
		            if (NewNode.MouseEvents.IsDown)
		            {
		                $(temp).css({ 'top': (event.pageY - 20) + 'px', 'left': (event.pageX - 25) + 'px', 'opacity': '0.5' });
		            }
		        });

		        $(window).mouseup(function (event) {
		            if (Nodes.SelectedNumber != 0) return;
		            if (NewNode.MouseEvents.IsDown) {
		                NewNode.MouseEvents.IsDown = false;
		                var x = $(temp).position().left,
		                y = $(temp).position().top,
		                container = document.getElementById('statemachine-demo'),
		                container_rect = container.getBoundingClientRect(),
		                container_x = container_rect.left + $(window).scrollLeft(),
		                container_y = container_rect.top + $(window).scrollTop(),
		                container_width = container.offsetWidth;
		                container_height = container.offsetHeight;
		                $(temp).remove();
		                if ((x > container_x && x < (container_x + container_width - 50)) && (y > container_y && y < (container_y + container_height - 40))) {
		                    $.when(InsertNode(NewNode.Number)).done(function (result) {
		                        if (result.d) {
		                                $('#window' + NewNode.Number).css({ "left": (x - container_x) + 'px', "top": (y - container_y) + 'px' })
                                            .removeClass('hidden');
		                                instance.animate($('#window' + NewNode.Number), { "left": (x - container_x), "top": (y - container_y) }, { duration: 1 });
		                                Nodes.NumbersOfVisibles.push(NewNode.Number);
		                         }
		                    });
		                }
		            }
		        });
		    });
		    var qaz = 0;
		    function AddDiv() {
		        qaz++;
		        var instance = jsPlumb.getInstance({
		            Endpoint: ["Dot", { radius: 2 }],
		            HoverPaintStyle: { strokeStyle: "#1e8151", lineWidth: 2 },
		            ConnectionOverlays: [
                        ["Arrow", {
                            location: 1,
                            id: "arrow",
                            length: 14,
                            foldback: 0.8
                        }],
                        ["Label", { label: "FOO", id: "label", cssClass: "aLabel" }]
		            ],
		            Container: "statemachine-demo"
		        });

		        window.jsp = instance;
		        document.getElementById('statemachine-demo').innerHTML += "<div class='w' id='id" + qaz + "'>neeeeeeeeew<div class='ep'></div></div>";
		       
		  var windows= jsPlumb.getSelector(".statemachine-demo .w");
		  window.jsp.draggable(windows);

	//	  window.jsp.setDraggable("id1", true);
		        //    jsPlumb.fire("jsPlumbDemoLoaded", instance);
		    }
            

		    //var _gaq = _gaq || [];
		    //_gaq.push(['_setAccount', 'UA-15400992-4']);
		    //_gaq.push(['_trackPageview']);

		    //(function () {
		    //    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
		    //    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
		    //    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
		    //})();

        </script>
        </form>
     </body>
</html>
