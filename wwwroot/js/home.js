$(document).ready(function () {
    debugger
    var user = localStorage.getItem("user");
              if (user) {
                  var parsedUser = JSON.parse(user);
                  console.log(parsedUser.id)
                  if (parsedUser.id) {
                      $("#profileContainer").show();
                  }
              }
  });
  