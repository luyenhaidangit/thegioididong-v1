// Register controller
var event = angular.module('DAGStore.event');
event.controller('eventListController', eventListController);

// Controller
function eventListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Sự kiện",
        urlPage: "event",
        nameDataTable: "DAGStoreDatatable",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            {
                targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }
            },
            { targets: 3, name: "Tiêu đề sự kiện" },
            {
                targets: 4, name: "Nội dung", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            { targets: 5, name: "Độ ưu tiên" },
            { targets: 6, name: "Trạng thái" },
            { targets: 7, name: "Hiện trang chủ" },
            { targets: 8, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6,7],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.events = [];
    apiService.get("/event/getall", null, function (result) {
        $scope.events = result.data;
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.Deleteevent = Deleteevent;
    function Deleteevent(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/event/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                    alertService.alertDeleteSuccess();
                }, function (error) {
                    console.log("Xóa thất bại")
                })
            }
        });
    }
}