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

var id, name, surname, job, salary, Employee;

function submitEmployee() {
    id = parseInt(document.getElementById("id").value);
    name = document.getElementById("name").value;
    surname = document.getElementById("surname").value;
    job = document.getElementById("job").value;
    salary = parseFloat(document.getElementById("salary").value);
    Employee = { Id: id, Name: name, Surname: surname, Job: job, Salary: salary };
    Employee = JSON.stringify(Employee);
    var chosenMethod = document.getElementById("methods");
    chosenMethod = chosenMethod.options[chosenMethod.selectedIndex].value;
    if (chosenMethod == "post")
    {
        postEmployee();
    }
    else if (chosenMethod == "put")
    {
        putEmployee();
    }
    else
    {
        console.log("You must choose an HTTP method.");
    }
}

function postEmployee() {
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
            alert("That eployee ID may already exist");
            console.log(error);
        }
      });
}

function putEmployee() {
    $.ajax({
        method: "PUT",
        url: `${baseURL}api/employees/${id}`,
        data: Employee,
        dataType: "json",
        contentType: "application/json",
        success: function() {
            alert(`The employee with ID ${id} was updated successfully.`);
        },
        error: function(error) {
            alert("That eployee ID may not exist");
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