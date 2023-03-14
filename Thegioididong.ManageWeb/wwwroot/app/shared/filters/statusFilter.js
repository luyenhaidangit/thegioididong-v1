

(function (app) {
    app.filter("statusFilter",function(){
        return function(input){
            if(input===true){
                return "Hoạt động";
            }else{
                return "Ngừng hoạt động";
            }
        }
    })

    app.filter("importBillFilter", function () {
        return function (input) {
            if (input === true) {
                return "Phiếu nhập";
            } else {
                return "Phiếu hủy";
            }
        }
    })

    app.filter("existDataFilter", function () {
        return function (input) {
            if (input === null) {
                return "---";
            } else {
                return input;
            }
        }
    });

    app.filter("formatJsonDate", function () {
        return function (input) {

            function convert(str) {
                var date = new Date(str),
                    mnth = ("0" + (date.getMonth() + 1)).slice(-2),
                    day = ("0" + date.getDate()).slice(-2);
                 return [day,mnth,date.getFullYear()].join("-");
                /*return [day, mnth, date.getFullYear()].join("-");*/
            }

            return convert(new Date(parseInt(input.substr(6))));
        }
    });

    app.filter("formatCurrencyVND", function () {
        return function (input) {
            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(input);
        }
    });

    app.filter("paymentFormat", function () {
        return function (input) {
            if (input === 0) {
                return "Trả tiền khi nhận hàng";
            } else {
                return "Thanh toán Momo";
            }
        }
    });
    app.filter("statusOrderFormat", function () {
        return function (input) {
            if (input === 0) {
                return "Chưa xử lý";
            } else if (input === 1) {
                return "Đã xử lý";
            } else {
                return "Đã nhận hàng"
            }
        }
    });

    app.filter("nullImage", function () {
        return function (input) {
            if (input) {
                return input;
            } else {
                return "/Upload/images/Slider/IndexMain/null-va-mot-so-nghia-thong-dung.png";
            }
        }
    });
})(angular.module('DAGStore.common'));