// Register controller
var discount = angular.module('DAGStore.discount');
discount.controller('discountAddController', discountAddController);

// Controller
function discountAddController($scope, apiService, notificationService, $state, ckeditorService) {
    // Default Value
    $scope.discount = {
        UsePercentage: false,
    }

    // Choose Image Avatar
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        console.log($scope.discounts)
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.discount.PicturePath = fileUrl;
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }
            finder.popup();
        }
        if (status === false) {
            $scope.discount.PicturePath = null;
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }
    

    // Submit Add
    $scope.AddDiscount = AddDiscount;
    function AddDiscount() {
        console.log("ok")
        // Add Value
        apiService.post("/discount/create", $scope.discount, function (result) {
            
            notificationService.displaySuccess("Thêm thông tin thành công!");

            $state.go("discount");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.discount);
        });
    }
}