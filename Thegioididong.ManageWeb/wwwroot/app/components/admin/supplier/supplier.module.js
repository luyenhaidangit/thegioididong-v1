// Register module
var supplier = angular.module('DAGStore.supplier', ['DAGStore.common']);

// Config module
supplier.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'supplier',
            url: '/supplier',
            templateUrl: '/app/components/admin/supplier/supplierListView.html',
            controller: "supplierListController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




