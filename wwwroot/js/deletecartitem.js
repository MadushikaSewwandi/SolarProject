$(document).ready(function () {
    // Click event handler for the delete button inside #cartListContainer
    $("#cartListContainer").on("click", ".delete", function () {
        debugger
        // Get the cart item's ID from the data attribute of the delete button
        var itemId = $(this).data("cart-item-id");
        
        // Call the function to delete the cart item from the database
        deleteCartItem(itemId);
    });
});

// Function to delete the cart item from the database
function deleteCartItem(itemId) {
    var user = localStorage.getItem("user");
    if (user) {
        var parsedUser = JSON.parse(user);
        var token = parsedUser?.token;

        // Make an AJAX DELETE request to delete the cart item by its ID
        $.ajax({
            type: "DELETE",
            url: "/api/AddtoCart/DeleteCartItem/" + itemId,
            headers: {
                "Authorization": "Bearer " + token,
            },
            success: function (response) {
                // Cart item deleted successfully, refresh the cart items on the frontend
                fetchCartItemsByUserId(parsedUser?.id);
            },
            error: function (error) {
                console.error("Error deleting cart item:", error.responseText);
                // Handle any error actions if needed
            },
        });
    } else {
        console.error("User data not found in localStorage.");
    }
}
