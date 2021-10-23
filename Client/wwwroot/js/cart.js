function PlusCart(CartId) {
    $.post("Cart/PlusCart", { CartId: CartId }, (data) => {
        if (data.success) {
            location.reload();
        }
        else {
            toastr.error(data.message);
        }
    });
}

function MinusCart(CartId) {
    $.post("Cart/MinusCart", { CartId: CartId }, (data) => {
        if (data.success) {
            location.reload();
        }
        else {
            toastr.error(data.message);
        }
    });
}

function RemoveCart(CartId) {
    $.post("Cart/RemoveCart", { CartId: CartId }, (data) => {
        if (data.success) {
            location.reload();
        }
        else {
            toastr.error(data.message);
        }
    });
}