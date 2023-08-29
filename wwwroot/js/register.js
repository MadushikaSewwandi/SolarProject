$(document).ready(function () {
    $("#RegisterButton").click(function (event) {
        event.preventDefault(); 

        var FirstName = $("#firstname").val();
        var LastName = $("#lastname").val();
        var PhoneNumber = $("#tel").val();
        var Email = $("#email").val();
        var Password = $("#password").val();

        var formData = {
            FirstName: FirstName,
            LastName: LastName,
            PhoneNumber: PhoneNumber,
            Email: Email,
            Password: Password,
        };


        $.ajax({
            url: "/api/Authentication/Register",
            type: "POST",
            data: JSON.stringify(formData),
            contentType: "application/json",
            success: function (response) {
                console.log("User registered successfully!");
                console.log(response);
                window.location.href = "/";
            },
            error: function (xhr, textStatus, errorThrown) {
                console.error("Error sending form data:", textStatus);
            },
            complete: function () {
                console.log("AJAX request completed.");
            }
        });
    });
});


