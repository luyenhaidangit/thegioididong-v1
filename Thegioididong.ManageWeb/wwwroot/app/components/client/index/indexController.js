// Register controller
var index = angular.module('DAGStoreHome.index');
index.controller('indexController', indexController);

// Controller
function indexController($scope, apiService, sliderService, $rootScope, $timeout, $state) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    
    // Get Slider
    $scope.sliders = [];
    apiService.get("/index/showslider", null, function (result) {
        $scope.sliders = result.data;  
    }, function (error) {
        console.log("Get data fail");
    })

    //Get Event
    $scope.events = [];
    apiService.get("/index/getevents", null, function (result) {
        $scope.events = result.data;
        console.log($scope.events)
        var config = {
            selector: ".event__swiper",
            prebutton: ".event__button-prev",
            nextbutton: ".event__button-next",
        }

        sliderService.createSliderEvent(config)
    }, function (error) {
        console.log("Get data fail");
    })                                        

    // Get Suggest
    $scope.suggests = [];
    apiService.get("/index/getsuggests", null, function (result) {
        $scope.suggests = result.data;
        var setup = $scope.suggests.filter(x => x.Type == 0).map((item) => {
            var config = {
                selector: ".suggest__swiper.suggest__swiper__" + item.ID,
                prebutton: ".suggest__button-prev__" + item.ID,
                nextbutton: ".suggest__button-next__" + item.ID,
            }

            sliderService.createSliderProduct(config)
        })
    }, function (error) {
        console.log("Get data fail");
    })

    // Get Category
    $scope.categories = [];
    apiService.get("/index/getcategories", null, function (result) {
        $scope.categories = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    // Get Discount
    $scope.discounts = [];
    apiService.get("/index/getdiscounts", null, function (result) {
        $scope.discounts = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    // Get Product News
    $scope.productsNew = [];
    apiService.get("/index/GetProductsNewShowHomePage", null, function (result) {

        $scope.productsNew = result.data;

    }, function (error) {
        console.log("Get data fail");
    })

    // Get Product Discount
    $scope.productsDiscount = [];
    apiService.get("/index/GetProductsDiscountShowHomePage", null, function (result) {

        $scope.productsDiscount = result.data;
        console.log($scope.productsDiscount)

    }, function (error) {
        console.log("Get data fail");
    })

    // Get Product View
    $scope.productsView = [];
    apiService.get("/index/GetProductsViewCountShowHomePage", null, function (result) {

        $scope.productsView = result.data;

    }, function (error) {
        console.log("Get data fail");
    })

    // Get Product View
    $scope.news = [];
    apiService.get("/index/getnews", null, function (result) {

        $scope.news = result.data;

    }, function (error) {
        console.log("Get data fail");
    })

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 700);
    });
}
