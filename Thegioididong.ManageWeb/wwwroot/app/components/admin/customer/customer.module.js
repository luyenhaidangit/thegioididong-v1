// Register module
var customer = angular.module('DAGStore.customer', ['DAGStore.common']);

// Config module
customer.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'customer',
            url: '/customer',
            templateUrl: '/app/components/admin/customer/customerListView.html',
            controller: "customerListController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




