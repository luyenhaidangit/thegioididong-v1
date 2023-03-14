

(function (app) {
    app.factory('dropdownService', dropdownService);

    // apiService.$inject = ['$http'];

    function dropdownService() {
        return {
            createDefaultDropdown: createDefaultDropdown,
        }

        function createDefaultDropdown(selector) {
            angular.element(document).ready(function () {
                $(selector).dropdown({

                }); 
            });
        }
    }
})(angular.module('DAGStore.common'));