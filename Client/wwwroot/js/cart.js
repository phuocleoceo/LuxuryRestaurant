$(window).on('load', function () {
	loadCartList();
});

function loadCartList() {
	$.ajax({
		dataType: "json",
		type: "GET",
		url: "/Cart/GetAll"
	}).done((data) => {
		$('#total-price').html(`${data.total}`);
		$('.box-container').empty();
		data.listCart.forEach((cart) => {
			$('.box-container').append(
				`<div class="box">
                        <button onclick="RemoveCart(${cart.id})">
                            <i class="fas fa-times"></i>
                        </button>
                        <img src="${cart.image}" alt="">
                        <div class="content">
                            <h3>${cart.foodName}</h3>
                            <span> Số lượng : </span> <br>
                            <input type="button" value="-" onclick="MinusCart(${cart.id})">
                            <p class="quatity">${cart.count}</p>
                            <input type="button" value="+" onclick="PlusCart(${cart.id})">
                            <br>
                            <span> Giá : </span>
                            <span class="price"> ${cart.foodPrice} </span>
                        </div>
                    </div>`
			);
		})
	});
}

function PlusCart(CartId) {
	$.post("Cart/PlusCart", { CartId: CartId }, (data) => {
		if (data.success) {
			loadCartList();
		}
		else {
			toastr.error(data.message);
		}
	});
}

function MinusCart(CartId) {
	$.post("Cart/MinusCart", { CartId: CartId }, (data) => {
		if (data.success) {
			loadCartList();
		}
		else {
			toastr.error(data.message);
		}
	});
}

function RemoveCart(CartId) {
	$.post("Cart/RemoveCart", { CartId: CartId }, (data) => {
		if (data.success) {
			loadCartList();
		}
		else {
			toastr.error(data.message);
		}
	});
}

function PlaceOrder(CartId) {
	$.post("Cart/PlaceOrder", {}, (data) => {
		if (data.success) {
			toastr.success(data.message);
			loadCartList();
		}
		else {
			toastr.error(data.message);
		}
	});
}

