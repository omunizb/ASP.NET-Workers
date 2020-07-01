var baseURL = "https://localhost:44393/";

function getEmployees() {
    $.ajax({
        method: "GET",
        url: baseURL + "api/employees",
        success: function(response) {
            $("#preOutput").text(JSON.stringify(response));
        },
        dataType: "json",
        error: function(error) {
            console.log(error)
        }
      });
}

function getEmployeeById() {
    var id = document.getElementById("employeeId").value;
    $.ajax({
        method: "GET",
        url: `${baseURL}api/employees/${id}`,
        success: function(response) {
            $("#preOutput").text(JSON.stringify(response));
        },
        dataType: "json",
        error: function() {
            getEmployees();
            alert("This index does not exist!");
            console.log(error);
        }
      });
}

function postEmployee() {
    var id = parseInt(document.getElementById("id").value);
    var name = document.getElementById("name").value;
    var surname = document.getElementById("surname").value;
    var job = document.getElementById("job").value;
    var salary = parseFloat(document.getElementById("salary").value);
    var Employee = { Id: id, Name: name, Surname: surname, Job: job, Salary: salary };
    Employee = JSON.stringify(Employee);
    $.ajax({
        method: "POST",
        url: baseURL + "api/employees",
        data: Employee,
        dataType: "json",
        contentType: "application/json",
        success: function() {
            alert("The new employee was added successfully.");
        },
        error: function(error) {
            console.log(error);
        }
      });
}

function deleteEmployee() {
    var id = document.getElementById("deleteEmployee").value;
    $.ajax({
        method: "DELETE",
        url: `${baseURL}api/employees/${id}`,
        success: function() {
            alert("The new employee was removed successfully.");
        },
        dataType: "json",
        error: function() {
            getEmployees();
            alert("This index does not exist!");
            console.log(error);
        }
      });
}