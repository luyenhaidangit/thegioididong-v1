// Register controller
var slider = angular.module('DAGStore.slider');
slider.controller('sliderListController', sliderListController);

// Controller
function sliderListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Slider",
        urlPage: "slider",
        nameDataTable: "DAGStoreDatatable",
        data: "/slider/getdata",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Tiêu đề" },
            { targets: 3, name: "Vị trí" },
            { targets: 4, name: "Trang" },
            { targets: 5, name: "Kiểu slider" },
            { targets: 6, name: "Màu nền", visible: false },
            { targets: 7, name: "Độ ưu tiên", visible: false },
            { targets: 8, name: "Trạng thái" },
            { targets: 9, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7,8],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.sliders = [];
    $scope.getItems = getItems;
    function getItems() {
        apiService.get("/slider/getall", null, function (result) {

            $scope.sliders = result.data;
            dataTableService.createDataTable($scope.config);
            
            console.log($scope.sliders);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.getItems();

    $scope.AddSliderItemTop = AddSliderItemTop;
    function AddSliderItemTop() {
        console.log("om")
        var item = {
            SliderID: 1,
            ImagePath: "",
            URL: "#",
            DisplayOrder: -1,
        }
        $scope.sliders[0].SliderItems.push(item); 
    }

    $scope.ChangeImage = ChangeImage;
    function ChangeImage(item) {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            item.ImagePath = fileUrl;
            $scope.$apply();
        }
        finder.popup();
      
    }

    $scope.DeleteImage = DeleteImage;
    function DeleteImage(value) {
        $scope.sliders[0].SliderItems = $scope.sliders[0].SliderItems.filter(function (item) {
            return item !== value
        })
        
    }

    $scope.RemoveDetailBill = RemoveDetailBill;
    function RemoveDetailBill(value) {
        $scope.products.push(value.ProductDetail);
        
        InvoiceTotalProcessing();
    }

    $scope.UpdateSlider = UpdateSlider;
    function UpdateSlider() {
        console.log($scope.sliders)
        for (let i = 0; i < $scope.sliders.length; i++) {
            apiService.put("/slider/update", $scope.sliders[i], function (result) {
               
            }, function (error) {
          
            });
        }
        console.log("ok")
        notificationService.displaySuccess("Cập nhật thông tin thành công!");
        //apiService.put("/slider/update", $scope.sliders, function (result) {
        //    notificationService.displaySuccess("Cập nhật thông tin thành công!");
        //}, function (error) {
        //    notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        //});
    }
}