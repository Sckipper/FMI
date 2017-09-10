var Home = function () {

    var elements = {
        role: $("#role"),
        panel1: $("#panel1"),
        panel2: $("#panel2"),
        chart: $("#chart1"),
        chart2: $("#chart2")
    }

    var colors = ['orange', 'green', 'blue', 'red', 'yellow', 'grey', 'lime', 'purple'];
    var numbers = elements.chart.attr("data").split(",").map(Number);
    var numbers2 = elements.chart2.attr("data").split(",").map(Number);

    switch (parseInt(elements.role.html())) {
        case 0:
            elements.panel2.hide();
            elements.panel1.find(".dashboardTitle").html("LIVRARI").click(function () {
                window.location.href = "/Licenta/Deliveries/Index";
            });
            
            var labels = new Array("initiate", "de livrat", "livrate", "refuzate");
            var data = new Array();
            for (var i = 0; i < numbers.length; i++) {
                data.push({
                    'label': labels[i],
                    'value': numbers[i],
                    'color': colors[i]
                })
            }
            elements.chart.ntkPieChart({ data: data });

            break;

        case 1:
            elements.panel1.find(".dashboardTitle").html("CATEGORII").click(function () {
                window.location.href = "/Licenta/Categories/Index";
            });
            elements.panel2.find(".dashboardTitle").html("PRODUSE").click(function () {
                window.location.href = "/Licenta/Products/Index";
            });

            var labels = new Array("categorii principale", "categorii secundare");
            var data = new Array();
            for (var i= 0; i < numbers.length; i++){
                data.push({
                    'label': labels[i],
                    'value': numbers[i],
                    'color': colors[i]
                })
            }
            elements.chart.ntkPieChart({ data: data });

            var labels = new Array("produse ce expiră în 3 zile", "produse ce expiră într-o săptămână", "produse ce expiră într-o lună");
            var data = new Array();
            for (var i = 0; i < numbers2.length; i++) {
                data.push({
                    'label': labels[i],
                    'value': numbers2[i],
                    'color': colors[i]
                })
            }
            elements.chart2.ntkPieChart({ data: data });

            break;

        case 2:
            elements.panel1.find(".dashboardTitle").html("LIVRARI").click(function () {
                window.location.href = "/Licenta/Deliveries/Index";
            });
            elements.panel2.find(".dashboardTitle").html("ANGAJATI").click(function () {
                window.location.href = "/Licenta/Employees/Index";
            });

            var labels = new Array("angajaţi", "manageri","şefi","furnizori" );
            var data = new Array();
            for (var i = 0; i < numbers.length; i++) {
                data.push({
                    'label': labels[i],
                    'value': numbers[i],
                    'color': colors[i]
                })
            }
            elements.chart.ntkPieChart({ data: data });

        default:
            break;
    }

    elements.chart.find("table tr td:first").width("10px");
}

var home = new Home();