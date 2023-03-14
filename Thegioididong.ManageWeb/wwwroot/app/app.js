// Register App
var app = angular.module('DAGStore', [
    'DAGStore.supplier',
    'DAGStore.brand',
    'DAGStore.category',
    'DAGStore.product',
    'DAGStore.discount',
    'DAGStore.importBill',
    'DAGStore.slider',
    'DAGStore.event',
    'DAGStore.page',
    'DAGStore.customer',
    'DAGStore.order',
    'DAGStore.suggest',
    'DAGStore.common',
]);



// Config app
app.config(function ($stateProvider, $urlRouterProvider) {
    /* Config Router*/
    var states = [
        {
            name: 'base',
            url: '',
            templateUrl: '/app/shared/views/baseView.html',
            abstract: true,
        },
        {
            name: 'dashboard',
            url: '/dashboard',
            templateUrl: '/app/components/admin/home/homeView.html',
            controller: "homeController",
            parent: 'base',
        },
        {
            name: 'login',
            url: '/login',

            templateUrl: '/app/components/admin/login/loginView.html',
            controller: "loginController",
        }
    ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/login');
    $urlRouterProvider.otherwise('/login');
});

app.config(configAuthentication).$inject = ['$stateProvider', '$urlRouterProvider'];;

function configAuthentication($httpProvider) {
    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            request: function (config) {

                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    });
}

// Register App Home
var app = angular.module('DAGStoreHome', [
    'DAGStoreHome.index',
    'DAGStoreHome.category',
    'DAGStoreHome.product',
    'DAGStoreHome.cart',
    'DAGStoreHome.suggest',
    'DAGStoreHome.discount',
    'DAGStoreHome.news',
    'DAGStoreHome.search',
    'DAGStoreHome.historyorder',
    'DAGStore.common']);

// Config App Home
app.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'index',
            url: '/index',
            templateUrl: '/app/components/client/index/indexView.html',
            controller: "indexController",
            onEnter: function () {
                $('html, body').animate({ scrollTop: -10000 }, 0);
            }
        },
    ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/index');
});


// Register App
var applogin = angular.module('DAGStoreLogin', [
    'DAGStore.common']);

// Config app
applogin.config(function ($stateProvider, $urlRouterProvider) {
    // Config Router
    var states = [
        {
            name: 'signin',
            url: '/signin',
            templateUrl: '/app/components/admin/login/loginView.html',
            controller: "loginController",
        }
    ];
    states.forEach((state) => $stateProvider.state(state));
    $urlRouterProvider.otherwise('/signin');
});

applogin.config(function ($httpProvider) {
    // Config Router
    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            request: function (config) {

                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    });
});