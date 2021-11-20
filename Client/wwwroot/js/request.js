function SendRequest() {
    var message = document.getElementById("message").value;
    $.post("Request/SendRequest", { message: message }, (data) => {
        if (data.success) {
            toastr.success(data.message);
        }
        else {
            toastr.error(data.message);
        }
    });
}