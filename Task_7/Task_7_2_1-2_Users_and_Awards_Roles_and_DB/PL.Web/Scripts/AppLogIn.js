$(document).ready(onReady);

function onReady() {
    $('#loginButton').click(logIn);
    $('#registrationButton').click(register);

    $(document).keydown(function (event) {
        if (event.keyCode === 13) {
            $('#loginButton').click();
        }
    });
}

function register() {
    $.post("/Pages/processSingIn.cshtml",
        {
            Login: $('#login').val(),
            Password: $.md5($('#password').val()),
            IsAdmin: $('#is_admin').prop('checked')
        }, function (data) {
            $('#result').html(data);
        });
}

function logIn() {
    $.post("/Pages/processLogIn.cshtml",
        {
            Login: $('#login').val(),
            Password: $.md5($('#password').val())
        }, function (data) {
            if (data == "")
                window.location.href = "/";
            else
                $('#result').html(data);
        });
}