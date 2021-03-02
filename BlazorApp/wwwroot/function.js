function confirmation() {
    alert("Task created");
}

function dataTable(table)
{
    $(document).ready( function () {
        $('#' + table).DataTable();
    } );
}
