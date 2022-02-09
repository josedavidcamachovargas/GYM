var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {


    const div = document.getElementById("infoButton");
    const infoButton = document.createElement("a");

    infoButton.id = "mostrar";

    div.appendChild(infoButton);

    let idCard = document.getElementById("userId").value;

    infoButton.href = `/Admin/User/ShowCodeInfo/` + idCard;
    infoButton.className = "btn btn-info text-white";
    infoButton.style = "cursor:pointer";
    infoButton.innerHTML = `MostrarDatos<i class="fas fa - user"></i>`;

    infoButton.onclick = "updateInput()";
    
}

function updateInput() {
    const infoButton = document.getElementById("mostrar");
    infoButton.href = `/Admin/User/ShowCodeInfo/` + idCard;

}

