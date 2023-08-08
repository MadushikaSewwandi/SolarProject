$(document).ready(function () {
 
      $("#addreview").on("click", function ()
  {
    debugger;
      //var productName = $("#productName").val();
      let numberOfStarsSelected = 0;

  function getNumberOfStarsSelected() {
    const stars = document.querySelectorAll("input[name='rating']");

    for (const star of stars) {
      if (star.checked) {
        switch (star.id) {
          case "star5":
            numberOfStarsSelected = 5;
            break;
          case "star4":
            numberOfStarsSelected = 4;
            break;
          case "star3":
            numberOfStarsSelected = 3;
            break;
          case "star2":
            numberOfStarsSelected = 2;
            break;
          case "star1":
            numberOfStarsSelected = 1;
            break;
          default:
            numberOfStarsSelected = 0;
        }
      }
    }
  }

  console.log(getNumberOfStarsSelected());

  const Name = document.getElementById("ratingName").value;
  const Email = document.getElementById("ratingEmail").value;
  const Review = document.getElementById("review").value;
  const RatingValue = numberOfStarsSelected;
  //const productName = document.getElementById("productName2").value;
  var productName = $("#productName").val();
        
    
        // Get user data from localStorage
        var user = localStorage.getItem("user");
        if (user) {
          var parsedUser = JSON.parse(user);
          var userId = parsedUser?.id;
          var token = parsedUser?.token;
    
          var item = {
            
              UserId: userId,
              ProductName: productName,
              Name: Name,
              Email: Email,
              Review: Review,
              RatingValue: RatingValue
            
          };
          console.log(item)
    
          // Make an AJAX POST request to add the item to the cart
          $.ajax({
            type: "POST",
            url: "/api/Ratings/AddRate",
            data: JSON.stringify(item),
            contentType: "application/json",
            headers: {
              "Authorization": "Bearer " + token, // Include the JWT token in the request headers
            },
            success: function (response) {
              console.log("Item added to the cart successfully.");
              // Handle any success actions if needed
            },
            error: function (error) {
              console.error("Error adding item to cart:", error.responseText);
              // Handle any error actions if needed
            },
          });
          
    
        } else {
          // Handle the case when user data is not available in localStorage
          console.error("User data not found in localStorage.");
        }
      });
    });