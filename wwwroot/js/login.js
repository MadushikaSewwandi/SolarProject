$(document).ready(function () {
  $("#LoginButton").click(function (event) {
    event.preventDefault();

    var formData = {
      Email: $("#email").val(),
      Password: $("#password").val(),
    };

    $.ajax({
      url: "/api/Authentication/Login",
      type: "POST",
      data: JSON.stringify(formData),
      contentType: "application/json",
      success: function (response) {
        console.log("Login successful");
        localStorage.setItem("user", JSON.stringify(response));
        window.location.href = "/";
      },
      error: function (xhr, textStatus, errorThrown) {
        console.error("Error in AJAX request:", textStatus);
      },
      complete: function () {
        console.log("AJAX request completed.");
      },
    });
  });
});

var user = localStorage.getItem("user");
if (user) {
  var parsedUser = JSON.parse(user);
  var firstName = parsedUser?.firstName;
  var greeting = "Welcome";
  document.getElementById("loginName").textContent = greeting + " " + firstName;
} else {
  console.error("User data not found in localStorage.");
}
