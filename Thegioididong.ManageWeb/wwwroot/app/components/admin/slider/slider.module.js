// Register module
var slider = angular.module('DAGStore.slider', ['DAGStore.common']);

// Config module
slider.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'slider',
            url: '/slider',
            templateUrl: '/app/components/admin/slider/sliderListView.html',
            controller: "sliderListController",
            parent: 'base',
        },
        {
            name: 'add-slider',
            url: '/slider/add',
            templateUrl: '/app/components/admin/slider/sliderAddView.html',
            controller: "sliderAddController",
            parent: 'base',
        },
        ];
    states.forEach((state) => $stateProvider.state(state));
});




