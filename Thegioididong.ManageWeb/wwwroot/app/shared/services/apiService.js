

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http','authenticationService'];

    function apiService($http, authenticationService) {
        return {
            get: get,
            post:post,
            put: put,
            del: del,
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    
                }
                else if (failure != null) {
                    failure(error);
                }   
            });
        }

        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                   
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }

        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                if(error.status===401){
                    
                }else if(failure!=null){
                    failure(error);
                }
                
            });
        }

        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    
                }
                else if (failure != null) {
                    failure(error);
                }
                
            });
        }
    }
})(angular.module('DAGStore.common'));