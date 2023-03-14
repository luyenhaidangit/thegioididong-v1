// Register controller
var page = angular.module('DAGStore.page');
page.controller('pageListController', pageListController);

// Controller
function pageListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Page",
        urlPage: "page",
        nameDataTable: "DAGStoreDatatable",
        data: "/page/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            {
                targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }
            },
            { targets: 3, name: "Tên trang" },
            {
                targets: 4, name: "Nội dung", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            { targets: 5, name: "Alias" },
            { targets: 6, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.pages = [];
    apiService.get("/page/getall", null, function (result) {
        $scope.pages = result.data;
        console.log($scope.pages)
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.Deletepage = Deletepage;
    function Deletepage(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/page/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                    alertService.alertDeleteSuccess();
                }, function (error) {
                    var message = error.data.split('<title>').pop().split('<br>')[0];
                    console.log(message)
                    if (message === 'That bai,chi xoa được nhung nhom hang khong chua hang hoa nao') {
                        alertService.alertDeleteError("Chỉ xóa được những nhóm hàng không chứa sản phẩm nào!");
                    }
                    if (message === 'That bai,chi xoa được nhung nhom hang khong chua nhom hang con') {
                        alertService.alertDeleteError("Chỉ xóa được những nhóm hàng không chứa nhóm hàng con nào!");
                    }
                })
            }
        });
    }
}