
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
            Container: "dv_nodes"
        });

        window.jsp = instance;

        var windows = jsPlumb.getSelector(".dv_nodes .w");

        $(windows).bind('click', function () {
            if (Nodes.SelectedNumber != 0) return;
            $('.HighLighted').removeClass('HighLighted');
            $(this).addClass('HighLighted');
            Nodes.HighLightedNumber = parseInt($(this).attr('rel'));

        }).bind('dblclick', function () {
            if (Nodes.SelectedNumber != 0) return;
            Nodes.SelectedNumber = parseInt($(this).attr('rel'));
            $.when(LoadNodeProperties(Nodes.SelectedNumber - 1)).done(function (result) {
                document.getElementById('txtName').value = result.d.Name;
                document.getElementById('cmbTypes').selectedIndex = result.d.TypeCode - 1;
                if (result.d.TypeCode != 11)
                    document.getElementById('txtPostCodes').value = result.d.PostCode;
                else  // for Type == SQL Query
                    document.getElementById('txtPostsSQL').value = result.d.PostCode;
                document.getElementById('txtCondition').value = result.d.Condition;
                ShowPropertiesControls(result.d.TypeCode);
                HideWarining();
            });
            
        });

        $(window).mousedown(function () {
            if (Nodes.SelectedNumber != 0) return;
            $('.HighLighted').removeClass('HighLighted');
            Nodes.HighLightedNumber = 0;

        }).mousemove(function (event) {
            if (Nodes.SelectedNumber != 0) return;
            if (NewNode.MouseEvents.IsDown) {
                $(temp).css({ 'top': (event.pageY - 20) + 'px', 'left': (event.pageX - 25) + 'px', 'opacity': '0.5' });
            }

        }).mouseup(function (event) {
            if (Nodes.SelectedNumber != 0) return;
            $(this).css('cursor', 'auto');
            if (NewNode.MouseEvents.IsDown) {
                NewNode.MouseEvents.IsDown = false;
                var x = $(temp).position().left,
                y = $(temp).position().top,
                container = document.getElementById('dv_nodes'),
                container_rect = container.getBoundingClientRect(),
                container_x = container_rect.left + $(window).scrollLeft(),
                container_y = container_rect.top + $(window).scrollTop(),
                container_width = container.offsetWidth;
                container_height = container.offsetHeight;
                $(temp).remove();
                if ((x > container_x && x < (container_x + container_width - 50)) && (y > container_y && y < (container_y + container_height - 40))) {
                    $.when(InsertNode(NewNode.Number - 1)).done(function (result) {
                        if (result.d) {
                            $('#window' + NewNode.Number).css({ "left": (x - container_x) + 'px', "top": (y - container_y) + 'px' })
                                .removeClass('hidden');
                            instance.animate($('#window' + NewNode.Number), { "left": (x - container_x), "top": (y - container_y) }, { duration: 1 });
                            Nodes.NumbersOfVisibles.push(NewNode.Number);
                            HideWarining();
                        }
                    });
                }
            }
        });

        window.onkeyup = function (e) {
            if (e.keyCode == 46) {
                $('.HighLighted').each(function () {
                    var that = this;
                    $.when(DeleteNode(Nodes.HighLightedNumber - 1)).done(function (result) {
                        if (result.d) {
                            $(that).removeClass('HighLighted').addClass('hidden');
                            that.innerHTML = document.getElementById('temp').innerHTML;
                            instance.detachAllConnections(that);
                            var NodeIndex = Nodes.NumbersOfVisibles.indexOf(Nodes.HighLightedNumber);
                            delete Nodes.NumbersOfVisibles[NodeIndex];
                            HideWarining();
                        }
                    });
                });
            }
        }

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
//        document.getElementById('dv_nodes').innerHTML += "<div class='w hidden' rel='" + (i + 1) + "' id='window" + (i + 1) + "'>new<div class='ep'></div></div>";

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
//        Container: "dv_nodes"
//    });

//    window.jsp = instance;

//    var windows = jsPlumb.getSelector(".dv_nodes .w");
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

