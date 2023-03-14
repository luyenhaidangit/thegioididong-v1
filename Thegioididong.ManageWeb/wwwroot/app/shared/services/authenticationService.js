//(function (app) {
//    'use strict';
//    app.service('authenticationService', ['$http', '$q', '$window',
//        function ($http, $q, $window) {

//            var tokenInfo;

//            this.setTokenInfo = function (data) {

//                tokenInfo = data;
//                $window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
//            }

//            this.getTokenInfo = function () {
//                return tokenInfo;
//            }

//            this.removeToken = function () {
//                tokenInfo = null;
//                $window.sessionStorage["TokenInfo"] = null;
//            }

//            this.init = function () {
//                console.log("ok")
//                if ($window.sessionStorage["TokenInfo"]) {
//                    tokenInfo = JSON.parse($window.sessionStorage["TokenInfo"]);
//                }
//            }

//            this.setHeader = function () {
//                delete $http.defaults.headers.common['X-Requested-With'];
//                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
//                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
//                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
//                }
//            }

//            this.validateRequest = function () {
//                console.log("tes")
//                var url = '/home/TestMethod';
//                var deferred = $q.defer();
//                $http.get(url).then(function () {
//                    deferred.resolve(null);
//                }, function (error) {
//                    deferred.reject(error);
//                });
//                return deferred.promise;
//            }



//            this.init();
//            this.validateRequest();
//        }
//    ]);
//})(angular.module('DAGStore.common'));

(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window',
        function ($http, $q, $window) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                $window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                $window.sessionStorage["TokenInfo"] = null;
            }

            this.init = function () {
                if ($window.sessionStorage["TokenInfo"]) {
                    tokenInfo = JSON.parse($window.sessionStorage["TokenInfo"]);
                    console.log(tokenInfo)
                }
            }

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            this.validateRequest = function () {
                var url = '/home/TestMethod';
                var deferred = $q.defer();
                this.setHeader();
                $http.get(url).then(function () {
                    deferred.resolve(null);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            this.init();
        }
    ]);
})(angular.module('DAGStore.common'));