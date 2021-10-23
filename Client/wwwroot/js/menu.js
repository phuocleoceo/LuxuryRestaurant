function AddToCart(FoodId) {
    $.post("Cart/AddToCart", { FoodId: FoodId }, (data) => {
        if (data.success) {
            toastr.success(data.message);
        }
        else {
            toastr.error(data.message);
        }
    });
}