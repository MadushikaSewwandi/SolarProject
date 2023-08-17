$(document).ready(function () {
  $("#ForgetPasswordButton").click(function (event) {
      debugger
    
     
      var formData = {
        Email: $("#email").val(),
       
      }; 
  
      console.log(formData);
      console.log(encodeURIComponent(email));
      console.log("forget password.........");
      
      
     $.ajax({
        type: "GET",
        url: "/api/Authentication/SendResetPwdLink?email=" + encodeURIComponent(formData.Email),
        data: JSON.stringify(formData),
        contentType: "application/json",
        success: function (response) {
        
          console.log("Rest email successfully sent");
        },
        error: function (error) {
          window.location.href = "/Login";
        },
      });
    });
  });
  
