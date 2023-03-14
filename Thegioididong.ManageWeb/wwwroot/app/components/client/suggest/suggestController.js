// Register controller
var suggest = angular.module('DAGStoreHome.suggest');
suggest.controller('suggestController', suggestController);

// Controller
function suggestController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    

    //// Load suggest Detail
    //$scope.suggest = {
    //}
    //$scope.LoadsuggestDetail = LoadsuggestDetail;
    //function LoadsuggestDetail() {
    //    apiService.get("/suggest/getbyid/" + $stateParams.id, null, function (result) {
    //        $scope.suggest = result.data;
    //    }, function (error) {
    //        notificationService.displaySuccess("Không thể tải dữ liệu");
    //    })
    //}
    //$scope.LoadsuggestDetail();

    //// Load List Product Of suggest
    //$scope.products = [];
    //$scope.GetProductsOfsuggest = GetProductsOfsuggest;
    //function GetProductsOfsuggest() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { suggestID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfsuggest();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}