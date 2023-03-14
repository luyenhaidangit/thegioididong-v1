// Register controller
var product = angular.module('DAGStoreHome.product');
product.controller('productController', productController);

// Controller
function productController($scope, apiService, $stateParams, $filter, notificationService, $state, $sce, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;

    // Load Product Detail
    $scope.product = {
    }
    $scope.productSuggestCategory = [];

    // Increase Views Product
    apiService.put("/product/IncreaseViewCount/" + $stateParams.id,null, function (success) {
        console.log("Tang view");
    }, function (error) {
        console.log("Xóa không thành công!")
    })

   /* $scope.category =*/
    apiService.get("/product/getproductdetail/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        console.log($scope.product)
        $scope.Message = $sce.trustAsHtml($scope.product.FullDescription);

        //Get Suggest Product Category
        // Get Product Suggest Category
        apiService.get("/product/GetProductsByCategory?id=" + $scope.product.CategoryID, null, function (result) {
            $scope.productSuggestCategory = result.data.filter((obj) => {
                return obj.IDProduct !== $scope.product.ID;
            });
            console.log($scope.productSuggestCategory)
            
        }, function (error) {
            console.log("Không thể tải dữ liệu");
        })
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    // Add Session Product Cart
    $scope.AddSessionProductCart = AddSessionProductCart;
    function AddSessionProductCart(id) {
        
        var config = {
            params: {
                id: id
            }
        }
        console.log(config.params)
        apiService.post("/cart/create", config.params, function (result) {
            console.log(config);
            notificationService.displaySuccess("Sản phẩm đã được thêm vào giỏ hàng!");
            $state.go("cart");
           /* $state.go("category");*/
        }, function (error) {
           /* notificationService.displaySuccess("Thêm mới không thành công!");*/
           /* console.log($scope.category);*/
        });
    }

    

    //Load Page
    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 600);
    });
}