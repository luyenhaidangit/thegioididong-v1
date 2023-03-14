// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandEditController', brandEditController);

// Controller
function brandEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Hãng Sản Phẩm",
        urlManage: "brand",
        namePage: "Sửa Thông Tin",
    }

    // Load brand Detail
    $scope.brand = {
    }
    apiService.get("/brand/getbyid/" + $stateParams.id, null, function (result) {
        $scope.brand = result.data;
        console.log($scope.brand)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Choose Image Avatar
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.brand.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.brand.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.brand.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit
    $scope.EditBrand = EditBrand;
    function EditBrand() {
        // Edit Value
        apiService.put("/brand/update", $scope.brand, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("brand");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.brand)
        });
    }
}