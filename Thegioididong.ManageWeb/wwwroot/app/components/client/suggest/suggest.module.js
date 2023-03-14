// Register module
var suggest = angular.module('DAGStoreHome.suggest', ['DAGStore.common']);

// Config module
suggest.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'suggest',
            url: '/suggest/:id',
            templateUrl: '/app/components/client/suggest/suggestView.html',
            controller: "suggestController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




