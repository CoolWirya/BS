//(function () {
//    $.fn.Uploader =
function Uploader(evt) {
    var fileUpload = evt;//.get(0);
    var files = fileUpload.files;
    var data = new FormData();
    //for (var i = 0; i < files.length; i++) {
        //data.append(files[i].name, files[i]);
        //alert(files[i].name);
    //}
    if (files.length > 0)
        data.append(files[0].name, files[0]);
    var options = {};
    //options.url = "~/WebEstate/Land/Ground/Usage/Handler/Handler2.ashx";
    options.url = "/WebEstate/Land/Ground/Usage/Handler/Handler2.ashx";
    options.type = "POST";
    options.data = data;
    options.contentType = false;
    options.processData = false;
    options.success = function (result) { alert(result); };
    options.error = function (err) { alert(err.statusText); };

    $.ajax(options);

    //evt.preventDefault();
}

function readURL(input, target) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            target.src= e.target.result;
        }

        reader.readAsDataURL(input.files[0]);
    }
}




