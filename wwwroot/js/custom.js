$(document).ready(function () {
    $("#addToCartBtn").on("click", function () {
        console.log("add to cart")

         // Check if the user is authenticated
         var token = localStorage.getItem("token");
         console.log(token)
         var decodedToken = jwt.decode(token);
        var userId = decodedToken.id;
         if (!token) {
             // Redirect to the login page or show an error message
             console.error("User is not authenticated. Please log in.");
             return;
         }
         
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

        // Get existing cart items from localStorage or initialize an empty array
        var existingCartItems = JSON.parse(localStorage.getItem("cartItems")) || [];

        // Check if the product is already in the cart
        var existingCartItem = existingCartItems.find(function (item) {
            return item.productName === productName;
        });

        if (existingCartItem) {
            // If the product is already in the cart, update its quantity
            existingCartItem.quantity += quantity;
        } else {
            // If the product is not in the cart, add it as a new item
            existingCartItems.push({
                productName: productName,
                productPrice: productPrice,
                quantity: quantity,
                productThumbnail: productThumbnail,
                productLink: productLink,
            });
        }

        // Save the updated cart items back to localStorage
        localStorage.setItem("cartItems", JSON.stringify(existingCartItems));

        // Update the cart dropdown on the home page
        updateCartDropdown(existingCartItems);

        // Update the cart page table
        updateCartTable(existingCartItems);

        // Update the order summary section
        updateOrderSummary(existingCartItems);
    });

    

    // Function to calculate the total price of an item
    function calculateTotalPrice(item) {
        var priceWithoutComma = item.productPrice.replace(/,/g, "");
        return parseFloat(priceWithoutComma) * parseInt(item.quantity);
    }

    // Function to update the cart dropdown
    function updateCartDropdown(cartItems) {
        var cartItemsHtml = "";

        // Generate the HTML for each cart item
        cartItems.forEach(function (item) {
            var totalPrice = calculateTotalPrice(item).toLocaleString();

            var itemHtml =
                "<div class='product-widget'>" +
                "<a href='" + item.productLink + "'>" +
                "<div class='product-img'>" +
                "<img src='" + item.productThumbnail + "' alt=''>" +
                "</div>" +
                "<div class='product-body'>" +
                "<h3 class='product-name'><a href='#'>" + item.productName + "</a></h3>" +
                "<h4 class='product-price'><span class='product-price'>" + item.quantity + "x</span>" + item.productPrice + "</h4>" +
                "</div>" +
                "<button class='delete'><i class='fa fa-close'></i></button>" +
                "</a>" +
                "</div>";

            cartItemsHtml += itemHtml;
        });

        // Update the cart dropdown on the home page
        $("#cartListContainer").html(cartItemsHtml);

        // Update the cart summary in the home page cart section
        var totalItems = cartItems.reduce(function (total, item) {
            return total + item.quantity;
        }, 0);

        var totalPrice = cartItems.reduce(function (total, item) {
            var priceWithoutComma = item.productPrice.replace(/,/g, "");
            return total + parseFloat(priceWithoutComma) * parseInt(item.quantity);
        }, 0);

        $(".cart-summary small").text(totalItems + " Item(s) selected");
        $(".cart-summary h5").text("SUBTOTAL: Rs." + totalPrice.toLocaleString());
        $(".qty").text(totalItems);
    }

    // Function to update the cart page table with cart items
    function updateCartTable(cartItems) {
        var cartTableHtml = "";

        // Generate the HTML for each cart item
        cartItems.forEach(function (item) {
            var totalPrice = calculateTotalPrice(item).toLocaleString();

            var tableItemHtml =
                "<tr>" +
                "<td class='align-middle'><img src='" + item.productThumbnail + "' alt='' style='width: 50px;'></td>" +
                "<td class='align-middle'>" + item.productName + "</td>" +
                "<td class='align-middle'>" + item.productPrice + "</td>" +
                "<td class='align-middle'>" +
                "<div class='input-group quantity mx-auto' style='width: 100px;'>" +
                "<div class='input-group-btn'>" +
                "</div>" +
                "<input type='text' class='form-control form-control-sm bg-secondary text-center' value='" + item.quantity + "'>" +
                "<div class='input-group-btn'>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "<td class='align-middle'>" + totalPrice + "</td>" +
                "</tr>";

            cartTableHtml += tableItemHtml;
        });

        // Update the cart page table with cart items
        $("#cartTableBody").html(cartTableHtml);
    }

    // Function to update the order summary section
    function updateOrderSummary(cartItems) {
        var orderProductsHtml = "";
        var totalPrice = 0;

        // Generate the HTML for each item in the order summary
        cartItems.forEach(function (item) {
            var totalPricePerItem = calculateTotalPrice(item);
            totalPrice += totalPricePerItem;

            var orderItemHtml =
                "<div class='order-col'>" +
                "<div>" + item.quantity + "x " + item.productName + "</div>" +
                "<div>" + totalPricePerItem + "</div>" +
                "</div>";

            orderProductsHtml += orderItemHtml;
        });

        // Update the order summary section
        $(".order-products").html(orderProductsHtml);
        $(".order-total").text("" + totalPrice);
    }

    var existingCartItems = JSON.parse(localStorage.getItem("cartItems")) || [];
    updateCartDropdown(existingCartItems);
    updateCartTable(existingCartItems);
    updateOrderSummary(existingCartItems);

    function removeCartItem(productName) {
        var existingCartItems = JSON.parse(localStorage.getItem("cartItems")) || [];
        var updatedCartItems = existingCartItems.filter(function (item) {
            return item.productName !== productName;
        });

        // Save the updated cart items back to localStorage
        localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));

        // Update the cart dropdown on the home page
        updateCartDropdown(updatedCartItems);

        // Update the cart page table
        updateCartTable(updatedCartItems);

        // Update the order summary section
        updateOrderSummary(updatedCartItems);
    }

    $("#cartListContainer").on("click", ".delete", function () {
        var productName = $(this).siblings(".product-body").find(".product-name a").text();
        removeCartItem(productName);
    });


});