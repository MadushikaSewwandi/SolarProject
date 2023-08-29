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
        updateCartTable(response);
        updateOrderSummary(response); 
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

  var cartItemsHtml = "";
  cartItems.forEach(function (cartItem) {
    var totalPrice = ((cartItem.productPrice) * cartItem.quantity);

    var itemHtml =
      "<div class='product-widget'>" +
      "<a href='" + cartItem.productLink + "'>" +
      "<div class='product-img'>" +
      "<img src='" + cartItem.productThumbnail + "' alt=''>" +
      "</div>" +
      "<div class='product-body'>" +
      "<h3 class='product-name'><a href='#'>" + cartItem.productName + "</a></h3>" +
      "<h4 class='product-price'><span class='qtys'>" + cartItem.quantity + "x</span>$" + cartItem.productPrice + "</h4>" +
      "</div>" +
      "<button class='delete' data-cart-item-id='" + cartItem.id + "'><i class='fa fa-close'></i></button>" +
      "</a>" +
      "</div>";

    cartItemsHtml += itemHtml;
  });

  cartItemsContainer.html(cartItemsHtml);

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
  $(".cart-summary h5").text("SUBTOTAL: $" + totalPrice.toLocaleString());
  $(".qty").text(totalItems);
}

function updateCartTable(cartItems) {
  var tableItemsContainer = $("#cartTableBody");
  tableItemsContainer.empty();

  var tableItemHtml = ""; 

  cartItems.forEach(function (cartItem) {
    var totalPrice = ((cartItem.productPrice) * cartItem.quantity).toLocaleString();

    
    tableItemHtml +=
      "<tr>" +
      "<td class='align-middle'><img src='" + cartItem.productThumbnail + "' alt='' style='width: 50px;'></td>" +
      "<td class='align-middle'>" + cartItem.productName + "</td>" +
      "<td class='align-middle'>$" + cartItem.productPrice + "</td>" +
      "<td class='align-middle'>" +
      "<div class='input-group quantity mx-auto' style='width: 100px;'>" +
      "<div class='input-group-btn'>" +
      "</div>" +
      "<input type='text' class='form-control form-control-sm bg-secondary text-center' value='" + cartItem.quantity + "'>" +
      "<div class='input-group-btn'>" +
      "</div>" +
      "</div>" +
      "</td>" +
      "<td class='align-middle'>$" + totalPrice + "</td>" +
      "</tr>";
  });

  
  tableItemsContainer.html(tableItemHtml);
}

function calculateTotalPrice(cartItem) {
  return parseFloat(cartItem.productPrice) * parseInt(cartItem.quantity);
}



function updateOrderSummary(cartItems) {
  var orderProductsHtml = "";
  var totalPrice = 0;

  cartItems.forEach(function (item) {
    
    var totalPricePerItem = calculateTotalPrice(item); 
    orderProductsHtml +=
      "<div class='order-col'>" +
      "<div>" + item.quantity + "x " + item.productName + "</div>" +
      "<div>$" + totalPricePerItem + "</div>" +
      "</div>";

    totalPrice += totalPricePerItem; 
  });

  console.log("orderProductsHtml:", orderProductsHtml);
  console.log("totalPrice:$", totalPrice);

  
  $(".order-products").html(orderProductsHtml);
  $(".order-total").text("$" + totalPrice.toLocaleString()); 
}








