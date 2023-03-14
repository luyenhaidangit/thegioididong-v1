// Register controller
var news = angular.module('DAGStoreHome.news');
news.controller('newsController', newsController);

// Controller
function newsController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    

    //// Load news Detail
    //$scope.news = {
    //}
    //$scope.LoadnewsDetail = LoadnewsDetail;
    //function LoadnewsDetail() {
    //    apiService.get("/news/getbyid/" + $stateParams.id, null, function (result) {
    //        $scope.news = result.data;
    //    }, function (error) {
    //        notificationService.displaySuccess("Không thể tải dữ liệu");
    //    })
    //}
    //$scope.LoadnewsDetail();

    //// Load List Product Of news
    //$scope.products = [];
    //$scope.GetProductsOfnews = GetProductsOfnews;
    //function GetProductsOfnews() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { newsID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfnews();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}