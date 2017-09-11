var CodePicker = function () {

    var elements = {
        codePickerDiv: $("#CodePickerDiv"),
        canvas: $("#canvas"),
        canvas2: $("#canvas2"),
        codePicker: $("#codepicker"),
    };

    var Rayons = [];

    var initialize = function () {
        var ctx = elements.canvas[0].getContext("2d");
        ctx.lineWidth = 2;

        var img = new Image(800, 800);
        var overlayImg = new Image(800, 800);
        img.onload = function () {
            ctx.drawImage(img, 0, 0, 800, 800);
        }
        img.src = "/Licenta/Content/Images/ShopSplit.png";

        initializeRayons();
    }

    var initializeRayons = function () {
        var rects = null;

        rects = splitRectangleInParts(2, 96, 97, 453, 3, "vertical");
        Rayons.push({ 'id': 1, 'coords': { 'startX': 2, 'startY': 96, 'endX': 97, 'endY': 453 }, 'rafturi': rects, 'aranjament': "vertical", 'nrRafturi': 3 });
    };

    elements.codePicker.click(function () {
        elements.codePickerDiv.show();
    });

    elements.canvas.click(function (e) {
        pointX = parseInt(e.clientX);
        pointY = parseInt(e.clientY);	//determin punctul la care s-a dat click
        console.log(pointX, pointY, Rayons)

        var ctx = elements.canvas[0].getContext("2d");
        var canvas2 = elements.canvas2[0];
        var ctx2 = canvas2.getContext("2d");

        for (var i = 0; i < Rayons.length; i++) {	//trec prin fiecare raion si verific sa vad unde a dat click
            if (pointX > Rayons[i].coords.startX && pointX < Rayons[i].coords.endX && pointY > Rayons[i].coords.startY && pointY < Rayons[i].coords.endY) {
                ctx.strokeStyle = '#ff0000';
                ctx2.beginPath();		//testing purpose desenez ceva ca sa se vada unde s-a dat click
                ctx2.arc(pointX, pointY, 10, 0, 2 * Math.PI);
                ctx2.stroke();
                for (var j = 0; j < Rayons[i].rafturi.length; j++) {
                    if (pointX > Rayons[i].rafturi[j].startX && pointX < Rayons[i].rafturi[j].endX && pointY > Rayons[i].rafturi[j].startY && pointY < Rayons[i].rafturi[j].endY) {
                        var code = Rayons[i].id + '-' + (j + 1) + '-' + Rayons[i].nrRafturi;
                        console.log('COD:' + Rayons[i].id + '-' + (j + 1) + '-' + Rayons[i].nrRafturi);
                        elements.codePicker.val(code);
                        elements.codePickerDiv.hide();
                    }
                }
            }
        }
    });

    function splitRectangleInParts(startX, startY, endX, endY, parts, direction) {	//direction means position of the shelf
        var rectangles = [];
        if (direction == 'vertical') {	//in functie de directie calculez distanta si creez noile dreptunghiuri
            var distance = Math.floor(Math.abs(startY - endY) / parts);
            for (var i = 0; i < parts; i++) {
                rectangles.push({ 'startX': startX, 'startY': (startY + (i * distance)), 'endX': endX, 'endY': startY + ((i + 1) * distance) });
            }
        } else {
            var distance = Math.floor(Math.abs(startX - endX) / parts);
            for (var i = 0; i < parts; i++) {
                rectangles.push({ 'startX': (startX + (i * distance)), 'startY': startY, 'endX': startX + ((i + 1) * distance), 'endY': endY });
            }
        }
        return rectangles;
    }

    initialize();
}
var codpicker = new CodePicker();


//$(document).ready(function () {
//    var drawRaion = false;
//    var drawProdus = false;
//    var nrRafturi = 1;
//    var verticalPosition = 'vertical';

//    $('#drawRaion').click(function () {
//        if (drawRaion == false) {
//            drawRaion = true;
//            $('#titlu').html('RAIOOON!!!');
//        } else {
//            drawRaion = false;
//            $('#titlu').html('Normal');
//        }
//    });

//    $('#drawProdus').click(function () {
//        if (drawProdus == false) {
//            drawProdus = true;
//            $('#titlu').html('PRODUUUUS!!!');
//        } else {
//            drawProdus = false;
//            $('#titlu').html('Normal');
//        }
//    });

//    $('#cBoxPosition').change(function () {
//        if ($(this).is(':checked')) {
//            verticalPosition = 'vertical';
//        } else {
//            verticalPosition = 'horizontal';
//        }
//    });

//    $('#nBoxNrRaioane').change(function () {
//        if ($('#nBoxNrRaioane').val() <= 6 && $('#nBoxNrRaioane').val() >= 1)
//            nrRafturi = $('#nBoxNrRaioane').val();
//        else {
//            nrRafturi = 3;
//        }
//    });

//    $('#doneDraw').click(function () {
//        console.log(raioane);
//    });

//    var raioane = [];		//tine minte toate raioanele ce sunt desenate
//    var startDrawRectangle = false;
//    var canvas = $('#canvas2')[0];
//    var ctx = canvas.getContext("2d");
//    ctx.lineWidth = 2;
//    var count = 1;

//    var canvasOffset = $('#canvas2').offset();
//    var offsetX = canvasOffset.left;
//    var offsetY = canvasOffset.top;

//    var img = new Image(800, 800);
//    var overlayImg = new Image(800, 800);
//    img.onload = function () {
//        ctx.drawImage(img, 0, 0, 800, 800);
//    }
//    img.src = "magazin.png";


