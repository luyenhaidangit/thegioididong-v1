// Register controller
var brand = angular.module('DAGStore.brand');
brand.controller('brandListController', brandListController);

// Controller
function brandListController($scope, apiService, dataTableService, notificationService, alertService) {
    //Config
    $scope.config = {
        namePage: "Hãng Sản Phẩm",
        urlPage: "brand",
        nameDataTable: "DAGStoreDatatable",
        data: "/brand/getdata",
        columnDefs: [
            { targets: 0, name: "STT" },
            { targets: 1, name: "ID", visible: false },
            {
                targets: 2, name: "Ảnh minh họa", render: function (data, type) {
                    return type === 'export' ? (data === '"' ? null : data) : '<img src="' + data + '" alt="" class="img-fluid" style="height:28px;">'
                }
            },
            { targets: 3, name: "Tên nhãn hiệu sản phẩm" },
            {
                targets: 4, name: "Mô tả", visible: false, render: function (data, type) {
                    return type === 'export' ? (data === '---' ? null : data) : data
                }
            },
            { targets: 5, name: "Độ ưu tiên" },
            { targets: 6, name: "Trạng thái" },
            { targets: 7, name: "Thao tác" },
        ],
        exportOptions: {
            columns: [1, 2, 3, 4, 5, 6],
            orthogonal: 'export'
        },
    }

    // Get Data
    $scope.brands = [];
    apiService.get("/brand/getdata", null, function (result) {
        $scope.brands = result.data;
        dataTableService.createDataTable($scope.config);
    }, function (error) {
        console.log("Get data fail");
    })
    
    // Delete Object
    $scope.DeleteBrand = DeleteBrand;
    function DeleteBrand(e, id) {
        alertService.alertSubmitDelete().then((result) => {
            if (result.isConfirmed) {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del("/brand/delete", config, function (success) {
                    notificationService.displaySuccess("Xóa thành công bản ghi!");
                    let pageIndex = $("#DAGStoreDatatable").DataTable().page.info().page;
                    let recordOfPage = $("#DAGStoreDatatable").DataTable().page.info().length;
                    let recordIndexOfPage = $(e.currentTarget).parents('tr').index();
                    let index = pageIndex * recordOfPage + recordIndexOfPage;
                    console.log($(e.currentTarget).parents('tr').index());
                    $("#DAGStoreDatatable").DataTable().row(index).remove().draw();
                    alertService.alertDeleteSuccess();
               
                }, function (error) {
                    var message = error.data.split('<title>').pop().split('<br>')[0];
                    console.log(message)
                    if (message === 'That bai,chi xoa được nhung hang hang khong chua hang hoa nao') {
                        alertService.alertDeleteError("Chỉ xóa được những hãng hàng không chứa sản phẩm nào!");
                    }
                })
                
            }
        });
    }
}