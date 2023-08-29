
$("#logoutButton").click(function (event) {
    debugger
    console.log("hi")
    localStorage.removeItem("user");
    console.log("User removed:", localStorage.getItem("user"));

    window.location.href = "/";
});
