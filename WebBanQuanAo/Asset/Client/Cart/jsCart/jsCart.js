


var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        //$('#btnMuaHang').off('click').on('click', function () {

        //    window.location.href = "/";
        //});

        //$('#btnThanhToan').off('click').on('click', function () {

        //    window.location.href = "/thanh-toan";
        //});

        $('#btnCapNhat').off('click').on('click', function () {
            var listProduct = $('.txtquantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        ma: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/UpdateCart',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        windown.location.href = "/gio-hang";
                    }
                }
            });
        });

        //$('#btnXoaGio').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    $.ajax({
        //        url: '/Cart/DeleteAll',
        //        dataType: 'json',
        //        type: 'POST',
        //        success: function (res) {
        //            if (res.status == true) {
        //                windown.location.href = "/gio-hang";
        //            }
        //        }
        //    });
        //});

        //$('#btnXoaSP').off('click').on('click', function () {
        //    $.ajax({
        //        data: { id: $(this).data('id') },
        //        url: '/Cart/Delete',
        //        dataType: 'json',
        //        type: 'POST',
        //        success: function (res) {
        //            if (res.status == true) {
        //                windown.location.href = "/gio-hang";
        //            }
        //        }
        //    })
        //});
    }
}


cart.init();
