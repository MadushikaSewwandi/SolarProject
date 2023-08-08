$(document).ready(function () {
    debugger;
    var user = localStorage.getItem("user");
    if (user) {
      var parsedUser = JSON.parse(user);
      var userId = parsedUser?.id;
      fetchRatings();
    } else {
      console.error("User data not found in localStorage.");
    }
  
  });
  
  function fetchRatings() {
    var user = localStorage.getItem("user");
    if (user) {
      var parsedUser = JSON.parse(user);
      var token = parsedUser?.token;
  
      $.ajax({
        type: "GET",
        url: "/api/Ratings/GetRatingsByProductName/",
        headers: {
          "Authorization": "Bearer " + token,
        },
        success: function (response) {
          console.log(response);
          displayRatings(response);
          var avgrate = sumRatingValue(response);
          displayStars(response);
          
          
        },
        error: function (error) {
          console.error("Error fetching cart items:", error.responseText);
        },
      });
    } else {
      console.error("User data not found in localStorage.");
    }
  }
  
  function displayRatings(response) {
    debugger;
    var RatingsContainer = $("#RatingsContainer");
    RatingsContainer.empty();
  
    var RatingsHtml = "";
    response.slice(-3).forEach(function (Rating) {
      //var totalPrice = (parseFloat(cartItem.productPrice) * cartItem.quantity).toLocaleString();
      console.log(Rating.name);

      var ratingValue = Rating.ratingvalue-1;
      var stars = [];
      for (let i = 0; i < ratingValue; i++) {
        stars.push('<i class="fa fa-star"></i>');
      }
      
      stars.push('<i class="fa fa-star o-empty"></i>');
      
      
  
      var itemHtml =
        "<div>"+
        "<div class='review-body'>"+
        "<h5 class='name'>"+Rating.name+"</h5>"+
        "<div class='review-rating' style='color: #D10024;'>"+
        stars.join("")+
        "</div>"+"</div>"+
        "<div class='review-body'>"+
        "<p>"+Rating.review+"</p>"+
        "</div>"
  
      RatingsHtml += itemHtml;
    });
  
    RatingsContainer.html(RatingsHtml);
  }

  function sumRatingValue(response) {
    debugger;
    var sum = 0;
    var avgrate=0;
    for (var i = 0; i < response.length; i++) {
      sum += response[i].ratingvalue;
      avgrate=sum/response.length;
    }
    
    return avgrate;
    

  }
  function displayStars(response, avgrate) {
    var avgrate = sumRatingValue(response);

    var ratingboxContainer = $("#rating-box");
    ratingboxContainer.empty();

    var itemHtmlratingbox = "";
    var RatingsHtml = "";

    if (avgrate >= 1) {
      var stars = [];
      for (var i = 0; i < avgrate; i++) {
        stars.push('<i class="fa fa-star" style="color: #D10024;"></i>');
      }
      var emptyStars = [];
      for (var i = 0; i < 5 - avgrate; i++) {
        emptyStars.push('<i class="fa fa-star o-empty"></i>');
      }

      itemHtmlratingbox += "<div class='rating-stars'>" + stars.join("") + emptyStars.join("")+"</div>";

      RatingsHtml += itemHtmlratingbox;
    }
    ratingboxContainer.html(RatingsHtml);
  }