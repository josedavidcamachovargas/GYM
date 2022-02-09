var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="text-center">
                                    <a href="/Admin/User/Details/${data}" class="btn btn-info text-white" style="cursor:pointer">Details
                                         <i class="fas fa-user"></i>
                                    </a>
                                    <a href="/Admin/User/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">Edit
                                         <i class="fas fa-edit"></i>
                                    </a>
                                    <a href="/Admin/User/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">Delete
                                         <i class="fas fa-trash-alt"></i>
                                    </a>
                                </div>
                            `;
                }, "width": "30%"
            },
            {
                "data": { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockOut = new Date(data.lockoutEnd).getTime();
                    if (lockOut > today) //User is locked
                    {
                        return `
                                <div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:100px">
                                        <i class="fas fa-lock-open"></i> Unlock
                                    </a>
                                </div>
                               `;
                    }
                    //User is Unlocked
                    return `
                                    <div class="text-center">
                                    <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:100px">
                                        <i class="fas fa-lock"></i> Lock
                                    </a>
                                </div>
                           `;
                }, "width": "15%"
            }
        ]

    });
}



function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });
}
