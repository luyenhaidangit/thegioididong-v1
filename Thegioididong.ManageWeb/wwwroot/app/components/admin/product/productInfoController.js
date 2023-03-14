// Register controller
var product = angular.module('DAGStore.product');
product.controller('productInfoController', productInfoController);

// Controller
function productInfoController($scope, apiService, notificationService, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Sản Phẩm",
        urlManage: "product",
        namePage: "Thông Tin Chi Tiết",
    }

    // Load Product Detail
    $scope.product = {
    }
    apiService.get("/product/GetProductDetail/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");
}