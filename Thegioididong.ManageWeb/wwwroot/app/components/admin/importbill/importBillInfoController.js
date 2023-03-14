// Register controller
var importbill = angular.module('DAGStore.importBill');
importbill.controller('importBillInfoController', importBillInfoController);

// Controller
function importBillInfoController($scope, apiService, notificationService, $stateParams) {
    //Config
    $scope.config = {
        nameManage: "Hóa Đơn Nhập",
        urlManage: "info-import-bill",
        namePage: "Chi Tiết Hóa Đơn",
    }
    
    // Load Product Detail
    $scope.importbill = {
    }
    apiService.get("/importbill/getinfo/" + $stateParams.id, null, function (result) {
        $scope.importbill = result.data;
        console.log("ok")
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })
}