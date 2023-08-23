$(document).ready(function () {
  $("#LoginButton").click(function (event) {
    debugger;
    event.preventDefault();


    var formData = {
      Email: $("#email").val(),
      Password: $("#password").val(),
    }; // Log the form data to the console


    console.log(formData);
    console.log("your logging....!");



    $.ajax({
      url: "/api/Authentication/Login",
      type: "POST",
      data: JSON.stringify(formData),
      contentType: "application/json",
      success: function (_response) {
        localStorage.setItem("token", _response.token);
        localStorage.setItem("user", JSON.stringify(_response));





        window.location.href = "/";



      },
      error: function (error) {
        window.location.href = "/Login";
      },

    });
  });


});
var user = localStorage.getItem("user");
if (user) {
  var parsedUser = JSON.parse(user);
  var firstName = parsedUser?.firstName;
  var greeting ="Welcome";
  document.getElementById('loginName').textContent = greeting+" "+firstName;

} else {
  console.error("User data not found in localStorage.");
}