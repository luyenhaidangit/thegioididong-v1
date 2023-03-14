// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryListController', categoryListController);

// Controller
function categoryListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Loại Sản Phẩm",
        urlPage: "category",
        nameDataTable: "DAGStoreDatatable",
        data: "/category/getall",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            {
                targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }
            },
            { targets: 3, name: "Tên loại sản phẩm" },
            {
                targets: 4, name: "Loại sản phẩm cha", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            {
                targets: 5, name: "Mô tả", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            { targets: 6, name: "Độ ưu tiên" },
            { targets: 7, name: "Trạng thái" },
            { targets: 8, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6, 7],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.categorys = [];
    apiService.get("/category/getall", null, function (result) {
        $scope.categorys = result.data;
        console.log($scope.categorys)
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })

    // Delete Object
    $scope.DeleteCategory = DeleteCategory;
    function DeleteCategory(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/category/delete", config, function (success) {
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