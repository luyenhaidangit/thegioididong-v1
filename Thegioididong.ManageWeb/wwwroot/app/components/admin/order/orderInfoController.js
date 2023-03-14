// Register controller
var order = angular.module('DAGStore.order');
order.controller('orderInfoController', orderInfoController);

// Controller
function orderInfoController($scope, apiService, notificationService, $stateParams) {
    //Config
    $scope.config = {
        nameManage: "Đơn Hàng Đặt",
        urlManage: "info-order",
        namePage: "Chi Tiết Đơn Hàng Đặt",
    }

    // Load Product Detail
    $scope.order = {
    }
    apiService.get("/order/getbyid/" + $stateParams.id, null, function (result) {
        $scope.order = result.data;
        apiService.get("/orderitem/GetOrderItemsByOrder/" + $stateParams.id, null, function (result) {
            $scope.order.OrderItems = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
        apiService.get("/customer/getbyid/" + $scope.order.CustomerID, null, function (result) {
            $scope.order.Customer = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
        console.log($scope.order)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })
}