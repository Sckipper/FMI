var Categories = function () {
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
        $(this).children("td").children(".edit").show();
        $(this).children("td").children(".delete").show();
    });

    elements.addedrow.mouseout(function () {
        $(this).children("td").children(".edit").hide();
        $(this).children("td").children(".delete").hide();
    });

    $(".delete").click(function () {
        elements.deleteDialog.show();
        var id = $(this).parent().parent().find("#id").text();
        elements.innerDialog.data( "foo", id );
        var categoryName = $(this).parent().parent().find("#nume").text();
        elements.deleteMesage.text("Esti sigur ca vrei sa stergi categoria \"" + categoryName + "\" ?");
    });

    elements.deleteDialogFalse.click(function () {
        elements.deleteDialog.hide();
    });

    elements.deleteDialogTrue.click(function () {
        window.location.href = "Delete/" + elements.innerDialog.data("foo");
        elements.deleteDialog.hide();
    });
}

var cat = new Categories();

