// Register module
var news = angular.module('DAGStoreHome.news', ['DAGStore.common']);

// Config module
news.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'news',
            url: '/news/:id',
            templateUrl: '/app/components/client/news/newsView.html',
            controller: "newsController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




