// Register module
var brand = angular.module('DAGStore.brand', ['DAGStore.common']);

// Config module
brand.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'brand',
            url: '/brand',
            templateUrl: '/app/components/admin/brand/brandListView.html',
            controller: "brandListController",
            parent: 'base',
        },
        {
            name: 'add-brand',
            url: '/brand/add',
            templateUrl: '/app/components/admin/brand/brandAddView.html',
            controller: "brandAddController",
            parent: 'base',
        },
        {
            name: 'info-brand',
            url: '/brand/info/:id',
            templateUrl: '/app/components/admin/brand/brandInfoView.html',
            controller: "brandInfoController",
            parent: 'base',
        },
        {
            name: 'edit-brand',
            url: '/brand/edit/:id',
            templateUrl: '/app/components/admin/brand/brandEditView.html',
            controller: "brandEditController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




