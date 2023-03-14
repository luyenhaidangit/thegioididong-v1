// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryEditController', categoryEditController);

// Controller
function categoryEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Loại Sản Phẩm",
        urlManage: "category",
        namePage: "Sửa Thông Tin",
    }

    // Load Category Detail
    $scope.category = {
    }
    apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
        $scope.category = result.data;
        console.log($scope.category)
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    // Load Parent Category
    $scope.parentCategory = {};
    $scope.categorys = [];
    apiService.get("/category/getall", null, function (result) {
        $scope.categorys = result.data.filter(x => x.ID !== $scope.category.ID);
        $scope.parentCategory = $scope.categorys.filter(x => x.ID === $scope.category.ParentCategoryID)[0];
        dropdownService.createDefaultDropdown("#parentCategory");
    }, function (error) {
        console.log("Get data fail");
    })

    // Choose Image Avatar
    $scope.statusChooseAvatar1 = true;
    $scope.statusChooseAvatar2 = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status,type) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                if (type == 1) {
                    $scope.category.PicturePath = fileUrl;
                    $("img[name=picturepath]").attr("src", $scope.category.PicturePath);
                    $scope.statusChooseAvatar1 = true;
                    $scope.$apply();
                } else {
                    $scope.category.PictureAvatar = fileUrl;
                    $("img[name=pictureavatar]").attr("src", $scope.category.PictureAvatar);
                    $scope.statusChooseAvatar2 = true;
                    $scope.$apply();
                }
            }
            finder.popup();
        }
        if (status === false) {
            if (type == 1) {
                $scope.category.PicturePath = "";
                $scope.statusChooseAvatar1 = false;
                $scope.$apply();
            } else {
                $scope.category.PictureAvatar = "";
                $scope.statusChooseAvatar2 = false;
                $scope.$apply();
            }
            
        }
    }

    // Register Description TextArea
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit
    $scope.UpdateCategory = UpdateCategory;
    function UpdateCategory() {
        // Set Value
        $scope.category.ParentCategoryID = document.getElementsByName("parentcategoryid")[0].value;
        $scope.category.Description = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Edit Value
        apiService.put("/category/update", $scope.category, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.category)
        });
    }
}