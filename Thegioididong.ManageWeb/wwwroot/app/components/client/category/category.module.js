// Register module
var category = angular.module('DAGStoreHome.category', ['DAGStore.common']);

// Config module
category.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'category',
            url: '/category/:id',
            templateUrl: '/app/components/client/category/categoryView.html',
            controller: "categoryController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




