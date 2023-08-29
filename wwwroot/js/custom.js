$(document).ready(function () {
 
    $("#addToCartBtn").on("click", function () {
      console.log("add to cart");
      debugger
  
      var productName = $("#productName").val();
      var productPrice = $("#productPrice").val();
      var productThumbnail = $("#productThumbnail").val();
      var quantity = parseInt($("#quantityInput").val());
      var productLink = $("#quantityInput").data("product-url");
  
      
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
  
       
        $.ajax({
          type: "POST",
          url: "/api/AddtoCart/AddItem",
          data: JSON.stringify(item),
          contentType: "application/json",
          headers: {
            "Authorization": "Bearer " + token, 
          },
          success: function (response) {
            console.log("Item added to the cart successfully.");
           
          },
          error: function (error) {
            console.error("Error adding item to cart:", error.responseText);
            
          },
        });
        
  
      } else {
        window.location.href = "/Login"; 
      }
    });

    
  });
  
  