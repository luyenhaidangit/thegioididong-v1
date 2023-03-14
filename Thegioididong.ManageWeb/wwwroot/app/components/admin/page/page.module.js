// Register module
var page = angular.module('DAGStore.page', ['DAGStore.common']);

// Config module
page.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'page',
            url: '/page',
            templateUrl: '/app/components/admin/page/pageListView.html',
            controller: "pageListController",
            parent: 'base',
        },
        {
            name: 'add-page',
            url: '/page/add',
            templateUrl: '/app/components/admin/page/pageAddView.html',
            controller: "pageAddController",
            parent: 'base',
        },
        {
            name: 'info-page',
            url: '/page/info/:id',
            templateUrl: '/app/components/admin/page/pageInfoView.html',
            controller: "pageInfoController",
            parent: 'base',
        },
        {
            name: 'edit-page',
            url: '/page/edit/:id',
            templateUrl: '/app/components/admin/page/pageEditView.html',
            controller: "pageEditController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




