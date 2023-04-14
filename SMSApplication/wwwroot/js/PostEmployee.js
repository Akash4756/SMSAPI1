$(function () {
    $("#btnSubmit").click(function () {
        
        PostEmployee()
    })
})

function PostEmployee() {

    var data = {
        "Id":0,
        "Name":$("#txtName").val(),
        "Email": $("#txtEmail").val(),
        "Gender": $("#ddlGender").val(),
        "Mobile": $("#txtMobile").val(),
        "Salary": parseFloat($("#txtSalary").val()),
        "Address": $("#txtAddress").val(),
        "EmpCode":"",

    }

    ApiCallAjax("Employee/PostEmployee", JSON.stringify(data), "POST", true, function (result) {
        if (result.ok) {
            alert(result.message)
            setTimeout(() => {
                window.location.reload()
            },2000)
        }
        else {
            alert("Something went wrong.....")
        }
    })
}