

(function (app) {
    app.factory('dataTableService', dataTableService);

    // apiService.$inject = ['$http'];

    function dataTableService() {
        return {
            createDataTable: createDataTable,
            desTroyDataTable: desTroyDataTable,
            deleteRowDataTable: deleteRowDataTable,
            createDefaultDataTable: createDefaultDataTable,
            createDataTableEdit: createDataTableEdit
        }

        function createDefaultDataTable(nameTable) {
            return $('#' + nameTable).DataTable();
        }

        function desTroyDataTable(nameTable) {
            $('#' + nameTable).DataTable().destroy();
        }

        function deleteRowDataTable(nameTable,indexRow) {
            var table = $('#' + nameTable).DataTable();
            table.row(indexRow).remove().draw();
        }
        
        function createDataTable(config) {          
            angular.element(document).ready(function() { 
                $.fn.dataTable.ext.errMode = 'none';

                var table = $('#' + config.nameDataTable).DataTable({
                    language: {
                        paginate: {
                            previous: "<i class='mdi mdi-chevron-left'>",
                            next: "<i class='mdi mdi-chevron-right'>",
                        },
                        info: "Hiển thị từ _START_ đến _END_ trong _TOTAL_ bản ghi",
                        search : "Tìm kiếm",
                        infoEmpty : "Không tìm thấy bản ghi",
                        infoFiltered:"(Trong tổng số _MAX_ bản ghi)",
                        lengthMenu:"Hiển thị _MENU_ bản ghi",
                    },

                    drawCallback: function () {
                    $(".dataTables_paginate > .pagination")
                        .addClass("pagination-rounded")
                    },

                    buttons: [
                        { extend: 'excel', className: 'btn btn-success waves-effect d-block text-left extension-button me-1 rounded', text: '<i class="fas fa-file-export"></i>', title: 'Dữ liệu ' + config.namePage.toLowerCase(), exportOptions: config.exportOptions, },
                        { extend: 'print', className: 'btn btn-success waves-effect d-block text-left extension-button me-1 rounded', text: '<i class="fas fa-print"></i>' },
                        { extend: 'colvis', className: 'btn btn-success waves-effect d-block text-left extension-button me-1 rounded', text: '<i class="fal fa-table"></i>' },
                    ],

                    columnDefs: config.columnDefs,
                });
                table.buttons()
                    .container()
                    .appendTo(".datatable-extension")

            });
        }

        function createDataTableEdit() {
           
        }
    }
})(angular.module('DAGStore.common'));