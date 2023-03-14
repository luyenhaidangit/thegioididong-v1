//// Register controller
//var app = angular.module('DAGStore');
//app.controller('rootController', rootController);

//// Controller
//function rootController($scope, $state) {
//    $scope.LogOut = LogOut;
//    function LogOut() {
//        $state.go('login');
//    }
//}

(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService', '$http', 'apiService','$location'];

    function rootController($state, authData, loginService, $scope, authenticationService, $http, apiService, $location) {
        $scope.LogOut = function () {
            loginService.logOut();
            $state.go('login');
        }

        $scope.authentication = authData.authenticationData;
      /*  $scope.AuthenSuccess = false;*/
       

        /* authenticationService.validateRequest();*/
        //$http.get("/home/testmethod", null, function (result) {
           
        //}, function (error) {
        //    console.log("Get data fail");
        //})
        apiService.get("/home/testmethod", null, function (result) {
            console.log(result)
            $scope.AuthenSuccess = true;
            $scope.authentication = authData.authenticationData;
            console.log($scope.authentication)
        }, function (error) {
            //console.log(error)
            // $location.path('/login');
            // console.log("error")
            console.log("ok1")
        })
        //console.log("ok")
    }
})(angular.module('DAGStore'));