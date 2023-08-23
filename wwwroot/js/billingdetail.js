$(document).ready(function () {
    var user = localStorage.getItem("user");
    if (user) {
        var parsedUser = JSON.parse(user);
        var userId = parsedUser?.id;
        fetchBillingDetailsByUserId(userId);
    } else {
        console.error("User data not found in localStorage.");
    }

});

function fetchBillingDetailsByUserId(userId) {

    var user = localStorage.getItem("user");
    if (user) {
        var parsedUser = JSON.parse(user);
        var token = parsedUser?.token;
        console.log(token);


        $.ajax({

            type: "GET",
            url: "/api/GetBillingDetails/GetBillingDetailsByUserId/" + userId,
            headers: {
                "Authorization": "Bearer " + token,

            },
            success: function (billingDetails) {
                console.log("success");
                displayBillingDetails(billingDetails);


                //displayBillingDetails(response);
            },
            error: function (error) {
                console.log("failed");
                console.error("Error fetching cart items:", error.responseText);

            },
        });
    } else {

        console.error("User data not found in localStorage.");
    }
}

function displayBillingDetails(billingDetails) {
    
    //var billingDetailsContainer = $("#billing-details");
    //billingDetailsContainer.empty();
   // var billingDetailsHtml = "";
   /* billingDetails.forEach(function (billingDetails) {
        console.log("Billing Details:", billingDetails);
        //console.log(Register.email);

        var itemHtml =

            "<div class='section-title'>" +
            "<h3 class='title'>Billing address</h3>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text' id='first-name' name='first-name' placeholder='First Name' value='" + billingDetails.firstName + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text'  id='last-name' name='last-name' placeholder='Last Name' value='" + billingDetails.lastName + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='email' name='email' id='email' placeholder='Email' value='" + billingDetails.email + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input'' type='text' name='address' placeholder='Address' id='address' value='"+ billingDetails.address +"'>" +
            "</div>" +

            "<div class='form-group'>" +
            "<input class='input' type='text' name='city' placeholder='City' id='city' value='"+billingDetails.city +"'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text' name='country' placeholder='Country'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text' name='zip-code' placeholder='ZIP Code'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='tel' name='tel' placeholder='Telephone'>" +
            "</div>";

        billingDetailsHtml += itemHtml;


    });*/


    document.getElementById('first-name').value = billingDetails[0].firstName;
    document.getElementById('last-name').value = billingDetails[0].lastName;
    document.getElementById('email').value = billingDetails[0].email;
    document.getElementById('address').value = billingDetails[0].address;
    document.getElementById('city').value = billingDetails[0].city;
    document.getElementById('email').value = billingDetails[0].email;
    document.getElementById('telephone').value = billingDetails[0].telephone;
    document.getElementById('zipcode').value = billingDetails[0].zipCode;
    document.getElementById('country').value = billingDetails[0].country;
    




    //document.getElementById('tel').value = billingDetails.telephone;
}





