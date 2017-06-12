var Logged = function () {

    var elements = {
        userPanel: $("#userPanel"),
        menu: $("#menu"),
        logoMenu: $("#logoMenu")
    }

    var initialize = function () {
        elements.userPanel.css("display", "inline-block");
        elements.logoMenu.css("display", "inline-block");

        $(document).click(function () {
            elements.menu.css("display", "none");
        });
        elements.logoMenu.click(function (event) {
            elements.menu.css("display", "block");
            event.stopPropagation();
        });

        elements.menu.click(function (event) {
            event.stopPropagation();
        });
    }
    
    initialize();
}

var log = new Logged();
