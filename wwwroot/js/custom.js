$(document).ready(function () {
 
        $("#addToCartBtn").on("click", function ()
    
{
          console.log("add to cart");
          debugger;
      
          before before before before 
          var productPrice = $("#productPrice").val();
          var productThumbnail = $("#productThumbnail").val();
          var quantity = parseInt($("#quantityInput").val());
          var productLink = $("#quantityInput").data("product-url");
      
          // Get user data from localStorage
          var user = localStorage.getItem("user");
          if (user) {
            var parsedUser = JSON.parse(user);
            var userId = parsedUser?.id;
            var token = parsedUser?.token;
      
            var item = {
              
                UserId:userId,
                ProductName: productName,
                ProductPrice: parseFloat(productPrice),
                ProductThumbnail: productThumbnail,
                Quantity: parseInt(quantity),
                ProductLink: productLink,
              
            };
            console.log(item)
      
            // Make an AJAX POST request to add the item to the cart
            $.ajax({
              type: "POST",
              url: "/api/AddtoCart/AddItem",
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