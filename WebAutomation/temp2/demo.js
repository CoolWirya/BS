
function Load_jsPlumb() {
        // setup some defaults for jsPlumb.
        instance = jsPlumb.getInstance({
            Endpoint: ["Dot", {radius: 2}],
            HoverPaintStyle: {strokeStyle: "#1e8151", lineWidth: 2 },
            ConnectionOverlays: [
                [ "Arrow", {
                    location: 1,
                    id: "arrow",
                    length: 14,
                    foldback: 0.8
                } ],
                [ "Label", { label: "FOO", id: "label", cssClass: "aLabel" }]
            ],
            Container: "statemachine-demo"
        });

        window.jsp = instance;

        var windows = jsPlumb.getSelector(".statemachine-demo .w");

        $(windows).bind('click', function () {
            if (Nodes.SelectedNumber != 0) return;
            $('.HighLighted').removeClass('HighLighted');
            $(this).addClass('HighLighted');
            Nodes.HighLightedNumber = parseInt($(this).attr('rel'));

        }).dblclick(function () {
            if (Nodes.SelectedNumber != 0) return;
            Nodes.SelectedNumber = parseInt($(this).attr('rel'));
            $.when(LoadNodeProperties(Nodes.SelectedNumber)).done(function (result) {
                document.getElementById('txtName').value = result.d.Name;
                document.getElementById('cmbTypes').selectedIndex = result.d.TypeCode - 1;
                if (result.d.TypeCode != 11)
                    document.getElementById('txtPostCodes').value = result.d.PostCode;
                else  // for Type == SQL Query
                    document.getElementById('txtPostsSQL').value = result.d.PostCode;
                document.getElementById('txtCondition').value = result.d.Condition;
                ShowPropertiesControls(result.d.TypeCode);
            });
            
        });

        $(window).keyup(function (e) {
            if (e.keyCode == 46) {
                $('.HighLighted').each(function () {
                    var that = this;
                    $.when(DeleteNode(Nodes.HighLightedNumber)).done(function (result) {
                        if (result.d) {
                            $(that).removeClass('HighLighted').addClass('hidden');
                            instance.detachAllConnections(that);
                            var NodeIndex = Nodes.NumbersOfVisibles.indexOf(Nodes.HighLightedNumber);
                            delete Nodes.NumbersOfVisibles[NodeIndex];
                            //Nodes.NumbersOfVisibles.length--;
                        }
                    });
                });
            }
        }).mousedown(function () {
            if (Nodes.SelectedNumber != 0) return;
            $('.HighLighted').removeClass('HighLighted');
            Nodes.HighLightedNumber = 0;
        });

        // initialise draggable elements.
        instance.draggable(windows);

        // bind a click listener to each connection; the connection is deleted. you could of course
        // just do this: jsPlumb.bind("click", jsPlumb.detach), but I wanted to make it clear what was
        // happening.
        instance.bind("click", function (c) {
            if (Nodes.SelectedNumber != 0) return;
            instance.detach(c);
        });

        // bind a connection listener. note that the parameter passed to this function contains more than
        // just the new connection - see the documentation for a full list of what is included in 'info'.
        // this listener sets the connection's internal
        // id as the label overlay's text.
        instance.bind("connection", function (info) {
            info.connection.getOverlay("label").setLabel(info.connection.id);
        });


        // suspend drawing and initialise.
        instance.batch(function () {
            instance.makeSource(windows, {
                filter: ".ep",
                anchor: "Continuous",
                connector: [ "StateMachine", { curviness: 20 } ],
                connectorStyle: { strokeStyle: "#5c96bc", lineWidth: 2, outlineColor: "transparent", outlineWidth: 4 },
                maxConnections: 5,
                onMaxConnections: function (info, e) {
                    alert("Maximum connections (" + info.maxConnections + ") reached");
                }
            });

            // initialise all '.w' elements as connection targets.
            instance.makeTarget(windows, {
                dropOptions: { hoverClass: "dragHover" },
                anchor: "Continuous",
                allowLoopback: true
            });

            // and finally, make a couple of connections
            //instance.connect({ source: "opened", target: "phone1" });
            //instance.connect({ source: "phone1", target: "phone1" });
            //instance.connect({ source: "phone1", target: "inperson" });
        });

        jsPlumb.fire("jsPlumbDemoLoaded", instance);
}
//jsPlumb.ready(function () {
//    for (var i = 0; i < 20; i++)
//        document.getElementById('statemachine-demo').innerHTML += "<div class='w hidden' rel='" + (i + 1) + "' id='window" + (i + 1) + "'>new<div class='ep'></div></div>";

