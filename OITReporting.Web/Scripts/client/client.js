/// <reference path="jquery-1.9.1.intellisense.js" />
//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/ClientManager/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.clientId+ '</td>';
                html += '<td>' + item.ContactPersonName + '</td>';
                html += '<td>' + item.emailId + '</td>';
                html += '<td>' + item.companyName + '</td>';
                html += '<td>' + item.contactPersonContactNo1+ '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.clientId + ')">Edit</a> | <a href="#" onclick="Delele(' + item.clientId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function 

function Add() {
    /*var res = validate1();
    if (res == false) {
        return false;
    }*/
    var empObj = {
        clientId: $('#clientId').val(),
        userId: $('#userId').val(),
        domainId: $('#domainId').val(),
        status: $('#status').val(),
        emailId: $('#emailId').val(),
        companyName: $('#companyName').val(),
        ContactPersonName: $('#ContactPersonName').val(),
        ContactPersonDesignation: $('#ContactPersonDesignation').val(),
        contactPersonContactNo1: $('#contactPersonContactNo1').val(),
        address: $('#address').val(),
        city: $('#city').val(),
        state: $('#state').val(),
        counytryId: $('#counytryId').val(),
        isResponded: $('#isResponded').val(),
        isUnsubscribe: $('#isUnsubscribe').val()
        
    };
    $.ajax({
        url: "/ClientManager/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
/*
//Function for getting the Data Based upon Employee ID
function getbyID(userID) {
    $('#firstName').css('border-color', 'lightgrey');
    $('#ge').css('border-color', 'lightgrey');
    $('#state').css('border-color', 'lightgrey');
    $('#emailID').css('border-color', 'lightgrey');
    $.ajax({
        url: "/UserManager/getbyID/" + userID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#userID').val(result.userId);
            $('#firstName').val(result.firstName);
            $('#lastName').val(result.lastName),
                $('#dob').val(result.dob),
                $('#ge').val(result.gender);
                $('#address').val(result.address),
                $('#city').val(result.city),
                $('#state').val(result.state);
                $('#cou').val(result.countryId),
                $('#contactNo').val(result.contactNo),
                $('#emailId').val(result.emailID),
                $('#password').val(result.password)

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record
function Update() {
    var res = validate1();
    if (res == false) {
        return false;
    }
    var empObj = {
        userID: $('#userID').val(),
        firstName: $('#firstName').val(),
        lastName: $('#lastName').val(),
        dob: $('#dob').val(),
        gender: $('#ge').val(),
        address: $('#address').val(),
        city: $('#city').val(),
        state: $('#state').val(),
        countryId: $('#cou').val(),
        contactNo: $('#contactNo').val(),
        emailID: $('#emailId').val(),
        password: $('#password').val()
    };
    $.ajax({
        url: "/UserManager/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#userID').val(""),
            $('#firstName').val(""),
            $('#lastName').val(""),
            $('#dob').val(""),
            $('#ge').val(""),
            $('#address').val(""),
            $('#city').val(""),
            $('#state').val(""),
            $('#cou').val(""),
            $('#contactNo').val(""),
            $('#emailId').val(""),
            $('#password').val("")
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/UserManager/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes
function clearTextBox() {
        $('#userID').val("");
        $('#firstName').val(""),
        $('#lastName').val(""),
        $('#dob').val(""),
        $('#ge').val(""),
        $('#address').val(""),
        $('#city').val(""),
        $('#state').val(""),
        $('#cou').val(""),
        $('#contactNo').val(""),
        $('#emailId').val(""),
        $('#password').val("")
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#firstName').css('border-color', 'lightgrey');
    $('#gender').css('border-color', 'lightgrey');
    $('#state').css('border-color', 'lightgrey');
    $('#countrId').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#firstName').val().trim() == "") {
        $('#firstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#firstName').css('border-color', 'lightgrey');
    }
    if ($('#lastName').val().trim() == "") {
        $('#lastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#lastName').css('border-color', 'lightgrey');
    }
    if ($('#dob').val().trim() == "") {
        $('#dob').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dob').css('border-color', 'lightgrey');
    }
    if ($('#gender').val().trim() == "") {
        $('#gender').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#gender').css('border-color', 'lightgrey');
    }
    if ($('#address').val().trim() == "") {
        $('#address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#address').css('border-color', 'lightgrey');
    }
    if ($('#city').val().trim() == "") {
        $('#city').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#city').css('border-color', 'lightgrey');
    }
    if ($('#state').val().trim() == "") {
        $('#state').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#state').css('border-color', 'lightgrey');
    }
    return isValid;
}
function validate1() {
    var isValid = true;
    if ($('#firstName').val()== "") {
        $('#firstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#firstName').css('border-color', 'lightgrey');
    }
    if ($('#lastName').val() == "") {
        $('#lastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#lastName').css('border-color', 'lightgrey');
    }
    if ($('#dob').val()== "") {
        $('#dob').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dob').css('border-color', 'lightgrey');
    }
    if ($('#ge').val()== "") {
        $('#ge').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ge').css('border-color', 'lightgrey');
    }
    if ($('#address').val()== "") {
        $('#address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#address').css('border-color', 'lightgrey');
    }
    if ($('#city').val()== "") {
        $('#city').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#city').css('border-color', 'lightgrey');
    }
    if ($('#state').val()== "") {
        $('#state').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#state').css('border-color', 'lightgrey');
    }
    if ($('#cou').val() == "") {
        $('#cou').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#cou').css('border-color', 'lightgrey');
    }
    if ($('#contactNo').val() == "") {
        $('#contactNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contactNo').css('border-color', 'lightgrey');
    }
    if ($('#emailId').val() == "") {
        $('#emailId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#emailId').css('border-color', 'lightgrey');
    }
    if ($('#password').val() == "") {
        $('#password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#password').css('border-color', 'lightgrey');
    }
    return isValid;
}*/
