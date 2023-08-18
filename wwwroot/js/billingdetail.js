$(document).ready(function () {
    debugger;

    debugger;
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
            success: function (response) {
                console.log("success");
                displayBillingDetails(response);


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
    debugger;
    var billingDetailsContainer = $("#billing-details");
    billingDetailsContainer.empty();
    var billingDetailsHtml = "";
    billingDetails.forEach(function (Register) {
        console.log("Billing Details:", Register);
        console.log(Register.email);

        var itemHtml =

            "<div class='section-title'>" +
            "<h3 class='title'>Billing address</h3>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text' id='first-name' name='first-name' placeholder='First Name' value='" + Register.firstName + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='text'  id='last-name' name='last-name' placeholder='Last Name' value='" + Register.lastName + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input' type='email' name='email' id='email' placeholder='Email' value='" + Register.email + "'>" +
            "</div>" +
            "<div class='form-group'>" +
            "<input class='input'' type='text' name='address' placeholder='Address'>" +
            "</div>" +

            "<div class='form-group'>" +
            "<input class='input' type='text' name='city' placeholder='City'>" +
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


    });


    document.getElementById('first-name').value = billingDetails[0].firstName;
    document.getElementById('last-name').value = billingDetails[0].lastName;
    document.getElementById('email').value = billingDetails[0].email;



    //document.getElementById('tel').value = billingDetails.telephone;
}





