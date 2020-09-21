$(function () {
    $.fn.uploadingFunction = function (cID,picURL, newGuid) {
        uploadingFunction(cID, picURL, newGuid);
    }
    var uploadingFunction = (function () {
        function uploadingFunction(btnUploadName, picUrl, newGuid) {

            var btnUpload = $("#" + btnUploadName);
            var status = $('#status');
            var handlerPage = '../Handler/Handler1.ashx';
            var queryString = "?randomno=32&picUrl=" + picUrl + "&picName=" + Hdf_NewGuid.val();
            new AjaxUpload(btnUpload,
                {
                    action: handlerPage + queryString, name: 'uploadfile', onSubmit: function (file, ext) {
                        if (!(ext && /^(jpg|gif|png|rar|zip|doc|docx|txt|bmp|ppt|pptx|pps|ppsx|xls|xlsx|pdf)$/.test(ext)))
                        { status.text('Only JPG, PNG or GIF files are allowed'); return false; }
                        status.css("visibility", "visible");
                    }
                         , onComplete: function (file, response) {
                             picUrl = picUrl.replace('~/', '../');
                             //imageName.attr("src", picUrl + "NewsPic" + newGuid + ".jpg?" + new Date().getTime());
                         }
                });
        }
    });
});