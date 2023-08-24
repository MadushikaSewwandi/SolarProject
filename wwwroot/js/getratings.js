var start= -3;
var end;
$(document).ready(function () {
  debugger;
  var productName = $("#productName").val();
  var user = localStorage.getItem("user");
  if (user) {
    var parsedUser = JSON.parse(user);
    var userId = parsedUser?.id;
    fetchRatings(productName);
    fetchRatings();
    updateStartEndValues(newStart, newEnd);
  } else {
    console.error("User data not found in localStorage.");
  }
});




function fetchRatings(productName) {
  var user = localStorage.getItem("user");
  if (user) {
    var parsedUser = JSON.parse(user);
    var token = parsedUser?.token;
    debugger;

    $.ajax({
      type: "GET",
      url: "/api/Ratings/GetRatingsByProductName?productName=" + productName,
      headers: {
        "Authorization": "Bearer " + token,
      },
      success: function (response) {
        console.log(response);
        displayRatings(response);
        var avgrate = sumRatingValue(response);
        displayStars(response);
        starcount(response);


      },
      error: function (error) {
        console.error("Error fetching cart items:", error.responseText);
      },
    });
    console.log(response);
  } else {
    console.error("User data not found in localStorage.");
  }
}


function displayRatings(response) {
  
  debugger;
  var RatingsContainer = $("#RatingsContainer1");
  RatingsContainer.empty();


  var RatingsHtml = "";
  response.slice(start,end).forEach(function (Rating) {

    console.log(Rating.name);

    var ratingValue = Rating.ratingvalue;
    var stars = new Array(5).fill('<i class="fa fa-star o-empty"></i>');

    for (let i = 0; i < ratingValue; i++) {
      stars[i] = '<i class="fa fa-star" style="color: #D10024;"></i>';
    }





    var itemHtml =
      "<div>" +
      "<div class='review-body'>" +
      "<h5 class='name'>" + Rating.name + "</h5>" +
      "<div class='review-rating' >" +
      stars.join("") +
      "</div>" + "</div>" +
      "<div class='review-body'>" +
      "<p>" + Rating.review + "</p>" +
      "</div>"

    RatingsHtml += itemHtml;
  });





  RatingsContainer.html(RatingsHtml);
}

function sumRatingValue(response) {
  debugger;
  var sum = 0;
  var avgrate = 0;
  for (var i = 0; i < response.length; i++) {
    sum += response[i].ratingvalue;
    avgrate = sum / response.length;
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
    for (var i = 1; i < 5 - avgrate; i++) {
      emptyStars.push('<i class="fa fa-star o-empty"></i>');
    }

    itemHtmlratingbox += "<div class='rating-stars'>" + stars.join("") + emptyStars.join("") + "</div>";



    RatingsHtml += itemHtmlratingbox;

  }
  ratingboxContainer.html(RatingsHtml);


}

function starcount(response) {
  debugger;
  var fivepercent = 0;
  var fourpercent = 0;
  var threepercent = 0;
  var twopercent = 0;
  var onepercent = 0;
  var sumoffive = 0;
  var sumoffour = 0;
  var sumofthree = 0;
  var sumoftwo = 0;
  var sumofone = 0;
  var itemHtml1 = "";
  var itemHtml2 = "";
  var itemHtml3 = "";
  var itemHtml4 = "";
  var itemHtml5 = "";
  var RatingsHtml = "";
  var RatingsContainer5 = $("#5ratecount");
  RatingsContainer5.empty();

  var RatingsContainer4 = $("#4ratecount");
  RatingsContainer4.empty();

  var RatingsContainer3 = $("#3ratecount");
  RatingsContainer3.empty();

  var RatingsContainer2 = $("#2ratecount");
  RatingsContainer2.empty();

  var RatingsContainer1 = $("#1ratecount");
  RatingsContainer1.empty();



  if (response.length > 0) {
    for (var i = 0; i < response.length; i++) {
      if (response[i].ratingvalue == 5) {
        sumoffive++;

      }
      else if (response[i].ratingvalue == 4) {
        sumoffour++;
      }
      else if (response[i].ratingvalue == 3) {
        sumofthree++;
      }
      else if (response[i].ratingvalue == 2) {
        sumoftwo++;
      }
      else if (response[i].ratingvalue == 1) {
        sumofone++;
      }
    }

    fivepercent = (sumoffive / response.length) * 100;
    fourpercent = (sumoffour / response.length) * 100;
    threepercent = (sumofthree / response.length) * 100;
    twopercent = (sumoftwo / response.length) * 100;
    onepercent = (sumofone / response.length) * 100;

    console.log(fivepercent)
  }
  else {
    fivepercent = 0;
    fourpercent = 0;
    threepercent = 0;
    twopercent = 0;
    onepercent = 0;

  }

  var itemHtml5 = "<div class='rating-stars'>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "</div>" +
    "<div class='rating-progress'>" +
    "<div style='width: " + fivepercent + "%'></div>" +
    "</div>" +
    ("<span class='sum'>" + sumoffive + "</span>");

  var itemHtml4 = "<div class='rating-stars'>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "</div>" +
    "<div class='rating-progress'>" +
    "<div style='width:" + fourpercent + "%'></div>" +
    "</div>" +
    ("<span class='sum'>" + sumoffour + "</span>");


  var itemHtml3 = "<div class='rating-stars'>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "</div>" +
    "<div class='rating-progress'>" +
    "<div style='width: " + threepercent + "%'></div>" +
    "</div>" +
    ("<span class='sum'>" + sumofthree + "</span>");

  var itemHtml2 = "<div class='rating-stars'>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "</div>" +
    "<div class='rating-progress'>" +
    "<div style='width: " + twopercent + "%'></div>" +
    "</div>" +
    ("<span class='sum'>" + sumoftwo + "</span>");

  var itemHtml1 = "<div class='rating-stars'>" +
    "<i class='fa fa-star'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "<i class='fa fa-star-o'></i>" +
    "</div>" +
    "<div class='rating-progress'>" +
    "<div style='width:" + onepercent + "%'></div>" +
    "</div>" +
    ("<span class='sum'>" + sumofone + "</span>");


  RatingsContainer5.html(itemHtml5);
  RatingsContainer4.html(itemHtml4);
  RatingsContainer3.html(itemHtml3);
  RatingsContainer2.html(itemHtml2);
  RatingsContainer1.html(itemHtml1);



}


function updateStartEndValues(newStart, newEnd) {
  debugger
  start = newStart;
  end = newEnd;
  console.log("Start:", start, "End:", end);
  var productName = $("#productName").val();
  fetchRatings(productName);
  // You can perform other actions here based on the new values
}

// Click event handler for the button
document.getElementById('pagination1').addEventListener('click', function() {
  // Update start and end values when the button is clicked
  updateStartEndValues(-3); 
  displayRatings(response);// Change the values as needed
});
document.getElementById('pagination2').addEventListener('click', function() {
  // Update start and end values when the button is clicked
  updateStartEndValues(-6,-3); 
  displayRatings(response);// Change the values as needed
});
document.getElementById('pagination3').addEventListener('click', function() {
  // Update start and end values when the button is clicked
  updateStartEndValues(-9,-6); 
  displayRatings(response);// Change the values as needed
});
document.getElementById('pagination4').addEventListener('click', function() {
  // Update start and end values when the button is clicked
  updateStartEndValues(-12,-9); 
  displayRatings(response);// Change the values as needed
});
document.getElementById('pagination5').addEventListener('click', function() {
  // Update start and end values when the button is clicked
  updateStartEndValues(-15,-12); 
  displayRatings(response);// Change the values as needed
});