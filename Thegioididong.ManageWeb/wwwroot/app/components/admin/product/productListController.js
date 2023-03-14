// Register controller
var product = angular.module('DAGStore.product');
product.controller('productListController', productListController);

// Controller
function productListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Sản Phẩm",
        urlPage: "product",
        nameDataTable: "DAGStoreDatatable",
        data: "/product/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:32px;">'
            }},
            { targets: 3, name: "Tên sản phẩm" },
            { targets: 4, name: "Mô tả ngắn", visible: false },
            { targets: 5, name: "Mô tả", visible: false },
            { targets: 6, name: "Mô tả khuyến mãi", visible: false },
            { targets: 7, name: "Loại sản phẩm", visible: false },
            { targets: 8, name: "Hãng sản phẩm", visible: false },
            { targets: 9, name: "Giá nhập" },
            { targets: 10, name: "Giá bán" },
            { targets: 11, name: "Tồn kho" },
            { targets: 12, name: "Số lượng tồn tối thiểu", visible: false },
            { targets: 13, name: "Số lượng tồn tối đa", visible: false },
            { targets: 14, name: "Độ ưu tiên", visible: false },
            { targets: 15, name: "Trạng thái" },
            { targets: 16, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14],
            orthogonal: 'export'
        },
    }

    // Get data
    $scope.products = [];
    apiService.get("/product/getdata", null, function (result) {
        $scope.products = result.data;
        dataTableService.createDataTable($scope.config);

    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.DeleteProduct = DeleteProduct;
    function DeleteProduct(e, id) {
        console.log($(e.currentTarget).parents('tr').index());
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {

                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/product/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    console.log($(e.currentTarget).parents('tr').index());
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                }, function (error) {
                    console.log("Xóa không thành công!")
                })
                alertService.alertDeleteSuccess();
            }
        });
    }
}