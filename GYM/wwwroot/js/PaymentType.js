﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/PaymentTypes/GetAll"
        },
        "columns": [
            { "data": "paymentDate", "width": "10%" },
            { "data": "description.name", "width": "10%" },
            { "data": "payment", "width": "10%" },
            { "data": "periodOfTime", "width": "10%" },
            { "data": "paymentMean", "width": "10%" },
            { "data": "expirationDate", "width": "10%" },
            { "data": "customer.name", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                    <a href="/Admin/PaymentTypes/Details/${data}" class="btn btn-info text-white" style="cursor:pointer">Details
                                         <i class="fas fa-file-invoice-dollar"></i>
                                    </a>
                                    <a href="/Admin/PaymentTypes/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">Edit
                                         <i class="fas fa-edit"></i>
                                    </a>
                                    <a href="/Admin/PaymentTypes/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">Delete
                                         <i class="fas fa-trash-alt"></i>
                                    </a>
                                </div>
                            `;
                }, "width": "30%"
            }
        ]

    });
}



