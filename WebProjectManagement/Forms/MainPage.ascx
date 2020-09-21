<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainPage.ascx.cs" Inherits="WebProjectManagement.Forms.MainPage" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script type="text/javascript">
        (function () {

            var $;
            var tooltipManager;
            var demo = window.demo = window.demo || {};

            demo.initialize = function () {
                tooltipManager = window.tooltipManager;
            };
            window.onClientItemCreated = function (sender, args) {
                //  var toolTipValue = args.get_dataItem().value;
                var itemElement = args.get_element();
              //  var itemCode = itemElement.getElementsByClassName('itemCode')[0].innerHTML;
                $telerik.$(itemElement).on("click", function (e) {//"mouseover", function (e) {

                    e.stopPropagation();
                });
            }
        })();
</script>
        <telerik:RadTreeMap RenderMode="Lightweight" runat="server" ID="TreeMap1" OnClientItemCreated="onClientItemCreated"
            DataKeyNames="name,description,improvementPercent" AlgorithmType="Vertical" Skin="Metro" >
            <ClientItemTemplate>                
                 <h4 style="margin: auto;">#=dataItem.name # #=dataItem.improvementPercent#</h4>
                <div>#=dataItem.description #</div>
           </ClientItemTemplate>
        </telerik:RadTreeMap>
  <script type="text/javascript">
        Sys.Application.add_load(function () {
            demo.initialize();
        });
      </script>
