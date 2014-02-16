function validateLogin() {
    if ($('#UserName').val().length  == 0 && $('#Password').val().length == 0) {
        alert("Error...!!");
        return false;
    }
    else {
        alert("Submitting form...!!");
        $('#loginSubmit').form.submit;
        return true;
    }
}