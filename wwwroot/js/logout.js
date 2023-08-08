// Event handler for logout link click
$("#logoutButton").click(function (event) {
    debugger
    console.log("hi")
    localStorage.removeItem("user");
    console.log("User removed:", localStorage.getItem("user"));
});
