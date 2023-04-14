
$(function () {
    GetEmployees();
})

function GetEmployees() {
    ApiCallAjax("Employee/GetEmployees", null, "GET", true, function (result) {
        //console.log(result)
        $("#tblEmployees").DataTable().destroy();

        $("#tblEmployees").DataTable({
            "paging": true,
            "lenthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "responsive": true,
            "data": result.data,
            "columns": [
                {"data":"id"},
                {"data": "name"},
                {"data": "email"},
                {"data": "mobile"},
                {"data": "gender"},
                {"data": "salary"},
                { "data": "address" },
                {
                    "data": "id","class":"text-center","render": function (id) {

                        var btn = "<a><i class='fa fa-edit'></i></a> &emsp;";
                        btn += "<a onclick='deleteRecord(" + id + ")'><i class='fa fa-trash'></i></a>";
                        return btn               
                    }
                }

            ]

        });

    })
}

function deleteRecord(id) {
    console.log(id)
    ApiCallAjaxGet("Employee/DeleteEmployee", { "id": id }, true, function (result) {
        // console.log(result)
        if (result.ok) {
            alert(result.message)
            GetEmployees();
        }
        else
            alert(result.message)
    })
}
