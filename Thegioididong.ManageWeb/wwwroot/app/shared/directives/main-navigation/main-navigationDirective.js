var app = angular.module("DAGStore.common");
app.directive("mainNavigationDirective", function () {
    return {
        restrict: "EA",
        templateUrl: '/app/shared/directives/main-navigation/main-navigationView.html',
        controller: 'mainNavigationController',
    };
});