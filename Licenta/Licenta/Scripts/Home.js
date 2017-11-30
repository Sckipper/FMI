var Home = function () {

    var elements = {
        role: $("#role"),
        panel1: $("#panel1"),
        panel2: $("#panel2"),
        chart: $("#chart1"),
        chart2: $("#chart2")
    }

    var colors = ['orange', 'green', 'blue', 'red', 'yellow', 'grey', 'lime', 'purple'];
    var numbers2 = null;
    var numbers = null;
    if (elements.chart.attr("data"))
        numbers = elements.chart.attr("data").split(",").map(Number);
    if (elements.chart2.attr("data"))
        numbers2 = elements.chart2.attr("data").split(",").map(Number);

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

            var labels = new Array("produse ce expiră în 3 zile", "produse ce expiră într-o săptămână", "produse ce expiră într-o lună", "produse expirate");
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

            var labels = new Array("angajaţi", "manageri", "şefi", "furnizori");
            var sgLabels = new Array("angajat", "manager", "şef", "furnizor");
            var data = new Array();
            for (var i = 0; i < numbers2.length; i++) {
                data.push({
                    'label': parseInt(numbers2[i]) == 1 ? sgLabels[i] : labels[i],
                    'value': numbers2[i],
                    'color': colors[i]
                })
            }
            elements.chart2.ntkPieChart({ data: data });
            break;

        case 3:
            elements.panel1.find(".dashboardTitle").html("FURNIZORI").click(function () {
                window.location.href = "/Licenta/Suppliers/Index";
            });
            elements.panel2.find(".dashboardTitle").html("MAGAZINE").click(function () {
                window.location.href = "/Licenta/Markets/Index";
            });

            var labels = null;
            if (elements.chart.attr("data-cities") )
                labels = elements.chart.attr("data-cities").split(",");
            var data = new Array();

            for (var i = 0; i < numbers.length; i++) {
                data.push({
                    'label': labels[i],
                    'value': numbers[i],
                    'color': colors[i]
                })
            }
            elements.chart.ntkPieChart({ data: data });

            var labels = null;
            if (elements.chart2.attr("data-cities"))
                labels = elements.chart2.attr("data-cities").split(",");
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
        
        default:
            break;
    }

    elements.chart.find("table tr td:first").width("10px");
}

var home = new Home();