var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/PhysicalConditions/GetAll"
        },
        "columns": [
            { "data": "weight", "width": "15%" },
            { "data": "height", "width": "15%" },
            { "data": "diseases", "width": "15%" },
            { "data": "medicines", "width": "15%" },
            { "data": "customer.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                    <a href="/Admin/PhysicalConditions/Details/${data}" class="btn btn-info text-white" style="cursor:pointer">Details
                                         <i class="fas fa-file-invoice-dollar"></i>
                                    </a>
                                    <a href="/Admin/PhysicalConditions/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">Edit
                                         <i class="fas fa-edit"></i>
                                    </a>
                                    <a href="/Admin/PhysicalConditions/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">Delete
                                         <i class="fas fa-trash-alt"></i>
                                    </a>
                                </div>
                            `;
                }, "width": "30%"
            }
        ]

    });
}



