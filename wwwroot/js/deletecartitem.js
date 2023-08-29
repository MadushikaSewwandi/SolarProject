$(document).ready(function () {
  
    $("#cartListContainer").on("click", ".delete", function () {
        debugger
        
        var itemId = $(this).data("cart-item-id");
        
       
        deleteCartItem(itemId);
    });
});


function deleteCartItem(itemId) {
    var user = localStorage.getItem("user");
    if (user) {
        var parsedUser = JSON.parse(user);
        var token = parsedUser?.token;

       
        $.ajax({
            type: "DELETE",
            url: "/api/AddtoCart/DeleteCartItem/" + itemId,
            headers: {
                "Authorization": "Bearer " + token,
            },
            success: function (response) {
                
                fetchCartItemsByUserId(parsedUser?.id);
            },
            error: function (error) {
                console.error("Error deleting cart item:", error.responseText);
               
            },
        });
    } else {
        console.error("User data not found in localStorage.");
    }
}
