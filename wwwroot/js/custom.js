$(document).ready(function () {
    $("#addToCartBtn").on("click", function () {
        console.log("add to cart")

         // Check if the user is authenticated
         var token = localStorage.getItem("token");
         console.log(token)
         
         if (!token) {
             // Redirect to the login page or show an error message
             console.error("User is not authenticated. Please log in.");
             return;
         }
         
         var decodedToken = jwt.decode(token);
        var userId = decodedToken.id;
        
       

        var productName = $("#productName").val();
        var productPrice = $("#productPrice").val();
        var productThumbnail = $("#productThumbnail").val();
        var quantity = parseInt($("#quantityInput").val());
        var productLink = $("#quantityInput").data("product-url");

        var item = {
            Id:userId,
            ProductName: productName,
            ProductPrice: productPrice,
            ProductThumbnail: productThumbnail,
            Quantity: quantity,
            ProductLink: productLink
        };

        // Make an AJAX POST request to add the item to the cart
        $.ajax({
            type: "POST",
            url: "/api/AddtoCart/AddItem",
            data: JSON.stringify(item),
            contentType: "application/json",
            success: function (response) {
                console.log("Item added to the cart successfully.");
                // Handle any success actions if needed
            },
            error: function (error) {
                console.error("Error adding item to cart:", error.responseText);
                // Handle any error actions if needed
            }
        });

    });


});