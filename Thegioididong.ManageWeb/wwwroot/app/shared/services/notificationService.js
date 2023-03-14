(function (app) {
    app.factory('notificationService', notificationService);

  

    function notificationService() {
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
          };

          function displaySuccess(message){
            toastr.success(message);
          }

          function displayError(error){
            if(Array.isArray(error)){
                error.each(function(err){
                    toastr.error(err);
                })
            }else{
                toastr.error(err);
            }
            
          }

          function displayWarning(message){
            toastr.warning(message);
          }

          function displayInfo(message){
            toastr.info(message);
          }

          return{
            displaySuccess : displaySuccess,
              displayError: displayError,
            displayWarning : displayWarning,
            displayInfo : displayInfo
          }

    }
})(angular.module('DAGStore.common'));