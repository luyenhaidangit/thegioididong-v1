// Register controller
var app = angular.module("DAGStore.common");
app.controller("mainNavigationController", mainNavigationController);

// Controller
function mainNavigationController($scope, apiService) {
    // Get Data
    $scope.categorys = [];
    apiService.get("/index/ShowCategoryNavigation", null, function (result) {
        $scope.categorys = result.data;
    }, function (error) {
        console.log("Get data fail");
    })
};