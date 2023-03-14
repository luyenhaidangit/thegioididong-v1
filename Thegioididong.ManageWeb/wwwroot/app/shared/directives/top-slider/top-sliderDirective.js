var app = angular.module("DAGStore.common");
app.directive("topSliderDirective", function () {
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/top-slider/top-sliderView.html',
        controller: 'topSliderController',
    };
});