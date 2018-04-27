$(function () {
    var oddsCells = $(".odd");
    oddsCells.click(function () {
        var id = this.parentElement.id;
        var oddId = this.className.substr(4);
        var allOddsWithSameId = $("." + oddId);
        var result = "";
        for (var i = 0; i < allOddsWithSameId.length; i++) {
            result += allOddsWithSameId[i].innerText + " ";
        }
        console.log(result.trim());
    });
});