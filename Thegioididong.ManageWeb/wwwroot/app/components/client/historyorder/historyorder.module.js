// Register module
var historyorder = angular.module('DAGStoreHome.historyorder', ['DAGStore.common'])

// Config module
historyorder.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'historyorder',
            url: '/historyorder',
            templateUrl: '/app/components/client/historyorder/historyorderView.html',
            controller: "historyorderController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});



