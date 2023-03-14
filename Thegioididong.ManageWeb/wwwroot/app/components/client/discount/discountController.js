// Register controller
var discount = angular.module('DAGStoreHome.discount');
discount.controller('discountController', discountController);

// Controller
function discountController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    

    //// Load discount Detail
    //$scope.discount = {
    //}
    //$scope.LoaddiscountDetail = LoaddiscountDetail;
    //function LoaddiscountDetail() {
    //    apiService.get("/discount/getbyid/" + $stateParams.id, null, function (result) {
    //        $scope.discount = result.data;
    //    }, function (error) {
    //        notificationService.displaySuccess("Không thể tải dữ liệu");
    //    })
    //}
    //$scope.LoaddiscountDetail();

    //// Load List Product Of discount
    //$scope.products = [];
    //$scope.GetProductsOfdiscount = GetProductsOfdiscount;
    //function GetProductsOfdiscount() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { discountID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfdiscount();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}