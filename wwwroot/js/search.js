$(document).ready(function () {
    debugger;
    $("#search-button").on("click", function (e) {
        e.preventDefault();
        var searchInput = $("#search-input").val().trim().toLowerCase();

        var matchingProducts = productNames.filter(function (productName) {
            return productName.toLowerCase().indexOf(searchInput) !== -1;
        });

        displaySearchResults(matchingProducts);
    });

    function convertToSlug(text) {
        // Remove special characters and convert to lowercase
        let slugText = text.replace(/[^\w\s]/g, '').toLowerCase();
        // Replace spaces with hyphens
        slugText = slugText.replace(/\s+/g, '-');
        // Remove any double hyphens that might occur due to consecutive spaces
        slugText = slugText.replace(/--+/g, '-');
        // Remove leading and trailing hyphens
        slugText = slugText.replace(/^-+|-+$/g, '');
        return `/${slugText}/`;
    }

    function displaySearchResults(results) {
        var searchResultsDiv = $("#search-results");
        searchResultsDiv.empty();

        if (results.length === 0) {
            searchResultsDiv.append("<p style='color:white;'>No matching products found.</p>");
        } else {
            var resultList = $("<ul></ul>");
            results.forEach(function (result) {
                // Create a clickable anchor element for each result
                var clickableItem = $("<a></a>");
                clickableItem.css("color", "white");
                clickableItem.text(result);
                clickableItem.attr("href", convertToSlug(result)); // Set the href to the slug link

                resultList.append($("<li></li>").append(clickableItem));
            });
            searchResultsDiv.append(resultList);
        }
    }
});
