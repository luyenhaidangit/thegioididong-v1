// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryInfoController', categoryInfoController);

// Controller
function categoryInfoController($scope, apiService, notificationService, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Loại Sản Phẩm",
        urlManage: "category",
        namePage: "Thông Tin Chi Tiết",
    }

    // Load category Detail
    $scope.category = {
    }
    apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
        $scope.category = result.data;
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Load Parent Category
    $scope.parentCategory = {};
    $scope.categorys = [];
    apiService.get("/category/getdata", null, function (result) {
        $scope.categorys = result.data.filter(x => x.ID !== $scope.category.ID);
        $scope.parentCategory = $scope.categorys.filter(x => x.ID === $scope.category.ParentCategoryID)[0];
        console.log($scope.category)
    }, function (error) {
        console.log("Get data fail");
    })

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");
}