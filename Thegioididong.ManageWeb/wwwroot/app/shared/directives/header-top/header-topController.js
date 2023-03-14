// Register controller
var app = angular.module("DAGStore.common");
app.controller("headerTopController", headerTopController);

// Controller
function headerTopController($scope, apiService) {
    
    $scope.keySearch = "";
    $scope.searchItem = [];
    $scope.GetSearchProduct = GetSearchProduct;
    function GetSearchProduct() {
        if ($scope.keySearch == "") {
            $scope.searchItem = [];
        } else {
            apiService.get("/index/GetSearchNavigation?key=" + $scope.keySearch, null, function (result) {
                $scope.searchItem = result.data;
            }, function (error) {
                console.log("loi")
            })
        }
    }

    $scope.ChooseProduc = ChooseProduc;
    function ChooseProduc() {
        $scope.searchItem = [];
        $scope.keySearch = "";
    }

    
            

};