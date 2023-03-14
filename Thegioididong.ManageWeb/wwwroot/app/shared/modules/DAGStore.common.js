// Register module
var common = angular.module('DAGStore.common', ['ui.router', 'oc.lazyLoad', 'angular-loading-bar'])

common.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    window.scrollTo(0, 0);
    cfpLoadingBarProvider.includeSpinner = false;
    cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
    cfpLoadingBarProvider.spinnerTemplate = '<div><span class="fa fa-spinner">Custom Loading Message...</div>';
    }])
