// Register controller
var product = angular.module('DAGStore.product');
product.controller('productAddController', productAddController);

// Controller
function productAddController($scope, apiService, notificationService, $state, ckeditorService, dropdownService) {
    //Config
    $scope.config = {
        nameManage: "Sản Phẩm",
        urlManage: "product",
        namePage: "Thêm Mới",
    }
    $scope.product = {
        CostPrice: 0,
        SellPrice: 0,
        InventoryQuantity: 0,
        MinimumInventoryQuantity: 0,
        MaximumInventoryQuantity: 99999,
        DisplayOrder: -1,
        ImageProducts: [

        ],
        Published: true,
        CreateOn: new Date().toJSON().slice(0, 10),
        UpdateOn: new Date().toJSON().slice(0, 10),
        
    }
    // Load List Brand
    apiService.get("/brand/getdata", null, function (result) {
        $scope.brands = result.data;
        dropdownService.createDefaultDropdown("#brand");
    }, function (error) {
        console.log("Get data fail");
    })

    // Load List Category
    apiService.get("/category/getdata", null, function (result) {
        $scope.categorys = result.data;
        console.log($scope.categorys);
        dropdownService.createDefaultDropdown("#category");
    }, function (error) {
        console.log("Get data fail");
    })

    // Choose Image Product
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.product.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    // Choose Image Product
    $scope.statusChooseImageProduct = false;
    $scope.ChooseImageProduct = ChooseImageProduct;
    function ChooseImageProduct(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                var item = {
                    Index: $scope.product.ImageProducts.length,
                    ImagePath: fileUrl,
                }
                $scope.product.ImageProducts.push(item);
                $scope.statusChooseImageProduct = true;
                $scope.$apply();
                console.log($scope.product.ImageProducts)
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.ImageProducts = [];
            $scope.statusChooseImageProduct = false;
            $scope.$apply();
        }
    }

    // Resiger Ckeditor
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    //Get varialtions
    $scope.varialtions = [];
    apiService.get("/Variation/getall", null, function (result) {
        $scope.varialtions = result.data;
    }, function (error) {
        console.log("Get data fail");
    })



    // Add Varialtion
    $scope.varialtionsAdd = [];
    $scope.AddVarialtionProduct = AddVarialtionProduct;
    function AddVarialtionProduct() {
        var item = {
             
        }
        $scope.varialtionsAdd.push(item);
        var index = $scope.varialtionsAdd.indexOf(item);
        item.index = index;
        $scope.varialtionsAdd[index] = item;
        dropdownService.createDefaultDropdown("#varialtion-" + index);
        dropdownService.createDefaultDropdown("#varialtionoption-" + index);
    }

    $scope.Demo = Demo;
    function Demo() {
        console.log($scope.varialtionsAdd);
    }

    $scope.variation = {}
    $scope.AddVariation = AddVariation;
    function AddVariation() {
        apiService.post("/variation/create", $scope.variation, function (result) {
            apiService.get("/Variation/getall", null, function (result) {
                $scope.varialtions = result.data;
                console.log($scope.varialtions)
            }, function (error) {
                console.log("Get data fail");
            })
            $scope.variation = {}

            notificationService.displaySuccess("Thêm thông tin thành công!");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.product.Name);
        });
    }

    //option
    $scope.indexOption = 0;
    $scope.AddVariationOption = AddVariationOption;
    function AddVariationOption(index) {
        $scope.indexOption = index;
    }

    $scope.variationOption = {}
    $scope.AddVariationOptionContinue = AddVariationOptionContinue;
    function AddVariationOptionContinue(){
        $scope.variationOption.VariationID = $scope.varialtionsAdd[$scope.indexOption].Variation.ID;
        apiService.post("/variationoption/create", $scope.variationOption, function (result) {
            apiService.get("/VariationOption/GetVariationOptionByVariation?id=" + $scope.variationOption.VariationID, null, function (result) {
                $scope.varialtionsAdd[$scope.indexOption].Variation.Option = result.data;
                console.log($scope.varialtions)
            }, function (error) {
                console.log("Get data fail");
            })
            console.log($scope.varialtionsAdd[$scope.indexOption].Variation.Option);
            $scope.variationOption = {}

            notificationService.displaySuccess("Thêm thông tin thành công!");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.product.Name);
        });
    }

    //Option
    $scope.varialtionClick = [];
    $scope.GetVarialtionOption = GetVarialtionOption;
    function GetVarialtionOption(item, index) {
        $scope.varialtionsAdd[index].Variation = item;
        $scope.varialtionsAdd[index].ListOption = [];
        console.log($scope.varialtionsAdd);
    }

    $scope.productItems = [];
    $scope.result = [];
    $scope.VariationOptionItem = [];
    $scope.AddProductItem = AddProductItem;
    function AddProductItem(item, index) {

        $scope.varialtionsAdd[index].ListOption.push(item);

        let attributes = {};

        attributes = $scope.varialtionsAdd.map((x) => {
            return x.ListOption;
        })

         let attrs = [];

        for (const [attr, values] of Object.entries(attributes))
            attrs.push(values.map(v => ({ [v.VariationID]: v.Value })));
        
        attrs = attrs.reduce((a, b) => a.flatMap(d => b.map(e => ({ ...d, ...e }))));
        
        $scope.productItems = attrs;
        //var test = [];
        //attrs= attrs.map((x) => {
        //    for (var propName in x) {
        //        console.log("Iterating through prop with name", propName, " its value is ", x[propName])
        //    }
        //    var item = {
        //        Name : "ok"
        //    }
        //    return item;
        //})

        //console.log(attrs)

        /*$scope.productItems = attrs;*/
      /*  var name = "";*/
        //for (const [attr, value] of Object.entries(attrs)) {
        //    name += attr;
        //}

        //console.log(name)

        //var test = [];
        //for (const [attr, values] of Object.entries(attrs))
        //    test.push(values.map(v => ({
        //        "Name" : "ok",
        //        [v.VariationID]: v.Value
        //    })));
        
        //$scope.productItems = attrs.map((x) => {
        //    console.log(x)
        //})
      /*  console.log($scope.productItems)*/
        //console.log(attributes)

        //console.log($scope.varialtionsAdd[index].ListOption)

        //var itemOption = {
        //    item
        //}

        
        //apiService.get("/variationoption/getall", null, function (result) {
        //    //result = result.data;
        //    //console.log(result)
        //    //result = result.filter(x => x.VariationID === item.VariationID)

        //    //result = $scope.varialtionsAdd[index].ListOption.filter(item => !result.includes(item));
            
           
        //    //console.log(result)

            

        //}, function (error) {
        //    console.log("Get data fail");
        //})
     
    }

    // Submit Add Product
    $scope.AddProduct = AddProduct;
    function AddProduct() {
        $scope.product.BrandID = document.getElementsByName("brandid")[0].value;
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
        $scope.product.FullDescription = CKEDITOR.instances['DAGStoreTextArea'].getData();
        console.log($scope.product)
        apiService.post("/product/create", $scope.product, function (result) {
            notificationService.displaySuccess("Thêm thông tin thành công!");
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.product.Name);
        });
    }
}