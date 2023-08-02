        // Import jwt_decode at the beginning of your script, outside any functions
        // Not required in this case as it's already included using script tags
        // import jwt_decode from "jwt-decode";
        

        $(document).ready(function () {
            $("#addToCartBtn").on("click", function () {
                console.log("add to cart");
                
                // Check if the user is authenticated
                var token = localStorage.getItem("token");
                console.log(token);
                debugger;

                // Call the decodeToken function to decode the token
                var decodedToken = decodeToken(token);
                console.log(decodedToken);
                console.log("hi");
                 
                if (!token) {
                    // Redirect to the login page or show an error message
                    console.error("User is not authenticated. Please log in.");
                    return;
                }

                var userId = decodedToken.id;

                var productName = $("#productName").val();
                var productPrice = $("#productPrice").val();
                var productThumbnail = $("#productThumbnail").val();
                var quantity = parseInt($("#quantityInput").val());
                var productLink = $("#quantityInput").data("product-url");

                var item = {
                    Id: userId,
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
            
            // Move the decodeToken function outside the click event handler
            function decodeToken(token) {
                debugger;
                try {
                    const decodedToken = window.jwt_decode(token);
                    return decodedToken;
                } catch (error) {
                    console.error("Error decoding token:", error);
                    return null;
                }
            }
        });
    