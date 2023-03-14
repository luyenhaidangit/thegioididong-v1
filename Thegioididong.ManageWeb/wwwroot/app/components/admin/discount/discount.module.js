// Register module
var discount = angular.module('DAGStore.discount', ['DAGStore.common']);

// Config module
discount.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'discount',
            url: '/discount',
            templateUrl: '/app/components/admin/discount/discountListView.html',
            controller: "discountListController",
            parent: 'base',
        },
        {
            name: 'add-discount',
            url: '/discount/add',
            templateUrl: '/app/components/admin/discount/discountAddView.html',
            controller: "discountAddController",
            parent: 'base',
        },
        {
            name: 'info-discount',
            url: '/discount/info/:id',
            templateUrl: '/app/components/admin/discount/discountInfoView.html',
            controller: "discountInfoController",
            parent: 'base',
        },
        {
            name: 'edit-discount',
            url: '/discount/edit/:id',
            templateUrl: '/app/components/admin/discount/discountEditView.html',
            controller: "discountEditController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




