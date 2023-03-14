// Register module
var discount = angular.module('DAGStoreHome.discount', ['DAGStore.common']);

// Config module
discount.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'discount',
            url: '/discount/:id',
            templateUrl: '/app/components/client/discount/discountView.html',
            controller: "discountController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
});




