// Register controller
var importBill = angular.module('DAGStore.importBill');
importBill.controller('importBillListController', importBillListController);

// Controller
function importBillListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Hóa Đơn Nhập",
        urlPage: "import-bill",
        nameDataTable: "DAGStoreDatatable",
        data: "/import-bill/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Mã HDN" },
            { targets: 3, name: "Tên nhà cung cấp" },
            { targets: 4, name: "Tổng hóa đơn", visible: false },
            { targets: 5, name: "Tổng giảm giá", visible: false },
            { targets: 6, name: "Thanh toán" },
            { targets: 7, name: "Mô tả", visible: false },
            { targets: 8, name: "Trạng thái" },
            { targets: 9, name: "Ngày tạo" },
            { targets: 10, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6,7],
            orthogonal: 'export'
        },
    }
    // Get Data
    $scope.importbills = [];
    apiService.get("/importbill/getlist", null, function (result) {

        $scope.importbills = result.data;
        dataTableService.createDataTable($scope.config);

        console.log($scope.importbills);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.DeleteImportBill = DeleteImportBill;
    function DeleteImportBill(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/importbill/delete", config, function (success) {
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