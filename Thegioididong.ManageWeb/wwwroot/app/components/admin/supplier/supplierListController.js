// Register controller
var supplier = angular.module('DAGStore.supplier');
supplier.controller('supplierListController', supplierListController);

// Controller
function supplierListController($scope, apiService, dataTableService, notificationService, alertService) {

    // Get Data
    $scope.suppliers = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/supplier/getall", null, function (result) {

            $scope.suppliers = result.data;
            dataTableService.createDataTable("DAGStoreDatatable");
            
            console.log($scope.suppliers);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.Deletesupplier = Deletesupplier;
    function Deletesupplier(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/supplier/delete", config, function (success) {
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