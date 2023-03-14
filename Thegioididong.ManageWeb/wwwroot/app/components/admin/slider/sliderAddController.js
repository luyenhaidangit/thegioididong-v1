// Register controller
var slider = angular.module('DAGStore.slider');
slider.controller('sliderAddController', sliderAddController);

// Controller
function sliderAddController($scope, apiService, notificationService, $state, ckeditorService, dataTableService) {
    //Config
    $scope.config = {
        nameManage: "Slider",
        urlManage: "add-slider",
        namePage: "Thêm Mới",
    }
    $scope.slider = {
        SliderItems: [],
        TypeSlider: null,
        Page: null,
        BackgroundColor: null,
        DisplayOrder: -1,
        Status: true,
    }

    // Add Slider Detail
    $scope.AddSliderItem = AddSliderItem;
    function AddSliderItem() {
        console.log("ok")
        var item = {
            Content: null,
            ImagePath: null,
            URL: null,
            DisplayOrder: -1,
        }
        $scope.slider.SliderItems.push(item);
    }

    // Choose Image Product
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status,item) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
              /*  $scope.product.PicturePath = fileUrl;*/
                item.ImagePath = fileUrl;
              /*  $("img[name=picturepath]").attr("src", $scope.product.PicturePath);*/
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            item.ImagePath = "";
            $scope.statusChooseAvatar = false;
        }
        console.log($scope.slider.SliderItems)
    }

    //// Invoice Processing
    //$scope.InvoiceProcessing = InvoiceProcessing;
    //function InvoiceProcessing(index) {
    //    var result = ($scope.slider.sliderDetails[index].Quantity * $scope.slider.sliderDetails[index].ImportPrice) * (100 - $scope.slider.sliderDetails[index].Discount) / 100;
    //    $scope.slider.sliderDetails[index].TotalImportPrice = result;

    //    InvoiceTotalProcessing();
    //}

    //// Load List Brand
    //$scope.suppliers = [];
    //apiService.get("/supplier/getall", null, function (result) {
    //    $scope.suppliers = result.data;
    //}, function (error) {
    //    console.log("Get data fail");
    //})

    //// Invoice Total Processing
    //function Sum(items, prop) {
    //    return items.reduce(function (a, b) {
    //        return a + b[prop];
    //    }, 0);
    //};
    //$scope.InvoiceTotalProcessing = InvoiceTotalProcessing;
    //function InvoiceTotalProcessing() {
    //    $scope.slider.ActualPriceBill = Sum($scope.slider.sliderDetails, 'TotalImportPrice');
    //    var TotalPriceBill = 0;
    //    $scope.slider.sliderDetails.forEach(item => {
    //        TotalPriceBill += item.Quantity * item.ImportPrice;
    //    });
    //    $scope.slider.TotalPriceBill = TotalPriceBill;
    //    $scope.slider.TotalDiscount = $scope.slider.TotalPriceBill - $scope.slider.ActualPriceBill;
    //}

    //// Remove Detail Bill
    //$scope.RemoveDetailBill = RemoveDetailBill;
    //function RemoveDetailBill(value) {
    //    $scope.slider.sliderDetails = $scope.slider.sliderDetails.filter(function (item) {
    //        return item !== value
    //    })
    //    InvoiceTotalProcessing();
    //}

    //Choose Supplier Import Bill
    $scope.ChoosePositionSlider = ChoosePositionSlider;
    function ChoosePositionSlider(item, position) {
        $scope.slider.Position = position;
    }


    $scope.Addslider = Addslider;
    function Addslider() {
      /*  $scope.errorSupplier = $scope.slider.SupplierID == 0 ? true : false;*/
        console.log($scope.slider)
        apiService.post("/slider/create", $scope.slider, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("slider");
        }, function (error) {
                
        });
    }
}