//    var rectStartX, rectEndX;
//    var rectStartY, rectEndY;

//    function handleMouseMove(e) {
//        if (drawRaion == true) {	//daca desenez raion prelucrez mouseMove....inutil
//            mouseX = parseInt(e.clientX - offsetX);
//            mouseY = parseInt(e.clientY - offsetY);

//            if (startDrawRectangle == true) {
//                $('#coords').html('X:' + mouseX + ' Y:' + mouseY);
//            } else {

//            }
//        }
//    }

//    $("#canvas").mousemove(function (e) { handleMouseMove(e); });
//    $('#canvas').click(function (e) {
//        if (drawRaion == true && drawProdus == false) {
//            if (startDrawRectangle == false) {	//start draw rectangle 
//                startDrawRectangle = true;
//                rectStartX = parseInt(e.clientX - offsetX);	//preia pozitia de inceput la care se incepe desenarea dreptunghiului
//                rectStartY = parseInt(e.clientY - offsetY);
//            } else {	//finished drawing rectangle
//                startDrawRectangle = false;
//                rectEndX = parseInt(e.clientX - offsetX);	//a dat click pe pozitia de sfarsit si dreptunghiul are x1,y1,x2,y2: rectStartX,rectStartY,rectEndX,rectEndY
//                rectEndY = parseInt(e.clientY - offsetY);

//                //draw a rectangle
//                var canvas2 = $('#canvas')[0];
//                var ctx2 = canvas2.getContext("2d");
//                drawRaion = false;	//unset daca se deseneaza continuu


//                var rects = splitRectangleInParts(rectStartX, rectStartY, rectEndX, rectEndY, nrRafturi, verticalPosition);	//fac split in x parti a dreptunghiului initial si arat orientarea ca sa stiu daca fac dupa x sau y
//                for (var i = 0; i < rects.length; i++) {
//                    drawRectImg(rects[i].startX, rects[i].startY, rects[i].endX, rects[i].endY, ctx2);	//desenez un raion inauntru la cel mare
//                }
//                raioane.push({ 'id': count, 'coords': { 'startX': rectStartX, 'startY': rectStartY, 'endX': rectEndX, 'endY': rectEndY }, 'rafturi': rects, 'aranjament': verticalPosition, 'nrRafturi': nrRafturi });
//                count++;
//                //adaug noul raion cu toate informatiile in obiectul principal pentru recunoastere mai tarziu
//            }
//        } else if (drawRaion == false && drawProdus == true) {	//amplasez un produs in poza
//            pointX = parseInt(e.clientX - offsetX);
//            pointY = parseInt(e.clientY - offsetY);	//determin punctul la care s-a dat click

//            var canvas2 = $('#canvas2')[0];
//            var ctx2 = canvas2.getContext("2d");

//            for (var i = 0; i < raioane.length; i++) {	//trec prin fiecare raion si verific sa vad unde a dat click
//                if (pointX > raioane[i].coords.startX && pointX < raioane[i].coords.endX && pointY > raioane[i].coords.startY && pointY < raioane[i].coords.endY) {
//                    ctx.strokeStyle = '#ff0000';
//                    ctx2.beginPath();		//testing purpose desenez ceva ca sa se vada unde s-a dat click
//                    ctx2.arc(pointX, pointY, 10, 0, 2 * Math.PI);
//                    ctx2.stroke();
//                    for (var j = 0; j < raioane[i].rafturi.length; j++) {
//                        if (pointX > raioane[i].rafturi[j].startX && pointX < raioane[i].rafturi[j].endX && pointY > raioane[i].rafturi[j].startY && pointY < raioane[i].rafturi[j].endY) {
//                            console.log('COD:' + raioane[i].id + '-' + (j + 1) + '-' + raioane[i].nrRafturi);
//                        }
//                    }
//                }
//            }
//        }
//    });
//});

//function splitRectangleInParts(startX, startY, endX, endY, parts, direction) {	//direction means position of the shelf
//    var rectangles = [];
//    if (direction == 'vertical') {	//in functie de directie calculez distanta si creez noile dreptunghiuri
//        var distance = Math.floor(Math.abs(startY - endY) / parts);
//        for (var i = 0; i < parts; i++) {
//            rectangles.push({ 'startX': startX, 'startY': (startY + (i * distance)), 'endX': endX, 'endY': startY + ((i + 1) * distance) });
//        }
//    } else {
//        var distance = Math.floor(Math.abs(startX - endX) / parts);
//        for (var i = 0; i < parts; i++) {
//            rectangles.push({ 'startX': (startX + (i * distance)), 'startY': startY, 'endX': startX + ((i + 1) * distance), 'endY': endY });
//        }
//    }
//    return rectangles;
//}

//function drawRectImg(StartX, StartY, EndX, EndY, ctx) {	//functie pentru desenat un dreptunghi in poza
//    ctx.lineWidth = 5;
//    ctx.strokeStyle = '#000000';
//    ctx.beginPath();
//    ctx.moveTo(StartX, StartY);
//    ctx.lineTo(EndX, StartY);
//    ctx.moveTo(EndX, StartY);
//    ctx.lineTo(EndX, EndY);
//    ctx.moveTo(EndX, EndY);
//    ctx.lineTo(StartX, EndY);
//    ctx.moveTo(StartX, EndY);
//    ctx.lineTo(StartX, StartY);
//    ctx.stroke();
//}
