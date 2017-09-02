var Layout = function () {
    var deleteMesage = "Esti sigur ca vrei sa stergi"; 

    var getDeleteMessage = function () {
        switch ($(document).find("title").text()){
            case "Categorii":
                deleteMesage += "categoria";
                break;
            case "Produse": 
                deleteMesage += "produsul";
                break;
        }
    }

    var elements = {
        addedrow: $(".addedrow"),
        table: $("#myTable"),
        datatable: $("#datatable"),
        deleteDialog: $("#deleteDialog"),
        deleteMesage: $("#deleteMesage"),
        deleteDialogTrue: $("#deleteDialogTrue"),
        deleteDialogFalse: $("#deleteDialogFalse"),
        innerDialog: $("#innerDialog")
    }

    elements.addedrow.mouseover(function () {
        if (!$(this).children("td").hasClass("selected")) {
            $(this).children("td").children(".edit").show();
            $(this).children("td").children(".delete").show();
        }
    });

    elements.addedrow.click(function () {
        if ($(this).children("td").hasClass("selected")) {
            $(this).children("td").children(".edit").hide();
            $(this).children("td").children(".delete").hide();
        }
        $(this).children("td").toggleClass("selected");
    });

    elements.addedrow.mouseout(function () {
        if (!$(this).children("td").hasClass("selected")) {
            $(this).children("td").children(".edit").hide();
            $(this).children("td").children(".delete").hide();
        }
    });

    $(".delete").click(function () {
        elements.deleteDialog.show();
        var id = $(this).parent().parent().find("#id").text();
        elements.innerDialog.data("foo", id);
        var name = $(this).parent().parent().find("#nume").text();
        getDeleteMessage();
        elements.deleteMesage.text(deleteMesage + " \"" + name + "\" ?");
    });

    elements.deleteDialogFalse.click(function () {
        elements.deleteDialog.hide();
    });

    elements.deleteDialogTrue.click(function () {
        window.location.href = "Delete/" + elements.innerDialog.data("foo");
        elements.deleteDialog.hide();
    });
}

var layout = new Layout();

