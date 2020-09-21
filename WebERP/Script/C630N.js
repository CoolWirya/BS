function onInput_FilterBox(gridId, filterBoxId) {
	alert(gridId);
	alert($('#'+gridId+' .filterBox').find(filterBoxId).val());
}

//function FillListControl(controlId, data, keyField, textField) {
//	var xmlDoc = $.parseXML(data.d);
//	var xml = $(xmlDoc);
//	var dt = xml.find("datatable");
//	var listItems = [];
//	$.each(dt, function () {
//		listItems.push('<option value="' +
//		$(this).find(keyField).text() + '">' + $(this).find(textField).text()
//		+ '</option>');
//	});
//	$('#'+controlId).empty();
//	$('#' + controlId).append(listItems.join(''));
//}

function css(a) {
	var sheets = document.styleSheets, o = {};
	for (var i in sheets) {
		var rules = sheets[i].rules || sheets[i].cssRules;
		for (var r in rules) {
			if (a.is(rules[r].selectorText)) {
				o = $.extend(o, css2json(rules[r].style), css2json(a.attr('style')));
			}
		}
	}
	return o;
}

function css2json(css) {
	var s = {};
	if (!css) return s;
	if (css instanceof CSSStyleDeclaration) {
		for (var i in css) {
			if ((css[i]).toLowerCase) {
				s[(css[i]).toLowerCase()] = (css[css[i]]);
			}
		}
	} else if (typeof css == "string") {
		css = css.split("; ");
		for (var i in css) {
			var l = css[i].split(": ");
			s[l[0].toLowerCase()] = (l[1]);
		}
	}
	return s;
}

(function (window, undefined) {
    var rclass = /[\n\t\r]/g,
	rspace = /\s+/,
	rreturn = /\r/g,
	rtype = /^(?:button|input)$/i,
	rfocusable = /^(?:button|input|object|select|textarea)$/i,
	rclickable = /^a(?:rea)?$/i,
	rboolean = /^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,
	getSetAttribute = jQuery.support.getSetAttribute,
	nodeHook, boolHook, fixSpecified;
    jQuery.fn.extend({
        val: function (value) {
            var hooks, ret, isFunction,
                elem = this[0];

            if (!arguments.length) {
                if (elem) {
                    if (elem.getAttribute("owner") == "630N")
                        return elem.getAttribute("v63a0Nl");
                    hooks = jQuery.valHooks[elem.nodeName.toLowerCase()] || jQuery.valHooks[elem.type];

                    if (hooks && "get" in hooks && (ret = hooks.get(elem, "value")) !== undefined) {
                        return ret;
                    }

                    ret = elem.value;

                    return typeof ret === "string" ?
                        // handle most common string cases
                        ret.replace(rreturn, "") :
                        // handle cases where value is null/undef or number
                        ret == null ? "" : ret;
                }

                return;
            }

            isFunction = jQuery.isFunction(value);

            return this.each(function (i) {
                var self = jQuery(this), val;

                if (this.nodeType !== 1) {
                    return;
                }

                if (isFunction) {
                    val = value.call(this, i, self.val());
                } else {
                    val = value;
                }

                // Treat null/undefined as ""; convert numbers to string
                if (val == null) {
                    val = "";
                } else if (typeof val === "number") {
                    val += "";
                } else if (jQuery.isArray(val)) {
                    val = jQuery.map(val, function (value) {
                        return value == null ? "" : value + "";
                    });
                }
                if (elem.getAttribute("owner") == "630N")
                    elem.setAttribute("v63a0Nl", val);
                hooks = jQuery.valHooks[this.nodeName.toLowerCase()] || jQuery.valHooks[this.type];

                // If set returns undefined, fall back to normal setting
                if (!hooks || !("set" in hooks) || hooks.set(this, val, "value") === undefined) {
                    this.value = val;
                }
            });
        }
    });
})(window);

function C630N_Uploader(evt, resTag, desc, serviceUrl, path, dbcn, dboc, cn, oc) {
    var fileUpload = document.getElementById(evt);
    var files = fileUpload.files;
    var data = new FormData();
    var mainUploader = fileUpload.parentElement.parentElement.parentElement.parentElement;
    if (files.length > 0) {
        data.append(files[0].name, files[0]);
        data.append("path", path);
        data.append("Description", desc);
        data.append("DataBaseClassName", dbcn);
        data.append("DataBaseObjectCode", dboc);
        data.append("ClassName", cn);
        data.append("ObjectCode", oc);
        data.append("ResponseTag", resTag);
        data.append("MainUploader", mainUploader.id);
        data.append("ServiceUrl", serviceUrl);
    }
    var options = {};
    options.url = serviceUrl;
    options.type = "POST";
    options.data = data;
    options.contentType = false;
    options.processData = false;
    options.success = function (result) {
        var results = result.split('?!?');
        mainUploader.setAttribute('v63a0Nl', (mainUploader.getAttribute('v63a0Nl') != null ? mainUploader.getAttribute('v63a0Nl') : '') + results[0]);
        $("#" + resTag).append(results[1]);
    };
    options.error = function (err) { alert(err.statusText); };
    $.ajax(options);
}

function readURL(input, target) {
    var inp = document.getElementById(input);
    var tar = document.getElementById(target);
    if (inp.files && inp.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            tar.src = e.target.result;
        }
        reader.readAsDataURL(inp.files[0]);
    }
}

//function removeArchiveRow(guid, resTag) {
//    $("#" + resTag).children('[id=' + guid + ']').remove();
//}
function removeUploadedFile(guid, ext, path, mu, rt, serviceUrl, cn, oc) {
    var data = new FormData();
    data.append("path", path + guid + ext);
    var archiveCode = $("#" + rt + " tr[id=" + guid + "]").attr('archiveCode');
    data.append("ArchiveCode", archiveCode);
    var options = {};
    options.url = serviceUrl;
    options.type = "POST";
    options.data = data;
    options.contentType = false;
    options.processData = false;
    options.success = function (result) {
        $("#" + rt + " tr[id=" + guid + "]").remove();
        $("#" + mu).val($("#" + mu).val().replace((Number(archiveCode) != NaN && Number(archiveCode) > 0 ? archiveCode : guid) + ext + ',', ''));
    };
    options.error = function (err) { alert(err.d); };
    $.ajax(options);
}

function C630N_ArchiveUploadedFiles(evt, path, cn, oc) {
    var data = new FormData();
    //data.append("Description", desc);
    data.append("files", $("#" + evt).val());
    data.append("path", path);
    data.append("className", cn);
    data.append("objectCode", oc);
    var options = {};
    options.url = "../Services/FileUploader/UploaderService.asmx/ArchiveUploadedFiles";
    options.type = "POST";
    options.data = JSON.stringify(data);
    options.contentType = "application/json; charset=utf-8";
    options.dataType = "json";
    options.success = function (result) {
        $("#" + evt).val(result.d);
    };
    options.error = function (err) {
        alert(err.responseText);
    };
    $.ajax(options);
}