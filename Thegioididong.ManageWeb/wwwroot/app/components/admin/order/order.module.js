// Register module
var order = angular.module('DAGStore.order', ['DAGStore.common']);

// Config module
order.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'order',
            url: '/order',
            templateUrl: '/app/components/admin/order/orderListView.html',
            controller: "orderListController",
            parent: 'base',
        },
        {
            name: 'info-order',
            url: '/order/info/:id',
            templateUrl: '/app/components/admin/order/orderInfoView.html',
            controller: "orderInfoController",
            parent: 'base',
        },
        {
            name: 'add-order',
            url: '/order/add',
            templateUrl: '/app/components/admin/order/orderAddView.html',
            controller: "orderAddController",
            parent: 'base',
        },
        {
            name: 'edit-order',
            url: '/order/edit/:id',
            templateUrl: '/app/components/admin/order/orderEditView.html',
            controller: "orderEditController",
            parent: 'base',
        }];
    states.forEach((state) => $stateProvider.state(state));
});




