// Register controller
var page = angular.module('DAGStore.page');
page.controller('pageEditController', pageEditController);

// Controller
function pageEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Trình Tạo Trang",
        urlManage: "page",
        namePage: "Sửa Thông Tin",
    }

    // Load page Detail
    $scope.page = {
    }
    apiService.get("/page/getbyid/" + $stateParams.id, null, function (result) {
        $scope.page = result.data;
        angular.element(document).ready(function () {
            CKEDITOR.instances["DAGStoreTextArea"].setData($scope.page.Content);
        });
        console.log($scope.page)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

   
    // Choose Avatar Product
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.AvatarPath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.product.AvatarPath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.AvatarPath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit
    $scope.UpdatePage = UpdatePage;
    function UpdatePage() {
        // Set Value
        $scope.page.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Edit Value
        apiService.put("/page/update", $scope.page, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("page");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.page)
        });
    }
}