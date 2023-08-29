$(document).ready(function () {
    var user = localStorage.getItem("user");
    if (user) {
      var parsedUser = JSON.parse(user);
      var userId = parsedUser?.id;
      var token = parsedUser?.token;
      var userEmail = parsedUser?.firstName;

  
      $.ajax({
        type: "GET",
        url: "/api/UserProfile/ProfileDetails/"+ userId,
        headers: {
          "Authorization": "Bearer " + token, 
        },
        success: function (response) {
            document.getElementById('firstname').value = response.firstName;
            document.getElementById('lastname').value = response.lastName;
            document.getElementById('tel').value = response.phoneNumber;
            document.getElementById('email').value = response.email;
        
        },
        error: function (error) {
          console.error("Error fetching cart items:", error.responseText);
        },
      });
    } else {
      console.error("User data not found in localStorage.");
    }
  
    
    $("#ProfileButton").click(function (event) {
        var FirstName = $("#firstname").val();
        var LastName = $("#lastname").val();
        var PhoneNumber = $("#tel").val();
        var Email = $("#email").val();

        var user = localStorage.getItem("user");
        if (user) {
            var parsedUser = JSON.parse(user);
            var userId = parsedUser?.id;
            var token = parsedUser?.token;

            var formData = {
                UserId: userId,
                FirstName: FirstName,
                LastName: LastName,
                PhoneNumber: PhoneNumber,
                Email: Email,
            };

            $.ajax({
                url: "/api/UserProfile/GetProfileDetails", 
                type: "POST",
                data: JSON.stringify(formData),
                contentType: "application/json",
                headers: {
                    "Authorization": "Bearer " + token, 
                },
                success: function (response) {
                    console.log("User Update successfully!");
                    window.location.href = "/"; 
                },
                error: function (error) {
                    console.error("Error sending form data:", error);
                }
            });
        }
    });
});


   

  function displayBillingDetails(callingMember) {
    
  
    




}

