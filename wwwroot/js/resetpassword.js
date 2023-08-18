$(document).ready(function () {
  $("#ResetPasswordButton").click(function (event) {
      debugger
     
      var formData = {
        Password: $("#password").val(),
        ConfirmPassword: $("#confirmpassword").val(),
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
  