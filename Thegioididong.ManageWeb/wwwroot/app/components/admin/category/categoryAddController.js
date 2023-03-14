// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryAddController', categoryAddController);

// Controller
function categoryAddController($scope, apiService, notificationService, $state, ckeditorService, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Loại Sản Phẩm",
        urlManage: "category",
        namePage: "Thêm Mới",
    }

    // Load Parent Category
    $scope.categorys = [];
    apiService.get("/category/getall", null, function (result) {
        $scope.categorys = result.data;
        dropdownService.createDefaultDropdown("#parentCategory");
    }, function (error) {
        console.log("Get data fail");
    })

    // Default Value
    $scope.category = {
        DisplayOrder: -1,
        Published: true,
        ShowOnHomePage: true,
    }

    // Choose Image Avatar
    $scope.statusChooseAvatar1 = true;
    $scope.statusChooseAvatar2 = true;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status, type) {
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

    // Submit Add
    $scope.AddCategory = AddCategory;
    function AddCategory() {
        // Set Value
        $scope.category.ParentCategoryID = document.getElementsByName("parentcategoryid")[0].value;
        $scope.category.Description = CKEDITOR.instances['DAGStoreTextArea'].getData();

        // Add Value
        apiService.post("/category/create", $scope.category, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
        });
    }
}