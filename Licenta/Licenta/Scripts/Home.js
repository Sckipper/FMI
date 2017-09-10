var Home = function () {

    var elements = {
        role: $("#role"),
        panel1: $("#panel1"),
        panel2: $("#panel2"),
        chart: $("#chart")
    }
    switch (parseInt(elements.role.html())) {
        case 0:
            elements.panel2.hide();
            elements.panel1.find(".dashboardTitle").html("LIVRARI").click(function () {
                window.location.href = "/Licenta/Deliveries/Index";
            });
            elements.chart.chart({
                data: elements.chart.attr("data").split(",").map(Number),
                labels: new Array("initiate", "de livrat", "livrate", "refuzate"),
                width: 400
            });  
            break;

        case 1:
            elements.panel1.find(".dashboardTitle").html("CATEGORII").click(function () {
                window.location.href = "/Licenta/Categories/Index";
            });
            elements.panel2.find(".dashboardTitle").html("PRODUSE").click(function () {
                window.location.href = "/Licenta/Products/Index";
            });
            break;

        default:
            break;
    }

    elements.chart.find("table tr td:first").width("10px");
}

var home = new Home();