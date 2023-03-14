// Register controller
var page = angular.module('DAGStore.page');
page.controller('pageAddController', pageAddController);

// Controller
function pageAddController($scope, apiService, notificationService, $state, ckeditorService) {
    //Config
    $scope.config = {
        nameManage: "Trình tạo trang",
        urlManage: "page",
        namePage: "Thêm Mới",
    }

    // Load Parent page
    $scope.pages = [];
    apiService.get("/page/getall", null, function (result) {
        $scope.pages = result.data;
    }, function (error) {
        console.log("Get data fail");
    })

    // Default Value
    $scope.page = {
        Alias:"page",
    }

    // Choose Image Avatar
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.brand.AvatarPath = fileUrl;
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }
            finder.popup();
        }
        if (status === false) {
            $scope.brand.AvatarPath = null;
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Add
    $scope.AddPage = AddPage;
    function AddPage() {
        // Set Value
        $scope.page.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();
        console.log($scope.page)
        // Add Value
        apiService.post("/page/create", $scope.page, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("page");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
        });
    }
}