var Categories = function () {
    var elements = {
        addedrow: $(".addedrow"),
        table: $("#myTable"),
        datatable: $("#datatable"),
        deleteDialog: $("#deleteDialog"),
        deleteMesage: $("#deleteMesage"),
        deleteDialogTrue: $("#deleteDialogTrue"),
        deleteDialogFalse: $("#deleteDialogFalse"),
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
        var categoryName = $(this).parent().find("#nume").val();
        elements.deleteMesage.text("Esti sigur ca vrei sa stergi categoria \"" + categoryName + "\" ?");
    });

    elements.deleteDialogFalse.click(function () {
        elements.deleteDialog.hide();
    })

    elements.deleteDialogTrue.click(function () {
        var id = $(this).parent().find("#id").val();
        window.location.href = "/Categories/Delete/" + id;
        elements.deleteDialog.hide();
    })
}

var cat = new Categories();

