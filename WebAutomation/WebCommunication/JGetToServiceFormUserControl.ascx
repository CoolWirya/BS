<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGetToServiceFormUserControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JGetToServiceFormUserControl" %>

<link href="Style/jsplumb.css" rel="stylesheet">
<link href="Style/statemachine.css" rel="stylesheet">

<script src="Script/jquery-1.8.2.min.js"></script>
<script src="Script/jquery-ui-1.8.24.min.js"></script>
<%--<script src="WebAutomation/temp2/jquery.ui.touch-punch-0.2.2.min.js"></script>--%>
<script src="Script/jquery.jsPlumb-1.7.5-min.js"></script>
<script src="Script/statemachine.js"></script>
<script type="text/javascript">

    var ClassName;
    var ObjCode;
    var Data;
    var State = {
        value: 1
    };
    var Pcode;
    var vCode;

    
    function InsertDataFromUserController(Ordered) {
        ShowWarining('در  حال بارگذاری ...', false, 3);
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

    --------------------------------------------------
	var temp;
	var instance;
	var txtFocus;
	var NewNode = {
		MouseEvents: { IsDown: false },
		Number: 1
	};
	var Nodes = {
		SelectedNumber: 0,
		HighLightedNumber: 0,
		NumbersOfVisibles: [],
	    ClassRank: 0,
		ClassName: '',
		DynamicClassCode: -1,
		MaximumNumber: 30,
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

	function SetForm() {
	    ShowWarining('در  حال بارگذاری ...', false, 3);
	    ////  -------------------- Get Rank Of Selected ClassName ------------------------
	    Nodes.ClassRank = parseInt(getParameterByName('ClassRank'));
	    ////  -------------------- Set Maximum Numbers of Nodes --------------------------
	    var cd = "MaximumNumber=";
	    var ca = document.cookie.split(';');
	    for (var i = 0; i < ca.length; i++) {
	        var c = ca[i];
	        while (c.charAt(0) == ' ') c = c.substring(1);
	        if (c.indexOf(cd) != -1) Nodes.MaximumNumber = parseInt(c.substring(cd.length, c.length));
	    }
	    document.cookie = "MaximumNumber=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
		$.ajax({
		    type: 'POST',
		    url: '/Services/WebAutomationService.asmx/LoadFlowChart',
		    data: '{"ClassRank":' + Nodes.ClassRank + '}',
		    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    success: function (data) {
		        ////  ------------------------- Set Form Name -----------------------------
		        document.getElementById('dv_title').innerHTML = data.d.FormName;
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
		        if (data.d.Conditions != null && data.d.Conditions.length > 0)
		        {
		            combo = document.getElementById('cmbConditions');
		            //combo.innerHTML = "";
		            for (var i = 0; i < data.d.Conditions.length; i++){
		                var option = document.createElement("option");
		                option.text = data.d.Conditions[i].toString();
		                combo.add(option);
		            }
		        }
		        ////  --------------- Set ClassName and DynamicClassCode -------------------
		        Nodes.ClassName = data.d.ClassName;
		        Nodes.DynamicClassCode = data.d.DynamicClassCode;
		        ////  -------- Add Maximum Number of Nodes As Hidden Elements --------------
		        container_width = document.getElementById('dv_nodes').offsetWidth;
		        for (var i = 0; i < Nodes.MaximumNumber; i++)
		            document.getElementById('dv_nodes').innerHTML += "<div class='w hidden' rel='" + (i + 1) + "' id='window" + (i + 1)
                        + "' style='left:" + (container_width - 100) + "px' oncontextmenu='ShowMenu(\"contextMenu\",event);'>جدید<div class='ep'></div></div>";
		        Load_jsPlumb();
		        ////  ----------- Show Visible Nodes and Create Connections  ---------------
		        for (var i = 0; i < data.d.Nodes.length; i++) {
		            var _node = document.getElementById('window' + (data.d.Nodes[i].Ordered + 1));
		            $(_node).removeClass('hidden');
		            _node.innerHTML = data.d.Nodes[i].Name + '<div class="ep"></div>';
		            var NextNodes = data.d.Nodes[i].NextNodes;
		            if (NextNodes.length > 0) {
		                var targets = NextNodes.split(',');
		                for (var j = 0; j < targets.length; j++) {
		                    instance.connect({ source: "window" + (data.d.Nodes[i].Ordered + 1), target: "window" + (parseInt(targets[j]) + 1) });
		                }
		            }
		            Nodes.NumbersOfVisibles.push(data.d.Nodes[i].Ordered + 1);
		        }
		        ////  ---------------- Animate Nodes To Their Positions --------------------
		        for (var i = 0; i < data.d.Nodes.length; i++) {
		            instance.animate($('#window' + (data.d.Nodes[i].Ordered + 1)),
                        { "left": data.d.Nodes[i].Left, "top": data.d.Nodes[i].Top }, { duration: 1000 });
		        }
		        HideWarining();
		    },
		    error: function (xhr, status, error) {
		        var err = eval("(" + xhr.responseText + ")");
		        alert(err.Message);
		    }
		});
	}

	function ShowMenu(control, e) {
	    var posx = e.clientX + window.pageXOffset - 90 + 'px';
	    var posy = e.clientY + window.pageYOffset + 'px';
	    $(document.getElementById(control)).css({'position': 'absolute','display': 'initial', 'left': posx, 'top': posy});
	}

	function HideMenu(control) {
	    document.getElementById(control).style.display = 'none';
	}

	function ShowPropertiesControls(TypeCode) {
		var dv_properties = document.getElementById('dv_properties');
		var dv_basic_properties = document.getElementById('dv_basic_properties');
		var tr_post_selection = document.getElementById('cmbPosts').parentNode.parentNode;
		var txtPostsSQL = document.getElementById('txtPostsSQL');
		var txtPostCodes = document.getElementById('txtPostCodes');
		var dv_posts = document.getElementById('dv_posts');
		var lbl_posts = document.getElementById('lbl_posts');
		var btnAddPostCode = document.getElementById('btnAddPostCode');
		var NodeTypes1 = [2, 4, 9, 12];//برای "پایان" یا "یک یا چند پست مشخص همه در یک رکورد" یا "سطل زباله" یا "یک یا چند پست مشخص هر کدام در یک رکورد مجزا" می باشد

		//$(dv_properties).removeClass('hidden');
		if (NodeTypes1.indexOf(TypeCode) != -1) {
		    $(tr_post_selection).removeClass('hidden');
		    $(txtPostsSQL).addClass('hidden');
		    $(txtPostCodes).removeClass('hidden');
		    $(dv_posts).removeClass('hidden');
		    $(btnAddPostCode).removeClass('hidden');
		    lbl_posts.innerHTML = "پست ها";
		}
		else if (TypeCode == 11) {//  SQL Query برای
		    $(tr_post_selection).addClass('hidden');
		    $(txtPostsSQL).removeClass('hidden');
		    $(txtPostCodes).addClass('hidden');
		    $(dv_posts).removeClass('hidden');
		    $(btnAddPostCode).addClass('hidden');
		    lbl_posts.innerHTML = "ورود Query";
		}
		else {
		    $(dv_posts).addClass('hidden');
		}
		    $(dv_properties).css('width');
		    $(dv_properties).css('height');
		    $(dv_properties).css('right');
		    $(dv_properties).css('margin-top');
		if (NodeTypes1.indexOf(TypeCode) != -1 || TypeCode == 11) {
		    $(dv_properties).css({ 'width': '60%', 'height': '300px', 'right': '20%', 'margin-top': '70px' });
		    $(dv_basic_properties).css({ 'width': '50%' });
		}
		else {
		    $(dv_properties).css({ 'width': '30%', 'height': '300px', 'right': '35%', 'margin-top': '70px' });
		    $(dv_basic_properties).css({ 'width': '100%' });
		}
	}

	function ResetAndHideProperties() {
	    Nodes.SelectedNumber = 0;
	    var dv_properties = $('#dv_properties');
	    $(dv_properties).css({ 'width': '0%', 'height': '0px', 'right': '50%', 'margin-top': '220px' });
	    window.setTimeout(function () {
		    document.getElementById('cmbTypes').selectedIndex = 0;
		    document.getElementById('cmbPosts').selectedIndex = 0;
		    document.getElementById('cmbConditions').selectedIndex = 0;
		    document.getElementById('txtName').value = '';
		    document.getElementById('txtPostCodes').value = '';
		    document.getElementById('txtPostsSQL').value = '';
		    document.getElementById('txtCondition').value = '';
	    }, 400);
	    //$(dv_properties).css('transform');
	    //$(dv_properties).css('transform', 'rotate(90deg)');
	    //window.setTimeout(function () {
	    //    $(dv_properties).css({ 'transform': 'rotate(-45deg)', 'width': '0%', 'height': '0px', 'right': '50%', 'margin-top': '220px' });
	    //}, 200);
	    //window.setTimeout(function () {
	    //    $(dv_properties).addClass('hidden').css({ 'transform': 'none'});
	    //}, 600);
		//$('#dv_properties').addClass('hidden').css({ 'width': '0%', 'height': '0px', 'right': '50%', 'margin-top': '220px' });
	}

	function btnAddPostCode_click() {
		var cmbPosts = document.getElementById('cmbPosts');
		var txtPostCodes = document.getElementById('txtPostCodes');
		var PostCode = cmbPosts.options[cmbPosts.selectedIndex].value;
		if (txtPostCodes.value.trim() == '')
		    txtPostCodes.value = PostCode;
		else
		    txtPostCodes.value += ', ' + PostCode;
	}

	function InsertNode(Ordered) {
	    ShowWarining('در  حال بارگذاری ...', false, 3);
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
	    ShowWarining('در  حال بارگذاری ...', false, 3);
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
	    ShowWarining('در  حال بارگذاری ...', false, 3);
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

	function UpdateNodeProperties(Name, TypeCode, Ordered, PostCode, Condition) {
	    ShowWarining('در  حال بارگذاری ...', false, 3);
		return $.ajax({
		    type: 'POST',
		    url: '/Services/WebAutomationService.asmx/UpdateWorkFlowNode',
		    data: '{"Name":"' + Name + '", "TypeCode":' + TypeCode + ',"Ordered":' + Ordered + ', "PostCode":"' + PostCode
                + '", "Condition": "' + Condition + '", "ClassName":"' + Nodes.ClassName + '", "DynamicClassCode": ' + Nodes.DynamicClassCode + '}',
		    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    error: function (xhr, status, error) {
		        var err = eval("(" + xhr.responseText + ")");
		        alert(err.Message);
		    }
		});
	}

	function btnSaveProperties_click() {
		var Name = document.getElementById('txtName').value;
		var cmbTypes = document.getElementById('cmbTypes');
		var TypeCode = cmbTypes.options[cmbTypes.selectedIndex].value;
		var PostCodes = '';
		if (TypeCode != '11')
		    PostCodes = document.getElementById('txtPostCodes').value;
		else  //  Type == SQL Query برای
		    PostCodes = document.getElementById('txtPostsSQL').value;
		var Condition = document.getElementById('txtCondition').value;
		$.when(UpdateNodeProperties(Name, TypeCode, Nodes.SelectedNumber - 1, PostCodes, Condition)).done(function (result) {
		    if (result.d) {
		        var _node = document.getElementById('window' + Nodes.SelectedNumber);
		        instance.animate(_node, { "left": _node.offsetLeft, "top": _node.offsetTop }, { duration: 1 });
		        _node.innerHTML = Name + '<div class="ep"></div>';
		        ResetAndHideProperties();
		        HideWarining();
		    }
		});

	}

	function btnSave_click() {
		var _nodes = [];
		for (var i = 0; i < Nodes.NumbersOfVisibles.length; i++) {
		    var _node = document.getElementById('window' + Nodes.NumbersOfVisibles[i]);
		    var connections = instance.getConnections({ source: 'window' + Nodes.NumbersOfVisibles[i] });
		    var NextNodes = '';
		    if (i in Nodes.NumbersOfVisibles) {
		        for (var j = 0; j < connections.length; j++) {
		            var TargeID = connections[j].targetId;
		            var TargeNumber = parseInt(TargeID.substring(6, TargeID.length));
		            if (j == 0)
		                NextNodes = (TargeNumber - 1).toString();
		            else
		                NextNodes += ',' + (TargeNumber - 1);
		        }
		        var NodeInfo = { Ordered: Nodes.NumbersOfVisibles[i] - 1, NextNodes: NextNodes, Left: _node.offsetLeft, Top: _node.offsetTop };
		        _nodes.push(NodeInfo);
		    }
		}
		$.when(SaveForm(_nodes)).done(function (result) {
		    if (!result.d.HasError) {
		        ShowWarining('تغییرات با موفقیت ذخیره شد', false, 4);
		        window.setTimeout(function () { GetRadWindow().reload(); }, 2000);
		    }
		    else
		    {
		        if (result.d.ErrorCode == 1)
		            ShowWarining('هیچ گره ای از نوع \"شروع\" وجود ندارد', false, 1);
		        else if (result.d.ErrorCode == 2)
		            ShowWarining('بیش از یک گره ای از نوع \"شروع\" وجود دارد', false, 1);
		        else if (result.d.ErrorCode == 3)
		            ShowWarining('برنامه موقتا دارای مشکل است دوباره تلاش نمایید!', false, 1);
		    }
		});
	}

	function SaveForm(_nodes) {
		var Data = { ClassName: Nodes.ClassName, DynamicClassCode: Nodes.DynamicClassCode, Nodes: _nodes }
		var StringifiedData = JSON.stringify(Data);
	    ShowWarining('در  حال بارگذاری ...', false, 3);
		return $.ajax({
		    type: 'POST',
		    url: '/Services/WebAutomationService.asmx/SaveFlowChart',
		    data: StringifiedData,
		    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    error: function (xhr, status, error) {
		        var err = eval("(" + xhr.responseText + ")");
		        ShowWarining(xhr.responseText, false, 1);
		    }
		});
	}

	function getParameterByName(name) {
		name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
		var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
		return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
	}

	function btnAddCondition_click()
	{
	    var cmbConditions = document.getElementById('cmbConditions');
	    var Condition = cmbConditions.options[cmbConditions.selectedIndex].text;
	    var caretPos = txtFocus.selectionStart;
	    var text = jQuery(txtFocus).val();
	    if (txtFocus.id == "txtCondition")
	        jQuery(txtFocus).val(text.substring(0, caretPos) + Condition + text.substring(caretPos));
	    if (txtFocus.id == "txtPostsSQL")
	        jQuery(txtFocus).val(text.substring(0, caretPos) + "@" + Condition + text.substring(caretPos));
	}

	function btnConditionHelp_click()
	{
	    var dv_condition_help = document.getElementById('dv_condition_help');
	    $(dv_condition_help).removeClass('hidden');

	}

	function HideConditionHelp()
	{
	    var dv_condition_help = document.getElementById('dv_condition_help');
	    $(dv_condition_help).addClass('hidden');
	}

	$(document).ready(function () {////////////////////////////   document ready    ////////////////////////////////////////
	    GetRadWindow().maximize();
	    SetForm();
	    $('#temp').mousedown(function () {
	        if (Nodes.SelectedNumber != 0) return;
	        $(this).css('cursor', 'move');
	        Nodes.SetNumber();
	        NewNode.MouseEvents.IsDown = true;
	        temp = this.cloneNode(true);
	        temp.id = "temp_shadow";
	        $(temp).css({ 'position': 'absolute' });
	        document.body.appendChild(temp);
	    });

	});
</script>