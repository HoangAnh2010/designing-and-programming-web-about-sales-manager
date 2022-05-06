//hàm phân cách tiền phần nghìn
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

//hàm hiển thị giỏ hàng (popup)
function displayCart() {
    $.get("/GioHang/loadGioHang", function (data) {
        $("#count-cart").html(data.soluong);
        $("#total_price").html(numberWithCommas(data.tongtien));
        $("#show-cart").html("");
        $.each(data.giohang, function (i, val) {
            var thanhtien = val.SL * val.Gia;
            $("#show-cart").append("<tr class='cart_item'>\
                <td class='product-remove'>\
                    <div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>\
                </td>\
                <td class='product-name'>\
                    <b>" + val.Ten + "</b>\
                    <div class='clr'></div>\
                    <div class='box_quantity left'>\
                        <div class='quantity right'>\
                            <input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>\
                            <input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>\
                            <input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>\
                        </div>\
                    </div>\
                </td>\
                <td class='product-price' valign='top'>\
                    <span class='amount'>" + numberWithCommas(thanhtien) + "</span>\
                </td>\
                </tr>")
        });
    });
}
//hiển thị trang giỏ hàng (view)
function displayPageCart() {
    $.get("/GioHang/loadGioHang", function (data) {
        $("#count-item-cart").html(data.soluong);
        $("#total-item-price").html(numberWithCommas(data.tongtien));
        $("#show-item-cart").html("");
        $.each(data.giohang, function (i, val) {
            var thanhtien = val.SL * val.Gia;
            $("#show-item-cart").append("<tr>"
                + "<td class='cart_product'>"
                + "<a href='#'><img src='/Content/images/product-detail/" + val.Anh + "' alt='Product'></a>"
                + "</td>"
                + "<td class='cart_description'>"
                + "<p class='product-name'><a href='#'>" + val.Ten + "</a></p>"
                + "<small class='cart_ref'>Product Code : " + val.ID + "</small>"
                + "<br>"
                + "</td>"
                + "<td class='price'><span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(val.Gia) + "</span></td>"
                + "<td class='qty'>"
                + "<input class='form-control input-sm' type='text' readonly value='" + val.SL + "'>"
                + "<a class='plus' data-product-code='" + val.ID + "'><i class='fa fa-caret-up'></i></a>"
                + "<a class='minus' data-product-code='" + val.ID + "'><i class='fa fa-caret-down'></i></a>"
                + "</td>"
                + "<td class='price'>"
                + "<span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(thanhtien) + "</span>"
                + "</td>"
                + "<td class='action'>"
                + "<a class='remove_product' data-product-code='" + val.ID + "'>Delete item</a>"
                + "</td>"
                + "</tr>");
        });
    });
}
//hàm chạy -->hàm main
$(document).ready(function () {
    displayCart();
    displayPageCart();

    $("#show-cart").on("click", ".bt_plus", function (event) {
        var productcode = $(this).attr("data-product-code");
        //gọi đến controller thêm
        $.get("/GioHang/tang1sp", { id: productcode }, function (data) {
            if (data.success == true) {
                displayCart();
            }
        });
    });

    $("#show-cart").on("click", ".bt_minus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/giam1sp", { id: productcode }, function (data) {
            if (data.success == true) {
                displayCart();
            }
        });
    });

    $("#show-cart").on("click", ".bt_remove_product", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/xoa1sp", { id: productcode }, function (data) {
            if (data.success == true) {
                displayCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".remove_product", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/xoa1sp", { id: productcode }, function (data) {
            if (data.success = true) {
                displayPageCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".minus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/giam1sp", { id: productcode }, function (data) {
            if (data.success = true) {
                displayPageCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".plus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/tang1sp", { id: productcode }, function (data) {
            if (data.success = true) {
                displayPageCart();
            }
        });
    });
});

//hàm thực hiện chức năng khởi tạo giỏ hàng
function muahang(id) {
    $.get("/GioHang/MuaHang", { id: id }, function (data) {
        $("#count-cart").html(data.soluong);
        $("#total_price").html(numberWithCommas(data.tongtien));
        $("#show-cart").html("");
        //duyệt các sản phẩm trong giỏ hàng, đến sản phẩm nào thì thêm vào bảng
        $.each(data.giohang, function (i, val) {
            $("#show-cart").append("<tr class='cart_item'>\
               <td class='product-remove'>\
                    <div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>\
                </td>\
                <td class='product-name'>\
                    <b>" + val.Ten + "</b>\
                    <div class='clr'></div>\
                    <div class='box_quantity left'>\
                        <div class='quantity right'>\
                            <input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>\
                            <input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>\
                            <input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>\
                        </div>\
                    </div>\
                </td>\
                <td class='product-price' valign='top'>\
                    <span class='amount'>" + numberWithCommas(val.SL * val.Gia) + "</span>\
                </td>\
                </tr>")
        });
    });
}
