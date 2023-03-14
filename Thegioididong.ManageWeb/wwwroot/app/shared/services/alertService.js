

(function (app) {
    app.factory('alertService', alertService);

    // apiService.$inject = ['$http'];

    function alertService() {

        function alertSubmitDelete() {
            var alertSubmitDelete = Swal.fire({
                title: "Bạn có chắc muốn xóa thông tin bản ghi?"
                , text: "Bạn sẽ không thể khôi phục thông tin bản ghi sau khi xác nhận!"
                , icon: "warning"
                , showCancelButton: !0
                , confirmButtonColor: "#34c38f"
                , cancelButtonColor: "#ff3d60"
                , confirmButtonText: "Xác nhận"
                , cancelButtonText: "Bỏ qua"
            })
            return alertSubmitDelete;
        }

        function alertDeleteSuccess() {
            var alertDeleteSuccess = Swal.fire(
                  'Đã xóa!',
                  'Bản ghi đã xóa thành công!',
                  'success'
            )
            return alertDeleteSuccess;
        }

        function alertOrderSuccess() {
            var alertOrderSuccess = Swal.fire(
                'Thành công!',
                'Chúng tôi đã xác nhận đơn hàng của bạn!',
                'success'
            )
            return alertOrderSuccess;
        }

        function alertDeleteError(message) {
            var alertDeleteError = Swal.fire(
                'Xóa thất bại!',
                message,
                'error'
            )
            return alertDeleteError;
        }

        return {
            alertSubmitDelete: alertSubmitDelete,
            alertDeleteSuccess: alertDeleteSuccess,
            alertDeleteError: alertDeleteError,
            alertOrderSuccess: alertOrderSuccess,
        }
    }
})(angular.module('DAGStore.common'));