//    // setup some defaults for jsPlumb.
//    var instance = jsPlumb.getInstance({
//        Endpoint: ["Dot", {radius: 2}],
//        HoverPaintStyle: {strokeStyle: "#1e8151", lineWidth: 2 },
//        ConnectionOverlays: [
//            [ "Arrow", {
//                location: 1,
//                id: "arrow",
//                length: 14,
//                foldback: 0.8
//            } ],
//            [ "Label", { label: "FOO", id: "label", cssClass: "aLabel" }]
//        ],
//        Container: "statemachine-demo"
//    });

//    window.jsp = instance;

//    var windows = jsPlumb.getSelector(".statemachine-demo .w");
//    $(windows).bind('click', function () {
//        if (Nodes.SelectedNumber != 0) return;
//        $('.selected').removeClass('selected');
//        $(this).addClass('selected');
//    }).dblclick(function () {
//        if (Nodes.SelectedNumber != 0) return;
//        Nodes.SelectedNumber = parseInt($(this).attr('rel'));
//        $('#dv_properties').removeClass('hidden');
//        $('#dv_posts').addClass('hidden');///////////////////////////////////////////    transfer this line to ResetForm()      ////////////////////
//    });

//    $(window).keyup(function (e) {
//        if (e.keyCode == 46) {
//            $('.selected').each(function () {
//                $(this).removeClass('selected').addClass('hidden');
//                instance.detachAllConnections(this);
//                var NodeIndex = Nodes.NumbersOfVisibles.indexOf(parseInt($(this).attr('rel')));
//                delete Nodes.NumbersOfVisibles[NodeIndex];
//            });
//        }
//    }).mousedown(function () {
//        if (Nodes.SelectedNumber != 0) return;
//        $('.selected').removeClass('selected');
//    });

//    // initialise draggable elements.
//    instance.draggable(windows);

//    // bind a click listener to each connection; the connection is deleted. you could of course
//    // just do this: jsPlumb.bind("click", jsPlumb.detach), but I wanted to make it clear what was
//    // happening.
//    instance.bind("click", function (c) {
//        if (Nodes.SelectedNumber != 0) return;
//        instance.detach(c);
//    });

//    // bind a connection listener. note that the parameter passed to this function contains more than
//    // just the new connection - see the documentation for a full list of what is included in 'info'.
//    // this listener sets the connection's internal
//    // id as the label overlay's text.
//    instance.bind("connection", function (info) {
//        info.connection.getOverlay("label").setLabel(info.connection.id);
//    });


//    // suspend drawing and initialise.
//    instance.batch(function () {
//        instance.makeSource(windows, {
//            filter: ".ep",
//            anchor: "Continuous",
//            connector: [ "StateMachine", { curviness: 20 } ],
//            connectorStyle: { strokeStyle: "#5c96bc", lineWidth: 2, outlineColor: "transparent", outlineWidth: 4 },
//            maxConnections: 5,
//            onMaxConnections: function (info, e) {
//                alert("Maximum connections (" + info.maxConnections + ") reached");
//            }
//        });

//        // initialise all '.w' elements as connection targets.
//        instance.makeTarget(windows, {
//            dropOptions: { hoverClass: "dragHover" },
//            anchor: "Continuous",
//            allowLoopback: true
//        });

//        // and finally, make a couple of connections
//        instance.connect({ source: "opened", target: "phone1" });
//        instance.connect({ source: "phone1", target: "phone1" });
//        instance.connect({ source: "phone1", target: "inperson" });
//    });

//    jsPlumb.fire("jsPlumbDemoLoaded", instance);
//});

