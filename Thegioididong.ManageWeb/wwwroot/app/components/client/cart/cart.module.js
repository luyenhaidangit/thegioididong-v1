// Register module
var product = angular.module('DAGStoreHome.cart', ['DAGStore.common']);

// Config module
product.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'cart',
            url: '/cart',
            templateUrl: '/app/components/client/cart/cartView.html',
            controller: "cartController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
        {
            name: 'payment',
            url: '/payment',
            templateUrl: '/app/components/client/cart/paymentView.html',
            controller: "paymentController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




