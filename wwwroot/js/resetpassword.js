$(document).ready(function () {
  $("#ResetPasswordButton").click(function (event) {
      debugger
      // Extract token from URL query parameters
    var urlParams = new URLSearchParams(window.location.search);
    var email = urlParams.get("email");
    var token = urlParams.get("token"); // Assuming "token" is the parameter name

      var formData = {
        Id: email,
        NewPassword: $("#password").val(),
        confirmPassword: $("#confirmpassword").val(),
        Token: token
      };
  
      console.log(formData);
      
      
      
     $.ajax({
        url: "/api/Authentication/ResetPassword" ,
        type: "POST",
        data: JSON.stringify(formData),
        contentType: "application/json",
        success: function (response) {
        
          window.location.href = "/";
        },
        error: function (error) {
          window.location.href = "/Login";
        },
      });
    });
  });
  