var app = angular.module("DAGStore.common");
app.directive("footerDirective", function () {
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/footer/footerView.html',
        controller: 'footerController',
    };
});