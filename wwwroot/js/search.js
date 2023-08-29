$(document).ready(function () {
    $("#search-button").on("click", function (e) {
        e.preventDefault();
        var searchInput = $("#search-input").val().trim().toLowerCase();

        var matchingProducts = productNames.filter(function (productName) {
            return productName.toLowerCase().indexOf(searchInput) !== -1;
        });

        displaySearchResults(matchingProducts);
    });

    function convertToSlug(text) {
        
        let slugText = text.replace(/[^\w\s]/g, '').toLowerCase();
       
        slugText = slugText.replace(/\s+/g, '-');
     
        slugText = slugText.replace(/--+/g, '-');
      
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
               
                var clickableItem = $("<a></a>");
                clickableItem.css("color", "white");
                clickableItem.text(result);
                clickableItem.attr("href", convertToSlug(result)); 

                resultList.append($("<li></li>").append(clickableItem));
            });
            searchResultsDiv.append(resultList);
        }
    }
});
