$(document).ready(function () {
    
    $("#LoginForm").submit(function (event) {
        console.log("your logging....!")

        // Prevent the default form submission behavior
        event.preventDefault();

        // Collect form data
        var formData = {
            Email: $("#email").val(),
            Password: $("#password").val()
        };

        // Log the form data to the console
        console.log(formData);

        $.ajax({
            url: "/api/Authentication/Login",
            type: "POST",
            data: JSON.stringify(formData), 
            contentType: "application/json",
            success: function (response) {
                debugger
                console.log("Success function is executed.");
                console.log(response);
                localStorage.setItem("token", response.token);
                console.log("Token stored in local storage.");
            },
            
            error: function (error) {
                
                window.location.href = '/'; 
            }
        });
    
    });
});

