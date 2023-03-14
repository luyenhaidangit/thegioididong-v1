// Register module
var search = angular.module('DAGStoreHome.search', ['DAGStore.common']);

// Config module
search.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'search',
            url: '/search/:key',
            templateUrl: '/app/components/client/search/searchView.html',
            controller: "searchController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




