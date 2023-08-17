// Event handler for logout link click
$("#logoutButton").click(function (event) {
    console.log("hi")
    event.preventDefault(); // Prevent the default link behavior

    handleLogout();
});

function handleLogout() {
    // Remove the token from storage
    localStorage.removeItem("token");

    // Redirect the user to the logout page or home page
    window.location.href = "/"; // Replace with the URL of your logout page or home page
}

