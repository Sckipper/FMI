var Home = function () {

    var elements = {
        role: $("#role"),
        panel1: $("#panel1"),
        panel2: $("#panel2")
    }
    switch (parseInt(elements.role.html())) {
        case 0:
            elements.panel2.hide();
            elements.panel1.find(".dashboardTitle").html("Livrari").click(function () {
                window.location.href = "/Licenta/Deliveries/Index";
            });

            break;

        case 1:
            break;

        default:
            break;
    }

}

var home = new Home();