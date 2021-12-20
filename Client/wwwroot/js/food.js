$(function () {
    $("#food-table").dataTable();
})

function Delete(_url) {
    //Sweet Alert
    swal({
        title: "Xác nhận xoá món ăn ?",
        text: "Hành động này không thể hoàn tác !",
        icon: "warning",
        button: true,
        showCancelButton: true,
        dangerMode: true
    }).then((obj) => {
        if (obj) {
            $.ajax({
                type: 'DELETE',
                url: _url,
                success: function (data) {
                    //success and message from Delete Controller
                    if (data.success) {
                        toastr.success(data.message);
                        location.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}