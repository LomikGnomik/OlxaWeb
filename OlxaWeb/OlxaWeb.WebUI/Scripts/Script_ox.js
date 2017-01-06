// Stuck navbar on scroll
if ($('.navbar-sticky').length && $('.main-navigation').length) {
    var sticky = new Waypoint.Sticky({
        element: $('.navbar-sticky .main-navigation')[0]
    });
}