// Register module
var product = angular.module('DAGStoreHome.product', ['DAGStore.common']);

// Config module
product.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'product',
            url: '/product/:id',
            templateUrl: '/app/components/client/product/productView.html',
            controller: "productController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }

        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});








