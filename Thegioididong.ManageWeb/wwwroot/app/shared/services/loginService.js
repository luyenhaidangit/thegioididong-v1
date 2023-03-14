//(function (app) {
//    'use strict';
//    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
//        function ($http, $q, authenticationService, authData) {
//            var userInfo;
//            var deferred;

//            this.login = function (userName, password) {
//                deferred = $q.defer();
//                var data = "grant_type=password&username=" + userName + "&password=" + password;

//                console.log(data)

//                $http.post('/oauth/token', data, {
//                    headers:
//                        { 'Content-Type': 'application/x-www-form-urlencoded' }
//                }).then(function (response) {
//                    console.log(response)
//                    userInfo = {
//                        accessToken: response.data.access_token,
//                        userName: userName
//                    };
//                    console.log(userInfo)
//                    authenticationService.setTokenInfo(userInfo);
//                    authData.authenticationData.IsAuthenticated = true;
//                    authData.authenticationData.userName = userName;
//                    console.log(authenticationService.getTokenInfo())
//                    deferred.resolve(null);
//                }, function (err) {
//                    authData.authenticationData.IsAuthenticated = false;
//                    authData.authenticationData.userName = "";
//                    deferred.resolve(err.data);
//                    console.log(err)
//                })
//                return deferred.promise;
//            }

//            this.logOut = function () {
//                authenticationService.removeToken();
//                authData.authenticationData.IsAuthenticated = false;
//                authData.authenticationData.userName = "";
//            }
//        }]);
//})(angular.module('DAGStore.common'));

(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;

            this.login = function (userName, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + userName + "&password=" + password;
                $http.post('/oauth/token', data, {
                    headers:
                        { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (result) {
                        userInfo = {
                            accessToken: result.data.access_token,
                        userName: userName
                    };
                    authenticationService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = userName;
                    deferred.resolve(null);
                }, function (error) {
                    console.log(error)
                    authData.authenticationData.IsAuthenticated = false;
                    authData.authenticationData.userName = "";
                    deferred.resolve(error.data);
                });
                return deferred.promise;
            }

            this.logOut = function () {
                authenticationService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
            }
        }]);
})(angular.module('DAGStore.common'));