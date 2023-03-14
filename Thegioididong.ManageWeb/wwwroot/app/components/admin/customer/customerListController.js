// Register controller
var customer = angular.module('DAGStore.customer');
customer.controller('customerListController', customerListController);

// Controller
function customerListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Khách hàng",
        urlPage: "customer",
        nameDataTable: "DAGStoreDatatable",
        data: "/customer/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Tên khách hàng" },
            { targets: 3, name: "Số điện thoại" },
            { targets: 4, name: "Email" },
            { targets: 5, name: "Địa chỉ" },
            { targets: 6, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.customers = [];
    apiService.get("/customer/getall", null, function (result) {
        $scope.customers = result.data;
        console.log($scope.customers)
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.Deletecustomer = Deletecustomer;
    function Deletecustomer(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/customer/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                    alertService.alertDeleteSuccess();
                }, function (error) {
                    var message = error.data.split('<title>').pop().split('<br>')[0];
                    console.log(message)
                    if (message === 'That bai,chi xoa được nhung nhom hang khong chua hang hoa nao') {
                        alertService.alertDeleteError("Chỉ xóa được những nhóm hàng không chứa sản phẩm nào!");
                    }
                    if (message === 'That bai,chi xoa được nhung nhom hang khong chua nhom hang con') {
                        alertService.alertDeleteError("Chỉ xóa được những nhóm hàng không chứa nhóm hàng con nào!");
                    }
                })
            }
        });
    }
}