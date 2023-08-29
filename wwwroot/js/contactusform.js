$(document).ready(function () {
    $("#contactForm").click(function (event) {
        
        event.preventDefault();

    
        var formData = {
            name: $("#name").val(),
            email: $("#email").val(),
            subject: $("#subject").val(),
            message: $("#message").val()
        };

       
        console.log(formData);

        $.ajax({
            url: "/api/ContactUs/ContactUsForm", 
            type: "POST",
            data: JSON.stringify(formData),
            contentType: "application/json",
            success: function (response) {
                $("#name").val('');
                $("#email").val('');
                $("#subject").val('');
                $("#message").val('');
                console.log("Form data sent successfully!");
            },
            error: function (error) {
              
                console.log("Error sending form data:", error);
            }
        });
    });
});


