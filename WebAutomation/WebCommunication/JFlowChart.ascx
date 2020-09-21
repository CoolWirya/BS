<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFlowChart.ascx.cs" Inherits="WebAutomation.WebCommunication.JFlowChart" %>
<form runat="server">   
    <div> طراحی چارت </div>
    <p class="warning">dddddddddddddd </p>
    <input type="button" name="name" value=" " onclick="init()" />
    <div id="sample" style="overflow-y:scroll;height:350px">
  <div style="width:100%; white-space:nowrap;">
    <span style="display: inline-block; vertical-align: top; padding: 5px; width:100px">
      <div id="myPalette" style="border: solid 1px gray; height: 720px"></div>
    </span>

    <span style="display: inline-block; vertical-align: top; padding: 5px; width:80%">
      <div id="myDiagram" style="border: solid 1px gray; height: 720px"></div>
    </span>
  </div>
  <p>
  The FlowChart sample demonstrates several key features of GoJS,
  namely <a href="../intro/palette.html">Palette</a>s,
  <a href="../intro/links.html">Linkable nodes</a>, Drag/Drop behavior,
  <a href="../intro/textBlocks.html">Text Editing</a>, and the use of
  <a href="../intro/templateMaps.html">Node Template Maps</a> in Diagrams.
  </p>
  <p>
  Mouse-over a Node to view its ports.
  Drag from these ports to create new Links.
  Selecting Links allows you to re-shape and re-link them.
  Selecting a Node and then clicking its TextBlock will allow
  you to edit text (except on the Start and End Nodes).
  </p>
  <p>
  The Diagram Model data is loaded from the JSON below.
  </p>
  <button id="SaveButton" onclick="save()">Save</button>
  <button onclick="load()">Load</button>
  <textarea id="mySavedModel" style="width:100%;height:300px">{ "class": "go.GraphLinksModel",
  "linkFromPortIdProperty": "fromPort",
  "linkToPortIdProperty": "toPort",
  "nodeDataArray": [
{"category":"Comment", "loc":"360 -10", "text":"Kookie Brittle", "key":-13},
{"key":-1, "category":"Start", "loc":"175 0", "text":"Start"},
{"key":0, "loc":"0 77", "text":"Preheat oven to 375 F"},
{"key":1, "loc":"175 100", "text":"In a bowl, blend: 1 cup margarine, 1.5 teaspoon vanilla, 1 teaspoon salt"},
{"key":2, "loc":"175 190", "text":"Gradually beat in 1 cup sugar and 2 cups sifted flour"},
{"key":3, "loc":"175 270", "text":"Mix in 6 oz (1 cup) Nestle's Semi-Sweet Chocolate Morsels"},
{"key":4, "loc":"175 370", "text":"Press evenly into ungreased 15x10x1 pan"},
{"key":5, "loc":"352 85", "text":"Finely chop 1/2 cup of your choice of nuts"},
{"key":6, "loc":"175 440", "text":"Sprinkle nuts on top"},
{"key":7, "loc":"175 500", "text":"Bake for 25 minutes and let cool"},
{"key":8, "loc":"175 570", "text":"Cut into rectangular grid"},
{"key":-2, "category":"End", "loc":"175 640", "text":"Enjoy!"}
 ],
  "linkDataArray": [
{"from":1, "to":2, "fromPort":"B", "toPort":"T"},
{"from":2, "to":3, "fromPort":"B", "toPort":"T"},
{"from":3, "to":4, "fromPort":"B", "toPort":"T"},
{"from":4, "to":6, "fromPort":"B", "toPort":"T"},
{"from":6, "to":7, "fromPort":"B", "toPort":"T"},
{"from":7, "to":8, "fromPort":"B", "toPort":"T"},
{"from":8, "to":-2, "fromPort":"B", "toPort":"T"},
{"from":-1, "to":0, "fromPort":"B", "toPort":"T"},
{"from":-1, "to":1, "fromPort":"B", "toPort":"T"},
{"from":-1, "to":5, "fromPort":"B", "toPort":"T"},
{"from":5, "to":4, "fromPort":"B", "toPort":"T"},
{"from":0, "to":4, "fromPort":"B", "toPort":"T"}
 ]}
  </textarea>
  <p>Click the button below to render the current GoJS Diagram into SVG at one-half scale.
     The SVG is not interactive like the GoJS diagram, but can be used for printing or display.
     For more information, see the page on <a href="../intro/makingSVG.html">making SVG</a>.</p>
  <button onclick="makeSVG()">Render as SVG</button>
  <div id="SVGArea"></div>
</div>
    <script type="text/javascript">
        //$(document).ready(function () { alert(); });
    </script>
</form>
