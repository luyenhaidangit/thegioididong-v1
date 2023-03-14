// Register controller
var discount = angular.module('DAGStore.discount');
discount.controller('discountEditController', discountEditController);

// Controller
function discountEditController($scope, apiService, notificationService, $state, $stateParams) {

    // Load discount Detail
    $scope.discount = {
    }
    $scope.LoadDiscountDetail = LoadDiscountDetail;
    function LoadDiscountDetail() {
        apiService.get("/discount/getbyid/" + $stateParams.id, null, function (result) {
            $scope.discount = result.data;
            console.log($scope.discount)
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadDiscountDetail();

    // Choose Image Avatar
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.discount.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.discount.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.discount.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Submit Edit
    $scope.EditDiscount = EditDiscount;
    function EditDiscount() {

        // Edit Value
        apiService.put("/discount/update", $scope.discount, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("discount");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.discount)
        });
    }
}