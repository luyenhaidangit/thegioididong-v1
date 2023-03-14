// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandInfoController', brandInfoController);

// Controller
function brandInfoController($scope, apiService, notificationService, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Hãng sản phẩm",
        urlManage: "brand",
        namePage: "Thông Tin Chi Tiết",
    }

    // Load brand Detail
    $scope.brand = {
    }
    apiService.get("/brand/getbyid/" + $stateParams.id, null, function (result) {
        $scope.brand = result.data;
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");
}