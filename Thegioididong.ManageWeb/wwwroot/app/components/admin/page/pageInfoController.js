// Register controller
var page = angular.module('DAGStore.page');
page.controller('pageInfoController', pageInfoController);

// Controller
function pageInfoController($scope, apiService, notificationService, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Trình Tạo Trang",
        urlManage: "page",
        namePage: "Thông Tin Chi Tiết",
    }

    // Load page Detail
    $scope.page = {
    }
    apiService.get("/page/getbyid/" + $stateParams.id, null, function (result) {
        $scope.page = result.data;
        angular.element(document).ready(function () {
            CKEDITOR.instances["DAGStoreTextArea"].setData($scope.page.Content);
        });
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");
}