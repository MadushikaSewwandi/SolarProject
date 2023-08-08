$(document).ready(function () {
    $("#RegisterForm").click(function (event) {
        // Prevent the default form submission behavior
        event.preventDefault();

        // Collect form data
        var formData = {
            firstName: $("#firstname").val(),
            lastName: $("#lastname").val(),
            tel: $("#tel").val(),
            email: $("#email").val(),
            password: $("#password").val()
        };

        // Log the form data to the console
        console.log(formData);

        $.ajax({
            url: "/api/Authentication/Register", // Replace this with the actual URL of your controller's action method
            type: "POST",
            data: JSON.stringify(formData),
            contentType: "application/json",
            success: function (response) {
                // Optionally, you can handle the success response here
                console.log("User registered successfully!");
                alert("User registered successfully!");
                console.log(response); // If your controller returns a message like "User registered successfully!", you can log it here.
                // Optionally, you can redirect the user to another page after successful registration.
                // window.location.href = '/success'; // Replace '/success' with the URL of the success page.
                window.location.href="/";
            },
            error: function (error) {
                // Optionally, you can handle the error response here
                console.error("Error sending form data:", error);
            }
        });
       
    });
});

