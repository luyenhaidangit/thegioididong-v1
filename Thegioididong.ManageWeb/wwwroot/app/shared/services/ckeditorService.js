
(function (app) {
    app.factory('ckeditorService', ckeditorService);

    // apiService.$inject = ['$http'];

    function ckeditorService() {
        return {
            createDefaultCkeditor: createDefaultCkeditor,
        }

        function createDefaultCkeditor(idarea) {
            CKEDITOR.replace('DAGStoreTextArea');
        }




    }
}
)(angular.module('DAGStore.common'));