$(document).ready(function () {
  $("#LoginForm").submit(function (event) {
    console.log("your logging....!");

    // Prevent the default form submission behavior
    event.preventDefault();

    // Collect form data
    var formData = {
      Email: $("#email").val(),
      Password: $("#password").val(),
    }; // Log the form data to the console

    console.log(formData);
    
<<<<<<< HEAD
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
        console.log(formData);


        $.ajax({
            url: "/api/Authentication/Login",
            type: "POST",
            data: JSON.stringify(formData), 
            contentType: "application/json",
            success: function (response) {
                
                console.log(response);
                console.log("below is Email")
                console.log(response.id);
                localStorage.setItem("token", response.token);
                localStorage.setItem("user", JSON.stringify(response));
                console.log(localStorage.getItem("token"));
                
                window.location.href = '/';
                
                
            },
            error: function (error) {
                
                window.location.href = '/Login'; 
            }
        });
    
=======

    $.ajax({
      url: "/api/Authentication/Login",
      type: "POST",
      data: JSON.stringify(formData),
      contentType: "application/json",
      success: function (response) {
        console.log(response);
        localStorage.setItem("token", response.token);
        localStorage.setItem("user", JSON.stringify(response)); // Save the user information
        console.log(localStorage.getItem("token"));
      },
      error: function (error) {
        window.location.href = "/Login";
      },
>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5
    });
  });
});
