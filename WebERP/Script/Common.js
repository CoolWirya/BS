function Show_Message(message, messageType, width, height) {
    if (messageType == 'Normal') {
        CreateMessage(message, '', width, height);
    }
}

function CreateMessage(text, image, width, height) {
    var _messageDiv = document.getElementById("messageDiv");
    var _messageBoxDiv = document.getElementById("messageBoxDiv");
    var _messageImg = document.getElementById("messageImg");
    var _messageTextDiv = document.getElementById("messageTextDiv");

    _messageBoxDiv.style.width = width;
    _messageBoxDiv.style.height = height;
    _messageImg.src = image;
    _messageTextDiv.innerHTML = text;
    _messageDiv.style.display = "block";

}


