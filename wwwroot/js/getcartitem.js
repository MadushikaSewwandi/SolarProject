$(document).ready(function () {
        var user = localStorage.getItem("user");
        if (user) {
          var parsedUser = JSON.parse(user);
          var userId = parsedUser?.id;
          fetchCartItemsByUserId(userId);
        } else {
          console.error("User data not found in localStorage.");
        }
      
      });
      
      function fetchCartItemsByUserId(userId) {
        var user = localStorage.getItem("user");
        if (user) {
          var parsedUser = JSON.parse(user);
          var token = parsedUser?.token;
      
          
          $.ajax({
            type: "GET",
            url: "/api/AddtoCart/GetCartItemsByUserId/" + userId,
            headers: {
              "Authorization": "Bearer " + token, 
            },
            success: function (response) {
             
              displayCartItems(response);
            },
            error: function (error) {
              console.error("Error fetching cart items:", error.responseText);
              
            },
          });
        } else {
        
          console.error("User data not found in localStorage.");
        }
      }
      
      function displayCartItems(cartItems) {
        var cartItemsContainer = $("#cartListContainer");
        cartItemsContainer.empty();
      
        // Create the HTML to display the cart items
        var cartItemsHtml = "";
        cartItems.forEach(function (cartItem) {
          var totalPrice = (parseFloat(cartItem.productPrice) * cartItem.quantity).toLocaleString();
      
          var itemHtml =
            "<div class='product-widget'>" +
            "<a href='" + cartItem.productLink + "'>" +
            "<div class='product-img'>" +
            "<img src='" + cartItem.productThumbnail + "' alt=''>" +
            "</div>" +
            "<div class='product-body'>" +
            "<h3 class='product-name'><a href='#'>" + cartItem.productName + "</a></h3>" +
            "<h4 class='product-price'><span class='qtys'>" + cartItem.quantity + "x</span>$" + totalPrice + "</h4>" +
            "</div>" +
            "<button class='delete'><i class='fa fa-close'></i></button>" +
            "</a>" +
            "</div>";
      
          cartItemsHtml += itemHtml;
        });
      
        // Append the generated HTML to the cartItemsContainer
        cartItemsContainer.html(cartItemsHtml);
      
        // Update the cart summary in the cart dropdown
        updateCartSummary(cartItems);
      }
      
      function updateCartSummary(cartItems) {
        var totalItems = cartItems.reduce(function (total, cartItem) {
          return total + cartItem.quantity;
        }, 0);
      
        
        var totalPrice = cartItems.reduce(function (total, cartItem) {
            return total + parseFloat(cartItem.productPrice) * parseInt(cartItem.quantity);
        }, 0);
       
    
        $(".cart-summary small").text(totalItems + " Item(s) selected");
        $(".cart-summary h5").text("SUBTOTAL: Rs." + totalPrice.toLocaleString());
        $(".qty").text(totalItems);
      }