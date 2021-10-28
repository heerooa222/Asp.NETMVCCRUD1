
$(document).ready(function () {
    $(".menu-item").on("click", function () {
        $("#myTopnav .active").removeClass("active");
        $(this).addClass("active");

    });
});

function barClick() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

