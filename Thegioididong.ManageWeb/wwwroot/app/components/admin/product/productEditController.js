// Register controller
var product = angular.module('DAGStore.product');
product.controller('productEditController', productEditController);

// Controller
function productEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService, $filter, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Sản Phẩm",
        urlManage: "product",
        namePage: "Sửa Thông Tin",
    }

    //Load Product Detail
    $scope.product = {
    }
    apiService.get("/product/GetProductDetail/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        angular.element(document).ready(function () {
            CKEDITOR.instances["DAGStoreTextArea"].setData($scope.product.FullDescription);
        });
        
        console.log($scope.product)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    //Load List Brand
    $scope.brands = [];
    apiService.get("/brand/getdata", null, function (result) {
        $scope.brands = result.data;
        dropdownService.createDefaultDropdown("#brand");
    }, function (error) {
        console.log("Get data fail");
    })

    //Load List Category
    $scope.categorys = [];
    apiService.get("/category/getdata", null, function (result) {
        $scope.categorys = result.data;
        dropdownService.createDefaultDropdown("#category");
    }, function (error) {
        console.log("Get data fail");
    })

    // Choose Avatar Product
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.product.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Choose Image Product
    $scope.statusChooseImageProduct = true;
    $scope.ChooseImageProduct = ChooseImageProduct;
    function ChooseImageProduct(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                var item = {
                    Index: $scope.product.ImageProducts.length,
                    ImagePath: fileUrl,
                }
                $scope.product.ImageProducts.push(item);
                $scope.statusChooseImageProduct = true;
                $scope.$apply();
                console.log($scope.product.ImageProducts)
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.ImageProducts = [];
            $scope.statusChooseImageProduct = false;
            $scope.$apply();
        }
    }

    // Regster Ckeditor
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit Product
    $scope.EditProduct = EditProduct;
    function EditProduct() {
        console.log($scope.product)
        $scope.product.BrandID = document.getElementsByName("brandid")[0].value;
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
        $scope.product.FullDescription = CKEDITOR.instances['DAGStoreTextArea'].getData();
        
        apiService.put("/product/update", $scope.product, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            console.log($scope.product)
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });
    }
}