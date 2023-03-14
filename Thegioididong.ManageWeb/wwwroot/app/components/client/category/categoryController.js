// Register controller
var category = angular.module('DAGStoreHome.category');
category.controller('categoryController', categoryController);

// Controller
function categoryController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    var numberProduct = 10;
    // Load Category Detail
    $scope.category = {
    }
    $scope.LoadCategoryDetail = LoadCategoryDetail;
    function LoadCategoryDetail() {
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadCategoryDetail();

    
    // Load List Product Of Category
    $scope.brands = [];
    $scope.products = [];
    apiService.get("/product/GetProductsByCategory/" + $stateParams.id, null, function (result) {
        $scope.products = result.data;
        $scope.productsShow = $scope.products.slice(0, $scope.numberProduct);
        $scope.brands = result.data.map((item) => {
            return item.BrandProduct;
        }).filter((v, i, a) => a.findIndex(v2 => (v2.ID === v.ID)) === i);
        console.log($scope.brands)
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    //Load More Product
    $scope.LoadMoreProduct = LoadMoreProduct;
    $scope.numberProduct = 10;
    function LoadMoreProduct() {
        $scope.numberProduct += 10;
        FilterProduct();
    }

    //Filter Product
    $scope.FilterProduct = FilterProduct;
    function FilterProduct() {
        $scope.productsShow = $scope.products
            .filter(x => $scope.brandFilter == null ? true : x.BrandProduct.ID == $scope.brandFilter)
            .filter(x => x.PriceProduct >= $scope.priceStart && x.PriceProduct <= $scope.priceEnd)
            .slice(0, $scope.numberProduct);
    }

    //Filter Product By Brand
    $scope.brand = {
    }
    $scope.FilterProductByBrand = FilterProductByBrand;
    $scope.brand.Name = "Hãng";
    $scope.brandFilter = null;
    function FilterProductByBrand(item) {
        $scope.brandFilter = item.ID;
        $scope.brand = item;
        FilterProduct();
    }
    $scope.CloseFilterProductByBrand = CloseFilterProductByBrand;
    function CloseFilterProductByBrand() {
        $scope.brand.Name = "Hãng";
        $scope.brandFilter = true;
        /*$scope.productsShow = $scope.products.filter(x => x.BrandProduct.ID === !true).slice(0, $scope.numberProduct);*/
        $scope.productsShow = $scope.products.slice(0, $scope.numberProduct);
    }
    
    //Filter Product By Price
    $scope.price = {

    }
    $scope.price.Name = "Giá";
    $scope.priceStart = 0;
    $scope.priceEnd = Infinity;
    $scope.FilterProductByPrice = FilterProductByPrice;
    function FilterProductByPrice(start, end) {
        $scope.priceStart = start;
        $scope.priceEnd = end;
        $scope.price.Name = "Từ " + $filter('formatCurrencyVND')(start) + " - " + $filter('formatCurrencyVND')(end);
        FilterProduct();
    }
    //$scope.GetProductsOfCategory = GetProductsOfCategory;
    //function GetProductsOfCategory() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { CategoryID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfCategory();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}