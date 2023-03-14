// Register controller
var discount = angular.module('DAGStore.discount');
discount.controller('discountInfoController', discountInfoController);

// Controller
function discountInfoController($scope, apiService, notificationService, $stateParams) {
    // Load discount Detail
    $scope.discount = {
    }
    $scope.LoaddiscountDetail = LoaddiscountDetail;
    function LoaddiscountDetail() {
        apiService.get("/discount/getbyid/" + $stateParams.id, null, function (result) {
            $scope.discount = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoaddiscountDetail();
}