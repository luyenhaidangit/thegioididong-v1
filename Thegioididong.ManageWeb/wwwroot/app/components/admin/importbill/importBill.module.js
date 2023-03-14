// Register module
var importBill = angular.module('DAGStore.importBill', ['DAGStore.common']);

// Config module
importBill.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'import-bill',
            url: '/import-bill',
            templateUrl: '/app/components/admin/importBill/importBillListView.html',
            controller: "importBillListController",
            parent: 'base',
        },
        {
            name: 'add-import-bill',
            url: '/import-bill/add',
            templateUrl: '/app/components/admin/importBill/importBillAddView.html',
            controller: "importbillAddController",
            parent: 'base',
        },
        {
            name: 'info-import-bill',
            url: '/import-bill/info/:id',
            templateUrl: '/app/components/admin/importbill/importBillInfoView.html',
            controller: "importBillInfoController",
            parent: 'base',
        },
        {
            name: 'edit-import-bill',
            url: '/import-bill/edit/:id',
            templateUrl: '/app/components/admin/importBill/importBillEditView.html',
            controller: "importBillEditController",
            parent: 'base',
        }
        ];
    states.forEach((state) => $stateProvider.state(state));
});




