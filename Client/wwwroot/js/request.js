function SendRequest() {
    var txtMessage = document.getElementById("message");
    var message = txtMessage.value;
    $.post("Request/SendRequest", { message: message }, (data) => {
        if (data.success) {
            toastr.success(data.message);
            txtMessage.value = "";
        }
        else {
            toastr.error(data.message);
        }
    });
}