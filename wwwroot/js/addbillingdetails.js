$(document).ready(function () {
    
    
 
        $("#placeorderbtn").on("click", function ()
{
          
          
     
            
        // Get the values from the form fields
        var firstname=document.getElementById("first-name").value;
        var lastname=document.getElementById("last-name").value;
        var email=document.getElementById("email").value;
        var telephone=document.getElementById("telephone").value;
        var address = document.getElementById("address").value;
        var city = document.getElementById("city").value;
        var country = document.getElementById("country").value;
        var zipcode = document.getElementById("zipcode").value;
        
      
        // Print the form values to the console
        console.log("Address: " + address);
        console.log("City: " + city);
        console.log("Country: " + country);
        console.log("ZIP Code: " + zipcode);
        
  
            
          
      
          // Get user data from localStorage
          var user = localStorage.getItem("user");
          if (user) {
            var parsedUser = JSON.parse(user);
            var userId = parsedUser?.id;
            var token = parsedUser?.token;
      
            var item = {
              
                UserId:userId,
                FirstName:firstname,
                LastName:lastname,
                Email:email,
                Address: address,
                City: city,
                Country: country,
                ZipCode: zipcode,
                Telephone:telephone

                
              
            };
            console.log(item)
      
            // Make an AJAX POST request to add the item to the cart
           $.ajax({
              type: "POST",
              url: "/api/GetBillingDetails/AddBillingDetail",
              data: JSON.stringify(item),
              contentType: "application/json",
              headers: {
                "Authorization": "Bearer " + token, // Include the JWT token in the request headers
              },
              success: function (response) {
                console.log("Item added to the cart successfully.");
                // Handle any success actions if needed
              },
              error: function (error) {
                console.error("Error adding item to cart:", error.responseText);
                // Handle any error actions if needed
              },
            });
            
      
          } else {
            // Handle the case when user data is not available in localStorage
            console.error("User data not found in localStorage.");
          }
        });
      });