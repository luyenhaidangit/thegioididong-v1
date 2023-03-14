var app = angular.module("DAGStore.common");
app.directive("headerTopDirective", function () {
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/header-top/header-topView.html',
        controller: 'headerTopController',
    };
});