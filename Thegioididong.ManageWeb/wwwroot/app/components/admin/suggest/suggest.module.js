// Register module
var suggest = angular.module('DAGStore.suggest', ['DAGStore.common']);

// Config module
suggest.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'suggest',
            url: '/suggest',
            templateUrl: '/app/components/admin/suggest/suggestListView.html',
            controller: "suggestListController",
            parent: 'base',
        },
        {
            name: 'add-suggest',
            url: '/suggest/add',
            templateUrl: '/app/components/admin/suggest/suggestAddView.html',
            controller: "suggestAddController",
            parent: 'base',
        },
        ];
    states.forEach((state) => $stateProvider.state(state));
});




