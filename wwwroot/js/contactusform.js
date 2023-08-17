$(document).ready(function () {
    $("#contactForm").click(function (event) {
        // Prevent the default form submission behavior
        event.preventDefault();

        // Collect form data
        var formData = {
            name: $("#name").val(),
            email: $("#email").val(),
            subject: $("#subject").val(),
            message: $("#message").val()
        };

        // Log the form data to the console
        console.log(formData);

        $.ajax({
            url: "/api/ContactUs/ContactUsForm", // Replace this with the actual URL of your controller's action method
            type: "POST",
            data: JSON.stringify(formData),
            contentType: "application/json",
            success: function (response) {
                // Optionally, you can handle the success response here
                console.log("Form data sent successfully!");
            },
            error: function (error) {
                // Optionally, you can handle the error response here
                console.log("Error sending form data:", error);
            }
        });
    });
});


