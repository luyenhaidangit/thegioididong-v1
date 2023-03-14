// Register controller
var importbill = angular.module('DAGStore.importBill');
importbill.controller('importbillAddController', importbillAddController);

// Controller
function importbillAddController($scope, apiService, notificationService, $state, ckeditorService, dataTableService, dropdownService, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Hóa Đơn Nhập",
        urlManage: "add-import-bill",
        namePage: "Thêm Mới",
    }
    $scope.importbill = {
        SupplierID: 0,
        TotalPriceBill: 0,
        ActualPriceBill: 0,
        Discount: 0,
        Description: null,
        ImportBillCode: 'Code',
        CreateOn: '01-01-1990',
        Status: true,
        ImportBillDetails: [
            
        ],
    }

    //Load List Product
    $scope.products = [];
    apiService.get("/product/getall", null, function (result) {
        $scope.products = result.data;
        console.log($scope.products)
        angular.element(document).ready(function () {
            $("#importbill1").dropdown({
                action: 'select',
            });
        });
    }, function (error) {
        console.log("Get data fail");
    })

    // Add ImportBillDetail
    $scope.AddImportBillDetail = AddImportBillDetail;
    function AddImportBillDetail(item) {
        $scope.products.splice($scope.products.findIndex(a => a.ID === item.ID), 1)
        console.log(item)
        var item = {
            PicturePath: item.PicturePath,
            ProductName: item.Name,
            ImportBillID : null,
            ProductID: item.ID,
            Quantity: 1,
            ImportPrice: item.CostPrice,
            Discount: 0,
            TotalImportPrice: 0,
            ProductDetail: item,
        }
        item.TotalImportPrice = item.Quantity * item.ImportPrice - item.Discount
        $scope.importbill.ImportBillDetails.push(item);
        InvoiceTotalProcessing();
    }

    // Invoice Processing
    $scope.InvoiceProcessing = InvoiceProcessing;
    function InvoiceProcessing(index) {
        var result = ($scope.importbill.ImportBillDetails[index].Quantity * $scope.importbill.ImportBillDetails[index].ImportPrice) * (100 - $scope.importbill.ImportBillDetails[index].Discount)/100;
        $scope.importbill.ImportBillDetails[index].TotalImportPrice = result;

        InvoiceTotalProcessing();
    }

    // Load List Brand
    $scope.suppliers = [];
    apiService.get("/supplier/getall", null, function (result) {
        $scope.suppliers = result.data;
        dropdownService.createDefaultDropdown("#supplier");
    }, function (error) {
        console.log("Get data fail");
    })

    // Invoice Total Processing
    function Sum(items, prop) {
        return items.reduce(function (a, b) {
            return a + b[prop];
        }, 0);
    };
    $scope.InvoiceTotalProcessing = InvoiceTotalProcessing;
    function InvoiceTotalProcessing() {
        $scope.importbill.ActualPriceBill = Sum($scope.importbill.ImportBillDetails, 'TotalImportPrice');
        var TotalPriceBill = 0;
        $scope.importbill.ImportBillDetails.forEach(item => {
            TotalPriceBill += item.Quantity * item.ImportPrice;
        });
        $scope.importbill.TotalPriceBill = TotalPriceBill;
        $scope.importbill.TotalDiscount = $scope.importbill.TotalPriceBill - $scope.importbill.ActualPriceBill;
    }

    // Remove Detail Bill
    $scope.RemoveDetailBill = RemoveDetailBill;
    function RemoveDetailBill(value) {
        $scope.products.push(value.ProductDetail);
        $scope.importbill.ImportBillDetails = $scope.importbill.ImportBillDetails.filter(function (item) {
            return item !== value
        })
        InvoiceTotalProcessing();
    }

    //Choose Supplier Import Bill
    $scope.ChooseSupplierImportBill = ChooseSupplierImportBill;
    function ChooseSupplierImportBill(item) {
        $scope.importbill.SupplierID = item.ID;
        $scope.errorSupplier = false;
    }

    
  
    $scope.AddImportBill = AddImportBill;
    function AddImportBill() {
        $scope.errorSupplier = $scope.importbill.SupplierID == 0 ? true : false;
        console.log($scope.importbill)
        apiService.post("/importbill/create", $scope.importbill, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("import-bill");
        }, function (error) {
           
        });
    }
}