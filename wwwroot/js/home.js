$(document).ready(function () {
   var user = localStorage.getItem("user");
              if (user) {
                  var parsedUser = JSON.parse(user);
                  console.log(parsedUser.id)
                  if (parsedUser.id) {
                      $("#profileContainer").show();
                      $("#logoutButton").show();
                  }
              }
  });
  