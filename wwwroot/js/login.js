$(document).ready(function () {
  $("#LoginButton").click(function (event) {
    debugger
   
    var formData = {
      Email: $("#email").val(),
      Password: $("#password").val(),
    }; // Log the form data to the console
    debugger;

    console.log(formData);
    console.log("your logging....!");
    
    
   $.ajax({
      url: "/api/Authentication/Login",
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