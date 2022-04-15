
$(document).ready(function () {
    // Activate tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // Select/Deselect checkboxes
    var checkbox = $('table tbody input[type="checkbox"]');
    $("#selectAll").click(function () {
        if (this.checked) {
            checkbox.each(function () {
                this.checked = true;
            });
        } else {
            checkbox.each(function () {
                this.checked = false;
            });
        }
    });
    checkbox.click(function () {
        if (!this.checked) {
            $("#selectAll").prop("checked", false);
        }
    });
    $('#MyId').DataTable();
});
      


/*AssignTask*/
    function AssignDelete(EmpId) {
        $.ajax({
            type: "Delete",
            url: "/AssignTask/Delete",
            data: { EmpId: EmpId },
            dataType: "json",
            success: function (Result) {
                alert(Result);
                window.location.reload()
            },
            error: function (Result) {
                alert("Error");
            }
        });
        }
        function AssignEdit(EmpId) {
        //var Hiddencode = $("#HidnEditAssignTcode").val();
        //var HiddenName = $("#HidnEditAssignEName").val();
        $("#EditAssignId").val(EmpId);

            $.ajax({
        type: "GET",
                //contentType: "application/json; charset=utf-8",
                url: "/AssignTask/Edit",
                // data: "{EmpId:EmpId}",
                data: {EmpId: EmpId },
                dataType: "json",
                success: function (Result) {
        console.log(Result)
                    $("#EditTaskId").val(Result.at_TaskId );
                    $("#EditEmpId").val(Result.at_EmpId );
                },
                error: function (Result) {
        alert("Error");
                }
            });
        }
        function AssignUpdate() {
            //var EmpId = $("#EditEmpId").val();
            //var Name = $("#EditEmpName").val();
            //var Address = $("#EditEmpAddress").val();
            var At_Id = $("#EditAssignId").val();
            var EditEmpId = $("#EditEmpId").val();
            var EditTaskId = $("#EditTaskId").val();

            var obj = {
                At_Id: At_Id,
                At_EmpId: EditEmpId,
                At_TaskId: EditTaskId
            }

            $.ajax({
        type: "post",
                //contentType: "application/json; charset=utf-8",
                url: "/AssignTask/Edit",
                // data: "{EmpId:EmpId}",
                data: {At_Id: At_Id, At_EmpId: EditEmpId, At_TaskId: EditTaskId },
                // dataType: "json",
                success: function (Result) {
        console.log(Result);
                    alert("Successfully updated")
                    window.location.reload();
                },
                error: function (Result) {
        alert("Error");
                }
            });
        }
        ////function AssignNewEmployee() {

        ////    //var Name = $("#Name").val();
        ////    //var Address = $("#Address").val();
        ////    //var Phone = $("#Phone").val();
        ////    //var obj = {
        ////    //    empName: Name,
        ////    //    empAddress: Address,
        ////    //    phone: Phone
        ////    //}
        ////    debugger;
        ////    alert($(this).find(':selected').html());
        ////    var AssignId = $(this).find(':selected').data('id');
        ////    var TaskName = $("#Name").val();
        ////    var EmpName = $("#Address").val();
        ////    var Phone = $("#Phone").val();
        ////    var obj = {
        ////        TaskName: Name,
        ////        empName: EmpName,
        ////        phone: Phone
        ////    }
        ////    $.ajax({
        ////        type: "post",
        ////        url: "/AssignTask/Create",
        ////        data: { model: obj },
        ////        success: function (Result) {
        ////            alert("Successfully assign task")
        ////        },
        ////        error: function (Result) {
        ////            alert("Error");
        ////        }
        ////    });
        ////}
function AssignNewEmployee() {

    var At_Task = $("#TaskId").val();
    var EditEmpId = $("#EmpId").val();
    if (At_Task == "" || EditEmpId == "") {
        alert("Please fill out this field.");
        return false;
    }
    else {


        var data = new FormData();
        //data.append("date", $("#c_date1").val());
        data.append("At_TaskId", $("#TaskId").val());
        data.append("At_EmpId", $("#EmpId").val());
        $.ajax({
            url: "/AssignTask/Create",
            type: "POST",
            contentType: false,
            processData: false,
            cache: false,
            data: data,
            success: function (response) {
                alert("Task Assign Successfully");
                window.location.reload();
            },
            error: function () {
                alert("Error");
            }
        });
    }

}

