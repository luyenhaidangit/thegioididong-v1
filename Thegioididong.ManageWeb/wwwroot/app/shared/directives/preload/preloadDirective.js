var app = angular.module("DAGStore.common");
app.directive("preloadDirective", function () {
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/preload/preloadView.html',
        controller: 'preloadController',
    };
});