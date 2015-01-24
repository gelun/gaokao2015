
/////////////////////////////////导航浮动//////////////////////////////////
function FloatMenu() {
    var animationSpeed = 10;
    var animationEasing = 'easeOutQuint';
    var scrollAmount = $(document).scrollTop();
    //  var newPosition = menuPosition + scrollAmount;

    if (scrollAmount > 143) {
        //   $("#Toolbar").css("padding-top", scrollAmount);
        $("#Toolbar").animate({ "padding-top": scrollAmount - 135 }, animationSpeed, animationEasing);
        $("#schoolalert").animate({ "padding-top": scrollAmount }, animationSpeed, animationEasing);

    } else {
        $("#Toolbar").css("padding-top", 0);
        $("#schoolalert").css("padding-top", 0);
    }

}
$(window).load(function () {
    //  menuPosition = $('#Toolbar').position().top;
    FloatMenu();
});
$(window).scroll(function () {
    FloatMenu();
});