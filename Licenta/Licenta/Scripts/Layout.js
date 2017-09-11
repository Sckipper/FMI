var Layout = function () {
    var deleteMesage = null; 

    var getDeleteMessage = function () {
        deleteMesage = "Esti sigur ca vrei sa stergi ";
        switch ($(document).find("title").text()){
            case "Categorii":
                deleteMesage += "categoria";
                break;
            case "Produse": 
                deleteMesage += "produsul";
                break;
            case "Livrari":
                deleteMesage += "livrarea";
                break;
            case "Furnizori":
                deleteMesage += "furnizorul";
                break;
            case "Magazine":
                deleteMesage += "magazinul";
                break;
            case "Angajati":
                deleteMesage += "angajatul";
                break;
        }
    }
    var role = parseInt($("#role").html());
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
            if (role != 0)
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
        if ($(this).parent().parent().find("#nume"))
            var name = $(this).parent().parent().find("#nume").text();
        else 
            var name = $(this).parent().parent().find("#id").text();
        getDeleteMessage();
        elements.deleteMesage.text(deleteMesage + (name?" \"" + name + "\"":" aceasta" )+" ?");
        event.stopImmediatePropagation();
    });

    elements.deleteDialogFalse.click(function () {
        elements.deleteDialog.hide();
    });

    elements.deleteDialogTrue.click(function () {
        console.log(elements.innerDialog.data("foo"));
        window.location.href = "Delete/" + elements.innerDialog.data("foo");
        elements.deleteDialog.hide();
    });
}

var layout = new Layout();

