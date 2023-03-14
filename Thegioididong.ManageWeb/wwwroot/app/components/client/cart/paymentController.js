// Register controller
var product = angular.module('DAGStoreHome.cart');
product.controller('paymentController', paymentController);

// Controller
function paymentController($scope, apiService, $stateParams, $filter, $rootScope, notificationService, alertService, $window) {
    //Load Page
    $rootScope.LoadPageSuccess = true;
    // Get Data
    
        
    

    //Load Page
    //angular.element(function () {
    //    $timeout(function () {
    //        $rootScope.LoadPageSuccess = true;
    //    }, 600);
    //});
}