/*UserAdd*/

function Delete(EmpId) {
    $.ajax({
        type: "Delete",
        url: "/Employee/Delete",
        data: { EmpId: EmpId },
        dataType: "json",
        success: function (Result) {
            alert(Result);
            window.location.reload()
        },
        error: function (Result) {
            alert("Error");
        }
    });
} function Edit(EmpId) {
    $.ajax({
        type: "GET",
        url: "/Employee/Edit",
        data: { EmpId: EmpId },
        dataType: "json",
        success: function (Result) {
            $("#EditEmpId").val(Result.empId);
            $("#EditEmpName").val(Result.empName);
            $("#EditEmpAddress").val(Result.empAddress);
            $("#EditEmpPhone").val(Result.phone);

            //window.location.reload();
        },
        error: function (Result) {
            alert("Error");
        }
    });
}
function Update() {
    var EmpId = $("#EditEmpId").val();
    var Name = $("#EditEmpName").val();
    var Address = $("#EditEmpAddress").val();
    var Phone = $("#EditEmpPhone").val();

    var obj = {
        EmpId:EmpId,
        empName: Name,
        empAddress: Address,
        phone: Phone
    }
    debugger
    $.ajax({
        type: "post",
        url: "/Employee/Edit",
        data: { EmpId: EmpId, model: obj },
        success: function (Result) {
            alert("Successfully Updated");
            window.location.reload();
        },
        error: function (Result) {
            alert("Error");
        }
    });
}
function NewEmployee() {

    var Name = $("#Name").val();
    var Address = $("#Address").val();
    var Phone = $("#Phone").val();
    
    if (Name == "" || Address == "" || Phone == "") {
        alert("Please fill out this field.");
        return false;
    }
    else {
        var obj = {
            empName: Name,
            empAddress: Address,
            phone: Phone
        }
        $.ajax({
            type: "post",
            url: "/Employee/Create",
            data: { model: obj },
            success: function (Result) {
                window.location.reload();
                alert("New User Created Successfully")
            },
            error: function (Result) {
                alert("Error");
            }
        });
    }
}

/*TaskDetailsAdd*/

    function TaskDelete(EmpId) {
        $.ajax({
            type: "Delete",
            url: "/TaskDetails/Delete",
            data: { EmpId: EmpId },
            dataType: "json",
            success: function (Result) {
                alert(Result);
                window.location.reload()
            },
            error: function (Result) {
                alert("Error");
            }
        });
        }
        function TaskEdit(EmpId) {
        $.ajax({
            type: "GET",
            //contentType: "application/json; charset=utf-8",
            url: "/TaskDetails/Edit",
            // data: "{EmpId:EmpId}",
            data: { EmpId: EmpId },
            dataType: "json",
            success: function (Result) {
                //alert(Result.TaskId);
                $("#EditTaskId").val(Result.taskId);
                $("#EditTaskName").val(Result.taskName);
                $("#EditTaskCode").val(Result.taskCode);
                // $("#EditEmpPhone").val(Result.phone);
            },
            error: function (Result) {
                alert("Error");
            }
        });
        }
        function TaskUpdate() {
            debugger;
            var TaskId = $("#EditTaskId").val();
            var TaskName = $("#EditTaskName").val();
            var TaskCode = $("#EditTaskCode").val();
            //var Phone = $("#EditEmpPhone").val();
            var obj = {
        taskName: TaskName,
                TaskCode: TaskCode,
                TaskId: TaskId
            }
            debugger
            $.ajax({
        type: "post",
                url: "/TaskDetails/Edit",
                data: {TaskId: TaskId, model: obj },
                success: function (Result) {
        alert("Success");
                    window.location.reload();
                },
                error: function (Result) {
        alert("Error");
                }
            });
        }
function NewTask() {
    var TaskName = $("#TaskName").val();
    var TaskCode = $("#TaskCode").val();

    var obj = {
        taskName: TaskName,
        TaskCode: TaskCode,
    }
    if (TaskName == "" || TaskCode == "") {
        alert("Please fill out this field.");
        return false;
    } else {
        $.ajax({
            type: "post",
            url: "/TaskDetails/Create",
            data: { model: obj },
            success: function (Result) {
                window.location.reload();
                alert("Task Created Successfully");
            },
            error: function (Result) {
                alert("Error");
            }
        });
    }
}

