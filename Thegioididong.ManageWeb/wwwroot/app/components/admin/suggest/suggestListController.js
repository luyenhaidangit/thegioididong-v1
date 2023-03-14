// Register controller
var suggest = angular.module('DAGStore.suggest');
suggest.controller('suggestListController', suggestListController);

// Controller
function suggestListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Đề Xuất",
        urlPage: "suggest",
        nameDataTable: "DAGStoreDatatable",
        data: "/suggest/getdata",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            { targets: 2, name: "Tiêu đề" },
            { targets: 3, name: "Vị trí" },
            { targets: 4, name: "Trang" },
            { targets: 5, name: "Kiểu suggest" },
            { targets: 6, name: "Màu nền", visible: false },
            { targets: 7, name: "Độ ưu tiên", visible: false },
            { targets: 8, name: "Trạng thái" },
            { targets: 9, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7,8],
            orthogonal: 'export'
        },
    }

    $scope.suggests = []
    apiService.get("/suggest/getall", null, function (result) {
        $scope.suggests = result.data; 
        console.log($scope.suggests);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.Deletesuggest = Deletesuggest;
    function Deletesuggest(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/suggest/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    console.log($(e.currentTarget).parents('tr').index());
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
               
                }, function (error) {
                    console.log("Xóa không thành công!")
                })

                alertService.alertDeleteSuccess();
            }
        });
    }
}