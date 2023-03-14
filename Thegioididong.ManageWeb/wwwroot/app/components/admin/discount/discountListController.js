// Register controller
var discount = angular.module('DAGStore.discount');
discount.controller('discountListController', discountListController);

// Controller
function discountListController($scope, apiService, dataTableService, notificationService, alertService) {

    // Get Data
    $scope.discounts = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/discount/getall", null, function (result) {

            $scope.discounts = result.data;
            dataTableService.createDataTable("DAGStoreDatatable");
            
            console.log($scope.discounts);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    // Delete Object
    $scope.DeleteDiscount = DeleteDiscount;
    function DeleteDiscount(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/discount/delete", config, function (success) {
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